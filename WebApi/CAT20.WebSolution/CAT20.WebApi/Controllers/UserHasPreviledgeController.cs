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
    public class UserHasPreviledgesController : BaseController
    {
        private readonly IUserHasPreviledgeService _userHasPreviledgeService;
        private readonly IMapper _mapper;

        public UserHasPreviledgesController(IUserHasPreviledgeService userHasPreviledgeService, IMapper mapper)
        {
            this._mapper = mapper;
            this._userHasPreviledgeService = userHasPreviledgeService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<UserHasPreviledge>>> GetAllProducts()
        {
            var userHasPreviledges = await _userHasPreviledgeService.GetAllUserHasPreviledges();
            var userHasPreviledgeResources = _mapper.Map<IEnumerable<UserHasPreviledge>, IEnumerable<UserHasPreviledgeResource>>(userHasPreviledges);

            return Ok(userHasPreviledgeResources);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserHasPreviledgeResource>> GetUserHasPreviledgeById(int id)
        {
            var userHasPreviledge = await _userHasPreviledgeService.GetUserHasPreviledgeById(id);
            var userHasPreviledgeResource = _mapper.Map<UserHasPreviledge, UserHasPreviledgeResource>(userHasPreviledge);
            return Ok(userHasPreviledgeResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<UserHasPreviledgeResource>> CreateUserHasPreviledge([FromBody] SaveUserHasPreviledgeResource saveUserHasPreviledgeResource)
        {
            var validator = new SaveUserHasPreviledgeResourceValidator();
            var validationResult = await validator.ValidateAsync(saveUserHasPreviledgeResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var userHasPreviledgeToCreate = _mapper.Map<SaveUserHasPreviledgeResource, UserHasPreviledge>(saveUserHasPreviledgeResource);

            var newUserHasPreviledge = await _userHasPreviledgeService.CreateUserHasPreviledge(userHasPreviledgeToCreate);

            var userHasPreviledge = await _userHasPreviledgeService.GetUserHasPreviledgeById(newUserHasPreviledge.ID);

            var userHasPreviledgeResource = _mapper.Map<UserHasPreviledge, UserHasPreviledgeResource>(userHasPreviledge);

            return Ok(userHasPreviledgeResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserHasPreviledgeResource>> UpdateProduct(int id, [FromBody] SaveUserHasPreviledgeResource saveUserHasPreviledgeResource)
        {
            var validator = new SaveUserHasPreviledgeResourceValidator();
            var validationResult = await validator.ValidateAsync(saveUserHasPreviledgeResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var userHasPreviledgeToBeUpdate = await _userHasPreviledgeService.GetUserHasPreviledgeById(id);

            if (userHasPreviledgeToBeUpdate == null)
                return NotFound();

            var product = _mapper.Map<SaveUserHasPreviledgeResource, UserHasPreviledge>(saveUserHasPreviledgeResource);

            await _userHasPreviledgeService.UpdateUserHasPreviledge(userHasPreviledgeToBeUpdate, product);

            var updatedUserHasPreviledge = await _userHasPreviledgeService.GetUserHasPreviledgeById(id);
            var updatedUserHasPreviledgeResource = _mapper.Map<UserHasPreviledge, UserHasPreviledgeResource>(updatedUserHasPreviledge);

            return Ok(updatedUserHasPreviledgeResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == 0)
                return BadRequest();

            var userHasPreviledge = await _userHasPreviledgeService.GetUserHasPreviledgeById(id);

            if (userHasPreviledge == null)
                return NotFound();

            await _userHasPreviledgeService.DeleteUserHasPreviledge(userHasPreviledge);

            return NoContent();
        }
    }
}
