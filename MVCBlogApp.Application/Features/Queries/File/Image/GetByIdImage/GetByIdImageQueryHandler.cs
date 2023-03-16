using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.File.Image.GetByIdImage
{
    public class GetByIdImageQueryHandler : IRequestHandler<GetByIdImageQueryRequest, GetByIdImageQueryResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public GetByIdImageQueryHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<GetByIdImageQueryResponse> Handle(GetByIdImageQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fileProcessService.GetByIdImageAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Image = null,
                    Languages = null,
                    Statuses = null,
                    State = false,
                    Message = "Lütfen geçerli değerler giriniz."
                };
            }
        }
    }
}
