using MVCBlogApp.Application.Repositories.EventCategory;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.EventCategory
{
    public class EventCategoryReadRepository : ReadRepository<E.EventCategory>, IEventCategoryReadRepository
    {
        public EventCategoryReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
