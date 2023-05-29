using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryCreate;
using MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetAllEventCategory;
using MVCBlogApp.Application.Repositories.Event;
using MVCBlogApp.Application.Repositories.EventCategory;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Services
{
    public class AdminGeneralProcess : IAdminGeneralProcess
    {
        private readonly IEventReadRepository _eventReadRepository;
        private readonly IEventWriteRepository _eventWriteRepository;
        private readonly IEventCategoryReadRepository _eventCategoryReadRepository;
        private readonly IEventCategoryWriteRepository _eventCategoryWriteRepository;

        public AdminGeneralProcess(
            IEventReadRepository eventReadRepository, 
            IEventWriteRepository eventWriteRepository, 
            IEventCategoryReadRepository eventCategoryReadRepository, 
            IEventCategoryWriteRepository eventCategoryWriteRepository
            )
        {
            _eventReadRepository = eventReadRepository;
            _eventWriteRepository = eventWriteRepository;
            _eventCategoryReadRepository = eventCategoryReadRepository;
            _eventCategoryWriteRepository = eventCategoryWriteRepository;
        }

        
        #region AdminCalendar

        #region Event



        #endregion

        #region EventCategory

        public async Task<GetAllEventCategoryQueryResponse> GetAllEventCategoryAsync()
        {
            List<VM_EventCategory> vM_EventCategories = await _eventCategoryReadRepository.GetAll()
                .Select(x => new VM_EventCategory
                {
                    Id = x.Id,
                    EventCategoryName = x.EventCategoryName
                }).ToListAsync();

            return new()
            {
                EventCategories = vM_EventCategories
            };
        }

        public async Task<EventCategoryCreateCommandResponse> EventCategoryCreateAsync(EventCategoryCreateCommandRequest request)
        {
            var check = await _eventCategoryReadRepository
                .GetWhere(x => x.EventCategoryName.Trim().ToLower() == request.EventCategoryName.Trim().ToLower() || x.EventCategoryName.Trim().ToUpper() == request.EventCategoryName.Trim().ToUpper()).ToListAsync();

            if (check.Count() > 0)
            {
                return new()
                {
                    Message = "Bilgilere ait kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                EventCategory eventCategory = new()
                {
                    EventCategoryName = request.EventCategoryName
                };

                await _eventCategoryWriteRepository.AddAsync(eventCategory);
                await _eventCategoryWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }



        #endregion

        #endregion
    }
}
