using MVCBlogApp.Application.Repositories.DiseasesDiabetes;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.DiseasesDiabetes
{
    public class DiseasesDiabetesReadRepository : ReadRepository<E.DiseasesDiabetes>, IDiseasesDiabetesReadRepository
    {
        public DiseasesDiabetesReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
