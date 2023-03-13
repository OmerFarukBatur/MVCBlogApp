using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Result.ResultBMhs.ResultBMhsCreate;
using MVCBlogApp.Application.Features.Commands.Result.ResultBMhs.ResultBMhsDelete;
using MVCBlogApp.Application.Features.Commands.Result.ResultBMhs.ResultBMhsUpdate;
using MVCBlogApp.Application.Features.Commands.Result.ResultBMIs.ResultBMIsCreate;
using MVCBlogApp.Application.Features.Commands.Result.ResultBMIs.ResultBMIsDelete;
using MVCBlogApp.Application.Features.Commands.Result.ResultBMIs.ResultBMIsUpdate;
using MVCBlogApp.Application.Features.Queries.Result.ResultBMhs.GetAllResultBMhs;
using MVCBlogApp.Application.Features.Queries.Result.ResultBMhs.GetByIdResultBMhs;
using MVCBlogApp.Application.Features.Queries.Result.ResultBMIs.GetAllResultBMI;
using MVCBlogApp.Application.Features.Queries.Result.ResultBMIs.GetByIdResultBMI;
using MVCBlogApp.Application.Repositories.ResultBMh;
using MVCBlogApp.Application.Repositories.ResultBMI;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;
using System.Globalization;

namespace MVCBlogApp.Persistence.Services
{
    public class ResultIslemleriService : IResultIslemleriService
    {
        private readonly IResultBMhReadRepository _bmhReadRepository;
        private readonly IResultBMhWriteRepository _bmhWriteRepository;
        private readonly IResultBMIReadRepository _bmiReadRepository;
        private readonly IResultBMIWriteRepository _bmiWriteRepository;

        public ResultIslemleriService(
            IResultBMhReadRepository bmhReadRepository,
            IResultBMhWriteRepository bmhWriteRepository
,
            IResultBMIReadRepository bmiReadRepository,
            IResultBMIWriteRepository bmiWriteRepository)
        {
            _bmhReadRepository = bmhReadRepository;
            _bmhWriteRepository = bmhWriteRepository;
            _bmiReadRepository = bmiReadRepository;
            _bmiWriteRepository = bmiWriteRepository;
        }


        #region ResultBMhs

        public async Task<ResultBMhsCreateCommandResponse> ResultBMhsCreateAsync(ResultBMhsCreateCommandRequest request)
        {
            var check = await _bmhReadRepository
                .GetWhere(x => x.Resulttext.Trim().ToLower() == request.ResultText.Trim().ToLower() || x.Resulttext.Trim().ToUpper() == request.ResultText.Trim().ToUpper()).ToListAsync();

            if (check.Count() > 0)
            {
                return new()
                {
                    Message = "Bu bilgilere sahip kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                ResultBmh resultBmh = new() { Resulttext = request.ResultText };
                await _bmhWriteRepository.AddAsync(resultBmh);
                await _bmhWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetAllResultBMhsQueryResponse> GetAllResultBMhsAsync()
        {
            List<VM_ResultBMhs> vM_ResultBMhs = await _bmhReadRepository.GetAll()
                .Select(x => new VM_ResultBMhs
                {
                    Id = x.Id,
                    ResultText = x.Resulttext
                }).ToListAsync();

            return new() { ResultBMhs = vM_ResultBMhs };
        }

        public async Task<GetByIdResultBMhsQueryResponse> GetByIdResultBMhsAsync(int id)
        {
            VM_ResultBMhs? vM_ResultBMhs = await _bmhReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_ResultBMhs
                {
                    Id = x.Id,
                    ResultText = x.Resulttext
                }).FirstOrDefaultAsync();

            if (vM_ResultBMhs != null)
            {
                return new()
                {
                    ResultBMhs = vM_ResultBMhs,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    State = false,
                    Message = "Bu bilgilere ait kayıt bulunmamaktadır.",
                    ResultBMhs = null
                };
            }
        }

        public async Task<ResultBMhsUpdateCommandResponse> ResultBMhsUpdateAsync(ResultBMhsUpdateCommandRequest request)
        {
            ResultBmh resultBmh = await _bmhReadRepository.GetByIdAsync(request.Id);

            if (resultBmh != null)
            {
                resultBmh.Resulttext = request.ResultText;
                _bmhWriteRepository.Update(resultBmh);
                await _bmhWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Güncelleme işlemi başarılı bir şekilde yapılmıştır.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Bu bilgilere ait kayıt bulunmamaktadır.",
                    State = false
                };
            }
        }

        public async Task<ResultBMhsDeleteCommandResponse> ResultBMhsDeleteAsync(int id)
        {
            ResultBmh resultBmh = await _bmhReadRepository.GetByIdAsync(id);

            if (resultBmh != null)
            {
                _bmhWriteRepository.Remove(resultBmh);
                await _bmhWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Silme işlemi başarılı bir şekilde yapılmıştır.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Bu bilgilere ait kayıt bulunmamaktadır.",
                    State = false
                };
            }
        }


        #endregion

        #region ResultBMIs

        public async Task<ResultBMIsCreateCommandResponse> ResultBMIsCreateAsync(ResultBMIsCreateCommandRequest request)
        {
            var check = await _bmiReadRepository
                .GetWhere(x => x.IntervalDescription.Trim().ToLower() == request.IntervalDescription.Trim().ToLower() || x.IntervalDescription.Trim().ToUpper() == request.IntervalDescription.Trim().ToUpper()).ToListAsync();

            if (check.Count() > 0)
            {
                return new()
                {
                    Message = "Bu bilgilere sahip kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {                
                var clone = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                clone.NumberFormat.NumberDecimalSeparator = ".";

                ResultBMI resultBMI = new()
                {
                    IntervalDescription = request.IntervalDescription,
                    IntervalMax = Decimal.Parse(request.IntervalMax, clone),
                    IntervalMin = Decimal.Parse(request.IntervalMin, clone)
                };

                await _bmiWriteRepository.AddAsync(resultBMI);
                await _bmiWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarılı birşekilde yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetAllResultBMIQueryResponse> GetAllResultBMIAsync()
        {
            List<VM_ResultBMI> vM_ResultBMIs = await _bmiReadRepository.GetAll()
                .Select(x=> new VM_ResultBMI
                {
                    Id = x.Id,
                    IntervalDescription = x.IntervalDescription,
                    IntervalMax= x.IntervalMax,
                    IntervalMin= x.IntervalMin
                }).ToListAsync();
            return new()
            {
                ResultBMIs = vM_ResultBMIs
            };
        }

        public async Task<GetByIdResultBMIQueryResponse> GetByIdResultBMIAsync(int id)
        {
            VM_ResultBMI? vM_ResultBMI = await _bmiReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_ResultBMI
                {
                    Id = x.Id,
                    IntervalDescription = x.IntervalDescription,
                    IntervalMax = x.IntervalMax,
                    IntervalMin = x.IntervalMin
                }).FirstOrDefaultAsync();

            if (vM_ResultBMI != null)
            {
                return new()
                {
                    ResultBMI = vM_ResultBMI,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Bu bilgilere sahip kayıt bulunmamaktadır.",
                    State = false,
                    ResultBMI = null
                };
            }
        }

        public async Task<ResultBMIsUpdateCommandResponse> ResultBMIsUpdateAsync(ResultBMIsUpdateCommandRequest request)
        {
           ResultBMI resultBMI = await _bmiReadRepository.GetByIdAsync(request.Id);

            if (resultBMI != null)
            {
                var clone = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                clone.NumberFormat.NumberDecimalSeparator = ".";

                resultBMI.IntervalMax = Decimal.Parse(request.IntervalMax, clone);
                resultBMI.IntervalMin = Decimal.Parse(request.IntervalMin, clone);
                resultBMI.IntervalDescription = request.IntervalDescription;

                _bmiWriteRepository.Update(resultBMI);
                await _bmiWriteRepository.SaveAsync();

                return new()
                {
                    State = true,
                    Message = "Güncelleme işlemi başarıyla yapılmıştır."
                };
            }
            else
            {
                return new()
                {
                    Message = "Bu bilgiye ait kayıt bulunmamaktadır.",
                    State = false
                };
            }
        }

        public async Task<ResultBMIsDeleteCommandResponse> ResultBMIsDeleteAsync(int id)
        {
            ResultBMI resultBMI = await _bmiReadRepository.GetByIdAsync(id);
            if (resultBMI != null)
            {
                _bmiWriteRepository.Remove(resultBMI);
                await _bmiWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Silme işlemi başarılı bir şekilde yapıldı.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Bu bilgiye ait kayıt bulunamadı.",
                    State = false
                };
            }
        }


        #endregion

        #region ResultOptimums



        #endregion

        #region ResultPulses



        #endregion

    }
}
