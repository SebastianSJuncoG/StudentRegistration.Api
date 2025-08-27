using StudentRegistration.Data.Models;
using StudentRegistration.Data.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Data.Interfaces
{
    public interface IUsersLoginRepository
    {
        /// <summary>
        /// Obtiene un usuario en especifico según su ID
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <returns>Retorna un usuario en especifico según su ID</returns>
        Task<UserResponse> GetUserId(Guid id);

        /// <summary>
        /// Permite buscar usuarios por su username
        /// </summary>
        /// <param name="userName">Username del usuario</param>
        /// <returns>Retorna el objeto del usuario encontrado</returns>
        Task<UsersLogin> GetUserByUserName(string userName);

        /// <summary>
        /// Permite crear usuarios 
        /// </summary>
        /// <param name="user">Objeto del usuario a crear</param>
        /// <returns>Retorna un bool para indicar si la creación fue satisfactoria</returns>
        Task<UserResponse> AddUser(UsersLogin user);

        /// <summary>
        /// Permite el inicio de sesión
        /// </summary>
        /// <param name="UserName">Usurio que desea iniciar sesión</param>
        /// <param name="Password">Clave que desea iniciar sesión</param>
        /// <returns>Entrega el un objeto con data si se logro iniciar sesión y vacio si no se inicio sesión</returns>
        Task<UserLoginResponse> LogIn(string UserName, string Password);

        /// <summary>
        /// Permite el cierre de sesión para un usuario
        /// </summary>
        /// <param name="id">Id del usuario que desea cerrar la sesión</param>
        /// <returns>Retorna un booleano para identificar si el cierre de sesión fue satisfactorio o no</returns>
        Task<Boolean> LogOut(Guid id);
    }
}
