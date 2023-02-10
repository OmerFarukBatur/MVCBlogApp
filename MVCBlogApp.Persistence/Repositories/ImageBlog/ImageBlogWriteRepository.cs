using MVCBlogApp.Application.Repositories.ImageBlog;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ImageBlog
{
    public class ImageBlogWriteRepository : WriteRepository<E.ImageBlog>, IImageBlogWriteRepository
    {
        public ImageBlogWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
