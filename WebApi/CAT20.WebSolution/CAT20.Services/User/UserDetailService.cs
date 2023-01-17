using CAT20.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAT20.Core.Models.User;
using CAT20.Core.Services.User;
using CAT20.Core.Models.Enums;
using CAT20.Core.Models.Interfaces;
using System.Globalization;

namespace CAT20.Services.User
{
    public class UserDetailService : IUserDetailService
    {
        private readonly IUserUnitOfWork _unitOfWork;
        public UserDetailService(IUserUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UserDetail> CreateUserDetail(UserDetail newUserDetail)
        {
            try
            {
                await _unitOfWork.UserDetails.AddAsync(newUserDetail);
                await _unitOfWork.CommitAsync();

                #region AuditLog

                var _sb = new StringBuilder();
                _sb.Append("Created on " + DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
                _sb.Append(" by System");

                await _unitOfWork.AuditLogs.AddAsync(new AuditLogUser
                {
                    Transaction = Transaction.User,
                    SourceID = newUserDetail.ID,
                    RecordDateTime = DateTime.Now,
                    Notes = _sb.ToString(),
                    UserID = newUserDetail.ID,
                });
                await _unitOfWork.CommitAsync();

                #endregion

            }
            catch (Exception e)
            {
                var exception = e.Message;
            }

            return newUserDetail;
        }
        public async Task DeleteUserDetail(UserDetail userDetail)
        {
            _unitOfWork.UserDetails.Remove(userDetail);
            await _unitOfWork.CommitAsync();

            #region AuditLog

            var _sb = new StringBuilder();
            _sb.Append("Deleted on " + DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            _sb.Append(" by System");

            await _unitOfWork.AuditLogs.AddAsync(new AuditLogUser
            {
                Transaction = Transaction.User,
                SourceID = userDetail.ID,
                //User = UserDetail,
                RecordDateTime = DateTime.Now,
                Notes = _sb.ToString(),
                UserID = userDetail.ID,
            });
            await _unitOfWork.CommitAsync();

            #endregion

        }
        public async Task<IEnumerable<UserDetail>> GetAllUserDetails()
        {
            return await _unitOfWork.UserDetails.GetAllAsync();
        }
        public async Task<UserDetail> GetUserDetailById(int id)
        {
            return await _unitOfWork.UserDetails.GetByIdAsync(id);
        }
        public async Task<UserDetail> GetUserDetailByUsernamePassword(UserDetail userDetail)
        {
            return await _unitOfWork.UserDetails.GetWithUserDetailByUsernamePasswordAsync(userDetail);
        }

        public async Task UpdateUserDetail(UserDetail userDetailToBeUpdated, UserDetail userDetail)
        {
            userDetailToBeUpdated.NameInFull = userDetail.NameInFull;
            userDetailToBeUpdated.NameWithInitials = userDetail.NameWithInitials;
            userDetailToBeUpdated.Password = userDetail.Password;
            userDetailToBeUpdated.NIC = userDetail.NIC;
            userDetailToBeUpdated.Birthday = userDetail.Birthday;
            userDetailToBeUpdated.GenderID = userDetail.GenderID;
            userDetailToBeUpdated.ProfilePicPath = userDetail.ProfilePicPath;
            userDetailToBeUpdated.Q1Id = userDetail.Q1Id;
            userDetailToBeUpdated.Answer1 = userDetail.Answer1;
            userDetailToBeUpdated.Q2Id = userDetail.Q2Id;
            userDetailToBeUpdated.Answer2 = userDetail.Answer2;

            await _unitOfWork.CommitAsync();
        }

        public async Task<UserDetail> Authenticate(string username, string password)
        {

            return await _unitOfWork.UserDetails.Authenticate(username, password);
        }

        public async Task<IEnumerable<UserDetail>> GetAllUserDetailsForSabhaId(int id)
        {
            return await _unitOfWork.UserDetails.GetAllUserDetailsForSabhaIdAsync(id);
        }
        public async Task<IEnumerable<UserDetail>> GetAllUserDetailsForOfficeId(int id)
        {
            return await _unitOfWork.UserDetails.GetAllUserDetailsForOfficeIdAsync(id);
        }

        public async Task<IEnumerable<UserDetail>> GetAllUserDetailsForSabhaIdandOfficeId(int SabhaId, int OfficeId)
        {
            return await _unitOfWork.UserDetails.GetAllUserDetailsForSabhaIdandOfficeIdAsync(SabhaId, OfficeId);
        }
    }
}