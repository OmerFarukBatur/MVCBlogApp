using MVCBlogApp.Application.Repositories.Examination;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Examination
{
    public class ExaminationReadRepository : ReadRepository<E.Examination>, IExaminationReadRepository
    {
        public ExaminationReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
