using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Repositories.Days;
using MVCBlogApp.Application.Repositories.Meal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Persistence.Services
{
    public class DoctorGeneralOptionsService : IDoctorGeneralOptionsService
    {
        private readonly IDaysReadRepository _daysReadRepository;
        private readonly IDaysWriteRepository _daysWriteRepository;
        private readonly IMealReadRepository _mealReadRepository;
        private readonly IMealWriteRepository _mealWriteRepository;

        public DoctorGeneralOptionsService(
            IDaysReadRepository daysReadRepository, 
            IDaysWriteRepository daysWriteRepository, 
            IMealReadRepository mealReadRepository, 
            IMealWriteRepository mealWriteRepository)
        {
            _daysReadRepository = daysReadRepository;
            _daysWriteRepository = daysWriteRepository;
            _mealReadRepository = mealReadRepository;
            _mealWriteRepository = mealWriteRepository;
        }

        #region Day



        #endregion

        #region Meal



        #endregion
    }
}
