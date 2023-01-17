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
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CAT20.Api.Controllers
{
    [Route("api/vote/accountBalance")]
    [ApiController]
    public class AccountBalanceDetailsController : BaseController
    {
        private readonly IAccountBalanceDetailService _accountBalanceDetailService;
        private readonly IMapper _mapper;

        public AccountBalanceDetailsController(IAccountBalanceDetailService accountBalanceDetailService, IMapper mapper)
        {
            this._mapper = mapper;
            this._accountBalanceDetailService = accountBalanceDetailService;
        }
       
        [HttpGet("getAllAccountBalanceDetails")]
        public async Task<ActionResult<IEnumerable<AccountBalanceDetail>>> GetAllAccountBalanceDetails()
        {
            var accountBalanceDetails = await _accountBalanceDetailService.GetAllAccountBalanceDetails();
            var accountBalanceDetailResources = _mapper.Map<IEnumerable<AccountBalanceDetail>, IEnumerable<AccountBalanceDetailResource>>(accountBalanceDetails);

            return Ok(accountBalanceDetailResources);
        }

        [HttpGet]
        [Route("getAccountBalanceDetailById/{id}")]
        public async Task<ActionResult<AccountBalanceDetailResource>> GetAccountBalanceDetailById([FromRoute]int id)
        {
            var accountBalanceDetail = await _accountBalanceDetailService.GetAccountBalanceDetailById(id);
            var accountBalanceDetailResource = _mapper.Map<AccountBalanceDetail, AccountBalanceDetailResource>(accountBalanceDetail);
            return Ok(accountBalanceDetailResource);
        }

        [HttpPost("saveAccountBalanceDetail")]
        public async Task<ActionResult<AccountBalanceDetailResource>> CreateAccountBalanceDetail([FromBody] SaveAccountBalanceDetailResource saveAccountBalanceDetailResource)
        {
            var validator = new SaveAccountBalanceDetailResourceValidator();
            var validationResult = await validator.ValidateAsync(saveAccountBalanceDetailResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var accountBalanceDetailToCreate = _mapper.Map<SaveAccountBalanceDetailResource, AccountBalanceDetail>(saveAccountBalanceDetailResource);

            var newAccountBalanceDetail = await _accountBalanceDetailService.CreateAccountBalanceDetail(accountBalanceDetailToCreate);

            var accountBalanceDetail = await _accountBalanceDetailService.GetAccountBalanceDetailById(newAccountBalanceDetail.ID);

            var accountBalanceDetailResource = _mapper.Map<AccountBalanceDetail, AccountBalanceDetailResource>(accountBalanceDetail);

            return Ok(accountBalanceDetailResource);
        }

        [HttpPost("updateAccountBalanceDetail")]
        public async Task<ActionResult<AccountBalanceDetailResource>> UpdateAccountBalanceDetail(SaveAccountBalanceDetailResource saveAccountBalanceDetailResource)
        {
            var validator = new SaveAccountBalanceDetailResourceValidator();
            var validationResult = await validator.ValidateAsync(saveAccountBalanceDetailResource);

            var requestIsInvalid = saveAccountBalanceDetailResource.ID == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var accountBalanceDetailToBeUpdate = await _accountBalanceDetailService.GetAccountBalanceDetailById(saveAccountBalanceDetailResource.ID);

            if (accountBalanceDetailToBeUpdate == null)
                return NotFound();

            var product = _mapper.Map<SaveAccountBalanceDetailResource, AccountBalanceDetail>(saveAccountBalanceDetailResource);

            await _accountBalanceDetailService.UpdateAccountBalanceDetail(accountBalanceDetailToBeUpdate, product);

            var updatedAccountBalanceDetail = await _accountBalanceDetailService.GetAccountBalanceDetailById(saveAccountBalanceDetailResource.ID);
            var updatedAccountBalanceDetailResource = _mapper.Map<AccountBalanceDetail, AccountBalanceDetailResource>(updatedAccountBalanceDetail);

            return Ok(updatedAccountBalanceDetailResource);
        }

        [HttpPost]
        [Route("deleteAccountBalanceDetail/{id}")]
        public async Task<IActionResult> DeleteAccountBalanceDetail([FromRoute]int id)
        {
            if (id == 0)
                return BadRequest();

            var accountBalanceDetail = await _accountBalanceDetailService.GetAccountBalanceDetailById(id);

            if (accountBalanceDetail == null)
                return NotFound();

            await _accountBalanceDetailService.DeleteAccountBalanceDetail(accountBalanceDetail);

            return NoContent();
        }

        [HttpGet]
        [Route("getAllAccountBalanceDetailsForAccountDetailId/{AccountDetailId}")]
        public async Task<ActionResult<IEnumerable<AccountBalanceDetail>>> GetAllWithAccountBalanceDetailByAccountDetailId(int AccountDetailId)
        {
            var accountBalanceDetails = await _accountBalanceDetailService.GetAllWithAccountBalanceDetailByAccountDetailId(AccountDetailId);
            var accountBalanceDetailResources = _mapper.Map<IEnumerable<AccountBalanceDetail>, IEnumerable<AccountBalanceDetailResource>>(accountBalanceDetails);

            return Ok(accountBalanceDetailResources);
        }

        [HttpGet]
        [Route("getAllAccountBalanceDetailsForSabhaId/{SabhaId}")]
        public async Task<ActionResult<IEnumerable<AccountBalanceDetail>>> GetAllWithAccountBalanceDetailBySabhaId([FromRoute] int SabhaId)
        {
            var accountBalanceDetails = await _accountBalanceDetailService.GetAllWithAccountBalanceDetailBySabhaId(SabhaId);
            var accountBalanceDetailResources = _mapper.Map<IEnumerable<AccountBalanceDetail>, IEnumerable<AccountBalanceDetailResource>>(accountBalanceDetails);

            return Ok(accountBalanceDetailResources);
        }

        [HttpGet]
        [Route("getAllWithAccountBalanceDetailByAccountId/{AccountId}")]
        public async Task<ActionResult<IEnumerable<AccountBalanceDetail>>> GetAllWithAccountBalanceDetailByAccountId([FromRoute] int AccountId)
        {
            var accountBalanceDetails = await _accountBalanceDetailService.GetAllWithAccountBalanceDetailByAccountId(AccountId);
            var accountBalanceDetailResources = _mapper.Map<IEnumerable<AccountBalanceDetail>, IEnumerable<AccountBalanceDetailResource>>(accountBalanceDetails);

            return Ok(accountBalanceDetailResources);
        }

        
        [HttpGet]
        [Route("getAllAccountBalanceDetailsForAccountDetailIdandSabhaId/{AccountDetailId}/{SabhaId}")]
        public async Task<ActionResult<IEnumerable<AccountBalanceDetail>>> GetAllWithAccountBalanceDetailByAccountDetailIdSabhaId([FromRoute]int AccountDetailId, [FromRoute]int SabhaId)
        {
            var accountBalanceDetails = await _accountBalanceDetailService.GetAllWithAccountBalanceDetailByAccountDetailIdSabhaId(AccountDetailId,SabhaId);
            var accountBalanceDetailResources = _mapper.Map<IEnumerable<AccountBalanceDetail>, IEnumerable<AccountBalanceDetailResource>>(accountBalanceDetails);

            return Ok(accountBalanceDetailResources);
        }

    }
}
