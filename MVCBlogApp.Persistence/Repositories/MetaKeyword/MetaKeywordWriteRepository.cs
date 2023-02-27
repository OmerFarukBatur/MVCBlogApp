using MVCBlogApp.Application.Repositories.MetaKeyword;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.MembersDetail
{
    public class MetaKeywordWriteRepository : WriteRepository<E.MetaKeyword>, IMetaKeywordWriteRepository
    {
        public MetaKeywordWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
