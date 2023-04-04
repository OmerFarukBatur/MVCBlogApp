using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixFeedPyramid.GetFixFeedPyramidCreateItems
{
    public class GetFixFeedPyramidCreateItemsQueryHandler : IRequestHandler<GetFixFeedPyramidCreateItemsQueryRequest, GetFixFeedPyramidCreateItemsQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetFixFeedPyramidCreateItemsQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetFixFeedPyramidCreateItemsQueryResponse> Handle(GetFixFeedPyramidCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fixService.GetFixFeedPyramidCreateItemsAsync();
        }
    }
}
