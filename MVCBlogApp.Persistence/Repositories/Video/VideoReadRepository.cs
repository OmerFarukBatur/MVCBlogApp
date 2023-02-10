using MVCBlogApp.Application.Repositories.Video;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Video
{
    public class VideoReadRepository : ReadRepository<E.Video>, IVideoReadRepository
    {
        public VideoReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
