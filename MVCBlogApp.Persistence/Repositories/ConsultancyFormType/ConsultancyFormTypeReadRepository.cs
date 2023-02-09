using MVCBlogApp.Application.Repositories.ConsultancyFormType;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ConsultancyFormType
{
    public class ConsultancyFormTypeReadRepository : ReadRepository<E.ConsultancyFormType>, IConsultancyFormTypeReadRepository
    {
        public ConsultancyFormTypeReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
