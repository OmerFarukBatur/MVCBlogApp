using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Repositories.ImageBlog
{
    public interface IImageBlogWriteRepository : IWriteRepository<E.ImageBlog>
    {
    }
}
