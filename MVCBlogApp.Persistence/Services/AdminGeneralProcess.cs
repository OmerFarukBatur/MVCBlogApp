using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Admin.Calendar.EventDateTimeUpdate;
using MVCBlogApp.Application.Features.Commands.Admin.Event.EventCreate;
using MVCBlogApp.Application.Features.Commands.Admin.Event.EventDelete;
using MVCBlogApp.Application.Features.Commands.Admin.Event.EventUpdate;
using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryCreate;
using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryDelete;
using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryUpdate;
using MVCBlogApp.Application.Features.Queries.Admin.Calendar.GetAllCalendarEvent;
using MVCBlogApp.Application.Features.Queries.Admin.Dashboard;
using MVCBlogApp.Application.Features.Queries.Admin.Event.GetAllEvent;
using MVCBlogApp.Application.Features.Queries.Admin.Event.GetByIdEvent;
using MVCBlogApp.Application.Features.Queries.Admin.Event.GetEventCreateItems;
using MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetAllEventCategory;
using MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetByIdEventCategory;
using MVCBlogApp.Application.Features.Queries.Admin.Header;
using MVCBlogApp.Application.Repositories.Article;
using MVCBlogApp.Application.Repositories.Blog;
using MVCBlogApp.Application.Repositories.Confession;
using MVCBlogApp.Application.Repositories.Contact;
using MVCBlogApp.Application.Repositories.ContactCategory;
using MVCBlogApp.Application.Repositories.D_Appointment;
using MVCBlogApp.Application.Repositories.Event;
using MVCBlogApp.Application.Repositories.EventCategory;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.Members;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.Repositories.User;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;
using MVCBlogApp.Persistence.Repositories.D_Appointment;
using System;

namespace MVCBlogApp.Persistence.Services
{
    public class AdminGeneralProcess : IAdminGeneralProcess
    {
        private readonly IEventReadRepository _eventReadRepository;
        private readonly IEventWriteRepository _eventWriteRepository;
        private readonly IEventCategoryReadRepository _eventCategoryReadRepository;
        private readonly IEventCategoryWriteRepository _eventCategoryWriteRepository;
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly IMembersReadRepository _membersReadRepository;
        private readonly IContactReadRepository _contactReadRepository;
        private readonly IBlogReadRepository _blogReadRepository;
        private readonly IConfessionReadRepository _confessionReadRepository;
        private readonly IArticleReadRepository _articleReadRepository;
        private readonly ID_AppointmentReadRepository _dateReadRepository;
        private readonly ILanguagesReadRepository _languagesReadRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IContactCategoryReadRepository _contactCategoryReadRepository;

        public AdminGeneralProcess(
            IEventReadRepository eventReadRepository,
            IEventWriteRepository eventWriteRepository,
            IEventCategoryReadRepository eventCategoryReadRepository,
            IEventCategoryWriteRepository eventCategoryWriteRepository,
            IStatusReadRepository statusReadRepository,
            IMembersReadRepository membersReadRepository,
            IContactReadRepository contactReadRepository,
            IBlogReadRepository blogReadRepository,
            IConfessionReadRepository confessionReadRepository,
            IArticleReadRepository articleReadRepository,
            ID_AppointmentReadRepository dateReadRepository,
            ILanguagesReadRepository languagesReadRepository,
            IUserReadRepository userReadRepository,
            IContactCategoryReadRepository contactCategoryReadRepository)
        {
            _eventReadRepository = eventReadRepository;
            _eventWriteRepository = eventWriteRepository;
            _eventCategoryReadRepository = eventCategoryReadRepository;
            _eventCategoryWriteRepository = eventCategoryWriteRepository;
            _statusReadRepository = statusReadRepository;
            _membersReadRepository = membersReadRepository;
            _contactReadRepository = contactReadRepository;
            _blogReadRepository = blogReadRepository;
            _confessionReadRepository = confessionReadRepository;
            _articleReadRepository = articleReadRepository;
            _dateReadRepository = dateReadRepository;
            _languagesReadRepository = languagesReadRepository;
            _userReadRepository = userReadRepository;
            _contactCategoryReadRepository = contactCategoryReadRepository;
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

        #region Calendar

        public async Task<GetAllCalendarEventQueryResponse> GetAllCalendarEventAsync()
        {
            List<VM_CalenderData> vM_CalenderDatas = await _eventReadRepository.GetAll()
                .Join(_statusReadRepository.GetWhere(x => x.StatusName == "Aktif"), eventt => eventt.StatusId, st => st.Id, (eventt, st) => new { eventt, st })
                .Select(x => new VM_CalenderData
                {
                    Id = x.eventt.Id,
                    Description = null,
                    End = x.eventt.FinishDatetime,
                    Start = x.eventt.StartDatetime,
                    Title = x.eventt.Title,
                    Color = "darkorange", // x.eventt.FinishDatetime.Value.Date == DateTime.Now.Date ? true : x.eventt.FinishDatetime.Value.Date > DateTime.Now.Date ? true : false
                    AllDay = false
                }).ToListAsync();           

            return new()
            {
                AllEvents = vM_CalenderDatas
            };
        }

        public async Task<EventDateTimeUpdateCommandResponse> EventDateTimeAsync(EventDateTimeUpdateCommandRequest request)
        {
            Event eventt = await _eventReadRepository.GetByIdAsync(request.Id);

            if (eventt != null)
            {
                DateTime StartDateTime = request.StartDate.Date.Add(request.StartTime.TimeOfDay);
                DateTime FinishDateTime = request.FinishDate.Date.Add(request.FinishTime.TimeOfDay);

                eventt.StartDatetime = StartDateTime;
                eventt.FinishDatetime = FinishDateTime;

                _eventWriteRepository.Update(eventt);
                await _eventWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Güncelleme başarıyla yapılmıştır.",
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

        #region Dashboard

        public async Task<GetDashboardItemListQueryResponse> GetDashboardItemListAsync()
        {
            int statusActive = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();


            ////// User
            List<VM_Member> members = await _membersReadRepository.GetWhere(x => x.IsActive == true)
                .Select(x => new VM_Member
                {
                    Id = x.Id,
                    NameSurname = x.NameSurname,
                    Email = x.Email,
                    Phone = x.Phone,
                    IsActive = x.IsActive,
                    Lacation = x.Lacation,
                    CreateDate = x.CreateDate
                }).ToListAsync();
            int allUser = members.Count();
            List<VM_Member> oneMonthCreateUsers = members.Where(x=> x.CreateDate > DateTime.Now.AddMonths(-1)).ToList();


            ////// Event
            List<VM_Event> vM_Events = await _eventReadRepository.GetWhere(x=> x.StatusId == statusActive)
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

            int allEventCount = vM_Events.Count();
            List<VM_Event> oneWeekActivities = vM_Events.Where(x=> x.FinishDatetime > DateTime.Now.AddDays(-7) && x.FinishDatetime < DateTime.Now.AddDays(7)).ToList();

            ////// Message(Conatct)
            //DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0);
            //DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1, 0, 0, 0, 0);

            //int oneDayMessage = await _contactReadRepository
            //    .GetWhere(x => x.CreateDate > startDate && x.CreateDate < endDate && x.IsRead == false).CountAsync();

            //// Blog
            List<VM_Blog> vM_Blogs = await _blogReadRepository
                .GetWhere(x => x.StatusId == statusActive)
                .Join(_languagesReadRepository.GetAll(), b => b.LangId, lg => lg.Id, (b, lg) => new { b, lg })
                .Join(_statusReadRepository.GetAll(), bl => bl.b.StatusId, st => st.Id, (bl, st) => new { bl, st })
                .Select(x => new VM_Blog
                {
                    Id = x.bl.b.Id,
                    Title = x.bl.b.Title,
                    UrlRoot = x.bl.b.UrlRoot,
                    Language = x.bl.lg.Language,
                    StatusName = x.st.StatusName,
                    CreateDate = x.bl.b.CreateDate,
                    UpdateDate = x.bl.b.UpdateDate
                }).ToListAsync();

            int allBlogCount = vM_Blogs.Count();
            List<VM_Blog> oneWeekBlogs = vM_Blogs.Where(x=> x.CreateDate > DateTime.Now.AddDays(-7) && x.CreateDate < DateTime.Now.AddDays(7)).ToList();

            /// Confession
            List<VM_Confession> lastWeekConfession = await _confessionReadRepository
                .GetWhere(x => x.CreateDatetime > DateTime.Now.AddDays(-7) && x.CreateDatetime < DateTime.Now.AddDays(7) && x.IsRead == false)
                .Join(_languagesReadRepository.GetAll(), co => co.LangId, lg => lg.Id, (co, lg) => new { co, lg })
                .Join(_statusReadRepository.GetAll(), con => con.co.StatusId, st => st.Id, (con, st) => new { con, st })
                .Select(x => new VM_Confession
                {
                    Id = x.con.co.Id,
                    MemberConfession = x.con.co.MemberConfession,
                    MemberName = x.con.co.MemberName,
                    CreateDatetime = x.con.co.CreateDatetime,
                    Language = x.con.lg.Language,
                    StatusName = x.st.StatusName
                }).ToListAsync();

            //// Article
            int allArticle = await _articleReadRepository.GetWhere(x => x.StatusId == statusActive).CountAsync();
            int lastMounthArticleCount = await _articleReadRepository
                .GetWhere(x => x.CreateDate > DateTime.Now.AddMonths(-1) && x.StatusId == statusActive).CountAsync();

            /// Appointment
            List<VM_D_Appointment> allAppointment = await _dateReadRepository
                .GetWhere(x=> x.StatusId == statusActive)
                .Join(_membersReadRepository.GetAll(), ap => ap.MembersId, mem => mem.Id, (ap, mem) => new { ap, mem })
                .Join(_userReadRepository.GetAll(), app => app.ap.UserId, us => us.Id, (app, us) => new { app, us })
                .Join(_statusReadRepository.GetAll(), appo => appo.app.ap.StatusId, st => st.Id, (appo, st) => new { appo, st })
                .Select(x => new VM_D_Appointment
                {
                    Id = x.appo.app.ap.Id,
                    AppointmentDate = x.appo.app.ap.AppointmentDate,
                    Subject = x.appo.app.ap.Subject,
                    Price = x.appo.app.ap.Price,
                    Description = x.appo.app.ap.Description,
                    UserName = x.appo.us.Username,
                    MemeberName = x.appo.app.mem.NameSurname,
                    StatusName = x.st.StatusName,
                    CreateDate = x.appo.app.ap.CreateDate
                }).ToListAsync();

            List<VM_D_Appointment> lastWeekAppointment = allAppointment
                .Where(x=> x.AppointmentDate > DateTime.Now.AddDays(-7) && x.AppointmentDate < DateTime.Now.AddDays(7)).ToList();

            return new()
            {
                ActiveAllUserCount = allUser,
                ActiveOneMonthCreateUsers = oneMonthCreateUsers,
                ActiveAllActivityCount = allEventCount,
                ActiveOneWeekActivities = oneWeekActivities,
                //DailyIncomingMessageCount = oneDayMessage,
                ActiveAllBlogCount = allBlogCount,
                ActiveOneWeekBlogs = oneWeekBlogs,
                LastWeekConfession = lastWeekConfession,
                ActiveAllArticleCount = allArticle,
                LastMounthArticleCount = lastMounthArticleCount,
                //ActiveAllAppointment = allAppointment,
                ActiveLastWeekAppointment = lastWeekAppointment
            };
        }

        public async Task<GetAdminHeaderDataQueryResponse> GetAdminHeaderDataAsync()
        {
            //// Message(Conatct)
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0);
            DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1, 0, 0, 0, 0);

            int oneDayMessage = await _contactReadRepository
                .GetWhere(x => x.CreateDate > startDate && x.CreateDate < endDate && x.IsRead == false).CountAsync();

            return new()
            {
                DailyIncomingMessageCount = oneDayMessage
            };
        }

        #endregion
    }
}
