using StudentRegistration.Data.Models;
using StudentRegistration.Data.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentRegistration.Data.Interfaces
{
    public interface ITeacherRepository
    {
        /// <summary>
        /// Obtiene una lista con los profesor registrados
        /// </summary>
        /// <param name="actualPage">Pagina que se desea consultar</param>
        /// <param name="recordsQuantity">Cantidad de registros que se requieren en la consulta</param>
        /// <param name="username">Filtro por el campo del profesor</param>
        /// <param name="firstName">Filtro por el campo del primer nombre de la persona</param>
        /// <param name="lastName">Filtro por el campo del apellido de la persona</param>
        /// <param name="documentNumber">Filtro por el campo del número de documento</param>
        /// <returns>Una lista filtrada según la pagina y la cantidad de registros</returns>
        Task<IEnumerable<Teacher>> GetTeachers(int actualPage, int recordsQuantity);

        /// <summary>
        /// Obtiene un profesor en especifico según su ID
        /// </summary>
        /// <param name="id">Id del profesor</param>
        /// <returns>Retorna un profesor en especifico según su ID</returns>
        Task<Teacher> GetTeachersId(Guid id);

        /// <summary>
        /// Obtiene una lista con las asignatiras que imparte el profesor
        /// </summary>
        /// <param name="id">Id del profesor</param>
        /// <returns>Retorna una lista con las asignaturas que imparte el profesor</returns>
        Task<IEnumerable<SubjectByTeacherResponse>> GetSubjectsByTeacher(Guid id);
    }
}
