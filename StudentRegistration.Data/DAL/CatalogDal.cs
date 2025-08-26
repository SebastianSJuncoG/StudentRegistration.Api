using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.Data.Interfaces;
using StudentRegistration.Data.Models;

namespace StudentRegistration.Data.DAL
{
    public class CatalogDal : ICatalogsRepository
    {
        private readonly StudentRegistrationContext _dbContext;

        public CatalogDal(StudentRegistrationContext context)
        {
            _dbContext = context;
        }

        #region Tipos de identificación
        public async Task<IEnumerable<IdentificationType>> GetIdentificationType()
        {
            return await _dbContext.IdentificationTypes.ToListAsync();
        }

        public async Task<IdentificationType> GetIdentificationTypeId(int Id)
        {
            return await _dbContext.IdentificationTypes.FirstOrDefaultAsync(w => w.IdIdentificationType == Id) ?? new IdentificationType();
        }
        #endregion

        #region Tipo de eventos
        public async Task<IEnumerable<TypeOfEvent>> GetTypeOfEvent()
        {
            return await _dbContext.TypeOfEvents.ToListAsync();
        }

        public async Task<TypeOfEvent> GetTypeOfEventId(int Id)
        {
            return await _dbContext.TypeOfEvents.FirstOrDefaultAsync(w => w.Id == Id) ?? new TypeOfEvent();
        }
        #endregion
    }
}
