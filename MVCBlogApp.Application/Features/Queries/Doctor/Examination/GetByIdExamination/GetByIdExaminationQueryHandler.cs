using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Examination.GetByIdExamination
{
    public class GetByIdExaminationQueryHandler : IRequestHandler<GetByIdExaminationQueryRequest, GetByIdExaminationQueryResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public GetByIdExaminationQueryHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<GetByIdExaminationQueryResponse> Handle(GetByIdExaminationQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _optionsService.GetByIdExaminationAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Examination = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
