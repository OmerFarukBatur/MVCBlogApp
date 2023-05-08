using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Application.Features.Commands.Doctor.ByIdAppointmentDateTimeUpdate
{
    public class ByIdAppointmentDateTimeUpdateCommandHandler : IRequestHandler<ByIdAppointmentDateTimeUpdateCommandRequest, ByIdAppointmentDateTimeUpdateCommandResponse>
    {
        public Task<ByIdAppointmentDateTimeUpdateCommandResponse> Handle(ByIdAppointmentDateTimeUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

