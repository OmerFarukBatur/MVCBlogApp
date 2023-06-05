using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Application.Features.Commands.Member.MemberInfo.MemberInfoCreate
{
    public class MemberInfoCreateCommandHandler : IRequestHandler<MemberInfoCreateCommandRequest, MemberInfoCreateCommandResponse>
    {
        public Task<MemberInfoCreateCommandResponse> Handle(MemberInfoCreateCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
