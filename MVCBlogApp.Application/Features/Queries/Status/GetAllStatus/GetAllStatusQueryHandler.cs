using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Status.GetAllStatus
{
    public class GetAllStatusQueryHandler : IRequestHandler<GetAllStatusQueryRequest, GetAllStatusQueryResponse>
    {
        private readonly IStatusReadRepository _statusReadRepository;

        public GetAllStatusQueryHandler(IStatusReadRepository statusReadRepository)
        {
            _statusReadRepository = statusReadRepository;
        }

        public async Task<GetAllStatusQueryResponse> Handle(GetAllStatusQueryRequest request, CancellationToken cancellationToken)
        {
            List<AllStatus> status = await _statusReadRepository.GetAll().Select(a => new AllStatus
            {
                Id = a.Id,
                StatusName = a.StatusName
            }).ToListAsync();
            return new()
            {
                AllStatus = status
            };
        }
    }
}
