using Assignment_2.Models;
using Assignment_2.Models.Data;
using Assignment_2.Models.Data.Dto;
using Assignment_2.Models.Error;
using Assignment_2.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Repositories
{
    public class BatchRepository : IBatchRepository
    {
        public readonly AppDbContext _db;
        public BatchRepository(AppDbContext context)
        {
            _db = context;
        }
        public async Task<Batch> AddBatch(Batch request)
        {
            var batch = await _db.Batch.AddAsync(request);
            await _db.SaveChangesAsync();
            return batch.Entity;
        }

        public async Task<BusinessUnit> AddBusinessUnit(BusinessUnit request)
        {
            var Bu = await _db.BusinessUnit.AddAsync(request);
            await _db.SaveChangesAsync();
            return Bu.Entity;

        }

        public async Task<Batch> DeleteBatchAsync(Guid batchId)
        {
            var batch = await GetBatchAsync(batchId);
            if (batch != null)
            {
                _db.Batch.Remove(batch);
                await _db.SaveChangesAsync();
                return batch;
            }
            return null;

        }

        public async Task<bool> Exists(Guid batchId)
        {
            return await _db.Batch.AnyAsync(x => x.BatchId == batchId);
        }

        public async Task<Batch> GetBatchAsync(Guid batchId)
        {
            
            return await _db.Batch.Include(x => x.BusinessUnit).Include(x => x.Acl).ThenInclude(x=>x.ReadUsers).Include(x => x.Acl).ThenInclude(x => x.ReadGroups).Include(x => x.Attributes).Include(x => x.Files).ThenInclude(x => x.FileAttributes).FirstOrDefaultAsync(x => x.BatchId == batchId);
        }

        public async Task<List<Batch>> GetBatchsAsync()
        {
            return await _db.Batch.Include(x=>x.BusinessUnit).Include(x => x.Acl).ThenInclude(x => x.ReadUsers).Include(x => x.Acl).ThenInclude(x=>x.ReadUsers).Include(x => x.Acl).ThenInclude(x => x.ReadGroups).Include(x => x.Attributes).Include(x => x.Files).ThenInclude(x => x.FileAttributes).ToListAsync();

        }

        public async Task<BusinessUnit> GetBusinessUnitAsync(int buId)
        {
            return await _db.BusinessUnit.FirstOrDefaultAsync(x => x.Id == buId);
        }

        public async Task<List<BusinessUnit>> GetBusinessUnitsAsync()
        {
            return await _db.BusinessUnit.ToListAsync();
        }

        public async Task<bool> ExistsbusinessUnit(string Name)
        {
            return await _db.BusinessUnit.AnyAsync(x => x.Description == Name);

        }

        public async Task<Batch> UpdateBatchAsync(Guid batchId, Batch request)
        {
            var existingbatch = await GetBatchAsync(batchId);
            if (existingbatch != null)
            {
                existingbatch.BusinessUnit.Description = request.BusinessUnit.Description;
                existingbatch.Acl.ReadUsers = request.Acl.ReadUsers;
                existingbatch.Acl.ReadGroups = request.Acl.ReadGroups;
                existingbatch.Attributes = request.Attributes;
                existingbatch.ExpiryDate = request.ExpiryDate;
                existingbatch.Files = request.Files;
                await _db.SaveChangesAsync();
                return existingbatch;
            }
            return null;

        }

   
    }
}


