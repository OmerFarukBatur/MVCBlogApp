using MVCBlogApp.Application.Repositories.MetaKeyword;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.MembersDetail
{
    public class MetaKeywordReadRepository : ReadRepository<E.MetaKeyword>, IMetaKeywordReadRepository
    {
        public MetaKeywordReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
