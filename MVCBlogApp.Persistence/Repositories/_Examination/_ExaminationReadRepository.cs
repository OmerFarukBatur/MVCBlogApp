using MVCBlogApp.Application.Repositories._Examination;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories._Examination
{
    public class _ExaminationReadRepository : ReadRepository<E._Examination>, I_ExaminationReadRepository
    {
        public _ExaminationReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
