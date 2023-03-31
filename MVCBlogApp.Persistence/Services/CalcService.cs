using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.Calc.CalcBmhs.GetAllCalcBmhs;
using MVCBlogApp.Application.Features.Queries.Calc.CalcBMIs.GetAllCalcBMIs;
using MVCBlogApp.Application.Features.Queries.Calc.CalcOptimums.GetAllCalcOptimums;
using MVCBlogApp.Application.Features.Queries.Calc.CalcPulses.GetAllCalcPulses;
using MVCBlogApp.Application.Repositories.CalcBmh;
using MVCBlogApp.Application.Repositories.CalcBMI;
using MVCBlogApp.Application.Repositories.CalcOptimum;
using MVCBlogApp.Application.Repositories.CalcPulse;
using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Persistence.Services
{
    public class CalcService : ICalcService
    {
        private readonly ICalcBmhReadRepository _calcBmhReadRepository;
        private readonly ICalcBMIReadRepository _calcBMIReadRepository;
        private readonly ICalcOptimumReadRepository _calcOptimumReadRepository;
        private readonly ICalcPulseReadRepository _calcPulseReadRepository;

        public CalcService(
            ICalcBmhReadRepository calcBmhReadRepository,
            ICalcBMIReadRepository calcBMIReadRepository,
            ICalcOptimumReadRepository calcOptimumReadRepository,
            ICalcPulseReadRepository calcPulseReadRepository
            )
        {
            _calcBmhReadRepository = calcBmhReadRepository;
            _calcBMIReadRepository = calcBMIReadRepository;
            _calcOptimumReadRepository = calcOptimumReadRepository;
            _calcPulseReadRepository = calcPulseReadRepository;
        }


        #region CalcBmhs

        public async Task<GetAllCalcBmhsQueryResponse> GetAllCalcBmhsAsync()
        {
            List<VM_CalcBmh> vM_CalcBmhs = await _calcBmhReadRepository.GetAll()
                .Select(x => new VM_CalcBmh
                {
                    Id = x.Id,
                    NameSurname = x.NameSurname,
                    Email = x.Email,
                    Age = x.Age,
                    Gender = x.Gender,
                    Size = x.Size,
                    Weight = x.Weight,
                    Result = x.Result
                }).ToListAsync();

            return new()
            {
                CalcBmhs = vM_CalcBmhs
            };
        }

        #endregion

        #region CalcBMIs

        public async Task<GetAllCalcBMIsQueryResponse> GetAllCalcBMIsAsync()
        {
            List<VM_CalcBMI> vM_CalcBMIs = await _calcBMIReadRepository.GetAll()
                .Select(x => new VM_CalcBMI
                {
                    Id = x.Id,
                    NameSurname = x.NameSurname,
                    Email = x.Email,
                    Age = x.Age,
                    Size = x.Size,
                    Weight = x.Weight,
                    Result = x.Result
                }).ToListAsync();

            return new()
            {
                CalcBMIs = vM_CalcBMIs
            };
        }

        #endregion

        #region CalcOptimums

        public async Task<GetAllCalcOptimumsQueryResponse> GetAllCalcOptimumsAsync()
        {
            List<VM_CalcOptimum> vM_CalcOptimums = await _calcOptimumReadRepository.GetAll()
                .Select(x => new VM_CalcOptimum
                {
                    Id = x.Id,
                    Email = x.Email,
                    Age = x.Age,
                    Gender = x.Gender,
                    NameSurname = x.NameSurname,
                    Result1 = x.Result1,
                    Result2 = x.Result2,
                    Result3 = x.Result3,
                    Result4 = x.Result4,
                    Size = x.Size,
                    Weight = x.Weight,
                }).ToListAsync();

            return new()
            {
                CalcOptimums = vM_CalcOptimums
            };
        }

        #endregion

        #region CalcPulses

        public async Task<GetAllCalcPulsesQueryResponse> GetAllCalcPulsesAsync()
        {
            List<VM_CalcPulse> vM_CalcPulses = await _calcPulseReadRepository.GetAll()
                .Select(x => new VM_CalcPulse
                {
                    Id = x.Id,
                    NameSurname = x.NameSurname,
                    Email = x.Email,
                    Age = x.Age,
                    Gender = x.Gender,
                    ResultMax = x.ResultMax,
                    ResultMin = x.ResultMin
                }).ToListAsync();

            return new()
            {
                CalcPulses = vM_CalcPulses
            };
        }

        #endregion

    }
}
