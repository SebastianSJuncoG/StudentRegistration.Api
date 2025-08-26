using Microsoft.EntityFrameworkCore;
using StudentRegistration.Data.DTOs;
using StudentRegistration.Data.Interfaces;
using StudentRegistration.Data.Models;
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

        public async Task<IEnumerable<Teacher>> GetTeachers(int actualPage, int recordsQuantity, string firstName, string lastName, string documentNumber)
        {
            return await _dbContext.Teachers.OrderBy(x => x.IdTeacher)
                                            .Where(w =>
                                                   w.FirstName.Contains(firstName) ||
                                                   w.LastName.Contains(lastName) ||
                                                   w.DocumentNumber.Contains(documentNumber)
                                            )
                                            .Skip(actualPage)
                                            .Take(recordsQuantity)
                                            .ToListAsync();
        }

        public async Task<Teacher> GetTeachersId(Guid id)
        {
            Teacher response = await _dbContext.Teachers.FirstOrDefaultAsync(f => f.IdTeacher == id) ?? new Teacher();

            return response;
        }

        public async Task<IEnumerable<SubjectsByTeacherDTO>> GetSubjectsByTeacher(Guid id)
        {
            return (IEnumerable<SubjectsByTeacherDTO>)await _dbContext.SubjectTeachers
                                                                      .Where(w => w.IdTeacher == id)
                                                                      .ToListAsync();
        }
    }
}
