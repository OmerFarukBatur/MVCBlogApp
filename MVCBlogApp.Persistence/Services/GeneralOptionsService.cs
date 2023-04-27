using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Contact.ContactReadUpdate;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.ContactCategory.ContactCategoryCreate;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.ContactCategory.ContactCategoryDelete;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.ContactCategory.ContactCategoryUpdate;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Form.FormCreate;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Form.FormDelete;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Form.FormUpdate;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.CreateLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.DeleteLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.UpdateLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationCreate;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationDelete;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationUpdate;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Contact.GetAllContact;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.ContactCategory.GetAllContactCategory;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.ContactCategory.GetByIdContactCategory;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.ContactCategory.GetContactCategoryCreateItems;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Form.GetAllForms;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Form.GetByIdForm;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Form.GetFormCreateItems;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Languages.GetAllLanguage;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Languages.GetByIdLanguage;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetAllNavigation;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetByIdNavigation;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetNavigationCreateItems;
using MVCBlogApp.Application.Operations;
using MVCBlogApp.Application.Repositories.Contact;
using MVCBlogApp.Application.Repositories.ContactCategory;
using MVCBlogApp.Application.Repositories.Form;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.Navigation;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Services
{
    public class GeneralOptionsService : IGeneralOptionsService
    {
        private readonly ILanguagesReadRepository _languagesReadRepository;
        private readonly ILanguagesWriteRepository _languagesWriteRepository;
        private readonly INavigationReadRepository _navigationReadRepository;
        private readonly INavigationWriteRepository _navigationWriteRepository;
        private readonly IFormReadRepository _formReadRepository;
        private readonly IFormWriteRepository _formWriteRepository;
        private readonly IContactReadRepository _contactReadRepository;
        private readonly IContactWriteRepository _contactWriteRepository;
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly IContactCategoryReadRepository _contactCategoryReadRepository;
        private readonly IContactCategoryWriteRepository _contactCategoryWriteRepository;

        public GeneralOptionsService(
            ILanguagesReadRepository languagesReadRepository,
            ILanguagesWriteRepository languagesWriteRepository,
            INavigationReadRepository navigationReadRepository,
            INavigationWriteRepository navigationWriteRepository,
            IFormReadRepository formReadRepository,
            IFormWriteRepository formWriteRepository,
            IContactReadRepository contactReadRepository,
            IContactWriteRepository contactWriteRepository,
            IStatusReadRepository statusReadRepository,
            IContactCategoryReadRepository contactCategoryReadRepository,
            IContactCategoryWriteRepository contactCategoryWriteRepository)
        {
            _languagesReadRepository = languagesReadRepository;
            _languagesWriteRepository = languagesWriteRepository;
            _navigationReadRepository = navigationReadRepository;
            _navigationWriteRepository = navigationWriteRepository;
            _formReadRepository = formReadRepository;
            _formWriteRepository = formWriteRepository;
            _contactReadRepository = contactReadRepository;
            _contactWriteRepository = contactWriteRepository;
            _statusReadRepository = statusReadRepository;
            _contactCategoryReadRepository = contactCategoryReadRepository;
            _contactCategoryWriteRepository = contactCategoryWriteRepository;
        }

        #region Language

        public async Task<CreateLanguageCommandResponse> CreateLanguageAsync(CreateLanguageCommandRequest request)
        {
            var language = await _languagesReadRepository.GetWhere(l => l.Language.Trim().ToLower() == request.Language.Trim().ToLower() || l.Language.Trim().ToUpper() == request.Language.Trim().ToUpper()).ToListAsync();

            if (language.Count > 0)
            {
                return new()
                {
                    Message = "Bu bilgilere sahip kayıt vardır.",
                    State = false
                };
            }
            else
            {
                Languages languages = new()
                {
                    Language = request.Language,
                    IsActive = true,
                    CreateDate = DateTime.Now
                };

                await _languagesWriteRepository.AddAsync(languages);
                await _languagesWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<DeleteLanguageCommandResponse> DeleteLanguageAsync(DeleteLanguageCommandRequest request)
        {
            Languages languages = await _languagesReadRepository.GetByIdAsync(request.Id);
            if (languages != null)
            {
                languages.IsActive = false;
                _languagesWriteRepository.Update(languages);
                await _languagesWriteRepository.SaveAsync();

                return new()
                {
                    Message = "İşlem başarıyla yapıldı.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "İşlem sırasında beklenmedik bir hatayla karşılaşıldı.",
                    State = false
                };
            }
        }

        public async Task<List<AllLanguage>> GetAllLanguageAsync(GetAllLanguageQueryRequest request)
        {
            List<AllLanguage> allLanguages = await _languagesReadRepository.GetAll().Select(a => new AllLanguage
            {
                Id = a.Id,
                Language = a.Language,
                IsActive = (bool)a.IsActive,
                CreatedDate = a.CreateDate
            }).ToListAsync();

            return allLanguages;
        }

        public async Task<GetByIdLanguageQueryResponse> GetByIdLanguageAsync(GetByIdLanguageQueryRequest request)
        {
            Languages language = await _languagesReadRepository.GetByIdAsync(request.Id);

            if (language != null)
            {
                return new()
                {
                    Language = new VM_Language
                    {
                        Id = language.Id,
                        Language = language.Language,
                        IsActive = (bool)language.IsActive
                    },
                    State = true

                };
            }

            return new()
            {
                State = false
            };
        }


        public async Task<UpdateLanguageCommandResponse> UpdateLanguageAsync(UpdateLanguageCommandRequest request)
        {
            Languages languages = await _languagesReadRepository.GetByIdAsync(request.Id);
            if (languages != null)
            {
                languages.Language = request.Language;
                languages.IsActive = request.IsActive;

                _languagesWriteRepository.Update(languages);
                await _languagesWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Güncellenme işlemi başarılı bir şekilde yapıldı.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Güncellenme işlemi sırasında beklenmedik bir hata oluştu.",
                    State = false
                };
            }
        }

        #endregion

        #region Navigation

        public async Task<NavigationCreateCommandResponse> NavigationCreateAsync(NavigationCreateCommandRequest request)
        {
            var navigationList = await _navigationReadRepository.GetWhere(x => x.NavigationName.Trim().ToLower() == request.NavigationName.Trim().ToLower() || x.NavigationName.Trim().ToUpper() == request.NavigationName.Trim().ToUpper()).ToListAsync();

            if (navigationList.Count > 0)
            {
                return new()
                {
                    Message = "Bu bilgilere sahip kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                Navigation navigation = new()
                {
                    ParentId = request.ParentID,
                    OrderNo = request.OrderNo,
                    IsHeader = request.IsHeader,
                    IsSubHeader = request.IsSubHeader,
                    MetaTitle = request.MetaTitle,
                    MetaKey = request.MetaKey,
                    UrlRoot = request.UrlRoot,
                    NavigationName = request.NavigationName,
                    Controller = request.Controller,
                    Action = request.Action,
                    FontAwesomeIcon = request.FontAwesomeIcon,
                    IsActive = request.IsActive,
                    LangId = request.LangID,
                    IsAdmin = request.IsAdmin,
                    CreateDate = DateTime.Now,
                    Type = 0
                };

                await _navigationWriteRepository.AddAsync(navigation);
                await _navigationWriteRepository.SaveAsync();

                return new()
                {
                    Message = "İşlem başarıyla gerçekleştirildi.",
                    State = true
                };
            }
        }

        public async Task<GetNavigationCreateItemsCommandResponse> GetNavigationCreateItemsAsync()
        {
            List<VM_Navigation> vM_Navigations = await _navigationReadRepository.GetAll().Select(x => new VM_Navigation
            {
                Id = x.Id,
                MetaTitle = x.MetaTitle,
                NavigationName = x.NavigationName
            }).ToListAsync();

            List<VM_Language> vM_Languages = await _languagesReadRepository.GetAll().Select(x => new VM_Language
            {
                Id = x.Id,
                Language = x.Language,
                IsActive = (bool)x.IsActive
            }).ToListAsync();

            return new()
            {
                Languages = vM_Languages,
                Navigations = vM_Navigations
            };
        }

        public async Task<GetAllNavigationQueryResponse> GetAllNavigationAsync()
        {
            List<VM_Navigation> vM_Navigations = await _navigationReadRepository.GetAll(false)
                .Join(_languagesReadRepository.GetAll(), na => na.LangId, la => la.Id, (na, la) => new { na, la })
                .Select(x => new VM_Navigation
                {
                    Id = x.na.Id,
                    MetaTitle = x.na.MetaTitle,
                    Action = x.na.Action,
                    Controller = x.na.Controller,
                    CreateDate = x.na.CreateDate,
                    FontAwesomeIcon = x.na.FontAwesomeIcon,
                    IsActive = x.na.IsActive,
                    IsAdmin = x.na.IsAdmin,
                    IsHeader = x.na.IsHeader,
                    IsSubHeader = x.na.IsSubHeader,
                    Language = x.la.Language,
                    MetaKey = x.na.MetaKey,
                    NavigationName = x.na.NavigationName,
                    OrderNo = x.na.OrderNo,
                    ParentId = x.na.ParentId,
                    Type = x.na.Type,
                    UrlRoot = x.na.UrlRoot,
                    LangId = x.na.LangId
                }).ToListAsync();

            return new()
            {
                AllNavigations = vM_Navigations
            };
        }

        public async Task<GetByIdNavigationQueryResponse> GetByIdNavigationAsync(GetByIdNavigationQueryRequest request)
        {
            VM_Navigation? navigation = await _navigationReadRepository
                .GetWhere(x => x.Id == request.Id)
                .Select(s => new VM_Navigation
                {
                    Id = s.Id,
                    Action = s.Action,
                    Controller = s.Controller,
                    CreateDate = s.CreateDate,
                    FontAwesomeIcon = s.FontAwesomeIcon,
                    IsActive = s.IsActive,
                    IsAdmin = s.IsAdmin,
                    IsHeader = s.IsHeader,
                    IsSubHeader = s.IsSubHeader,
                    LangId = s.LangId,
                    MetaKey = s.MetaKey,
                    MetaTitle = s.MetaTitle,
                    NavigationName = s.NavigationName,
                    OrderNo = s.OrderNo,
                    ParentId = s.ParentId,
                    Type = s.Type,
                    UrlRoot = s.UrlRoot
                }).FirstOrDefaultAsync();

            if (navigation != null)
            {
                List<VM_Language> vM_Language = await _languagesReadRepository
                    .GetAll()
                    .Select(x => new VM_Language
                    {
                        Id = x.Id,
                        IsActive = (bool)x.IsActive,
                        Language = x.Language
                    }).ToListAsync();

                List<VM_Navigation> vM_Navigations = await _navigationReadRepository
                    .GetAll()
                    .Select(a => new VM_Navigation
                    {
                        Id = a.Id,
                        NavigationName = a.NavigationName
                    }).ToListAsync();


                return new()
                {
                    Languages = vM_Language,
                    Navigation = navigation,
                    Navigations = vM_Navigations,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    State = false
                };
            }

        }

        public async Task<NavigationUpdateCommandResponse> NavigationUpdateAsync(NavigationUpdateCommandRequest request)
        {
            Navigation navigation = await _navigationReadRepository.GetByIdAsync(request.Id);

            if (navigation != null)
            {
                navigation.Action = request.Action;
                navigation.NavigationName = request.NavigationName;
                navigation.OrderNo = request.OrderNo;
                navigation.ParentId = request.ParentId;
                navigation.IsHeader = request.IsHeader;
                navigation.IsSubHeader = request.IsSubHeader;
                navigation.Controller = request.Controller;
                navigation.FontAwesomeIcon = request.FontAwesomeIcon;
                navigation.IsActive = request.IsActive;
                navigation.IsAdmin = request.IsAdmin;
                navigation.LangId = request.LangId;
                navigation.MetaKey = request.MetaKey;
                navigation.MetaTitle = request.MetaTitle;
                navigation.UrlRoot = request.UrlRoot;

                _navigationWriteRepository.Update(navigation);
                await _navigationWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Güncelleme başarıyla yapıldı.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "İşlem sırasında beklenmedik bir hata oluştu.",
                    State = false
                };
            }
        }

        public async Task<NavigationDeleteCommandResponse> NavigationDeleteAsync(NavigationDeleteCommandRequest request)
        {
            Navigation navigation = await _navigationReadRepository.GetByIdAsync(request.Id);
            if (navigation != null)
            {
                navigation.IsActive = false;
                _navigationWriteRepository.Update(navigation);
                await _navigationWriteRepository.SaveAsync();

                return new()
                {
                    Message = "İşlem başarıyla yapıldı.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "İşlem sırasında beklenmedik bir hata oluştu.",
                    State = false
                };
            }
        }


        #endregion

        #region URL Create

        public string URLCreate(string title)
        {
            return NameOperation.GeneretaRootUrl(title);
        }


        #endregion

        #region Form

        public async Task<GetFormCreateItemsQueryResponse> GetFormCreateItemsAsync()
        {
            List<VM_Language> vM_Languages = await _languagesReadRepository.GetAll()
               .Select(x => new VM_Language
               {
                   Id = x.Id,
                   Language = x.Language
               }).ToListAsync();

            return new()
            {
                Languages = vM_Languages
            };
        }

        public async Task<GetAllFormsQueryResponse> GetAllFormsAsync()
        {
            List<VM_Form> vM_Forms = await _formReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), fr => fr.LangId, lg => lg.Id, (fr, lg) => new { fr, lg })
                .Select(x => new VM_Form
                {
                    Id = x.fr.Id,
                    Action = x.fr.Action,
                    Controller = x.fr.Controller,
                    FormName = x.fr.FormName,
                    Language = x.lg.Language
                }).ToListAsync();

            return new()
            {
                Forms = vM_Forms
            };
        }

        public async Task<FormCreateCommandResponse> FormCreateAsync(FormCreateCommandRequest request)
        {
            var check = await _formReadRepository
                .GetWhere(x => x.FormName.Trim().ToLower() == request.FormName.Trim().ToLower() || x.FormName.Trim().ToUpper() == request.FormName.Trim().ToUpper()).ToListAsync();

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
                Form form = new()
                {
                    Action = request.Action,
                    Controller = request.Controller,
                    FormName = request.FormName,
                    LangId = request.LangId
                };

                await _formWriteRepository.AddAsync(form);
                await _formWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetByIdFormQueryResponse> GetByIdFormAsync(int id)
        {
            VM_Form? vM_Form = await _formReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_Form
                {
                    Id = x.Id,
                    Action = x.Action,
                    Controller = x.Controller,
                    FormName = x.FormName,
                    LangId = x.LangId
                }).FirstOrDefaultAsync();

            if (vM_Form != null)
            {

                List<VM_Language> vM_Languages = await _languagesReadRepository.GetAll()
               .Select(x => new VM_Language
               {
                   Id = x.Id,
                   Language = x.Language
               }).ToListAsync();

                return new()
                {
                    Languages = vM_Languages,
                    Form = vM_Form,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Languages = null,
                    Form = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }

        public async Task<FormUpdateQueryResponse> FormUpdateAsync(FormUpdateQueryRequest request)
        {
            Form form = await _formReadRepository.GetByIdAsync(request.Id);

            if (form != null)
            {
                form.FormName = request.FormName;
                form.Controller = request.Controller;
                form.LangId = request.LangId;
                form.Action = request.Action;

                _formWriteRepository.Update(form);
                await _formWriteRepository.SaveAsync();

                return new()
                {
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

        public async Task<FormDeleteCommandResponse> FormDeleteAsync(int id)
        {
            Form form = await _formReadRepository.GetByIdAsync(id);

            if (form != null)
            {
                _formWriteRepository.Remove(form);
                await _formWriteRepository.SaveAsync();

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

        #region Contact

        public async Task<GetAllContactQueryResponse> GetAllContactAsync()
        {
            List<VM_Contact> vM_Contacts = await _contactReadRepository.GetAll()
                .Join(_statusReadRepository.GetAll(), co => co.StatusId, st => st.Id, (co, st) => new { co, st })
                .Join(_contactCategoryReadRepository.GetAll(), con => con.co.ContactCategoryId, cr => cr.Id, (con, cr) => new { con, cr })
                .Select(x => new VM_Contact
                {
                    Id = x.con.co.Id,
                    Description = x.con.co.Description,
                    IsRead = x.con.co.IsRead,
                    Email = x.con.co.Email,
                    NameSurname = x.con.co.NameSurname,
                    Phone = x.con.co.Phone,
                    Subject = x.con.co.Subject,
                    CreateDate = x.con.co.CreateDate,
                    ContactCategoryName = x.cr.ContactCategoryName,
                    StatusName = x.con.st.StatusName
                }).ToListAsync();

            return new()
            {
                Contacts = vM_Contacts
            };
        }

        public async Task<ContactReadUpdateCommandResponse> ContactReadUpdateAsync(int id)
        {
            Contact contact = await _contactReadRepository.GetByIdAsync(id);

            if (contact != null)
            {
                contact.IsRead = true ? false : true;

                _contactWriteRepository.Update(contact);
                await _contactWriteRepository.SaveAsync();

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

        #region ContactCategory

        public async Task<GetContactCategoryCreateItemsQueryResponse> GetContactCategoryCreateItemsAsync()
        {
            List<VM_Language> vM_Languages = await _languagesReadRepository.GetAll().Select(x => new VM_Language
            {
                Id = x.Id,
                Language = x.Language
            }).ToListAsync();

            return new()
            {
                Languages = vM_Languages
            };
        }

        public async Task<GetAllContactCategoryQueryResponse> GetAllContactCategoryAsync()
        {
            List<VM_ContactCategory> vM_ContactCategories = await _contactCategoryReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), co => co.LangId, lg => lg.Id, (co, lg) => new { co, lg })
                .Select(x => new VM_ContactCategory
                {
                    Id = x.co.Id,
                    ContactCategoryName = x.co.ContactCategoryName,
                    Language = x.lg.Language
                }).ToListAsync();

            return new()
            {
                ContactCategories = vM_ContactCategories
            };
        }

        public async Task<ContactCategoryCreateCommandResponse> ContactCategoryCreateAsync(ContactCategoryCreateCommandRequest request)
        {
            var check = await _contactCategoryReadRepository
                .GetWhere(x => x.ContactCategoryName.Trim().ToLower() == request.ContactCategoryName.Trim().ToLower() || x.ContactCategoryName.Trim().ToUpper() == request.ContactCategoryName.Trim().ToUpper()).ToListAsync();

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
                ContactCategory contactCategory = new()
                {
                    ContactCategoryName = request.ContactCategoryName,
                    LangId = request.LangId
                };

                await _contactCategoryWriteRepository.AddAsync(contactCategory);
                await _contactCategoryWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetByIdContactCategoryQueryResponse> GetByIdContactCategoryAsync(int id)
        {
            VM_ContactCategory? vM_ContactCategory = await _contactCategoryReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_ContactCategory
                {
                    Id = x.Id,
                    ContactCategoryName = x.ContactCategoryName,
                    LangId = x.LangId
                }).FirstOrDefaultAsync();

            if (vM_ContactCategory != null)
            {
                List<VM_Language> vM_Languages = await _languagesReadRepository.GetAll().Select(x => new VM_Language
                {
                    Id = x.Id,
                    Language = x.Language
                }).ToListAsync();

                return new()
                {
                    Languages = vM_Languages,
                    ContactCategory = vM_ContactCategory,
                    Message = null,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Languages = null,
                    ContactCategory = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<ContactCategoryUpdateCommandResponse> ContactCategoryUpdateAsync(ContactCategoryUpdateCommandRequest request)
        {
            ContactCategory contactCategory = await _contactCategoryReadRepository.GetByIdAsync(request.Id);

            if (contactCategory != null)
            {
                contactCategory.ContactCategoryName = request.ContactCategoryName;
                contactCategory.LangId = request.LangId;

                _contactCategoryWriteRepository.Update(contactCategory);
                await _contactCategoryWriteRepository.SaveAsync();

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

        public async Task<ContactCategoryDeleteCommandResponse> ContactCategoryDeleteAsync(int id)
        {
            ContactCategory contactCategory = await _contactCategoryReadRepository.GetByIdAsync(id);

            if (contactCategory != null)
            {
                _contactCategoryWriteRepository.Remove(contactCategory);
                await _contactCategoryWriteRepository.SaveAsync();

                return new()
                {
                    Message = null,
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
    }
}
