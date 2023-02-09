using MVCBlogApp.Application.Repositories.DiseasesDiabetes;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.DiseasesDiabetes
{
    public class DiseasesDiabetesWriteRepository : WriteRepository<E.DiseasesDiabetes>, IDiseasesDiabetesWriteRepository
    {
        public DiseasesDiabetesWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
