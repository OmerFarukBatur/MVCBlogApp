using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.UserIslemleri.Confession.ConfessionUpdate
{
    public class ConfessionUpdateCommandHandler : IRequestHandler<ConfessionUpdateCommandRequest, ConfessionUpdateCommandResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public ConfessionUpdateCommandHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<ConfessionUpdateCommandResponse> Handle(ConfessionUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            ConfessionUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _userIslemleriService.ConfessionUpdateAsync(request);
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
