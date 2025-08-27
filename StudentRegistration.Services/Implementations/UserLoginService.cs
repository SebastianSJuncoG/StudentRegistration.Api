using StudentRegistration.Data.Interfaces;
using StudentRegistration.Data.Models;
using StudentRegistration.Services.DTOs;
using StudentRegistration.Services.Enums;
using StudentRegistration.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Implementations
{
    public class UserLoginService : IUsersLoginService
    {
        private readonly IUsersLoginRepository _usersLoginRepository;
        private readonly IStudentsService _studentsService;

        // Inyección de dependencia del repositorio
        public UserLoginService(IUsersLoginRepository usersLoginRepository, IStudentsService studentService)
        {
            _usersLoginRepository = usersLoginRepository;
            _studentsService = studentService;
        }

        public async Task<ApiResponse<UserDTO>> GetUserByUserName(string userName)
        {
            var Data = new UserDTO();
            var Message = "";
            var Status = 400;

            try
            {
                var responseDAL = await _usersLoginRepository.GetUserByUserName(userName);

                if (responseDAL == null || responseDAL.IdUsers == Guid.Empty)
                {
                    Message = "No se encontró el programa.";

                    return new ApiResponse<UserDTO>
                    {
                        Data = Data,
                        Message = Message,
                        Status = Status
                    };
                }

                var UserDTO = new UserDTO
                {
                    Id = responseDAL.IdUsers,
                    UserName = responseDAL.UserName,
                    CreationDate = responseDAL.CreationDate,
                    UpdateDate = responseDAL.UpdateDate,
                    BlockingAttempts = responseDAL.BlockingAttempts,
                    DateLastLogin = responseDAL.DateLastLogin,
                    Active = responseDAL.Active
                };
                Message = "Programa recuperado con éxito.";
                Status = 200;

                return new ApiResponse<UserDTO>
                {
                    Data = UserDTO,
                    Message = Message,
                    Status = Status
                };

            }
            catch (Exception ex)
            {
                Message = ex.Message;

                return new ApiResponse<UserDTO>
                {
                    Data = Data,
                    Message = Message,
                    Status = Status
                };
            }
        }

        public async Task<ApiResponse<bool>> AddUser(AddUserDTO user)
        {
            var Data = false;
            var Message = "";
            var Status = 400;

            TipoUsuario tipoUsuario = TipoUsuario.Estudiante;

            try
            {
                var programModel = new UsersLogin
                {
                    UserName = user.UserName,
                    TempPassword = user.TempPassword,
                    CreationDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    BlockingAttempts = 0,
                    DateLastLogin = null,
                    LogOutDate = null,
                    Active = true
                };

                // evita que se creen usuarios con el mismo username
                var existingProgram = await _usersLoginRepository.GetUserByUserName(programModel.UserName);

                // Evita la duplicidad en los nombres de usuario
                if (existingProgram.IdUsers != Guid.Empty)
                {
                    Message = "El usuario ya se encuentra registrado.";
                    Status = 400;
                }
                else
                {
                    // agrega el usuario en la tabla userLogin
                    var responseDAL = await _usersLoginRepository.AddUser(programModel);

                    // Inicia el proceso para crear el usuario como estudiante, profesor o administrativo
                    if (responseDAL.Id != Guid.Empty)
                    {
                        user.IdUser = responseDAL.Id;

                        var userStudent = new AddStudentDTO
                        {
                            UserId = (Guid)user.IdUser,
                            FirstName = user.FirstName,
                            LastName = user.LastName ,
                            Email = user.Email ,
                            IdIdentificationType = user.IdIdentificationType ,
                            DocumentNumber = user.DocumentNumber ,

                        };

                        // Crea al usuario según su Rol
                        var creationRol = valideTypeUserAsync(userStudent, user.TypeUser);

                        Data = true;
                        Message = "El usuario fue agregado con éxito.";
                        Status = 200;
                    }
                    else
                    {
                        Message = "No se pudo agregar el usuario. Ningún registro afectado.";
                        Status = 400;
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                Status = 500;
            }

            return new ApiResponse<bool>
            {
                Data = Data,
                Message = Message,
                Status = Status
            };
        }


        #region General
        /// <summary>
        /// Permite crear un tipo de usuario
        /// </summary>
        /// <param name="user">Información del usuario</param>
        /// <param name="typeUser">Tipo de usuario</param>
        /// <returns>Retorna un bool indicando si se creo el usuario de forma satisfactoria o no</returns>
        private async Task<ApiResponse<bool>> valideTypeUserAsync(AddStudentDTO user, int typeUser)
        {
            var Data = false;
            var Message = "";
            var Status = 400;

            if ((TipoUsuario)typeUser == TipoUsuario.Estudiante)
            {
                return await _studentsService.AddStudent(user);
            }
            else if ((TipoUsuario)typeUser == TipoUsuario.Profesor)
            {
                Data = false;
                Message = "En construcción";
                Status = 501;
            }
            else if ((TipoUsuario)typeUser == TipoUsuario.Administrativo)
            {
                Data = false;
                Message = "En construcción";
                Status = 501;
            }
            else
            {
                Data = false;
                Message = "Error con el tipo de usuario";
            }

            return new ApiResponse<bool>
            {
                Data = Data,
                Message = Message,
                Status = Status
            };
        }
        #endregion
    }
}
