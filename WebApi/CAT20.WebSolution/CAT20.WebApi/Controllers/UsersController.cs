using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CAT20.Api.Validators;
using CAT20.Core.Models.User;
using CAT20.Core.Services.User;
using CAT20.WebApi.Resources.User;
using CAT20.WebApi.Resources.User.Save;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using CAT20.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using CAT20.Core.Services.Control;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using CAT20.WebApi.Email;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using CAT20.WebApi.Controllers;

namespace CAT20.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IUserDetailService _userDetailService;
        private readonly IMapper _mapper;
        public IConfiguration _configuration;
        private readonly IEmailOutBoxService _emailOutBoxService;
        private readonly IEmailConfigurationService _emailConfigurationService;

        public UsersController(IUserDetailService userDetailService, IMapper mapper, IConfiguration config, IEmailOutBoxService emailOutBoxService, IEmailConfigurationService emailConfigurationService)
        {
            this._mapper = mapper;
            this._userDetailService = userDetailService;
            this._configuration = config;
            this._emailOutBoxService = emailOutBoxService;
            this._emailConfigurationService = emailConfigurationService;
        }

        [HttpGet]
        [Route("getAllUsers/{sabahaID}")]
        public async Task<ActionResult<IEnumerable<UserDetail>>> GetAllUserDetailsForSabhaId([FromRoute] int sabahaID)
        {
            var userDetails = await _userDetailService.GetAllUserDetailsForSabhaId(sabahaID);
            var userDetailResources = _mapper.Map<IEnumerable<UserDetail>, IEnumerable<UserDetailResource>>(userDetails);

            return Ok(userDetailResources);
        }


        [HttpGet]
        [Route("getUserById/{id}")]
        public async Task<ActionResult<UserDetailResource>> GetUserDetailById([FromRoute] int id)
        {
            var userDetail = await _userDetailService.GetUserDetailById(id);
            var userDetailResource = _mapper.Map<UserDetail, UserDetailResource>(userDetail);
            return Ok(userDetailResource);
        }



        //[HttpPut("")]
        //public async Task<ActionResult<UserDetailResource>> GetUserDetailByUsernamePassword(UserDetailResource saveUserDetailResource)
        //{
        //    var userDetail = _mapper.Map< UserDetailResource, UserDetail>(saveUserDetailResource);
        //    var userDetailForsave = await _userDetailService.GetUserDetailByUsernamePassword(userDetail);
        //    var userDetailResource = _mapper.Map<UserDetail, UserDetailResource>(userDetailForsave);
        //    return Ok(userDetailResource);
        //}

        //[HttpPost("")]
        //public async Task<ActionResult<UserDetailResource>> GetToken(UserDetailResource _userData)
        //{
        //    if (_userData != null && _userData.Username != null && _userData.Password != null)
        //    {
        //        var userDetail = _mapper.Map<UserDetailResource, UserDetail>(_userData);
        //        var userDetailForsave = await _userDetailService.GetUserDetailByUsernamePassword(userDetail);
        //        var userDetailResource = _mapper.Map<UserDetail, UserDetailResource>(userDetailForsave);

        //        if (userDetailResource != null)
        //        {
        //            //create claims details based on the user information
        //            var claims = new[] {
        //                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
        //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        //                //new Claim("SabhaID", userDetailResource.SabhaID.ToString()),
        //                //new Claim("OfficeID", userDetailResource.OfficeID.ToString()),
        //                new Claim("UserID", userDetailResource.ID.ToString()),
        //                new Claim("NameWithInitials", userDetailResource.NameWithInitials),
        //                new Claim("UserName", userDetailResource.Username)
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


        [HttpPost("saveUser")]
        public async Task<ActionResult<UserDetailResource>> CreateUserDetail([FromBody] SaveUserDetailResource saveUserDetailResource)
        {
            var validator = new SaveUserDetailResourceValidator();
            var validationResult = await validator.ValidateAsync(saveUserDetailResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            if (saveUserDetailResource.Password == string.Empty)
                saveUserDetailResource.Password = RandomPassword(saveUserDetailResource.Username);

            CryptoProvider crypto = new CryptoProvider();

            var userDetailToCreate = _mapper.Map<SaveUserDetailResource, UserDetail>(saveUserDetailResource);
            userDetailToCreate.Password = crypto.GetHash(saveUserDetailResource.Password.Trim());

            var newUserDetail = await _userDetailService.CreateUserDetail(userDetailToCreate);

            var userDetail = await _userDetailService.GetUserDetailById(newUserDetail.ID);

            var userDetailResource = _mapper.Map<UserDetail, UserDetailResource>(userDetail);

            #region Create Email Record
            if (userDetail != null)
            {
                try
                {
                    var emailSettings = await _emailConfigurationService.GetEmailConfigurationById(1);
                    await _emailOutBoxService.CreateEmailOutBox(new Core.Models.Control.EmailOutBox
                    {
                        Attachment = string.Empty,
                        Bc = string.Empty,
                        Cc = string.Empty,
                        CreatedByID = newUserDetail.ID,
                        EmailSendAttempts = 0,
                        EmailStatus = Core.Models.Enums.EmailStatus.Pending,
                        IsBodyHtml = true,
                        MailContent = createUserMailBody(userDetail.Username, saveUserDetailResource.Password, emailSettings.SystemURL),
                        Note = string.Empty,
                        Recipient = userDetail.Username,
                        Subject = "New User Account"
                    });
                }
                catch (Exception e)
                {
                }

            }
            #endregion
            EmailService email = new EmailService(_emailConfigurationService, _emailOutBoxService);
            await email.sendMail();

            return Ok(userDetailResource);
        }

        [HttpPost("updateUser")]
        public async Task<ActionResult<UserDetailResource>> UpdateProduct([FromBody] SaveUserDetailResource saveUserDetailResource)
        {
            var validator = new SaveUserDetailResourceValidator();
            var validationResult = await validator.ValidateAsync(saveUserDetailResource);

            var requestIsInvalid = saveUserDetailResource.ID == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var userDetailToBeUpdate = await _userDetailService.GetUserDetailById(saveUserDetailResource.ID);

            if (userDetailToBeUpdate == null)
                return NotFound();

            var product = _mapper.Map<SaveUserDetailResource, UserDetail>(saveUserDetailResource);

            await _userDetailService.UpdateUserDetail(userDetailToBeUpdate, product);

            var updatedUserDetail = await _userDetailService.GetUserDetailById(saveUserDetailResource.ID);
            var updatedUserDetailResource = _mapper.Map<UserDetail, UserDetailResource>(updatedUserDetail);

            return Ok(updatedUserDetailResource);
        }

        [HttpDelete("deleteUser")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == 0)
                return BadRequest();

            var userDetail = await _userDetailService.GetUserDetailById(id);

            if (userDetail == null)
                return NotFound();

            await _userDetailService.DeleteUserDetail(userDetail);

            return NoContent();
        }

        private string createUserMailBody(string userName, string password, string url)
        {
            var _sb = new StringBuilder();

            _sb.Append("<!DOCTYPE html> ");
            _sb.Append("<html>");
            _sb.Append("<head> ");
            _sb.Append("<title></title> ");
            _sb.Append("<meta charset = 'utf-8' /> ");
            _sb.Append("<style type='text/css'> ");
            _sb.Append(".outer_table { ");
            _sb.Append("    border-bottom: #58d0da solid 1px;");
            _sb.Append("    border-left: #58d0da solid 1px;  ");
            _sb.Append("    border-right: #58d0da solid 1px; ");
            _sb.Append("} ");
            _sb.Append("  ");
            _sb.Append(".outer_table_td { ");
            _sb.Append("    background-color: #c0edf1; ");
            _sb.Append("    height: 40px;              ");
            _sb.Append("    font-family: Tahoma;       ");
            _sb.Append("    font-size: 14px;           ");
            _sb.Append("    font-size-adjust: none;    ");
            _sb.Append("    font-weight: bold;         ");
            _sb.Append("}");
            _sb.Append(" ");
            _sb.Append(".txt_normal { ");
            _sb.Append("    font-family: Tahoma; ");
            _sb.Append("    font-size: 11px; ");
            _sb.Append("    font-size-adjust: none; ");
            _sb.Append("    color: #585858; ");
            _sb.Append("    height: 18px; ");
            _sb.Append("} ");
            _sb.Append(" ");
            _sb.Append(".inner_table_td_green { ");
            _sb.Append("    background-color: #cee6e8; ");
            _sb.Append("    font-family: Tahoma; ");
            _sb.Append("    font-size: 11px; ");
            _sb.Append("    color: #000000; ");
            _sb.Append("    height: 22px; ");
            _sb.Append("    text-indent: 5px; ");
            _sb.Append("} ");
            _sb.Append("");
            _sb.Append(" .inner_table_td_blue { ");
            _sb.Append("     background-color: #f3f3f3; ");
            _sb.Append("     font-family: Tahoma; ");
            _sb.Append("     font-size: 11px;");
            _sb.Append("     color: #045d86;");
            _sb.Append("     height: 22px;");
            _sb.Append("     text-indent: 10px; ");
            _sb.Append(" } ");
            _sb.Append("</style> ");
            _sb.Append(" </head> ");
            _sb.Append("<body> ");
            _sb.Append("<table border = '0' cellspacing='0' cellpadding='0' Class='outer_table'> ");
            _sb.Append("<tbody> ");
            _sb.Append("<tr> ");
            _sb.Append("<td Class='outer_table_td' style='background-color:#58d0da' width='5'>&nbsp;</td> ");
            _sb.Append("<td align='left' valign='middle' Class='outer_table_td' style='padding-left:10px'>");
            _sb.Append("    Notification - New User Account");
            _sb.Append("</td> ");
            _sb.Append("<td Class='outer_table_td' width='5'>&nbsp;</td> ");
            _sb.Append("</tr> ");
            _sb.Append("<tr> ");
            _sb.Append("    <td colspan='3' >&nbsp;</td> ");
            _sb.Append("</tr> ");
            _sb.Append("<tr> ");
            _sb.Append("<td>&nbsp;</td> ");
            _sb.Append("<td align='left' valign='top' style='padding-left:10px; padding-right:10px'> ");
            _sb.Append("    <Table width='100%' border='0' cellspacing='2' cellpadding='2'> ");
            _sb.Append("        <tbody> ");

            _sb.Append("<tr> ");
            _sb.Append("<td Class='txt_normal'> ");
            _sb.Append("                Dear &nbsp; User,<br> ");
            _sb.Append("                <br> ");
            _sb.Append("            </td> ");
            _sb.Append("        </tr> ");
            _sb.Append("        <tr> ");

            _sb.Append("<td Class='txt_normal'>");
            _sb.Append("");
            _sb.Append("                 Rensponse by Supervisor. ");
            _sb.Append("                <br> ");
            _sb.Append("    <br> ");
            _sb.Append("            </td> ");
            _sb.Append("        </tr> ");

            _sb.Append("    </tbody> ");
            _sb.Append("</table> ");
            _sb.Append("<Table width = '100%' border='0' cellspacing='2' cellpadding='2'> ");
            _sb.Append("    <tbody> ");
            _sb.Append("        <tr> ");
            _sb.Append("    <td Class='inner_table_td_green'>URL</td> ");
            _sb.Append("            <td Class='inner_table_td_blue'><a href='" + url + "'>Click Here to Access System</a></td> ");
            _sb.Append("        </tr> ");

            _sb.Append("        <tr> ");
            _sb.Append("            <td Class='inner_table_td_green'>User Name</td> ");
            _sb.Append("            <td Class='inner_table_td_blue'>" + userName + "</td> ");
            _sb.Append("        </tr> ");

            _sb.Append("        <tr> ");
            _sb.Append("                    <td Class='inner_table_td_green'>Password</td> ");
            _sb.Append("            <td Class='inner_table_td_blue'>" + password + "  </td> ");
            _sb.Append("        </tr> ");
            _sb.Append("            </tbody> ");
            _sb.Append("        </table> ");
            _sb.Append("        <Table width = '100%' border='0' cellspacing='2' cellpadding='2'> ");
            _sb.Append("            <tbody> ");
            _sb.Append("                                    <tr> ");
            _sb.Append("                                    <td>&nbsp;</td> ");
            _sb.Append("                </tr> ");
            _sb.Append("                <tr> ");
            _sb.Append("                                    <td Class='txt_normal'> ");
            _sb.Append("                        This Is an auto generated email sent to you from CAT20. Please do not reply to this email. ");
            _sb.Append("                    </td> ");
            _sb.Append("                </tr> ");
            _sb.Append("                <tr> ");
            _sb.Append("                                        <td Class='txt_normal'> ");
            _sb.Append("                        Regards,<br> ");
            _sb.Append("                        Leave Portal ");
            _sb.Append("                    </td> ");
            _sb.Append("                </tr> ");
            _sb.Append("            </tbody> ");
            _sb.Append("        </table> ");
            _sb.Append("    </td> ");
            _sb.Append("    <td align = 'left' valign='top'>&nbsp;</td> ");
            _sb.Append("</tr> ");
            _sb.Append("<tr> ");
            _sb.Append("                                            <td colspan = '3' >&nbsp;</td> ");
            _sb.Append("</tr> ");
            _sb.Append("</tbody> ");
            _sb.Append("</table> ");
            _sb.Append("</body> ");
            _sb.Append("</html> ");

            return _sb.ToString();
        }

        private string RandomPassword(string name)
        {
            var builder = new StringBuilder();
            try
            {
                char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

                builder.Append(name.Substring(1, 1).ToUpper());
                builder.Append(DateTime.Now.Second.ToString().Substring(1, 1));
                builder.Append(DateTime.Now.Day.ToString().Substring(0, 1));
                builder.Append(alpha[DateTime.Now.Hour]);
                builder.Append(name.Substring(name.Length - 2, 1).ToLower());
                builder.Append(DateTime.Now.Millisecond.ToString().Substring(0, 1));

            }
            catch (Exception e)
            {
                var message = e.Message;
            }
            return builder.ToString();
        }

        public class CryptoProvider
        {
            /// <summary>
            /// Provide Hash for the given text
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            private static int SALTLENGTHLIMIT = 32;
            public string GetHash(string text)
            {
                return this.ComputeHash(text);
            }

            /// <summary>
            /// Validate Hash
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public bool IsValidHash(string text)
            {
                string hash = this.ComputeHash(text);
                return hash == text ? true : false;
            }

            /// <summary>
            /// Compute Hash
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            private string ComputeHash(string value)
            {
                string hashKey = string.Empty;
                MD5 md5hash = MD5.Create();
                //Get the Hash data for the password
                byte[] hashdata = md5hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                //Store Byte in string
                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in hashdata)
                {
                    stringBuilder.Append(b);
                }

                hashKey = stringBuilder.ToString();
                return hashKey;
            }

            /// <summary>
            /// Generate Random Salt Value For Password
            /// </summary>
            /// <returns></returns>
            public static byte[] GetSalt()
            {
                return GetSalt(SALTLENGTHLIMIT);
            }
            /// <summary>
            /// Geneate Random Salt Based on Salt Length
            /// </summary>
            /// <param name="maximumSaltLength"></param>
            /// <returns></returns>
            private static byte[] GetSalt(int maximumSaltLength)
            {
                var salt = new byte[maximumSaltLength];
                using (var random = new RNGCryptoServiceProvider())
                {
                    random.GetNonZeroBytes(salt);
                }

                return salt;
            }

            public byte[] GenerateSaltedHash(byte[] plainPassword, byte[] salt)
            {
                return GenerateSaltedHash(plainPassword, salt, 0);
            }

            public byte[] GenerateSaltedHash(byte[] plainPassword, byte[] salt, int start)
            {
                HashAlgorithm algorithm = new SHA256Managed();

                byte[] plainTextWithSaltBytes =
                  new byte[plainPassword.Length + (salt.Length - (start))];

                for (int i = 0; i < plainPassword.Length; i++)
                {
                    plainTextWithSaltBytes[i] = plainPassword[i];
                }
                int inc = 1;
                for (int i = start + 1; i < salt.Length; i++)
                {
                    plainTextWithSaltBytes[plainPassword.Length + inc] = salt[i];
                    inc++;
                }

                return algorithm.ComputeHash(plainTextWithSaltBytes);
            }

            public string GenerateSaltedHashString(string plainPassword, string slat, int id)
            {
                try
                {
                    return Convert.ToBase64String(
                                       new CryptoProvider().GenerateSaltedHash(
                                           Encoding.UTF8.GetBytes(plainPassword), Convert.FromBase64String(slat), id % 3));
                }
                catch (Exception)
                {

                    return "";
                }

            }

            public static string Encrypt(string toEncrypt, bool useHashing)
            {
                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);


                string key = "CAT20";
                // Get the key from config file

                //System.Windows.Forms.MessageBox.Show(key);
                //If hashing use get hashcode regards to your key
                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    //Always release the resources and flush data
                    // of the Cryptographic service provide. Best Practice

                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                //Set the secret key for the tripleDES algorithm
                tdes.Key = keyArray;
                //Mode of operation. There are other 4 modes
                //We choose ECB(Electronic code Book)
                tdes.Mode = CipherMode.ECB;
                //Padding mode(If any extra byte added)

                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                //Transform the specified region of bytes array to resultArray
                byte[] resultArray =
                  cTransform.TransformFinalBlock(toEncryptArray, 0,
                  toEncryptArray.Length);
                //Release resources held by TripleDes Encryptor
                tdes.Clear();
                //Return the encrypted data into unreadable string format
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }

            public static string Decrypt(string cipherString, bool useHashing)
            {
                byte[] keyArray;
                //Get the byte code of the string

                byte[] toEncryptArray = Convert.FromBase64String(cipherString);

                string key = "CAT20";

                if (useHashing)
                {
                    //If hashing was used get the hash code with regards to your key
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    //release any resource held by the MD5CryptoServiceProvider

                    hashmd5.Clear();
                }
                else
                {
                    //If hashing was not implemented get the byte code of the key
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);
                }

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                //Set the secret key for the tripleDES algorithm
                tdes.Key = keyArray;
                //Mode of operation. There are other 4 modes 
                //We choose ECB(Electronic code Book)

                tdes.Mode = CipherMode.ECB;
                //Padding mode(if any extra byte added)
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(
                                     toEncryptArray, 0, toEncryptArray.Length);
                //Release resources held by TripleDes Encryptor                
                tdes.Clear();
                //Return the Clear decrypted TEXT
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
        }
    }
}
