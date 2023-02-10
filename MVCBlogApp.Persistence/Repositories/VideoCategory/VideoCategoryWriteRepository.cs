using MVCBlogApp.Application.Repositories.VideoCategory;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.VideoCategory
{
    public class VideoCategoryWriteRepository : WriteRepository<E.VideoCategory>, IVideoCategoryWriteRepository
    {
        public VideoCategoryWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
