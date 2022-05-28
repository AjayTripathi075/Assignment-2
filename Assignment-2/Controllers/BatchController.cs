using Assignment_2.Models;
using Assignment_2.Models.Data;
using Assignment_2.Models.Data.Dto;
using Assignment_2.Models.Error;
using Assignment_2.Repositories.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Assignment_2.Controllers
{

    [ApiController]
    public class BatchController : ControllerBase
    {

        private readonly IBatchRepository _batchRepository;
        

        public BatchController(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }

        [SwaggerOperation(Summary = "Get all details of the batch including links to all the files in the batch")]
        [HttpGet]
        [Route("[controller]/Batchs")]
        public async Task<IActionResult> GetAllBatchs()
        {
            var batches = await _batchRepository.GetBatchsAsync();
            return Ok(batches);
        }

        [SwaggerOperation(Summary = "Get details of the batch including links to all the files in the batch")]
        [HttpGet]
        [Route("[controller]/{batchId:guid}"), ActionName("GetStudent")]
        public async Task<IActionResult> GetBatch([FromRoute] Guid batchId)
        {
            var batch = await _batchRepository.GetBatchAsync(batchId);
            if (batch == null)
            {
                return NotFound();
            }
            return Ok(batch);
        }

        [SwaggerOperation(Summary = "Create a new Batch to upload files into ")]
        [HttpPost]
        [Route("[controller]")]
        public async Task<IActionResult> AddBatch([FromBody] Batch batch)
        {

                    if(ModelState.IsValid)
                    {
                     var addBatch = await _batchRepository.AddBatch(batch);
                     return Created(nameof(GetBatch), new { BatchId = addBatch.BatchId });
                    }
                    else
                    {
                     CorRelation result = CreateError();
                    // throw new Exception("Error");
                    ModelState.AddModelError("Error", "result");
                   // return BadRequest(result);
                    }
            return Ok();
        }

        private static CorRelation CreateError()
        { 
            Error e = new Error();
            e.Source = "abc";
            e.Description = "pqr";
            CorRelation result = new CorRelation();
            return result;
        }
    }
}