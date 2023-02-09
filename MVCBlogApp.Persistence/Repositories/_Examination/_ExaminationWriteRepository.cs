using MVCBlogApp.Application.Repositories._Examination;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories._Examination
{
    public class _ExaminationWriteRepository : WriteRepository<E._Examination>, I_ExaminationWriteRepository
    {
        public _ExaminationWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
