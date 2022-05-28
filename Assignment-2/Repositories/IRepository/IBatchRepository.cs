using Assignment_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Repositories.IRepository
{
   public interface IBatchRepository
    {
        Task<List<Batch>> GetBatchsAsync();
        Task<Batch> GetBatchAsync(Guid batchId);
        Task<bool> Exists(Guid batchId);
        Task<Batch> updateBatchAsync(Guid batchId, Batch request);
        Task<Batch> DeleteBatchAsync(Guid batchId);
        Task<Batch> AddBatch(Batch request);

        //Business Unit
        Task<BusinessUnit> AddBusinessUnit(BusinessUnit request);
        Task<bool> ExistsbusinessUnit(string Name);
        Task<BusinessUnit> GetBusinessUnitAsync(int buId);
        Task<List<BusinessUnit>> GetBusinessUnitsAsync();

       // Task<Batch> AddBatchDetails(Batch request,string businessUnit);


    }
}
