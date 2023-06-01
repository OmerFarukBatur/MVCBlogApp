using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Member.GetByIdMemberInfo
{
    public class GetByIdMemberInfoQueryHandler : IRequestHandler<GetByIdMemberInfoQueryRequest, GetByIdMemberInfoQueryResponse>
    {
        private readonly IMemberGeneralProcess _process;

        public GetByIdMemberInfoQueryHandler(IMemberGeneralProcess process)
        {
            _process = process;
        }

        public async Task<GetByIdMemberInfoQueryResponse> Handle(GetByIdMemberInfoQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _process.GetByIdMemberAsync(request.Id);
            }
            else
            {
                return new()
                {
                    MemberAllDetail = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
