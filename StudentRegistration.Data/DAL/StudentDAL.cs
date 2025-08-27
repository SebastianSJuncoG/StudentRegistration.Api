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
    public class StudentDAL : IStudentsRepository
    {
        private readonly StudentRegistrationContext _dbContext;

        public StudentDAL(StudentRegistrationContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Student>> GetStudents(int actualPage, int recordsQuantity)
        {
            return await _dbContext.Students.OrderBy(x => x.IdStudents)
                                            .Skip(actualPage)
                                            .Take(recordsQuantity)
                                            .ToListAsync() ?? new List<Student>();
        }

        public async Task<Student> GetStudentsId(Guid id)
        {
            Student response = await _dbContext.Students.FirstOrDefaultAsync(f => f.IdStudents == id) ?? new Student();

            return response;
        }

        public async Task<IEnumerable<SubjectByStudentResponse>> GetSubjectsByStudent(Guid id)
        {
            List<SubjectByStudentResponse> subjectsDTOs = await _dbContext.SubjectStudents
                                                        .Where(w => w.IdStudents == id)
                                                        .Select(s => new SubjectByStudentResponse
                                                        {
                                                            Id_Students = s.IdStudents,
                                                            Id_Subject = s.IdSubject,
                                                            Subject_Name = (_dbContext.Subjects.Where(ws => ws.IdSubject == s.IdSubject).Select(ss => ss.SubjectName).FirstOrDefault() ?? ""),
                                                            Num_Credits = (_dbContext.Subjects.Where(ws => ws.IdSubject == s.IdSubject).Select(ss => ss.NumCredits).FirstOrDefault())
                                                        })
                                                        .ToListAsync() ?? new List<SubjectByStudentResponse>();

            return subjectsDTOs ?? new List<SubjectByStudentResponse>();
        }

        public async Task<bool> AddStudent(Student student)
        {
            try
            {
                _dbContext.Students.Add(student);

                int result = await _dbContext.SaveChangesAsync();

                if (result > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            try
            {
                student.User = await _dbContext.UsersLogins.FirstOrDefaultAsync(f => f.IdUsers == student.UserId) ?? new UsersLogin();

                if (student.User.IdUsers == Guid.Empty)
                {
                    return false;
                }

                _dbContext.Entry(student).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteStudent(Guid idStudent)
        {
            try
            {
                var student = await _dbContext.Students.FindAsync(idStudent);

                if (student != null)
                {
                    _dbContext.Students.Remove(student);
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
