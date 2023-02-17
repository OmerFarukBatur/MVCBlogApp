using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminUpdate
{
    public class AdminUpdateCommandHandler : IRequestHandler<AdminUpdateCommandRequest, AdminUpdateCommandResponse>
    {
        public Task<AdminUpdateCommandResponse> Handle(AdminUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
