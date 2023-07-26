using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIPress.MedyaYansimalariPartialView
{
    public class MedyaYansimalariPartialViewQueryHandler : IRequestHandler<MedyaYansimalariPartialViewQueryRequest, MedyaYansimalariPartialViewQueryResponse>
    {
        private readonly IUIOtherService _service;

        public MedyaYansimalariPartialViewQueryHandler(IUIOtherService service)
        {
            _service = service;
        }

        public async Task<MedyaYansimalariPartialViewQueryResponse> Handle(MedyaYansimalariPartialViewQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.MedyaYansimalariPartialAsync(request);
        }
    }
}
