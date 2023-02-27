using MVCBlogApp.Application.Repositories.Examination;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Examination
{
    public class ExaminationWriteRepository : WriteRepository<E._Examination>, IExaminationWriteRepository
    {
        public ExaminationWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
