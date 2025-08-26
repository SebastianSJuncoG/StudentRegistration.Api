using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRegistration.Data.DTOs;

namespace StudentRegistration.Data.Interfaces
{
    public interface IUsersLoginRepository
    {
        /// <summary>
        /// Obtiene un usuario en especifico según su ID
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <returns>Retorna un usuario en especifico según su ID</returns>
        Task<UsersDTO> GetUserId(Guid id);

        /// <summary>
        /// Permite el inicio de sesión
        /// </summary>
        /// <param name="UserName">Usurio que desea iniciar sesión</param>
        /// <param name="Password">Clave que desea iniciar sesión</param>
        /// <returns>Entrega el un objeto con data si se logro iniciar sesión y vacio si no se inicio sesión</returns>
        Task<UserLoginDTO> LogIn(string UserName, string Password);

        /// <summary>
        /// Permite el cierre de sesión para un usuario
        /// </summary>
        /// <param name="id">Id del usuario que desea cerrar la sesión</param>
        /// <returns>Retorna un booleano para identificar si el cierre de sesión fue satisfactorio o no</returns>
        Task<Boolean> LogOut(Guid id);
    }
}
