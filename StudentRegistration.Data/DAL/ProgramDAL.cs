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
            try
            {
                return await _dbContext.Programs.ToListAsync() ?? new List<Program>();
            }
            catch (Exception ex)
            {
                return new List<Program>();
            }
        }

        public async Task<Program> GetProgramId(int Id)
        {
            try
            {
                return await _dbContext.Programs.FirstOrDefaultAsync(f => f.IdProgram == Id) ?? new Program();
            }
            catch (Exception ex)
            {
                return new Program();
            }
        }

        public async Task<Program> GetProgramByName(string programName)
        {
            try
            {
                return await _dbContext.Programs.FirstOrDefaultAsync(f => f.ProgramName == programName) ?? new Program();
            }
            catch (Exception ex)
            {
                return new Program();
            }
            
        }

        public async Task<bool> AddProgram(Program program)
        {
            try
            {
                _dbContext.Programs.Add(program);

                int result = await _dbContext.SaveChangesAsync();

                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateProgram(Program program)
        {
            try
            {
                _dbContext.Entry(program).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProgram(int id)
        {
            try
            {
                var program = await _dbContext.Programs.FindAsync(id);

                if (program != null)
                {
                    _dbContext.Programs.Remove(program);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}
