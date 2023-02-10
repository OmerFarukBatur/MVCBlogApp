using MVCBlogApp.Application.Repositories.Video;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Video
{
    public class VideoWriteRepository : WriteRepository<E.Video>, IVideoWriteRepository
    {
        public VideoWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
