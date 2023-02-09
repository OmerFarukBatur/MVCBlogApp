using MVCBlogApp.Application.Repositories.Event;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Event
{
    public class EventReadRepository : ReadRepository<E.Event>, IEventReadRepository
    {
        public EventReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
