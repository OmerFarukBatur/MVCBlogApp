using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.File.Video.GetByIdVideo
{
    public class GetByIdVideoQueryHandler : IRequestHandler<GetByIdVideoQueryRequest, GetByIdVideoQueryResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public GetByIdVideoQueryHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<GetByIdVideoQueryResponse> Handle(GetByIdVideoQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fileProcessService.GetByIdVideoAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Languages = null,
                    Statuses = null,
                    Video = null,
                    VideoCategories = null,
                    Message = "Lütfen geçerli değerler giriniz.",
                    State = false
                };
            }
        }
    }
}
