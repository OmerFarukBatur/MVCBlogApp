using MVCBlogApp.Application.Repositories.ImageBlog;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ImageBlog
{
    public class ImageBlogReadRepository : ReadRepository<E.ImageBlog>, IImageBlogReadRepository
    {
        public ImageBlogReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
