using MediatR;
using MVCBlogApp.Application.Repositories.Status;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Features.Queries.Status.GetByIdStatus
{
    public class GetByIdStatusQueryHandler : IRequestHandler<GetByIdStatusQueryRequest, GetByIdStatusQueryResponse>
    {
        private readonly IStatusReadRepository _statusReadRepository;

        public GetByIdStatusQueryHandler(IStatusReadRepository statusReadRepository)
        {
            _statusReadRepository = statusReadRepository;
        }

        public async Task<GetByIdStatusQueryResponse> Handle(GetByIdStatusQueryRequest request, CancellationToken cancellationToken)
        {
            E.Status status = await _statusReadRepository.GetByIdAsync(request.Id);

            if (status != null)
            {
                return new()
                {
                    Status = new()
                    {
                        Id = status.ID,
                        StatusName = status.StatusName
                    },
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Status = null,
                    State = false
                };
            }            
        }
    }
}
