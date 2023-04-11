using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.UserIslemleri.Confession.ConfessionCreate
{
    public class ConfessionCreateCommandHandler : IRequestHandler<ConfessionCreateCommandRequest, ConfessionCreateCommandResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public ConfessionCreateCommandHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<ConfessionCreateCommandResponse> Handle(ConfessionCreateCommandRequest request, CancellationToken cancellationToken)
        {
            ConfessionCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _userIslemleriService.ConfessionCreateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanları geçerli değerler ile doldurunuz.",
                    State = false
                };
            }
        }
    }
}
