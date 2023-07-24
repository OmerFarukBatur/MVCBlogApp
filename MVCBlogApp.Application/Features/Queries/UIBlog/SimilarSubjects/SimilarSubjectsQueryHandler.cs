using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIBlog.SimilarSubjects
{
    public class SimilarSubjectsQueryHandler : IRequestHandler<SimilarSubjectsQueryRequest, SimilarSubjectsQueryResponse>
    {
        private readonly IUIOtherService _service;

        public SimilarSubjectsQueryHandler(IUIOtherService service)
        {
            _service = service;
        }

        public async Task<SimilarSubjectsQueryResponse> Handle(SimilarSubjectsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.SimilarSubjectsAsync(request);
        }
    }
}
