using MVCBlogApp.Application.Repositories.DiseasesFamilyMembers;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.DiseasesFamilyMembers
{
    public class DiseasesFamilyMembersWriteRepository : WriteRepository<E.DiseasesFamilyMembers>, IDiseasesFamilyMembersWriteRepository
    {
        public DiseasesFamilyMembersWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
