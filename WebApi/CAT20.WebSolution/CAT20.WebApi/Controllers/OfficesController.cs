using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CAT20.Api.Validators;
using CAT20.Core.Models.Control;
using CAT20.Core.Services.Control;
using CAT20.WebApi.Controllers;
using CAT20.WebApi.Resources.Control;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CAT20.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesController : BaseController
    {
        private readonly IOfficeService _officeService;
        private readonly IMapper _mapper;

        public OfficesController(IOfficeService officeService, IMapper mapper)
        {
            this._mapper = mapper;
            this._officeService = officeService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Office>>> GetAllProducts()
        {
            var offices = await _officeService.GetAllOffices();
            var officeResources = _mapper.Map<IEnumerable<Office>, IEnumerable<OfficeResource>>(offices);

            return Ok(officeResources);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OfficeResource>> GetOfficeById(int id)
        {
            var office = await _officeService.GetOfficeById(id);
            var officeResource = _mapper.Map<Office, OfficeResource>(office);
            return Ok(officeResource);
        }

        //[HttpPost("")]
        //public async Task<ActionResult<OfficeResource>> CreateOffice([FromBody] SaveOfficeResource saveOfficeResource)
        //{
        //    var validator = new SaveOfficeResourceValidator();
        //    var validationResult = await validator.ValidateAsync(saveOfficeResource);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

        //    var officeToCreate = _mapper.Map<SaveOfficeResource, Office>(saveOfficeResource);

        //    var newOffice = await _officeService.CreateOffice(officeToCreate);

        //    var office = await _officeService.GetOfficeById(newOffice.ID);

        //    var officeResource = _mapper.Map<Office, OfficeResource>(office);

        //    return Ok(officeResource);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<OfficeResource>> UpdateProduct(int id, [FromBody] SaveOfficeResource saveOfficeResource)
        //{
        //    var validator = new SaveOfficeResourceValidator();
        //    var validationResult = await validator.ValidateAsync(saveOfficeResource);

        //    var requestIsInvalid = id == 0 || !validationResult.IsValid;

        //    if (requestIsInvalid)
        //        return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

        //    var officeToBeUpdate = await _officeService.GetOfficeById(id);

        //    if (officeToBeUpdate == null)
        //        return NotFound();

        //    var product = _mapper.Map<SaveOfficeResource, Office>(saveOfficeResource);

        //    await _officeService.UpdateOffice(officeToBeUpdate, product);

        //    var updatedOffice = await _officeService.GetOfficeById(id);
        //    var updatedOfficeResource = _mapper.Map<Office, OfficeResource>(updatedOffice);

        //    return Ok(updatedOfficeResource);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct(int id)
        //{
        //    if (id == 0)
        //        return BadRequest();

        //    var office = await _officeService.GetOfficeById(id);

        //    if (office == null)
        //        return NotFound();

        //    await _officeService.DeleteOffice(office);

        //    return NoContent();
        //}
    }
}