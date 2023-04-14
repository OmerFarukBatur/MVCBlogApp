using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberNutritionist.GetAllMemberNutritionist
{
    public class GetAllMemberNutritionistQueryHandler : IRequestHandler<GetAllMemberNutritionistQueryRequest, GetAllMemberNutritionistQueryResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public GetAllMemberNutritionistQueryHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<GetAllMemberNutritionistQueryResponse> Handle(GetAllMemberNutritionistQueryRequest request, CancellationToken cancellationToken)
        {
            return await _userIslemleriService.GetAllMemberNutritionistAsync();
        }
    }
}
