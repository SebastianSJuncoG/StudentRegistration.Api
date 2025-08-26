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
    public class ProgramDAL : IProgramRepository
    {
        private readonly StudentRegistrationContext _dbContext;

        public ProgramDAL(StudentRegistrationContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Program>> GetPrograms()
        {
            return await _dbContext.Programs.ToListAsync() ?? new List<Program>();
        }

        public async Task<Program> GetProgramId(int Id)
        {
            return await _dbContext.Programs.FirstOrDefaultAsync(f => f.IdProgram == Id) ?? new Program();
        }
    }
}
