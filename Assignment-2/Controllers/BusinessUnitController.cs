using Assignment_2.Models;
using Assignment_2.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Controllers
{
    
    [ApiController]
    public class BusinessUnitController : ControllerBase
    {
        private readonly IBatchRepository _batchRepository;

        public BusinessUnitController(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }


        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllBusinessUnit()
        {
            var businessUnits = await _batchRepository.GetBusinessUnitsAsync();
            return Ok(businessUnits);
        }

        [HttpGet]
        [Route("[controller]/{buId:int}"), ActionName("GetBusinessUnit")]
        public async Task<IActionResult> GetBusinessUnit([FromRoute] int buId)
        {
            var businessUnit = await _batchRepository.GetBusinessUnitAsync(buId);
            if (businessUnit == null)
            {
                return NotFound();
            }
            return Ok(businessUnit);
        }

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddBusinessUnit([FromBody] BusinessUnit businessUnit)
        {
            var addBusinessUnit = await _batchRepository.AddBusinessUnit(businessUnit);
            return Ok(addBusinessUnit.Id);

        }



    }
}
