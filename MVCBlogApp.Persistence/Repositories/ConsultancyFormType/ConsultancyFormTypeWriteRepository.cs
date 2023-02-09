using MVCBlogApp.Application.Repositories.ConsultancyFormType;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ConsultancyFormType
{
    public class ConsultancyFormTypeWriteRepository : WriteRepository<E.ConsultancyFormType>, IConsultancyFormTypeWriteRepository
    {
        public ConsultancyFormTypeWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
