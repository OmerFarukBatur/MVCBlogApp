using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Member.Contact.MemberContactCreate
{
    public class MemberContactCreateCommandHandler : IRequestHandler<MemberContactCreateCommandRequest, MemberContactCreateCommandResponse>
    {
        private readonly IMemberGeneralProcess _process;

        public MemberContactCreateCommandHandler(IMemberGeneralProcess process)
        {
            _process = process;
        }

        public async Task<MemberContactCreateCommandResponse> Handle(MemberContactCreateCommandRequest request, CancellationToken cancellationToken)
        {
            MemberContactCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);
            if (validation.IsValid)
            {
                return await _process.MemberContactCreateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanları geçerli değerlerle doldurunuz.",
                    State = false
                };
            }
        }
    }
}
