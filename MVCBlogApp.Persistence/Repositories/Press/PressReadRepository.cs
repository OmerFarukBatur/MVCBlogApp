using MVCBlogApp.Application.Repositories.Press;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Press
{
    public class PressReadRepository : ReadRepository<E.Press>, IPressReadRepository
    {
        public PressReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
