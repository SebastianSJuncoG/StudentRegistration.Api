using StudentRegistration.Data.Interfaces;
using StudentRegistration.Data.Models;
using StudentRegistration.Services.DTOs;
using StudentRegistration.Services.Enums;
using StudentRegistration.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        // Inyección de dependencia del repositorio
        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<ApiResponse<IEnumerable<SubjectByStudentDTO>>> GetSubjectsValids(Guid IdStudent)
        {
            var Data = new SubjectByStudentDTO();
            var Message = "";
            var Status = 400;

            try
            {
                int creditsLimit = await _subjectRepository.CreditCouting(IdStudent);

                if ((Credits)creditsLimit == Credits.creditLimit)
                {
                    var dataList = new List<SubjectByStudentDTO> { Data };
                    Message = "Ha llegado al limite de inscripciones";
                    Status = 404;

                    return new ApiResponse<IEnumerable<SubjectByStudentDTO>>
                    {
                        Data = dataList,
                        Message = Message,
                        Status = Status
                    };
                }

                var responseDAL = await _subjectRepository.GetSubjectsValids(IdStudent);

                if (responseDAL == null || !responseDAL.Any())
                {
                    var dataList = new List<SubjectByStudentDTO> { Data };
                    Message = "No se encontraron materias";
                    Status = 404;

                    return new ApiResponse<IEnumerable<SubjectByStudentDTO>>
                    {
                        Data = dataList,
                        Message = Message,
                        Status = Status
                    };
                }

                var subjectByStudentDTOs = responseDAL.Select(p => new SubjectByStudentDTO
                {
                    Id_Students = IdStudent,
                    Id_Subject = p.IdSubject,
                    Subject_Name = p.SubjectName,
                    Num_Credits = p.NumCredits,
                }).ToList();
                Message = "Lista de materias recuperada con éxito.";
                Status = 200;

                return new ApiResponse<IEnumerable<SubjectByStudentDTO>>
                {
                    Data = subjectByStudentDTOs,
                    Message = Message,
                    Status = Status
                };

            }
            catch (Exception ex)
            {
                Message = ex.Message;

                return new ApiResponse<IEnumerable<SubjectByStudentDTO>>
                {
                    Data = (IEnumerable<SubjectByStudentDTO>)Data,
                    Message = Message,
                    Status = Status
                };
            }
        }

        public async Task<ApiResponse<bool>> registerSubjectByStudent(AddSubjectByStudentDTO subjectByStudentDTO)
        {
            var Data = false;
            var Message = "";
            var Status = 400;

            try
            {
                var programModel = new SubjectStudent
                {
                    IdSubject = subjectByStudentDTO.Id_Subject,
                    IdStudents = (Guid)subjectByStudentDTO.Id_Students
                };

                var subjectsValids = await _subjectRepository.GetSubjectsValids(subjectByStudentDTO.Id_Students);

                var contieneId = subjectsValids.Any(a => a.IdSubject == programModel.IdSubject);

                if (!contieneId)
                {
                    Data = false;
                    Message = "La asignatura asignada no es valida.";
                    Status = 400;
                }
                else
                {
                    bool responseDAL = await _subjectRepository.registerSubjectByStudent(programModel);

                    if (responseDAL)
                    {
                        Data = true;
                        Message = "La materia fue agregada con éxito.";
                        Status = 200;
                    }
                    else
                    {
                        Data = false;
                        Message = "No se pudo agregar la materia. Ningún registro afectado.";
                        Status = 400;
                    }
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

        //public async Task<ApiResponse<bool>> UpdateSubjectByStudent(SubjectByStudentDTO subjectByStudent)
        //{
        //    var Data = false;
        //    var Message = "";
        //    var Status = 400;

        //    try
        //    {
        //        var subjectByStudentModel = new SubjectStudent
        //        {
        //            IdSubject = program.IdProgram,
        //            ProgramName = program.ProgramName,
        //            NumCredits = program.NumCredits,
        //        };

        //        var existingProgram = await _subjectRepository.UpdateSubjectByStudent(subjectByStudent.ProgramName);

        //        // Evita la duplicidad en los nombres de los programas
        //        if (existingProgram.IdProgram > 0)
        //        {
        //            Data = false;
        //            Message = "El programa ya se encuentra registrado.";
        //            Status = 400;
        //        }
        //        else
        //        {
        //            bool responseDAL = await _programRepository.UpdateProgram(programModel);

        //            if (responseDAL)
        //            {
        //                Data = true;
        //                Message = "Programa fue editado con éxito.";
        //                Status = 200;
        //            }
        //            else
        //            {
        //                Data = false;
        //                Message = "No se pudo agregar el programa. Ningún registro afectado.";
        //                Status = 400;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Data = false;
        //        Message = ex.Message;
        //        Status = 500;
        //    }

        //    return new ApiResponse<bool>
        //    {
        //        Data = Data,
        //        Message = Message,
        //        Status = Status
        //    };
        //}

        //public async Task<ApiResponse<bool>> DeleteProgram(int id)
        //{
        //    var Data = false;
        //    var Message = "";
        //    var Status = 400;

        //    try
        //    {
        //        var existingProgram = await _programRepository.GetProgramId(id);

        //        // Evita la duplicidad en los nombres de los programas
        //        if (existingProgram.IdProgram > 0)
        //        {
        //            bool responseDAL = await _programRepository.DeleteProgram(id);

        //            if (responseDAL)
        //            {
        //                Data = true;
        //                Message = "Programa fue eliminado con éxito.";
        //                Status = 200;
        //            }
        //            else
        //            {
        //                Data = false;
        //                Message = "No se pudo eliminar el programa. Ningún registro afectado.";
        //                Status = 400;
        //            }
        //        }
        //        else
        //        {
        //            Data = false;
        //            Message = "El programa no fue encontrado.";
        //            Status = 400;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Data = false;
        //        Message = ex.Message;
        //        Status = 500;
        //    }

        //    return new ApiResponse<bool>
        //    {
        //        Data = Data,
        //        Message = Message,
        //        Status = Status
        //    };
        //}
    }
}
