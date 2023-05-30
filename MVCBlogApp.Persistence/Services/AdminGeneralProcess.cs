using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Admin.Event.EventCreate;
using MVCBlogApp.Application.Features.Commands.Admin.Event.EventDelete;
using MVCBlogApp.Application.Features.Commands.Admin.Event.EventUpdate;
using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryCreate;
using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryDelete;
using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryUpdate;
using MVCBlogApp.Application.Features.Queries.Admin.Event.GetAllEvent;
using MVCBlogApp.Application.Features.Queries.Admin.Event.GetByIdEvent;
using MVCBlogApp.Application.Features.Queries.Admin.Event.GetEventCreateItems;
using MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetAllEventCategory;
using MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetByIdEventCategory;
using MVCBlogApp.Application.Repositories.Event;
using MVCBlogApp.Application.Repositories.EventCategory;
using MVCBlogApp.Application.Repositories.Status;
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
        private readonly IStatusReadRepository _statusReadRepository;

        public AdminGeneralProcess(
            IEventReadRepository eventReadRepository,
            IEventWriteRepository eventWriteRepository,
            IEventCategoryReadRepository eventCategoryReadRepository,
            IEventCategoryWriteRepository eventCategoryWriteRepository,
            IStatusReadRepository statusReadRepository)
        {
            _eventReadRepository = eventReadRepository;
            _eventWriteRepository = eventWriteRepository;
            _eventCategoryReadRepository = eventCategoryReadRepository;
            _eventCategoryWriteRepository = eventCategoryWriteRepository;
            _statusReadRepository = statusReadRepository;
        }


        #region AdminCalendar

        #region Event

        public async Task<GetEventCreateItemsQueryResponse> GetEventCreateItemsAsync()
        {
            List<VM_EventCategory> vM_EventCategories = await _eventCategoryReadRepository.GetAll()
                .Select(x => new VM_EventCategory
                {
                    Id = x.Id,
                    EventCategoryName = x.EventCategoryName
                }).ToListAsync();

            List<AllStatus> allStatuses = await _statusReadRepository.GetAll()
                .Select(x => new AllStatus
                {
                    Id = x.Id,
                    StatusName = x.StatusName
                }).ToListAsync();

            return new()
            {
                EventCategories = vM_EventCategories,
                Statuses = allStatuses
            };
        }

        public async Task<GetAllEventQueryResponse> GetAllEventAsync()
        {
            List<VM_Event> vM_Events = await _eventReadRepository.GetAll()
                .Join(_statusReadRepository.GetAll(), ev => ev.StatusId, st => st.Id, (ev, st) => new { ev, st })
                .Join(_eventCategoryReadRepository.GetAll(), eve => eve.ev.EventCategoryId, ca => ca.Id, (eve, ca) => new { eve, ca })
                .Select(x => new VM_Event
                {
                    Id = x.eve.ev.Id,
                    CreateDate = x.eve.ev.CreateDate,
                    EventCategoryName = x.ca.EventCategoryName,
                    FinishDatetime = x.eve.ev.FinishDatetime,
                    StartDatetime = x.eve.ev.StartDatetime,
                    StatusName = x.eve.st.StatusName,
                    Title = x.eve.ev.Title,
                    Description = x.eve.ev.Description
                }).ToListAsync();

            return new()
            {
                Events = vM_Events
            };
        }

        public async Task<EventCreateCommandResponse> EventCreateAsync(EventCreateCommandRequest request)
        {
            var check = await _eventReadRepository
                .GetWhere(x => x.Title.Trim().ToLower() == request.Title.Trim().ToLower() || x.Title.Trim().ToUpper() == request.Title.Trim().ToUpper()).ToListAsync();

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
                DateTime StartDateTime = request.StartDate.Date.Add(request.StartTime.TimeOfDay);
                DateTime FinishDateTime = request.FinishDate.Date.Add(request.FinishTime.TimeOfDay);

                Event eventt = new()
                {
                    CreateDate = DateTime.Now,
                    CreateUserId = request.CreateUserId != null ? request.CreateUserId : null,
                    Description = request.Description,
                    EventCategoryId = request.EventCategoryId,
                    StatusId = request.StatusId,
                    Title = request.Title,
                    FinishDatetime = FinishDateTime,
                    StartDatetime = StartDateTime
                };

                await _eventWriteRepository.AddAsync(eventt);
                await _eventWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetByIdEventQueryResponse> GetByIdEventAsync(int id)
        {
            VM_Event? vM_Event = await _eventReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_Event
                {
                    Id = x.Id,
                    Description = x.Description,
                    EventCategoryId = x.EventCategoryId,
                    FinishDatetime = x.FinishDatetime,
                    StartDatetime = x.StartDatetime,
                    StatusId = x.StatusId,
                    Title = x.Title
                }).FirstOrDefaultAsync();

            if (vM_Event != null)
            {
                List<VM_EventCategory> vM_EventCategories = await _eventCategoryReadRepository.GetAll()
                .Select(x => new VM_EventCategory
                {
                    Id = x.Id,
                    EventCategoryName = x.EventCategoryName
                }).ToListAsync();

                List<AllStatus> allStatuses = await _statusReadRepository.GetAll()
                    .Select(x => new AllStatus
                    {
                        Id = x.Id,
                        StatusName = x.StatusName
                    }).ToListAsync();

                return new()
                {
                    EventCategories = vM_EventCategories,
                    Statuses = allStatuses,
                    Event = vM_Event,
                    State = true,
                    Message = null
                };
            }
            else
            {
                return new()
                {
                    EventCategories = null,
                    Statuses = null,
                    Event = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }

        public async Task<EventUpdateCommandResponse> EventUpdateAsync(EventUpdateCommandRequest request)
        {
            Event eventt = await _eventReadRepository.GetByIdAsync(request.Id);

            if (eventt != null)
            {
                DateTime StartDateTime = request.StartDate.Date.Add(request.StartTime.TimeOfDay);
                DateTime FinishDateTime = request.FinishDate.Date.Add(request.FinishTime.TimeOfDay);

                eventt.Title = request.Title;
                eventt.Description = request.Description;
                eventt.StartDatetime = StartDateTime;
                eventt.FinishDatetime = FinishDateTime;
                eventt.StatusId = request.StatusId;
                eventt.EventCategoryId = request.EventCategoryId;

                _eventWriteRepository.Update(eventt);
                await _eventWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Güncelleme işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }

        public async Task<EventDeleteCommandResponse> EventDeleteAsync(int id)
        {
            Event eventt = await _eventReadRepository.GetByIdAsync(id);

            if (eventt != null)
            {
                int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Pasif").Select(x => x.Id).FirstAsync();

                eventt.StatusId = statusId;

                _eventWriteRepository.Update(eventt);
                await _eventWriteRepository.SaveAsync();

                return new()
                {
                    State = true,
                    Message = null
                };
            }
            else
            {
                return new()
                {
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }

        }

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

        public async Task<GetByIdEventCategoryQueryResponse> GetByIdEventCategoryAsync(int id)
        {
            VM_EventCategory? vM_EventCategory = await _eventCategoryReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_EventCategory
                {
                    Id = x.Id,
                    EventCategoryName = x.EventCategoryName
                }).FirstOrDefaultAsync();

            if (vM_EventCategory != null)
            {
                return new()
                {
                    EventCategory = vM_EventCategory,
                    Message = null,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    EventCategory = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<EventCategoryUpdateCommandResponse> EventCategoryUpdateAsync(EventCategoryUpdateCommandRequest request)
        {
            EventCategory eventCategory = await _eventCategoryReadRepository.GetByIdAsync(request.Id);

            if (eventCategory != null)
            {
                eventCategory.EventCategoryName = request.EventCategoryName;
                _eventCategoryWriteRepository.Update(eventCategory);
                await _eventCategoryWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Güncelleme işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<EventCategoryDeleteCommandResponse> EventCategoryDeleteAsync(int id)
        {
            EventCategory eventCategory = await _eventCategoryReadRepository.GetByIdAsync(id);

            if (eventCategory != null)
            {
                _eventCategoryWriteRepository.Remove(eventCategory);
                await _eventCategoryWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Silme işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        #endregion

        #endregion
    }
}
