using StudentRegistration.Data.Models;
using StudentRegistration.Services.Implementations;
using StudentRegistration.Services.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRegistration.Services.DTOs;

namespace StudentRegistration.Services.Interfaces
{
    public interface IStudentsService
    {
        /// <summary>
        /// Obtiene una lista (Filtrada o no) con los estudiante registrados
        /// </summary>
        /// <param name="actualPage">Pagina que se desea consultar</param>
        /// <param name="recordsQuantity">Cantidad de registros que se requieren en la consulta</param>
        /// <param name="firstName">Filtro por el campo del primer nombre de la persona</param>
        /// <param name="lastName">Filtro por el campo del apellido de la persona</param>
        /// <param name="documentNumber">Filtro por el campo del número de documento</param>
        /// <returns>Una lista filtrada según la pagina y la cantidad de registros</returns>
        Task<ApiResponse<IEnumerable<StudentDTO>>> GetStudents(int actualPage, int recordsQuantity);

        /// <summary>
        /// Obtiene un estudiante en especifico según su ID
        /// </summary>
        /// <param name="id">Id del estudiante</param>
        /// <returns>Retorna un estudiante en especifico según su ID</returns>
        Task<ApiResponse<StudentDTO>> GetStudentsId(Guid id);

        /// <summary>
        /// Obtiene una lista con las asignatiras registradas que tiene el estudiante
        /// </summary>
        /// <param name="id">Id del estudiante</param>
        /// <returns>Retorna una lista con las asignaturas que tiene el estudiante</returns>
        Task<ApiResponse<IEnumerable<SubjectByStudentDTO>>> GetSubjectsByStudent(Guid id);

        /// <summary>
        /// Permite crear un usuario
        /// </summary>
        /// <param name="program">Objeto del usuario a guardar</param>
        /// <returns>Retorna un bool para indicar si se almaceno de forma correcta</returns>
        Task<ApiResponse<bool>> AddStudent(AddStudentDTO addStudentDTO);

        /// <summary>
        /// Permite editar un estudiante
        /// </summary>
        /// <param name="program">Objeto del estudiante a editar</param>
        /// <returns>Retorna un bool para indicar si se edito de forma correcta</returns>
        Task<ApiResponse<bool>> UpdateStudent(AddStudentDTO program);

        /// <summary>
        /// Permite eliminar un registro
        /// </summary>
        /// <param name="program">Objeto del estudiante a eliminar</param>
        /// <returns>Retorna un bool para indicar si se elimino de forma correcta</returns>
        Task<ApiResponse<bool>> DeleteStudent(Guid id);
    }
}
