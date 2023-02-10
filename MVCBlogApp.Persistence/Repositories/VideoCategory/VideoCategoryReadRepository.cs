using MVCBlogApp.Application.Repositories.VideoCategory;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.VideoCategory
{
    public class VideoCategoryReadRepository : ReadRepository<E.VideoCategory>, IVideoCategoryReadRepository
    {
        public VideoCategoryReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
