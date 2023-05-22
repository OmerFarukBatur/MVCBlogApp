using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.MembersInformation.GetByIdMembersInformation
{
    public class GetByIdMIQueryHandler : IRequestHandler<GetByIdMIQueryRequest, GetByIdMIQueryResponse>
    {
        public Task<GetByIdMIQueryResponse> Handle(GetByIdMIQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
