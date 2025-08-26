using StudentRegistration.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Data.Interfaces
{
    public interface IAdministrativRepository
    {
        /// <summary>
        /// Obtiene un usuario administrativo en especifico según su ID
        /// </summary>
        /// <param name="id">Id del usuario administrativo</param>
        /// <returns>Retorna un usuario administrativo en especifico según su ID</returns>
        Task<Administrative> GetAdministrativeId(Guid id);
    }
}
