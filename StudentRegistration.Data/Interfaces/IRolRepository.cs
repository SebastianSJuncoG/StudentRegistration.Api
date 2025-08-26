using StudentRegistration.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Data.Interfaces
{
    public interface IRolRepository
    {
        /// <summary>
        /// Obtiene un rol por su Id
        /// </summary>
        /// <param name="id">Id del rol a consultar</param>
        /// <returns>Retorna un rol en especifico segun su Id</returns>
        Task<Rol> GetRolId(int id);

        /// <summary>
        /// Obtiene una lista de todos los roles registrados
        /// </summary>
        /// <returns>Retorna una lista con todos los roles registrados</returns>
        Task<IEnumerable<Rol>> GetRoles();
    }
}
