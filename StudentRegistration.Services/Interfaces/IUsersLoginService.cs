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
    public interface IUsersLoginService
    {
        /// <summary>
        /// Permite buscar usuarios por su username
        /// </summary>
        /// <param name="userName">Username del usuario</param>
        /// <returns>Retorna el objeto del usuario encontrado</returns>
        Task<ApiResponse<UserDTO>> GetUserByUserName(string userName);

        /// <summary>
        /// Permite crear usuarios 
        /// </summary>
        /// <param name="user">Objeto del usuario a crear</param>
        /// <returns>Retorna un bool para indicar si la creación fue satisfactoria</returns>
        Task<ApiResponse<bool>> AddUser(AddUserDTO user);
    }
}
