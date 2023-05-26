using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberAppointment.GetByIdDietList
{
    public class GetByIdDietListQueryHandler : IRequestHandler<GetByIdDietListQueryRequest, GetByIdDietListQueryResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public GetByIdDietListQueryHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<GetByIdDietListQueryResponse> Handle(GetByIdDietListQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _userIslemleriService.GetByIdDietListAsync(request.Id);
            }
            else
            {
                return new()
                {
                    DaysMeals = null,
                    DietList = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
