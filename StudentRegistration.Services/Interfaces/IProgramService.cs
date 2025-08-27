using StudentRegistration.Data.Models;
using StudentRegistration.Services.DTOs;
using StudentRegistration.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Interfaces
{
    public interface IProgramService
    {
        /// <summary>
        /// Obtiene una lista de todos los programas registrados
        /// </summary>
        /// <returns>Retorna una lista con todos los programas registrados</returns>
        Task<ApiResponse<IEnumerable<ProgramDTO>>> GetPrograms();

        /// <summary>
        /// Obtiene un programa por su Id
        /// </summary>
        /// <param name="id">Id del programa a consultar</param>
        /// <returns>Retorna un programa en especifico segun su Id</returns>
        Task<ApiResponse<ProgramDTO>> GetProgramId(int id);

        /// <summary>
        /// Permite consultar un programa por el nombre
        /// </summary>
        /// <param name="programName">Nombre del programa</param>
        /// <returns>Retorna el objeto completo</returns>
        Task<ApiResponse<ProgramDTO>> GetProgramByName(string programName);

        /// <summary>
        /// Permite añadir un programa
        /// </summary>
        /// <param name="program">Objeto del programa a guardar</param>
        /// <returns>Retorna un bool para indicar si se almaceno de forma correcta</returns>
        Task<ApiResponse<bool>> AddProgram(ProgramDTO program);

        /// <summary>
        /// Permite editar un programa
        /// </summary>
        /// <param name="program">Objeto del programa a editar</param>
        /// <returns>Retorna un bool para indicar si se edito de forma correcta</returns>
        Task<ApiResponse<bool>> UpdateProgram(ProgramDTO program);

        /// <summary>
        /// Permite eliminar un registro
        /// </summary>
        /// <param name="program">Objeto del programa a eliminar</param>
        /// <returns>Retorna un bool para indicar si se elimino de forma correcta</returns>
        Task<ApiResponse<bool>> DeleteProgram(int id);
    }
}
