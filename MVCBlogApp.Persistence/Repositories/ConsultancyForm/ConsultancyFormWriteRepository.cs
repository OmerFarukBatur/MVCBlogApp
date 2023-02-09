using MVCBlogApp.Application.Repositories.ConsultancyForm;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ConsultancyForm
{
    public class ConsultancyFormWriteRepository : WriteRepository<E.ConsultancyForm>, IConsultancyFormWriteRepository
    {
        public ConsultancyFormWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
