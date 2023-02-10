using MVCBlogApp.Application.Repositories.NewsPaper;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.NewsPaper
{
    public class NewsPaperWriteRepository : WriteRepository<E.NewsPaper>, INewsPaperWriteRepository
    {
        public NewsPaperWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
