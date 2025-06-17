using kolos2Poprawa.Models;
using Microsoft.EntityFrameworkCore;

namespace kolos2Poprawa.Database;



public class DatabaseContext : DbContext
{


     public DbSet<Nursery> Nurseries {get; set;}
     public DbSet<TreeSpecies> TreeSpecieses {get; set;}
     public DbSet<Employee> Employees {get; set;}
     public DbSet<SeedlingBatch> SeedlingBatches {get; set;}
     public DbSet<Responsible> Responsibles {get; set;}
    
    
    protected DatabaseContext() : base()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         modelBuilder.Entity<Nursery>().HasData(new List<Nursery>
         {
             new Nursery(){NurseryId = 1, Name = "Anna", EstablishedDate = DateTime.Parse("2021-09-02")},
             new Nursery(){NurseryId = 2, Name = "Lucja", EstablishedDate = DateTime.Parse("2022-09-18")},
             new Nursery(){NurseryId = 3, Name = "Patrycja", EstablishedDate = DateTime.Parse("2021-08-10")},
             
         });
        
        
         modelBuilder.Entity<TreeSpecies>().HasData(new List<TreeSpecies>
         {
             new TreeSpecies(){SpeciesId = 1, LatinName = "Bleblablu", GrowthTimeInYears = 2},
             new TreeSpecies(){SpeciesId = 2, LatinName = "Annograjka", GrowthTimeInYears = 1},
             new TreeSpecies(){SpeciesId = 3, LatinName = "Silwuple", GrowthTimeInYears = 6},
             
         });
        
        
         modelBuilder.Entity<Employee>().HasData(new List<Employee>
         {
          new Employee(){EmployeeId = 1, FirstName = "Jan", LastName = "Kowalski", HireDate = DateTime.Parse("2019-03-16")},   
          new Employee(){EmployeeId = 2, FirstName = "Krzysztof", LastName = "Zalewski", HireDate = DateTime.Parse("2019-09-26")},   
          new Employee(){EmployeeId = 3, FirstName = "Grzegorz", LastName = "Floryda", HireDate = DateTime.Parse("2023-05-05")},   
         });
        
        
         modelBuilder.Entity<SeedlingBatch>().HasData(new List<SeedlingBatch>
         {
             new SeedlingBatch(){BatchId = 1, NurseryId = 1, SpeciesId = 1, Quantity = 5, SownDate = DateTime.Parse("2021-09-01"), ReadyDate = DateTime.Parse("2029-09-01")},
             new SeedlingBatch(){BatchId = 2, NurseryId = 1, SpeciesId = 2, Quantity = 1, SownDate = DateTime.Parse("2018-05-28"), ReadyDate = DateTime.Parse("2028-09-01")},
             new SeedlingBatch(){BatchId = 3, NurseryId = 2, SpeciesId = 1, Quantity = 7, SownDate = DateTime.Parse("2022-12-02"), ReadyDate = DateTime.Parse("2026-09-01")},
             new SeedlingBatch(){BatchId = 4, NurseryId = 2, SpeciesId = 3, Quantity = 3, SownDate = DateTime.Parse("2022-11-09"), ReadyDate = DateTime.Parse("2025-09-01")},
             new SeedlingBatch(){BatchId = 5, NurseryId = 3, SpeciesId = 3, Quantity = 9, SownDate = DateTime.Parse("2021-06-19"), ReadyDate = DateTime.Parse("2030-09-01")},
             
             
         });
        
         modelBuilder.Entity<Responsible>().HasData(new List<Responsible>
         {
             new Responsible(){BatchId = 1, EmployeeId = 1, Role = "Sprzatacz"},
             new Responsible(){BatchId = 1, EmployeeId = 2, Role = "Tancerz"},
             new Responsible(){BatchId = 1, EmployeeId = 3, Role = "Spiewak"},
             new Responsible(){BatchId = 2, EmployeeId = 1, Role = "Lekarz"},
             new Responsible(){BatchId = 2, EmployeeId = 3, Role = "Bulbulator"},
             new Responsible(){BatchId = 3, EmployeeId = 2, Role = "Mysisprzet"},
             new Responsible(){BatchId = 3, EmployeeId = 3, Role = "Ligma"},
         });

    }

}