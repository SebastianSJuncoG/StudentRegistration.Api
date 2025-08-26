using StudentRegistration.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Data.Interfaces
{
    public interface ICatalogsData
    {
        #region Tipos de identificacion
        /// <summary>
        /// Consulta una lista con los tipos de identificación
        /// </summary>
        /// <returns>Obtiene una lista con todos los tipos de identificación</returns>
        IEnumerable<IdentificationType> GetIdentificationType();
        /// <summary>
        /// Consulta la tabla de tipos de identificación
        /// </summary>
        /// <param name="id">ID del tipo de identificación</param>
        /// <returns>Obtiene una lista de los tipos de identificación</returns>
        IdentificationType GetIdentificationTypeId(int id);
        #endregion

        #region Tipos de eventos
        /// <summary>
        /// Consulta todos los eventos que se pueden realizar en el aplicativo
        /// </summary>
        /// <returns>Retorna una lista con todos los eventos que se pueden realizar en el aplicativo</returns>
        IEnumerable<TypeOfEvent> GetTypeOfEvent();

        /// <summary>
        /// Consulta un evento según su ID
        /// </summary>
        /// <param name="id">ID del tipo de evento</param>
        /// <returns>Retorna un evento en especifico según su ID</returns>
        TypeOfEvent GetTypeOfEventId(int id);
        #endregion
    }
}
