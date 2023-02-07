using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
