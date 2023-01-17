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
    [Route("api/vote/AccountDetails")]
    [ApiController]
    public class AccountDetailsController : BaseController
    {
        private readonly IAccountDetailService _accountDetailService;
        private readonly IMapper _mapper;

        public AccountDetailsController(IAccountDetailService accountDetailService, IMapper mapper)
        {
            this._mapper = mapper;
            this._accountDetailService = accountDetailService;
        }

        [HttpGet("getAllAccountDetails")]
        public async Task<ActionResult<IEnumerable<AccountDetail>>> GetAllAccountDetails()
        {
            var accountDetails = await _accountDetailService.GetAllAccountDetails();
            var accountDetailResources = _mapper.Map<IEnumerable<AccountDetail>, IEnumerable<AccountDetailResource>>(accountDetails);

            return Ok(accountDetailResources);
        }

        [HttpGet]
        [Route("GetAccountDetailById/{id}")]
        public async Task<ActionResult<AccountDetailResource>> GetAccountDetailById([FromRoute] int id)
        {
            var accountDetail = await _accountDetailService.GetAccountDetailById(id);
            var accountDetailResource = _mapper.Map<AccountDetail, AccountDetailResource>(accountDetail);
            return Ok(accountDetailResource);
        }

        [HttpPost("saveAccountDetail")]
        public async Task<ActionResult<AccountDetailResource>> CreateAccountDetail([FromBody] SaveAccountDetailResource saveAccountDetailResource)
        {
            var validator = new SaveAccountDetailResourceValidator();
            var validationResult = await validator.ValidateAsync(saveAccountDetailResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var accountDetailToCreate = _mapper.Map<SaveAccountDetailResource, AccountDetail>(saveAccountDetailResource);

            var newAccountDetail = await _accountDetailService.CreateAccountDetail(accountDetailToCreate);

            var accountDetail = await _accountDetailService.GetAccountDetailById(newAccountDetail.ID);

            var accountDetailResource = _mapper.Map<AccountDetail, AccountDetailResource>(accountDetail);

            return Ok(accountDetailResource);
        }

        [HttpPost("updateAccountDetail")]
        public async Task<ActionResult<AccountDetailResource>> UpdateAccountDetail(SaveAccountDetailResource saveAccountDetailResource)
        {
            var validator = new SaveAccountDetailResourceValidator();
            var validationResult = await validator.ValidateAsync(saveAccountDetailResource);

            var requestIsInvalid = saveAccountDetailResource.ID == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var accountDetailToBeUpdate = await _accountDetailService.GetAccountDetailById(saveAccountDetailResource.ID);

            if (accountDetailToBeUpdate == null)
                return NotFound();

            var product = _mapper.Map<SaveAccountDetailResource, AccountDetail>(saveAccountDetailResource);

            await _accountDetailService.UpdateAccountDetail(accountDetailToBeUpdate, product);

            var updatedAccountDetail = await _accountDetailService.GetAccountDetailById(saveAccountDetailResource.ID);
            var updatedAccountDetailResource = _mapper.Map<AccountDetail, AccountDetailResource>(updatedAccountDetail);

            return Ok(updatedAccountDetailResource);
        }

        [HttpPost]
        [Route("deleteAccountDetail/{id}")]
        public async Task<IActionResult> DeleteAccountDetail(int id)
        {
            if (id == 0)
                return BadRequest();

            var accountDetail = await _accountDetailService.GetAccountDetailById(id);

            if (accountDetail == null)
                return NotFound();

            await _accountDetailService.DeleteAccountDetail(accountDetail);

            return NoContent();
        }

        [HttpGet("getAllAccountDetailsForBankId")]
        public async Task<ActionResult<IEnumerable<AccountDetail>>> GetAllWithAccountDetailByBankId(int id)
        {
            var accountDetails = await _accountDetailService.GetAllWithAccountDetailByBankId(id);
            var accountDetailResources = _mapper.Map<IEnumerable<AccountDetail>, IEnumerable<AccountDetailResource>>(accountDetails);

            return Ok(accountDetailResources);
        }

        [HttpGet]
        [Route("getAllAccountDetailsForOfficeId/{id}/")]
        public async Task<ActionResult<IEnumerable<AccountDetail>>> GetAllAccountDetailByOfficeId([FromRoute] int id)
        {
            var accountDetails = await _accountDetailService.GetAllAccountDetailByOfficeId(id);
            var accountDetailResources = _mapper.Map<IEnumerable<AccountDetail>, IEnumerable<AccountDetailResource>>(accountDetails);

            return Ok(accountDetailResources);
        }

        [HttpGet]
        [Route("getAllAccountDetailsForBankIdandOfficeId/{BankId}/{OfficeId}")]
        public async Task<ActionResult<IEnumerable<AccountDetail>>> GetAllWithAccountDetailByBankIdandOfficeId([FromRoute] int BankId, [FromRoute] int OfficeId)
        {
            var accountDetails = await _accountDetailService.GetAllWithAccountDetailByBankIdandOfficeId(BankId,OfficeId);
            var accountDetailResources = _mapper.Map<IEnumerable<AccountDetail>, IEnumerable<AccountDetailResource>>(accountDetails);

            return Ok(accountDetailResources);
        }
    }
}
