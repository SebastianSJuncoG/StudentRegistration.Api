using Microsoft.EntityFrameworkCore;
using StudentRegistration.Data.Interfaces;
using StudentRegistration.Data.Models;
using StudentRegistration.Data.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentRegistration.Data.DAL
{
    public class TeacherDAL : ITeacherRepository
    {
        private readonly StudentRegistrationContext _dbContext;

        public TeacherDAL(StudentRegistrationContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Teacher>> GetTeachers(int actualPage, int recordsQuantity)
        {
            return await _dbContext.Teachers.OrderBy(x => x.IdTeacher)
                                            .Skip(actualPage)
                                            .Take(recordsQuantity)
                                            .ToListAsync() ?? new List<Teacher>();
        }

        public async Task<Teacher> GetTeachersId(Guid id)
        {
            Teacher response = await _dbContext.Teachers.FirstOrDefaultAsync(f => f.IdTeacher == id) ?? new Teacher();

            return response;
        }

        public async Task<IEnumerable<SubjectByTeacherResponse>> GetSubjectsByTeacher(Guid id)
        {
            return (IEnumerable<SubjectByTeacherResponse>)await _dbContext.SubjectTeachers
                                                                      .Where(w => w.IdTeacher == id)
                                                                      .ToListAsync();
        }
    }
}
