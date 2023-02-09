using MVCBlogApp.Application.Repositories.D_Appointment;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.D_Appointment
{
    public class D_AppointmentWriteRepository : WriteRepository<E.D_Appointment>, ID_AppointmentWriteRepository
    {
        public D_AppointmentWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
