using MVCBlogApp.Application.Repositories.D_Specialties;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.D_Specialties
{
    public class D_SpecialtiesWriteRepository : WriteRepository<E.D_Specialties>, ID_SpecialtiesWriteRepository
    {
        public D_SpecialtiesWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
