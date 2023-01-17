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
    [Route("api/vote/voteDetail")]
    [ApiController]
    public class VoteDetailsController : BaseController
    {
        private readonly IVoteDetailService _voteDetailService;
        private readonly IMapper _mapper;

        public VoteDetailsController(IVoteDetailService voteDetailService, IMapper mapper)
        {
            this._mapper = mapper;
            this._voteDetailService = voteDetailService;
        }

        [HttpGet("getAllVoteDetail")]
        public async Task<ActionResult<IEnumerable<VoteDetail>>> GetAllVoteDetail()
        {
            var voteDetails = await _voteDetailService.GetAllVoteDetails();
            var voteDetailResources = _mapper.Map<IEnumerable<VoteDetail>, IEnumerable<VoteDetailResource>>(voteDetails);

            return Ok(voteDetailResources);
        }

        [HttpGet]
        [Route("getVoteDetailById/{id}")]
        public async Task<ActionResult<VoteDetailResource>> GetVoteDetailById([FromRoute]int id)
        {
            var voteDetail = await _voteDetailService.GetVoteDetailById(id);
            var voteDetailResource = _mapper.Map<VoteDetail, VoteDetailResource>(voteDetail);
            return Ok(voteDetailResource);
        }

        [HttpPost("saveVoteDetail")]
        public async Task<ActionResult<VoteDetailResource>> CreateVoteDetail([FromBody] SaveVoteDetailResource saveVoteDetailResource)
        {
            var validator = new SaveVoteDetailResourceValidator();
            var validationResult = await validator.ValidateAsync(saveVoteDetailResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var voteDetailToCreate = _mapper.Map<SaveVoteDetailResource, VoteDetail>(saveVoteDetailResource);

            var newVoteDetail = await _voteDetailService.CreateVoteDetail(voteDetailToCreate);

            var voteDetail = await _voteDetailService.GetVoteDetailById(newVoteDetail.ID);

            var voteDetailResource = _mapper.Map<VoteDetail, VoteDetailResource>(voteDetail);

            return Ok(voteDetailResource);
        }

        [HttpPost("updateVoteDetail")]
        public async Task<ActionResult<VoteDetailResource>> UpdateVoteDetail(SaveVoteDetailResource saveVoteDetailResource)
        {
            var validator = new SaveVoteDetailResourceValidator();
            var validationResult = await validator.ValidateAsync(saveVoteDetailResource);

            var requestIsInvalid = saveVoteDetailResource.ID == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var voteDetailToBeUpdate = await _voteDetailService.GetVoteDetailById(saveVoteDetailResource.ID);

            if (voteDetailToBeUpdate == null)
                return NotFound();

            var product = _mapper.Map<SaveVoteDetailResource, VoteDetail>(saveVoteDetailResource);

            await _voteDetailService.UpdateVoteDetail(voteDetailToBeUpdate, product);

            var updatedVoteDetail = await _voteDetailService.GetVoteDetailById(saveVoteDetailResource.ID);
            var updatedVoteDetailResource = _mapper.Map<VoteDetail, VoteDetailResource>(updatedVoteDetail);

            return Ok(updatedVoteDetailResource);
        }

        [HttpPost]
        [Route("deleteVoteDetail/{id}")]
        public async Task<IActionResult> DeleteVoteDetail([FromRoute]int id)
        {
            if (id == 0)
                return BadRequest();

            var voteDetail = await _voteDetailService.GetVoteDetailById(id);

            if (voteDetail == null)
                return NotFound();

            await _voteDetailService.DeleteVoteDetail(voteDetail);

            return NoContent();
        }

        [HttpGet]
        [Route("getAllVoteDetailForSabhaId/{sabhaId}")]
        public async Task<ActionResult<IEnumerable<VoteDetail>>> GetAllWithVoteDetailBySabhaId([FromRoute]int sabhaId)
        {
            var voteDetails = await _voteDetailService.GetAllWithVoteDetailBySabhaId(sabhaId);
            var voteDetailResources = _mapper.Map<IEnumerable<VoteDetail>, IEnumerable<VoteDetailResource>>(voteDetails);

            return Ok(voteDetailResources);
        }

        [HttpGet]
        [Route("getAllVoteDetailForProgrammeId/{ProgrammeId}")]
        public async Task<ActionResult<IEnumerable<VoteDetail>>> GetAllVoteDetailForProgrammeId([FromRoute] int ProgrammeId)
        {
            var voteDetails = await _voteDetailService.GetAllWithVoteDetailByProgrammeId(ProgrammeId);
            var voteDetailResources = _mapper.Map<IEnumerable<VoteDetail>, IEnumerable<VoteDetailResource>>(voteDetails);

            return Ok(voteDetailResources);
        }

        [HttpGet]
        [Route("getAllVoteDetailForProgrammeIdandSabhaId/{ProgrammeId}/{SabhaId}")]
        public async Task<ActionResult<IEnumerable<VoteDetail>>> GetAllVoteDetailForProgrammeIdandSabhaId([FromRoute]int ProgrammeId,[FromRoute] int SabhaId)
        {
            var voteDetails = await _voteDetailService.GetAllWithVoteDetailByProgrammeIdandSabhaId(ProgrammeId, SabhaId);
            var voteDetailResources = _mapper.Map<IEnumerable<VoteDetail>, IEnumerable<VoteDetailResource>>(voteDetails);

            return Ok(voteDetailResources);
        }

        [HttpGet]
        [Route("getAllVoteDetailBySabhaId/{SabhaId}")]
        public async Task<ActionResult<IEnumerable<VoteDetail>>> GetAllVoteDetailBySabhaId([FromRoute] int SabhaId)
        {
            var voteDetails = await _voteDetailService.GetAllWithVoteDetailBySabhaId(SabhaId);
            var voteDetailResources = _mapper.Map<IEnumerable<VoteDetail>, IEnumerable<VoteDetailResource>>(voteDetails);

            return Ok(voteDetailResources);
        }
    }
}
