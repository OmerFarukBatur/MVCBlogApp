using MVCBlogApp.Application.Repositories.Examination;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Examination
{
    public class ExaminationWriteRepository : WriteRepository<E.Examination>, IExaminationWriteRepository
    {
        public ExaminationWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
