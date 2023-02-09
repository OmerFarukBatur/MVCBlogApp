using MVCBlogApp.Application.Repositories.D_Specialties;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.D_Specialties
{
    public class D_SpecialtiesReadRepository : ReadRepository<E.D_Specialties>, ID_SpecialtiesReadRepository
    {
        public D_SpecialtiesReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
