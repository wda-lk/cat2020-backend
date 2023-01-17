using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CAT20.Api.Validators;
using CAT20.Core.Models.User;
using CAT20.Core.Services.User;
using CAT20.WebApi.Resources.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using CAT20.Data;
using Microsoft.EntityFrameworkCore;
using CAT20.Services.User;
using CAT20.WebApi.Resources.User.Save;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using CAT20.Core.Models.Control;
using CAT20.WebApi.Resources.Control;
using CAT20.Core.Services.Control;
using CAT20.Services.Control;

namespace CAT20.WebApi.Controllers
{
    [Route("api/auth/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IUserDetailService _userDetailService;
        private readonly ISabhaService _sabhaService;
        private readonly IDistrictService _districtService;
        private readonly IProvinceService _provinceService;
        private readonly ISelectedLanguageService _selectedLanguageService;
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public AuthController(IUserDetailService userDetailService, IMapper mapper, IConfiguration config, ISabhaService sabhaService, IDistrictService districtService, IProvinceService provinceService, ISelectedLanguageService selectedLanguageService, ILanguageService languageService)
        {
            _mapper = mapper;
            _userDetailService = userDetailService;
            _configuration = config;
            _sabhaService = sabhaService;
            _districtService = districtService;
            _provinceService = provinceService;
            _selectedLanguageService = selectedLanguageService;
            _languageService = languageService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(LoginResource _loginData)
        {
            if (_loginData != null && _loginData.Username != null && _loginData.Password != null)
            {
                var userDetailForLogin = await _userDetailService.Authenticate(_loginData.Username, _loginData.Password);
                var user = _mapper.Map<UserDetail, UserDetailResource>(userDetailForLogin);

                if (user != null)
                {
                    var sabhainfo = await _sabhaService.GetSabhaById(user.SabhaID.Value);
                    var sabha = _mapper.Map<Sabha, SabhaResource>(sabhainfo);

                    var districtinfo = await _districtService.GetDistrictById(sabha.DistrictID.Value);
                    var district = _mapper.Map<District, DistrictResource>(districtinfo);

                    var provinceinfo = await _provinceService.GetProvinceById(district.ProvinceID);
                    var province = _mapper.Map<Province, ProvinceResource>(provinceinfo);

                    var selectedlanguage = await _selectedLanguageService.GetSelectedLanguageforSabhaId(user.SabhaID.Value);
                    var sellanguage = _mapper.Map<SelectedLanguage, SelectedLanguageResource>(selectedlanguage);

                    var language = await _languageService.GetLanguageById(sellanguage.LanguageId.Value);
                    var lang = _mapper.Map<Language, LanguageResource>(language);


                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("SabhaID", user.SabhaID.ToString()),
                        new Claim("OfficeID", user.OfficeID.ToString()),
                        new Claim("UserID", user.ID.ToString()),
                        new Claim("NameWithInitials", user.NameWithInitials),
                        new Claim("UserName", user.Username)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(60),
                        signingCredentials: signIn);

                    //return Ok(new
                    //{
                    //    token = new JwtSecurityTokenHandler().WriteToken(token),
                    //    expiration = token.ValidTo,
                    //    userid = user.ID,
                    //    username = user.Username,
                    //    sabhaId = user.SabhaID,
                    //    officeID = user.OfficeID,
                    //    sabhaName = sabha.NameEnglish

                    //});

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo,
                        userid = user.ID,
                        username = user.Username,
                        namewithinitials = user.NameWithInitials,
                        sabhaId = user.SabhaID,
                        sabhaLogoPath = sabha.LogoPath,
                        sabhaCode = sabha.Code,
                        officeID = user.OfficeID,
                        sabhaName = sabha.NameEnglish,
                        districtName = district.NameEnglish,
                        provinceName = province.NameEnglish,
                        languageid = lang.ID,
                        language = lang.Description,
                    });

                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }


        //[HttpPost]
        //public async Task<IActionResult> Post(UserDetailResource _userData)
        //{
        //    if (_userData != null && _userData.Username != null && _userData.Password != null)
        //    {
        //        var userDetail = _mapper.Map<UserDetailResource, UserDetail>(_userData);
        //        var userDetailForLogin = await _userDetailService.GetUserDetailByUsernamePassword(userDetail);
        //        var user = _mapper.Map<UserDetail, UserDetailResource>(userDetailForLogin);

        //        if (user != null)
        //        {
        //            //create claims details based on the user information
        //            var claims = new[] {
        //                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
        //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        //                new Claim("SabhaID", user.SabhaID.ToString()),
        //                new Claim("OfficeID", user.OfficeID.ToString()),
        //                new Claim("UserID", user.ID.ToString()),
        //                new Claim("NameWithInitials", user.NameWithInitials),
        //                new Claim("UserName", user.Username)
        //            };

        //            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //            var token = new JwtSecurityToken(
        //                _configuration["Jwt:Issuer"],
        //                _configuration["Jwt:Audience"],
        //                claims,
        //                expires: DateTime.UtcNow.AddMinutes(10),
        //                signingCredentials: signIn);

        //            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        //        }
        //        else
        //        {
        //            return BadRequest("Invalid credentials");
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
