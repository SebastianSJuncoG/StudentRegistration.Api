using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Responces
{
    public interface IApiResponses<T>
    {
        /// <summary>
        /// Contendrá la data entregada por el servicio
        /// </summary>
        T Data { get; set; }

        /// <summary>
        /// Entrega un mensaje explicando la respuesta (Satisfactoria, Error en el servidor, ...)
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Status sobre la respuesta (200, 400, 500, ...)
        /// </summary>
        int Status { get; set; }
    }
}
