using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberAppointment.GetByIdLab
{
    public class GetByIdLabQueryHandler : IRequestHandler<GetByIdLabQueryRequest, GetByIdLabQueryResponse>
    {
        public Task<GetByIdLabQueryResponse> Handle(GetByIdLabQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
