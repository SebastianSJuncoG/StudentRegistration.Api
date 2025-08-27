using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.Data.Interfaces;
using StudentRegistration.Data.Models;
using StudentRegistration.Data.Models.Responses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Data.DAL
{
    public class UserDAL : IUsersLoginRepository
    {
        private readonly StudentRegistrationContext _dbContext;

        public UserDAL(StudentRegistrationContext context)
        {
            _dbContext = context;
        }

        public async Task<UserResponse> GetUserId(Guid Id)
        {
            return await _dbContext.UsersLogins.Select(s => new UserResponse
            {
                Id = s.IdUsers,
                UserName = s.UserName,
                CreationDate = s.CreationDate,
                UpdateDate = s.UpdateDate,
                BlockingAttempts = s.BlockingAttempts,
                DateLastLogin = s.DateLastLogin,
                Active = s.Active
            }).FirstOrDefaultAsync(f => f.Id == Id) ?? new UserResponse();
        }

        public async Task<UsersLogin> GetUserByUserName(string userName)
        {
            try
            {
                return await _dbContext.UsersLogins.FirstOrDefaultAsync(f => f.UserName == userName) ?? new UsersLogin();
            }
            catch (Exception ex)
            {
                return new UsersLogin();
            }

        }

        public async Task<UserResponse> AddUser(UsersLogin user)
        {
            try
            {
                _dbContext.UsersLogins.Add(user);

                int result = await _dbContext.SaveChangesAsync();

                if (result > 0)
                {
                    var userResponse = new UserResponse
                    {
                        Id = user.IdUsers,
                        UserName = user.UserName,
                        CreationDate = user.CreationDate
                    };

                    return userResponse;
                }

                return new UserResponse();
            }
            catch (Exception ex)
            {
                return new UserResponse();
            }
        }

        public async Task<UserLoginResponse> LogIn(string UserName, string Password)
        {
            var usernameParam = new SqlParameter("@Username", UserName);
            var passwordParam = new SqlParameter("@Password", Password);

            var resultSP = await _dbContext.Set<UserLoginResponse>()
                                    .FromSqlRaw("EXEC SP_User_Login @Username, @Password",
                                        usernameParam, passwordParam)
                                    .FirstOrDefaultAsync();

            var userLoginResponse = new UserLoginResponse
            {
                Id_Users = resultSP.Id_Users,
                UserName = resultSP.UserName,
                CreationDate = resultSP.CreationDate,
                UpdateDate = resultSP.UpdateDate,
                BlockingAttempts = resultSP.BlockingAttempts,
                DateLastLogin = resultSP.DateLastLogin,
                Active = resultSP.Active,
                ResultMessage = resultSP.ResultMessage
            };

            // 2. Ejecuta la consulta de forma asíncrona y espera el resultado.
            return userLoginResponse;
        }

        public async Task<Boolean> LogOut(Guid Id)
        {
            try
            {
                var register = _dbContext.UsersLogins.FirstOrDefault(f => f.Equals(Id));

                if (register != null)
                {
                    register.LogOutDate = DateTime.Now;

                    _dbContext.Entry(register).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
