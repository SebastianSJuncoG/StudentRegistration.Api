using Microsoft.EntityFrameworkCore;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentRegistration.Services.Implementations
{
    public class ProgramService : IProgramService
    {
        private readonly IProgramRepository _programRepository;

        // Inyección de dependencia del repositorio
        public ProgramService(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<ApiResponse<IEnumerable<ProgramDTO>>> GetPrograms()
        {
            var Data = new ProgramDTO();
            var Message = "";
            var Status = 400;

            try
            {
                var responseDAL = await _programRepository.GetPrograms();

                if (responseDAL == null || !responseDAL.Any())
                {
                    var dataList = new List<ProgramDTO> { Data };
                    Message = "No se encontraron programas";
                    Status = 404;

                    return new ApiResponse<IEnumerable<ProgramDTO>>
                    {
                        Data = dataList,
                        Message = Message,
                        Status = Status
                    };
                }

                var programDTOs = responseDAL.Select(p => new ProgramDTO
                {
                    IdProgram = p.IdProgram,
                    ProgramName = p.ProgramName,
                    NumCredits = p.NumCredits,
                }).ToList();
                Message = "Lista de programas recuperada con éxito.";
                Status = 200;

                return new ApiResponse<IEnumerable<ProgramDTO>>
                {
                    Data = programDTOs,
                    Message = Message,
                    Status = Status
                };

            }
            catch (Exception ex)
            {
                Message = ex.Message;

                return new ApiResponse<IEnumerable<ProgramDTO>>
                {
                    Data = (IEnumerable<ProgramDTO>)Data,
                    Message = Message,
                    Status = Status
                };
            }
        }

        public async Task<ApiResponse<ProgramDTO>> GetProgramId(int id)
        {
            var Data = new ProgramDTO();
            var Message = "";
            var Status = 400;

            try
            {
                var responseDAL = await _programRepository.GetProgramId(id);

                if (responseDAL == null || responseDAL.IdProgram == 0)
                {
                    Message = "No se encontró el programa.";

                    return new ApiResponse<ProgramDTO>
                    {
                        Data = Data,
                        Message = Message,
                        Status = Status
                    };
                }

                var programDTO = new ProgramDTO
                {
                    IdProgram = responseDAL.IdProgram,
                    ProgramName = responseDAL.ProgramName,
                    NumCredits = responseDAL.NumCredits
                };
                Message = "Programa recuperado con éxito.";
                Status = 200;

                return new ApiResponse<ProgramDTO>
                {
                    Data = programDTO,
                    Message = Message,
                    Status = Status
                };

            }
            catch (Exception ex)
            {
                Message = ex.Message;

                return new ApiResponse<ProgramDTO>
                {
                    Data = Data,
                    Message = Message,
                    Status = Status
                };
            }
        }

        public async Task<ApiResponse<ProgramDTO>> GetProgramByName(string programName)
        {
            var Data = new ProgramDTO();
            var Message = "";
            var Status = 400;

            try
            {
                var responseDAL = await _programRepository.GetProgramByName(programName);

                if (responseDAL == null || responseDAL.IdProgram == 0)
                {
                    Message = "No se encontró el programa.";

                    return new ApiResponse<ProgramDTO>
                    {
                        Data = Data,
                        Message = Message,
                        Status = Status
                    };
                }

                var programDTO = new ProgramDTO
                {
                    IdProgram = responseDAL.IdProgram,
                    ProgramName = responseDAL.ProgramName,
                    NumCredits = responseDAL.NumCredits
                };
                Message = "Programa recuperado con éxito.";
                Status = 200;

                return new ApiResponse<ProgramDTO>
                {
                    Data = programDTO,
                    Message = Message,
                    Status = Status
                };

            }
            catch (Exception ex)
            {
                Message = ex.Message;

                return new ApiResponse<ProgramDTO>
                {
                    Data = Data,
                    Message = Message,
                    Status = Status
                };
            }
        }

        public async Task<ApiResponse<bool>> AddProgram(ProgramDTO program)
        {
            var Data = false;
            var Message = "";
            var Status = 400;

            try
            {
                var programModel = new Program
                {
                    IdProgram = program.IdProgram,
                    ProgramName = program.ProgramName,
                    NumCredits = program.NumCredits,
                };

                var existingProgram = await _programRepository.GetProgramByName(program.ProgramName);

                // Evita la duplicidad en los nombres de los programas
                if (existingProgram.IdProgram > 0)
                {
                    Data = false;
                    Message = "El programa ya se encuentra registrado.";
                    Status = 400;
                }
                else
                {
                    bool responseDAL = await _programRepository.AddProgram(programModel);

                    if (responseDAL)
                    {
                        Data = true;
                        Message = "Programa fue agregado con éxito.";
                        Status = 200;
                    }
                    else
                    {
                        Data = false;
                        Message = "No se pudo agregar el programa. Ningún registro afectado.";
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

        public async Task<ApiResponse<bool>> UpdateProgram(ProgramDTO program)
        {
            var Data = false;
            var Message = "";
            var Status = 400;

            try
            {
                var programModel = new Program
                {
                    IdProgram = program.IdProgram,
                    ProgramName = program.ProgramName,
                    NumCredits = program.NumCredits,
                };

                var existingProgram = await _programRepository.GetProgramByName(program.ProgramName);

                // Evita la duplicidad en los nombres de los programas
                if (existingProgram.IdProgram > 0)
                {
                    Data = false;
                    Message = "El programa ya se encuentra registrado.";
                    Status = 400;
                }
                else
                {
                    bool responseDAL = await _programRepository.UpdateProgram(programModel);

                    if (responseDAL)
                    {
                        Data = true;
                        Message = "Programa fue editado con éxito.";
                        Status = 200;
                    }
                    else
                    {
                        Data = false;
                        Message = "No se pudo agregar el programa. Ningún registro afectado.";
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

        public async Task<ApiResponse<bool>> DeleteProgram(int id)
        {
            var Data = false;
            var Message = "";
            var Status = 400;

            try
            {
                var existingProgram = await _programRepository.GetProgramId(id);

                // Evita la duplicidad en los nombres de los programas
                if (existingProgram.IdProgram > 0)
                {
                    bool responseDAL = await _programRepository.DeleteProgram(id);

                    if (responseDAL)
                    {
                        Data = true;
                        Message = "Programa fue eliminado con éxito.";
                        Status = 200;
                    }
                    else
                    {
                        Data = false;
                        Message = "No se pudo eliminar el programa. Ningún registro afectado.";
                        Status = 400;
                    }
                }
                else
                {
                    Data = false;
                    Message = "El programa no fue encontrado.";
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
    }
}
