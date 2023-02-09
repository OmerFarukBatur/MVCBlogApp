using MVCBlogApp.Application.Repositories.EventCategory;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.EventCategory
{
    public class EventCategoryWriteRepository : WriteRepository<E.EventCategory>, IEventCategoryWriteRepository
    {
        public EventCategoryWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
