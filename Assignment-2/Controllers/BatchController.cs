using Assignment_2.Models;
using Assignment_2.Models.Data.Dto;
using Assignment_2.Models.Error;
using Assignment_2.Repositories.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment_2.Controllers
{

    [ApiController]

    public class BatchController : ControllerBase
    {

        private readonly IBatchRepository _batchRepository;
        private readonly IMapper _mapper;

        public BatchController(IBatchRepository batchRepository, IMapper mapper)
        {
            _batchRepository = batchRepository;
            _mapper = mapper;

        }




        [SwaggerOperation(Summary = "Get all details of the batch including links to all the files in the batch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [Route("[controller]/Batchs")]
        public async Task<IActionResult> GetAllBatchs()
        {
            var batches = await _batchRepository.GetBatchsAsync();
            return Ok(batches);
        }



        /// <param name="batchId">A BatchId (BatchId accept Only Guid Format )</param>
        [SwaggerOperation(Summary = "Get details of the batch including links to all the files in the batch",Description = "This Get will include full details of batch , for example it's status , the file in the batch")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: null, description: "Ok-Returns details about the batch")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, type: typeof(CorRelation), description: "Bad Request - Could be an invalid batchId Format , Batch IDs Should be a GUID , A valid GUID that doesn't match a batch ID will return a 404 ")]
       
        [HttpGet]
        [Route("[controller]/{batchId:Guid}"), ActionName("GetStudent")]
        public async Task<IActionResult> GetBatch(Guid batchId)
        {

            if (batchId != Guid.Empty)
            {
                var batch = await _batchRepository.GetBatchAsync(batchId);
                if (batch == null)
                {
                    return NotFound();
                }
                return Ok(batch);
            }
            else
            {
                Error error = new Error
                {
                    Source = "Batch.BatchId",
                    Description = "Please Enter BatchId in  Guid Format"
                };
                var correlation = new
                {
                    CorrelationId = batchId,
                    Errors = error
                };
                return BadRequest(correlation);
            }
        }




        [SwaggerOperation(Summary = "Create a new Batch to upload files into ")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, type: typeof(CorRelation), description: "Bad Request - there are one or more error in the Specified parameters")]
        [HttpPost]
        [Route("[controller]")]
        public async Task<IActionResult> AddBatch([FromBody] BatchDto request)
        {
                if (ModelState.IsValid)
                {
                    var addBatch = await _batchRepository.AddBatch(_mapper.Map<Batch>(request));
                    return Created(nameof(GetBatch), new { BatchId = addBatch.BatchId });
                }
               return Ok();     
        }



      

    } 
}