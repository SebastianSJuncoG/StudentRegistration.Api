using Microsoft.EntityFrameworkCore;
using StudentRegistration.Data.Interfaces;
using StudentRegistration.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Data.DAL
{
    public class SubjectDAL : ISubjectRepository
    {
        private readonly StudentRegistrationContext _dbContext;

        public SubjectDAL(StudentRegistrationContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            return await _dbContext.Subjects.ToListAsync() ?? new List<Subject>();
        }

        public async Task<Subject> GetSubjectId(int Id)
        {
            return await _dbContext.Subjects.FirstOrDefaultAsync(f => f.IdSubject == Id) ?? new Subject();
        }

        public async Task<IEnumerable<Subject>> GetSubjectsValids(Guid IdStudent)
        {
            var listRegistredSubjects = _dbContext.SubjectStudents
                                                  .Where(w => w.IdStudents == IdStudent)
                                                  .Select(s => s.IdSubject)
                                                  .ToList();

            return await _dbContext.Subjects
                                   .Where(w => listRegistredSubjects.Contains(w.IdSubject))
                                   .ToListAsync();
        }

        public async Task<Boolean> registerSubjectByStudent(SubjectStudent NewRegister)
        {
            try
            {
                _dbContext.SubjectStudents.Add(NewRegister);

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Boolean> registerTeacherToSubject(SubjectTeacher newAssignment)
        {
            try
            {
                _dbContext.SubjectTeachers.Add(newAssignment);

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
