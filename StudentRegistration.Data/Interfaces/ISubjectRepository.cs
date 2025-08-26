using StudentRegistration.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Data.Interfaces
{
    public interface ISubjectRepository
    {
        /// <summary>
        /// Obtiene una materia por su Id
        /// </summary>
        /// <param name="id">Id de la materia a consultar</param>
        /// <returns>Retorna una materia en especifico segun su Id</returns>
        Task<Subject> GetSubjectId(int id);

        /// <summary>
        /// Obtiene una lista de todos las materias registradas
        /// </summary>
        /// <returns>Retorna una lista con todas las materia registradas</returns>
        Task<IEnumerable<Subject>> GetSubjects();
    }
}
