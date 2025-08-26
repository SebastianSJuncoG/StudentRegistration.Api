using StudentRegistration.Data.DTOs;
using StudentRegistration.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Data.Interfaces
{
    public interface IStudentsRepository
    {
        /// <summary>
        /// Obtiene una lista con los estudiante registrados
        /// </summary>
        /// <param name="actualPage">Pagina que se desea consultar</param>
        /// <param name="recordsQuantity">Cantidad de registros que se requieren en la consulta</param>
        /// <param name="username">Filtro por el campo del estudiante</param>
        /// <param name="firstName">Filtro por el campo del primer nombre de la persona</param>
        /// <param name="lastName">Filtro por el campo del apellido de la persona</param>
        /// <param name="documentNumber">Filtro por el campo del número de documento</param>
        /// <returns>Una lista filtrada según la pagina y la cantidad de registros</returns>
        Task<IEnumerable<Student>> GetStudents(int actualPage, int recordsQuantity, string firstName, string lastName, string documentNumber);

        /// <summary>
        /// Obtiene un estudiante en especifico según su ID
        /// </summary>
        /// <param name="id">Id del estudiante</param>
        /// <returns>Retorna un estudiante en especifico según su ID</returns>
        Task<Student> GetStudentsId(Guid id);

        /// <summary>
        /// Obtiene una lista con las asignatiras registradas que tiene el estudiante
        /// </summary>
        /// <param name="id">Id del estudiante</param>
        /// <returns>Retorna una lista con las asignaturas que tiene el estudiante</returns>
        Task<IEnumerable<SubjectsByStudentDTO>> GetSubjectsByStudent(Guid id);
    }
}
