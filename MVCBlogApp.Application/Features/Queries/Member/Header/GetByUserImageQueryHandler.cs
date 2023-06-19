using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Member.Header
{
    public class GetByUserImageQueryHandler : IRequestHandler<GetByUserImageQueryRequest, GetByUserImageQueryResponse>
    {
        private readonly IMemberGeneralProcess _process;

        public GetByUserImageQueryHandler(IMemberGeneralProcess process)
        {
            _process = process;
        }

        public async Task<GetByUserImageQueryResponse> Handle(GetByUserImageQueryRequest request, CancellationToken cancellationToken)
        {
            return await _process.GetByUserImageAsync(request.Id);
        }
    }
}
