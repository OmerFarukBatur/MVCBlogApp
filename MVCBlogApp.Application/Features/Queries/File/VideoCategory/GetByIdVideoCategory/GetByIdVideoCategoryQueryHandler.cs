using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetByIdVideoCategory
{
    public class GetByIdVideoCategoryQueryHandler : IRequestHandler<GetByIdVideoCategoryQueryRequest, GetByIdVideoCategoryQueryResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public GetByIdVideoCategoryQueryHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<GetByIdVideoCategoryQueryResponse> Handle(GetByIdVideoCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fileProcessService.GetByIdVideoCategoryAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Languages = null,
                    Statuses = null,
                    VideoCategory = null,
                    Message = "Lütfen geçerli değerler giriniz.",
                    State = false
                };
            }
        }
    }
}
