using StudentRegistration.Data.DAL;
using StudentRegistration.Data.Interfaces;
using StudentRegistration.Data.Models;
using StudentRegistration.Services.DTOs;
using StudentRegistration.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Implementations
{
    public class StudentService : IStudentsService
    {
        private readonly IStudentsRepository _studentRepository;

        // Inyección de dependencia del repositorio
        public StudentService(IStudentsRepository userRepository)
        {
            _studentRepository = userRepository;
        }

        public async Task<ApiResponse<IEnumerable<StudentDTO>>> GetStudents(int actualPage, int recordsQuantity)
        {
            var Data = new StudentDTO();
            var Message = "";
            var Status = 400;

            try
            {
                List<Student> responseDAL = (List<Student>)await _studentRepository.GetStudents(actualPage, recordsQuantity);

                var students = responseDAL.Select(MapToStudentDTO).ToList();

                if (students == null || !students.Any())
                {
                    Message = "No se encontraron estudiantes";
                    Status = 404;

                    return new ApiResponse<IEnumerable<StudentDTO>>
                    {
                        Data = (IEnumerable<StudentDTO>)Data,
                        Message = Message,
                        Status = Status
                    };
                }

                Message = "Lista de estudiantes recuperada con éxito.";
                Status = 200;

                return new ApiResponse<IEnumerable<StudentDTO>>
                {
                    Data = (IEnumerable<StudentDTO>)students,
                    Message = Message,
                    Status = Status
                };

            }
            catch (Exception ex)
            {
                Message = ex.Message;

                return new ApiResponse<IEnumerable<StudentDTO>>
                {
                    Data = (IEnumerable<StudentDTO>)Data,
                    Message = Message,
                    Status = Status
                };
            }
        }

        public async Task<ApiResponse<StudentDTO>> GetStudentsId(Guid id)
        {
            var Data = new StudentDTO();
            var Message = "";
            var Status = 400;

            try
            {
                var student = await _studentRepository.GetStudentsId(id);

                if(student == null || student.IdStudents == Guid.Empty)
                {
                    Message = "No se encontró el estudiante.";

                    return new ApiResponse<StudentDTO>
                    {
                        Data = Data,
                        Message = Message,
                        Status = Status
                    };
                }

                var studentDTO = new StudentDTO
                {
                    IdStudents = student.IdStudents,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email,
                    IdIdentificationType = student.IdIdentificationType,
                    DocumentNumber = student.DocumentNumber,
                };
                Message = "Estudiante recuperado con éxito.";
                Status = 200;

                return new ApiResponse<StudentDTO>
                {
                    Data = studentDTO,
                    Message = Message,
                    Status = Status
                };

            }
            catch (Exception ex)
            {
                Message = ex.Message;

                return new ApiResponse<StudentDTO>
                {
                    Data = Data,
                    Message = Message,
                    Status = Status
                };
            }
        }

        public async Task<ApiResponse<IEnumerable<SubjectByStudentDTO>>> GetSubjectsByStudent(Guid id)
        {
            var Data = new List<SubjectByStudentDTO>();
            var Message = "";
            var Status = 400;

            try
            {
                var subjectsByStudent = await _studentRepository.GetSubjectsByStudent(id);

                if (subjectsByStudent == null || !subjectsByStudent.Any())
                {
                    Message = "No se encontraron las materias del estudiante";
                    Status = 404;

                    return new ApiResponse<IEnumerable<SubjectByStudentDTO>>
                    {
                        Data = Data,
                        Message = Message,
                        Status = Status
                    };
                }

                Message = "Lista de materias recuperada con éxito.";
                Status = 200;

                return new ApiResponse<IEnumerable<SubjectByStudentDTO>>
                {
                    Data = (IEnumerable<SubjectByStudentDTO>)subjectsByStudent,
                    Message = Message,
                    Status = Status
                };
            }
            catch (Exception ex)
            {
                Message = ex.Message;

                return new ApiResponse<IEnumerable<SubjectByStudentDTO>>
                {
                    Data = Data,
                    Message = Message,
                    Status = Status
                };
            }
        }

        public async Task<ApiResponse<bool>> AddStudent(AddStudentDTO addStudentDTO)
        {
            var Data = false;
            var Message = "";
            var Status = 400;

            try
            {
                var studentModel = new Student
                {
                    UserId = addStudentDTO.UserId,
                    FirstName = addStudentDTO.FirstName,
                    LastName = addStudentDTO.LastName,
                    Email = addStudentDTO.Email,
                    IdIdentificationType = addStudentDTO.IdIdentificationType,
                    DocumentNumber = addStudentDTO.DocumentNumber,
                };

                bool responseDAL = await _studentRepository.AddStudent(studentModel);

                if (responseDAL)
                {
                    Data = true;
                    Message = "El estudiante fue agregado con éxito.";
                    Status = 200;
                }
                else
                {
                    Data = false;
                    Message = "No se pudo agregar el estudiante. Ningún registro afectado.";
                    Status = 400;
                }
            }
            catch (Exception ex)
            {
                Data = false;
                Message = ex.Message;
                Status = 500;
            }

            return new ApiResponse<bool>
            {
                Data = Data,
                Message = Message,
                Status = Status
            };
        }

        public async Task<ApiResponse<bool>> UpdateStudent(AddStudentDTO student)
        {
            var Data = false;
            var Message = "";
            var Status = 400;

            try
            {
                var studentModel = new Student
                {
                    IdStudents = (Guid)student.IdStudents,
                    UserId = student.UserId,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email,
                    IdIdentificationType = (int)student.IdIdentificationType,
                    DocumentNumber = student.DocumentNumber,
                };

                bool responseDAL = await _studentRepository.UpdateStudent(studentModel);

                if (responseDAL)
                {
                    Data = true;
                    Message = "El estudiante fue editado con éxito.";
                    Status = 200;
                }
                else
                {
                    Data = false;
                    Message = "No se pudo editar el estudiente. Ningún registro afectado.";
                    Status = 400;
                }
            }
            catch (Exception ex)
            {
                Data = false;
                Message = ex.Message;
                Status = 500;
            }

            return new ApiResponse<bool>
            {
                Data = Data,
                Message = Message,
                Status = Status
            };
        }

        public async Task<ApiResponse<bool>> DeleteStudent(Guid id)
        {
            var Data = false;
            var Message = "";
            var Status = 400;

            try
            {
                var existingProgram = await _studentRepository.GetStudentsId(id);

                // Evita la duplicidad en los nombres de los programas
                if (existingProgram.IdStudents != Guid.Empty)
                {
                    bool responseDAL = await _studentRepository.DeleteStudent(id);

                    if (responseDAL)
                    {
                        Data = true;
                        Message = "El estudiente fue eliminado con éxito.";
                        Status = 200;
                    }
                    else
                    {
                        Data = false;
                        Message = "No se pudo eliminar el estudiante. Ningún registro afectado.";
                        Status = 400;
                    }
                }
                else
                {
                    Data = false;
                    Message = "El estudiante no fue encontrado.";
                    Status = 400;
                }
            }
            catch (Exception ex)
            {
                Data = false;
                Message = ex.Message;
                Status = 500;
            }

            return new ApiResponse<bool>
            {
                Data = Data,
                Message = Message,
                Status = Status
            };
        }

        #region Mapear
        private static StudentDTO MapToStudentDTO(Student student)
        {
            if (student == null)
            {
                return null;
            }

            return new StudentDTO
            {
                IdStudents = student.IdStudents,
                UserId = student.UserId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                IdIdentificationType = student.IdIdentificationType,
                DocumentNumber = student.DocumentNumber,
            };
        }

        #endregion
    }
}
