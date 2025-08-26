using StudentRegistration.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Data.Interfaces
{
    public interface IProgramRepository
    {
        /// <summary>
        /// Obtiene una lista de todos los programas registrados
        /// </summary>
        /// <returns>Retorna una lista con todos los programas registrados</returns>
        Task<IEnumerable<Program>> GetPrograms();

        /// <summary>
        /// Obtiene un programa por su Id
        /// </summary>
        /// <param name="id">Id del programa a consultar</param>
        /// <returns>Retorna un programa en especifico segun su Id</returns>
        Task<Program> GetProgramId(int id);
    }
}
