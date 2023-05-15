using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Examination.GetAllExamination
{
    public class GetAllExaminationQueryHandler : IRequestHandler<GetAllExaminationQueryRequest, GetAllExaminationQueryResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public GetAllExaminationQueryHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<GetAllExaminationQueryResponse> Handle(GetAllExaminationQueryRequest request, CancellationToken cancellationToken)
        {
            return await _optionsService.GetAllExaminationAsync();
        }
    }
}
