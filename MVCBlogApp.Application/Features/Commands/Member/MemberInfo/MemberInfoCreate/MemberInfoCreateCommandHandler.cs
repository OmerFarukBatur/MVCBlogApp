using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Member.MemberInfo.MemberInfoCreate
{
    public class MemberInfoCreateCommandHandler : IRequestHandler<MemberInfoCreateCommandRequest, MemberInfoCreateCommandResponse>
    {
        private readonly IMemberGeneralProcess _process;

        public MemberInfoCreateCommandHandler(IMemberGeneralProcess process)
        {
            _process = process;
        }

        public async Task<MemberInfoCreateCommandResponse> Handle(MemberInfoCreateCommandRequest request, CancellationToken cancellationToken)
        {
            MemberInfoCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);
            if (validation.IsValid)
            {
                return await _process.MemberInfoCreateAsync(request);
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
