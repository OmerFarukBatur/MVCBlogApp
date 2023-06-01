using MVCBlogApp.Application.Features.Queries.Member.GetByIdMemberInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IMemberGeneralProcess
    {
        Task<GetByIdMemberInfoQueryResponse> GetByIdMemberAsync(int id);
    }
}
