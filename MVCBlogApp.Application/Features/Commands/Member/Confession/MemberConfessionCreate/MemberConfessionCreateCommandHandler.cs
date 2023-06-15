using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Member.Confession.MemberConfessionCreate
{
    public class MemberConfessionCreateCommandHandler : IRequestHandler<MemberConfessionCreateCommandRequest, MemberConfessionCreateCommandResponse>
    {
        private readonly IMemberGeneralProcess _memberGeneralProcess;

        public MemberConfessionCreateCommandHandler(IMemberGeneralProcess memberGeneralProcess)
        {
            _memberGeneralProcess = memberGeneralProcess;
        }

        public async Task<MemberConfessionCreateCommandResponse> Handle(MemberConfessionCreateCommandRequest request, CancellationToken cancellationToken)
        {
            MemberConfessionCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);
            if (validation.IsValid)
            {
                return await _memberGeneralProcess.MemberConfessionCreateAsync(request);
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
