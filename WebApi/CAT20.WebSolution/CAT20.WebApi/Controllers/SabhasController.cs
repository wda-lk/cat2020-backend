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
    public class SabhasController : BaseController
    {
        private readonly ISabhaService _sabhaService;
        private readonly IMapper _mapper;

        public SabhasController(ISabhaService sabhaService, IMapper mapper)
        {
            this._mapper = mapper;
            this._sabhaService = sabhaService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Sabha>>> GetAllProducts()
        {
            var sabhas = await _sabhaService.GetAllSabhas();
            var sabhaResources = _mapper.Map<IEnumerable<Sabha>, IEnumerable<SabhaResource>>(sabhas);

            return Ok(sabhaResources);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SabhaResource>> GetSabhaById(int id)
        {
            var sabha = await _sabhaService.GetSabhaById(id);
            var sabhaResource = _mapper.Map<Sabha, SabhaResource>(sabha);
            return Ok(sabhaResource);
        }

        //[HttpPost("")]
        //public async Task<ActionResult<SabhaResource>> CreateSabha([FromBody] SaveSabhaResource saveSabhaResource)
        //{
        //    var validator = new SaveSabhaResourceValidator();
        //    var validationResult = await validator.ValidateAsync(saveSabhaResource);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

        //    var sabhaToCreate = _mapper.Map<SaveSabhaResource, Sabha>(saveSabhaResource);

        //    var newSabha = await _sabhaService.CreateSabha(sabhaToCreate);

        //    var sabha = await _sabhaService.GetSabhaById(newSabha.ID);

        //    var sabhaResource = _mapper.Map<Sabha, SabhaResource>(sabha);

        //    return Ok(sabhaResource);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<SabhaResource>> UpdateProduct(int id, [FromBody] SaveSabhaResource saveSabhaResource)
        //{
        //    var validator = new SaveSabhaResourceValidator();
        //    var validationResult = await validator.ValidateAsync(saveSabhaResource);

        //    var requestIsInvalid = id == 0 || !validationResult.IsValid;

        //    if (requestIsInvalid)
        //        return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

        //    var sabhaToBeUpdate = await _sabhaService.GetSabhaById(id);

        //    if (sabhaToBeUpdate == null)
        //        return NotFound();

        //    var product = _mapper.Map<SaveSabhaResource, Sabha>(saveSabhaResource);

        //    await _sabhaService.UpdateSabha(sabhaToBeUpdate, product);

        //    var updatedSabha = await _sabhaService.GetSabhaById(id);
        //    var updatedSabhaResource = _mapper.Map<Sabha, SabhaResource>(updatedSabha);

        //    return Ok(updatedSabhaResource);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct(int id)
        //{
        //    if (id == 0)
        //        return BadRequest();

        //    var sabha = await _sabhaService.GetSabhaById(id);

        //    if (sabha == null)
        //        return NotFound();

        //    await _sabhaService.DeleteSabha(sabha);

        //    return NoContent();
        //}
    }
}