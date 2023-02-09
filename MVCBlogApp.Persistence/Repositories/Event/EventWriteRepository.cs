using MVCBlogApp.Application.Repositories.Event;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Event
{
    public class EventWriteRepository : WriteRepository<E.Event>, IEventWriteRepository
    {
        public EventWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
