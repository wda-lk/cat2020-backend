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
    public class SelectedLanguagesController : BaseController
    {
        private readonly ISelectedLanguageService _selectedLanguageService;
        private readonly IMapper _mapper;

        public SelectedLanguagesController(ISelectedLanguageService selectedLanguageService, IMapper mapper)
        {
            this._mapper = mapper;
            this._selectedLanguageService = selectedLanguageService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<SelectedLanguage>>> GetAllProducts()
        {
            var selectedLanguages = await _selectedLanguageService.GetAllSelectedLanguages();
            var selectedLanguageResources = _mapper.Map<IEnumerable<SelectedLanguage>, IEnumerable<SelectedLanguageResource>>(selectedLanguages);

            return Ok(selectedLanguageResources);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SelectedLanguageResource>> GetSelectedLanguageById(int id)
        {
            var selectedLanguage = await _selectedLanguageService.GetSelectedLanguageById(id);
            var selectedLanguageResource = _mapper.Map<SelectedLanguage, SelectedLanguageResource>(selectedLanguage);
            return Ok(selectedLanguageResource);
        }

        //[HttpPost("")]
        //public async Task<ActionResult<SelectedLanguageResource>> CreateSelectedLanguage([FromBody] SaveSelectedLanguageResource saveSelectedLanguageResource)
        //{
        //    var validator = new SaveSelectedLanguageResourceValidator();
        //    var validationResult = await validator.ValidateAsync(saveSelectedLanguageResource);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

        //    var selectedLanguageToCreate = _mapper.Map<SaveSelectedLanguageResource, SelectedLanguage>(saveSelectedLanguageResource);

        //    var newSelectedLanguage = await _selectedLanguageService.CreateSelectedLanguage(selectedLanguageToCreate);

        //    var selectedLanguage = await _selectedLanguageService.GetSelectedLanguageById(newSelectedLanguage.ID);

        //    var selectedLanguageResource = _mapper.Map<SelectedLanguage, SelectedLanguageResource>(selectedLanguage);

        //    return Ok(selectedLanguageResource);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<SelectedLanguageResource>> UpdateProduct(int id, [FromBody] SaveSelectedLanguageResource saveSelectedLanguageResource)
        //{
        //    var validator = new SaveSelectedLanguageResourceValidator();
        //    var validationResult = await validator.ValidateAsync(saveSelectedLanguageResource);

        //    var requestIsInvalid = id == 0 || !validationResult.IsValid;

        //    if (requestIsInvalid)
        //        return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

        //    var selectedLanguageToBeUpdate = await _selectedLanguageService.GetSelectedLanguageById(id);

        //    if (selectedLanguageToBeUpdate == null)
        //        return NotFound();

        //    var product = _mapper.Map<SaveSelectedLanguageResource, SelectedLanguage>(saveSelectedLanguageResource);

        //    await _selectedLanguageService.UpdateSelectedLanguage(selectedLanguageToBeUpdate, product);

        //    var updatedSelectedLanguage = await _selectedLanguageService.GetSelectedLanguageById(id);
        //    var updatedSelectedLanguageResource = _mapper.Map<SelectedLanguage, SelectedLanguageResource>(updatedSelectedLanguage);

        //    return Ok(updatedSelectedLanguageResource);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct(int id)
        //{
        //    if (id == 0)
        //        return BadRequest();

        //    var selectedLanguage = await _selectedLanguageService.GetSelectedLanguageById(id);

        //    if (selectedLanguage == null)
        //        return NotFound();

        //    await _selectedLanguageService.DeleteSelectedLanguage(selectedLanguage);

        //    return NoContent();
        //}
    }
}