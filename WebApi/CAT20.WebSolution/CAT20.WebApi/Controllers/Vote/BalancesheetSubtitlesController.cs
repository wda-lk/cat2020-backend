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
    [Route("api/vote/balancesheetSubtitles")]
    [ApiController]
    public class BalancesheetSubtitlesController : BaseController
    {
        private readonly IBalancesheetSubtitleService _balancesheetSubtitleService;
        private readonly IMapper _mapper;

        public BalancesheetSubtitlesController(IBalancesheetSubtitleService balancesheetSubtitleService, IMapper mapper)
        {
            this._mapper = mapper;
            this._balancesheetSubtitleService = balancesheetSubtitleService;
        }

        [HttpGet("getAllBalancesheetSubtitles")]
        public async Task<ActionResult<IEnumerable<BalancesheetSubtitle>>> GetAllBalancesheetSubtitles()
        {
            var balancesheetSubtitles = await _balancesheetSubtitleService.GetAllBalancesheetSubtitles();
            var balancesheetSubtitleResources = _mapper.Map<IEnumerable<BalancesheetSubtitle>, IEnumerable<BalancesheetSubtitleResource>>(balancesheetSubtitles);

            return Ok(balancesheetSubtitleResources);
        }
        [HttpGet]
        [Route("getBalancesheetSubtitleById/{id}")]
        public async Task<ActionResult<BalancesheetSubtitleResource>> GetBalancesheetSubtitleById([FromRoute] int id)
        {
            var balancesheetSubtitle = await _balancesheetSubtitleService.GetBalancesheetSubtitleById(id);
            var balancesheetSubtitleResource = _mapper.Map<BalancesheetSubtitle, BalancesheetSubtitleResource>(balancesheetSubtitle);
            return Ok(balancesheetSubtitleResource);
        }

        [HttpPost("saveBalancesheetSubtitle")]
        public async Task<ActionResult<BalancesheetSubtitleResource>> CreateBalancesheetSubtitle([FromBody] SaveBalancesheetSubtitleResource saveBalancesheetSubtitleResource)
        {
            var validator = new SaveBalancesheetSubtitleResourceValidator();
            var validationResult = await validator.ValidateAsync(saveBalancesheetSubtitleResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var balancesheetSubtitleToCreate = _mapper.Map<SaveBalancesheetSubtitleResource, BalancesheetSubtitle>(saveBalancesheetSubtitleResource);

            var newBalancesheetSubtitle = await _balancesheetSubtitleService.CreateBalancesheetSubtitle(balancesheetSubtitleToCreate);

            var balancesheetSubtitle = await _balancesheetSubtitleService.GetBalancesheetSubtitleById(newBalancesheetSubtitle.ID);

            var balancesheetSubtitleResource = _mapper.Map<BalancesheetSubtitle, BalancesheetSubtitleResource>(balancesheetSubtitle);

            return Ok(balancesheetSubtitleResource);
        }

        [HttpPost("updateBalancesheetSubtitle")]
        public async Task<ActionResult<BalancesheetSubtitleResource>> UpdateBalancesheetSubtitle(SaveBalancesheetSubtitleResource saveBalancesheetSubtitleResource)
        {
            var validator = new SaveBalancesheetSubtitleResourceValidator();
            var validationResult = await validator.ValidateAsync(saveBalancesheetSubtitleResource);

            var requestIsInvalid = saveBalancesheetSubtitleResource.ID == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var balancesheetSubtitleToBeUpdate = await _balancesheetSubtitleService.GetBalancesheetSubtitleById(saveBalancesheetSubtitleResource.ID);

            if (balancesheetSubtitleToBeUpdate == null)
                return NotFound();

            var product = _mapper.Map<SaveBalancesheetSubtitleResource, BalancesheetSubtitle>(saveBalancesheetSubtitleResource);

            await _balancesheetSubtitleService.UpdateBalancesheetSubtitle(balancesheetSubtitleToBeUpdate, product);

            var updatedBalancesheetSubtitle = await _balancesheetSubtitleService.GetBalancesheetSubtitleById(saveBalancesheetSubtitleResource.ID);
            var updatedBalancesheetSubtitleResource = _mapper.Map<BalancesheetSubtitle, BalancesheetSubtitleResource>(updatedBalancesheetSubtitle);

            return Ok(updatedBalancesheetSubtitleResource);
        }

        [HttpPost]
        [Route("deleteBalancesheetSubtitle/{id}")]
        public async Task<IActionResult> DeleteBalancesheetSubtitle([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest();

            var balancesheetSubtitle = await _balancesheetSubtitleService.GetBalancesheetSubtitleById(id);

            if (balancesheetSubtitle == null)
                return NotFound();

            await _balancesheetSubtitleService.DeleteBalancesheetSubtitle(balancesheetSubtitle);

            return NoContent();
        }

        [HttpGet]
        [Route("getAllBalancesheetSubtitlesForSabhaId/{SabhaId}")]
        public async Task<ActionResult<IEnumerable<BalancesheetSubtitle>>> GetAllBalancesheetSubtitlesForSabhaId([FromRoute] int SabhaId)
        {
            var balancesheetSubtitles = await _balancesheetSubtitleService.GetAllBalancesheetSubtitlesForSabhaId(SabhaId);
            var balancesheetSubtitleResources = _mapper.Map<IEnumerable<BalancesheetSubtitle>, IEnumerable<BalancesheetSubtitleResource>>(balancesheetSubtitles);

            return Ok(balancesheetSubtitleResources);
        }


        [HttpGet]
        [Route("getAllBalancesheetSubtitlesForTitleID/{TitleID}")]
        public async Task<ActionResult<IEnumerable<BalancesheetSubtitle>>> GetAllBalancesheetSubtitlesForTitleID([FromRoute] int TitleID)
        {
            var balancesheetSubtitles = await _balancesheetSubtitleService.GetAllBalancesheetSubtitlesForTitleID(TitleID);
            var balancesheetSubtitleResources = _mapper.Map<IEnumerable<BalancesheetSubtitle>, IEnumerable<BalancesheetSubtitleResource>>(balancesheetSubtitles);

            return Ok(balancesheetSubtitleResources);
        }
    }
}
