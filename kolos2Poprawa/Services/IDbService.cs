using kolos2Poprawa.DTOs;

namespace kolos2Poprawa.Services;


public interface IDbService
{
    public Task<NurseriesBatchesDTO> GetNurseriesBatches(int id);
    Task AddBatch(AddBatchDTO dto);
}