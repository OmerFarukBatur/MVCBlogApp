using MediatR;
using MVCBlogApp.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AdminRoleList
{
    public class AdminRoleListQueryHandler : IRequestHandler<AdminRoleListQueryRequest, AdminRoleListQueryResponse>
    {
        private readonly IYoneticiIslemleri _yoneticiIslemleri;

        public AdminRoleListQueryHandler(IYoneticiIslemleri yoneticiIslemleri)
        {
            _yoneticiIslemleri = yoneticiIslemleri;
        }

        public async Task<AdminRoleListQueryResponse> Handle(AdminRoleListQueryRequest request, CancellationToken cancellationToken)
        {
            return await _yoneticiIslemleri.AdminListRole();
        }
    }
}
