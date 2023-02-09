using MVCBlogApp.Application.Repositories.ConsultancyForm;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ConsultancyForm
{
    public class ConsultancyFormReadRepository : ReadRepository<E.ConsultancyForm>, IConsultancyFormReadRepository
    {
        public ConsultancyFormReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
