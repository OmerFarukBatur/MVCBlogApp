using MVCBlogApp.Application.Repositories.DiseasesFamilyMembers;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.DiseasesFamilyMembers
{
    public class DiseasesFamilyMembersReadRepository : ReadRepository<E.DiseasesFamilyMembers>, IDiseasesFamilyMembersReadRepository
    {
        public DiseasesFamilyMembersReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
