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
    public interface ISubjectService
    {
        /// <summary>
        /// Obtiene una lista de las materias que pueden ser validas para un estudiante
        /// </summary>
        /// <returns>Retorna una lista con las materia validas para un estudiante</returns>
        Task<ApiResponse<IEnumerable<SubjectByStudentDTO>>> GetSubjectsValids(Guid IdStudent);

        /// <summary>
        /// Registra una asignatura a un estudiente
        /// </summary>
        /// <param name="NewRegister">Objeto con el id del estudiante y de la materia</param>
        /// <returns>Retorna un booleano para identificar si el registro fue satisfactorio</returns>
        Task<ApiResponse<bool>> registerSubjectByStudent(AddSubjectByStudentDTO subjectByStudentDTO);

        /// <summary>
        /// Permite editar una materia para un estudiante
        /// </summary>
        /// <param name="program">Objeto de la materia a editar</param>
        /// <returns>Retorna un bool para indicar si se edito de forma correcta</returns>
        //Task<bool> UpdateSubjectByStudent(SubjectStudent subjectStudent);

        /// <summary>
        /// Permite eliminar una materia para un estudiante
        /// </summary>
        /// <param name="program">Objeto de la materia a eliminar</param>
        /// <returns>Retorna un bool para indicar si se elimino de forma correcta</returns>
        //Task<bool> DeleteSubjectByStudent(int id);
    }
}
