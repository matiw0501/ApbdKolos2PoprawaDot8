using kolos2Poprawa.Database;
using kolos2Poprawa.DTOs;
using kolos2Poprawa.Exceptions;
using kolos2Poprawa.Models;
using Microsoft.EntityFrameworkCore;

namespace kolos2Poprawa.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }


    public async Task<NurseriesBatchesDTO> GetNurseriesBatches(int id)
    {
        var nurseriesBatches = await _context.Nurseries.Where(n => n.NurseryId == id).Select(e =>
            new NurseriesBatchesDTO
            {

                NurseryId = e.NurseryId,
                Name = e.Name,
                EstablishedDate = e.EstablishedDate,
                Batches = e.SeedlingBatches.Select(a => new BatchDTO()
                {
                   BatchId = a.BatchId,
                   Quantity = a.Quantity,
                   SownDate = a.SownDate,
                   ReadyDate = a.ReadyDate,
                   Species = new SpeciesDTO()
                   {
                       LatinName = a.TreeSpecies.LatinName,
                       GrowthTimeInYears = a.TreeSpecies.GrowthTimeInYears
                   },
                   Responsibles = a.Responsibles.Select(r => new ResponsibleDTO()
                   {
                       FirstName = r.Employee.FirstName,
                       LastName = r.Employee.LastName,
                       Role = r.Role
                   }).ToList()
                   
                }).ToList()
                
            }).FirstOrDefaultAsync();

        if (nurseriesBatches is null)
        {
            throw new NotFoundException("No nursery batches found");
        }
        
        return nurseriesBatches;

    }
    
    
    public async Task AddBatch(AddBatchDTO dto)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var species = await _context.TreeSpecieses
                .FirstOrDefaultAsync(s => s.LatinName == dto.Species);

            if (species == null)
                throw new NotFoundException("Tree species not found.");

            var nursery = await _context.Nurseries
                .FirstOrDefaultAsync(n => n.Name == dto.Nursery);

            if (nursery == null)
                throw new NotFoundException("Nursery not found.");

            foreach (var r in dto.Responsible)
            {
                var empExists = await _context.Employees.AnyAsync(e => e.EmployeeId == r.EmployeeId);
                if (!empExists)
                    throw new NotFoundException("Employee not found.");
            }

            var newBatch = new SeedlingBatch
            {
                Quantity = dto.Quantity,
                NurseryId = nursery.NurseryId,
                SpeciesId = species.SpeciesId,
                SownDate = DateTime.Now,
                ReadyDate = DateTime.Now.AddYears(species.GrowthTimeInYears)
            };

            await _context.SeedlingBatches.AddAsync(newBatch);
            await _context.SaveChangesAsync();

            foreach (var r in dto.Responsible)
            {
                var responsible = new Responsible
                {
                    BatchId = newBatch.BatchId,
                    EmployeeId = r.EmployeeId,
                    Role = r.Role
                };
                await _context.Responsibles.AddAsync(responsible);
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch(Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
    

}