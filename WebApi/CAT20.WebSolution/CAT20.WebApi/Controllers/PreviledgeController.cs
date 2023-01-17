using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CAT20.Api.Validators;
using CAT20.Core.Models.User;
using CAT20.Core.Services.User;
using CAT20.WebApi.Controllers;
using CAT20.WebApi.Resources.User;
using CAT20.WebApi.Resources.User.Save;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CAT20.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreviledgesController : BaseController
    {
        private readonly IPreviledgeService _previledgeService;
        private readonly IMapper _mapper;

        public PreviledgesController(IPreviledgeService previledgeService, IMapper mapper)
        {
            this._mapper = mapper;
            this._previledgeService = previledgeService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Previledge>>> GetAllProducts()
        {
            var previledges = await _previledgeService.GetAllPreviledges();
            var previledgeResources = _mapper.Map<IEnumerable<Previledge>, IEnumerable<PreviledgeResource>>(previledges);

            return Ok(previledgeResources);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PreviledgeResource>> GetPreviledgeById(int id)
        {
            var previledge = await _previledgeService.GetPreviledgeById(id);
            var previledgeResource = _mapper.Map<Previledge, PreviledgeResource>(previledge);
            return Ok(previledgeResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<PreviledgeResource>> CreatePreviledge([FromBody] SavePreviledgeResource savePreviledgeResource)
        {
            var validator = new SavePreviledgeResourceValidator();
            var validationResult = await validator.ValidateAsync(savePreviledgeResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var previledgeToCreate = _mapper.Map<SavePreviledgeResource, Previledge>(savePreviledgeResource);

            var newPreviledge = await _previledgeService.CreatePreviledge(previledgeToCreate);

            var previledge = await _previledgeService.GetPreviledgeById(newPreviledge.ID);

            var previledgeResource = _mapper.Map<Previledge, PreviledgeResource>(previledge);

            return Ok(previledgeResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PreviledgeResource>> UpdateProduct(int id, [FromBody] SavePreviledgeResource savePreviledgeResource)
        {
            var validator = new SavePreviledgeResourceValidator();
            var validationResult = await validator.ValidateAsync(savePreviledgeResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var previledgeToBeUpdate = await _previledgeService.GetPreviledgeById(id);

            if (previledgeToBeUpdate == null)
                return NotFound();

            var product = _mapper.Map<SavePreviledgeResource, Previledge>(savePreviledgeResource);

            await _previledgeService.UpdatePreviledge(previledgeToBeUpdate, product);

            var updatedPreviledge = await _previledgeService.GetPreviledgeById(id);
            var updatedPreviledgeResource = _mapper.Map<Previledge, PreviledgeResource>(updatedPreviledge);

            return Ok(updatedPreviledgeResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == 0)
                return BadRequest();

            var previledge = await _previledgeService.GetPreviledgeById(id);

            if (previledge == null)
                return NotFound();

            await _previledgeService.DeletePreviledge(previledge);

            return NoContent();
        }
    }
}
