using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.Data.DTOs;
using StudentRegistration.Data.Interfaces;
using StudentRegistration.Data.Models;

namespace StudentRegistration.Data.DAL
{
    public class StudentDAL : IStudentsRepository
    {
        private readonly StudentRegistrationContext _dbContext;

        public StudentDAL(StudentRegistrationContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Student>> GetStudents(int actualPage, int recordsQuantity, string firstName, string lastName, string documentNumber)
        {
            return await _dbContext.Students.OrderBy(x => x.IdStudents)
                                            .Where(w =>
                                                   w.FirstName.Contains(firstName) ||
                                                   w.LastName.Contains(lastName) ||
                                                   w.DocumentNumber.Contains(documentNumber)
                                            )
                                            .Skip(actualPage)
                                            .Take(recordsQuantity)
                                            .ToListAsync();
        }

        public async Task<Student> GetStudentsId(Guid id)
        {
            Student response = await _dbContext.Students.FirstOrDefaultAsync(f => f.IdStudents == id) ?? new Student();

            return response;
        }

        public async Task<IEnumerable<SubjectsByStudentDTO>> GetSubjectsByStudent(Guid id)
        {
            return (IEnumerable<SubjectsByStudentDTO>) await _dbContext.SubjectStudents
                                                                       .Where(w => w.IdStudents == id)
                                                                       .ToListAsync();
        }
    }
}
