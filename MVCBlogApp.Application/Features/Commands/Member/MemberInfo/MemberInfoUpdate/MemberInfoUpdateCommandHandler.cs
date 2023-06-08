using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Member.MemberInfo.MemberInfoUpdate
{
    public class MemberInfoUpdateCommandHandler : IRequestHandler<MemberInfoUpdateCommandRequest, MemberInfoUpdateCommandResponse>
    {
        private readonly IMemberGeneralProcess _process;

        public MemberInfoUpdateCommandHandler(IMemberGeneralProcess process)
        {
            _process = process;
        }

        public async Task<MemberInfoUpdateCommandResponse> Handle(MemberInfoUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            MemberInfoUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);
            if (validation.IsValid)
            {
                return await _process.MemberInfoUpdateAsync(request);
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
