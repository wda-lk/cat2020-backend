using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CAT20.Api.Validators;
using CAT20.Core.Models.Vote;
using CAT20.WebApi.Resources.Vote.Save;
using CAT20.WebApi.Resources.Vote;
using CAT20.Core.Services.Vote;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CAT20.WebApi.Controllers;

namespace CAT20.Api.Controllers
{
    [Route("api/vote/voteAllocations")]
    [ApiController]
    public class VoteAllocationsController : BaseController
    {
        private readonly IVoteAllocationService _voteAllocationService;
        private readonly IMapper _mapper;

        public VoteAllocationsController(IVoteAllocationService voteAllocationService, IMapper mapper)
        {
            this._mapper = mapper;
            this._voteAllocationService = voteAllocationService;
        }

        [HttpGet("getAllVoteAllocations")]
        public async Task<ActionResult<IEnumerable<VoteAllocation>>> GetAllVoteAllocations()
        {
            var voteAllocations = await _voteAllocationService.GetAllVoteAllocations();
            var voteAllocationResources = _mapper.Map<IEnumerable<VoteAllocation>, IEnumerable<VoteAllocationResource>>(voteAllocations);

            return Ok(voteAllocationResources);
        }

        [HttpGet("getVoteAllocationById")]
        public async Task<ActionResult<VoteAllocationResource>> GetVoteAllocationById(int id)
        {
            var voteAllocation = await _voteAllocationService.GetVoteAllocationById(id);
            var voteAllocationResource = _mapper.Map<VoteAllocation, VoteAllocationResource>(voteAllocation);
            return Ok(voteAllocationResource);
        }

        [HttpPost("saveVoteAllocation")]
        public async Task<ActionResult<VoteAllocationResource>> CreateVoteAllocation([FromBody] SaveVoteAllocationResource saveVoteAllocationResource)
        {
            var validator = new SaveVoteAllocationResourceValidator();
            var validationResult = await validator.ValidateAsync(saveVoteAllocationResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var voteAllocationToCreate = _mapper.Map<SaveVoteAllocationResource, VoteAllocation>(saveVoteAllocationResource);

            var newVoteAllocation = await _voteAllocationService.CreateVoteAllocation(voteAllocationToCreate);

            var voteAllocation = await _voteAllocationService.GetVoteAllocationById(newVoteAllocation.ID);

            var voteAllocationResource = _mapper.Map<VoteAllocation, VoteAllocationResource>(voteAllocation);

            return Ok(voteAllocationResource);
        }

        [HttpPost("updateVoteAllocation")]
        public async Task<ActionResult<VoteAllocationResource>> UpdateVoteAllocation(SaveVoteAllocationResource saveVoteAllocationResource)
        {
            var validator = new SaveVoteAllocationResourceValidator();
            var validationResult = await validator.ValidateAsync(saveVoteAllocationResource);

            var requestIsInvalid = saveVoteAllocationResource.ID == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var voteAllocationToBeUpdate = await _voteAllocationService.GetVoteAllocationById(saveVoteAllocationResource.ID);

            if (voteAllocationToBeUpdate == null)
                return NotFound();

            var product = _mapper.Map<SaveVoteAllocationResource, VoteAllocation>(saveVoteAllocationResource);

            await _voteAllocationService.UpdateVoteAllocation(voteAllocationToBeUpdate, product);

            var updatedVoteAllocation = await _voteAllocationService.GetVoteAllocationById(saveVoteAllocationResource.ID);
            var updatedVoteAllocationResource = _mapper.Map<VoteAllocation, VoteAllocationResource>(updatedVoteAllocation);

            return Ok(updatedVoteAllocationResource);
        }

        [HttpPost]
        [Route("deleteVoteAllocation/{id}")]
        public async Task<IActionResult> DeleteVoteAllocation([FromRoute]int id)
        {
            if (id == 0)
                return BadRequest();

            var voteAllocation = await _voteAllocationService.GetVoteAllocationById(id);

            if (voteAllocation == null)
                return NotFound();

            await _voteAllocationService.DeleteVoteAllocation(voteAllocation);

            return NoContent();
        }

        [HttpGet]
        [Route("GetAllVoteAllocationByVoteDetailIdAsync/{SabhaId}")]
        public async Task<ActionResult<IEnumerable<VoteAllocation>>> GetAllWithVoteAllocationByVoteDetailIdAsync([FromRoute] int id)
        {
            var voteAllocations = await _voteAllocationService.GetAllWithVoteAllocationByVoteDetailIdAsync(id);
            var voteAllocationResources = _mapper.Map<IEnumerable<VoteAllocation>, IEnumerable<VoteAllocationResource>>(voteAllocations);

            return Ok(voteAllocationResources);
        }


        [HttpGet]
        [Route("getAllVoteAllocationsForVoteDetailIdandSabhaId/{VoteDetailId}/{SabhaId}")]
        public async Task<ActionResult<IEnumerable<VoteAllocation>>> GetAllWithVoteAllocationByVoteDetailIdSabhaId([FromRoute] int VoteDetailId, [FromRoute] int SabhaId)
        {
            var voteAllocations = await _voteAllocationService.GetAllWithVoteAllocationByVoteDetailIdSabhaId(VoteDetailId, SabhaId);
            var voteAllocationResources = _mapper.Map<IEnumerable<VoteAllocation>, IEnumerable<VoteAllocationResource>>(voteAllocations);

            return Ok(voteAllocationResources);
        }

        [HttpGet]
        [Route("getAllVoteAllocationsForVoteDetailIdandSabhaIdandYear/{VoteDetailId}/{SabhaId}/{Year}")]
        public async Task<ActionResult<IEnumerable<VoteAllocation>>> GetAllVoteAllocationsForVoteDetailIdandSabhaIdandYear([FromRoute] int VoteDetailId, [FromRoute] int SabhaId, [FromRoute] int Year)
        {
            var voteAllocations = await _voteAllocationService.GetAllVoteAllocationsForVoteDetailIdandSabhaIdandYear(VoteDetailId, SabhaId, Year);
            var voteAllocationResources = _mapper.Map<IEnumerable<VoteAllocation>, IEnumerable<VoteAllocationResource>>(voteAllocations);

            return Ok(voteAllocationResources);
        }

        [HttpGet]
        [Route("getAllWithVoteAllocationBySabhaId/{SabhaId}")]
        public async Task<ActionResult<IEnumerable<VoteAllocation>>> GetAllWithVoteAllocationBySabhaId([FromRoute] int SabhaId)
        {
            var voteAllocations = await _voteAllocationService.GetAllWithVoteAllocationBySabhaId(SabhaId);
            var voteAllocationResources = _mapper.Map<IEnumerable<VoteAllocation>, IEnumerable<VoteAllocationResource>>(voteAllocations);

            return Ok(voteAllocationResources);
        }
    }
}
