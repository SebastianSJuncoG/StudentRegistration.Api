using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.Data.DTOs;
using StudentRegistration.Data.Interfaces;
using StudentRegistration.Data.Models;
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

        public async Task<UsersDTO> GetUserId(Guid Id)
        {
            return await _dbContext.UsersLogins.Select(s => new UsersDTO
            {
                Id = s.IdUsers,
                UserName = s.UserName,
                CreationDate = s.CreationDate,
                UpdateDate = s.UpdateDate,
                BlockingAttempts = s.BlockingAttempts,
                DateLastLogin = s.DateLastLogin,
                Active = s.Active
            }).FirstOrDefaultAsync(f => f.Id == Id) ?? new UsersDTO();
        }

        public async Task<UserLoginDTO> LogIn(string UserName, string Password)
        {
            var usernameParam = new SqlParameter("@Username", UserName);
            var passwordParam = new SqlParameter("@Password", Password);

            var resultSP = await _dbContext.Set<UserLoginDTO>()
                                    .FromSqlRaw("EXEC SP_User_Login @Username, @Password",
                                        usernameParam, passwordParam)
                                    .FirstOrDefaultAsync();

            var userLoginDto = new UserLoginDTO
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
            return userLoginDto;
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
