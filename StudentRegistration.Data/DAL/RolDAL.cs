using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.Data.Interfaces;
using StudentRegistration.Data.Models;


namespace StudentRegistration.Data.DAL
{
    public class RolDAL : IRolRepository
    {
        private readonly StudentRegistrationContext _dbContext;

        public RolDAL(StudentRegistrationContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Rol>> GetRoles()
        {
            return await _dbContext.Rols.ToListAsync() ?? new List<Rol>();
        }

        public async Task<Rol> GetRolId(int Id)
        {
            return await _dbContext.Rols.FirstOrDefaultAsync(f => f.IdRol == Id) ?? new Rol();
        }
    }
}
