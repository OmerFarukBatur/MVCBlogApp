using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Repositories._DaysMeal;
using MVCBlogApp.Application.Repositories._Examination;
using MVCBlogApp.Application.Repositories.AllergyProducingFoods;
using MVCBlogApp.Application.Repositories.AppointmentDetail;
using MVCBlogApp.Application.Repositories.Article;
using MVCBlogApp.Application.Repositories.ArticleCategory;
using MVCBlogApp.Application.Repositories.Auth;
using MVCBlogApp.Application.Repositories.Banner;
using MVCBlogApp.Application.Repositories.Blog;
using MVCBlogApp.Application.Repositories.BlogCategory;
using MVCBlogApp.Application.Repositories.BlogType;
using MVCBlogApp.Application.Repositories.Book;
using MVCBlogApp.Application.Repositories.BookCategory;
using MVCBlogApp.Application.Repositories.CalcBmh;
using MVCBlogApp.Application.Repositories.CalcBMI;
using MVCBlogApp.Application.Repositories.CalcOptimum;
using MVCBlogApp.Application.Repositories.CalcPulse;
using MVCBlogApp.Application.Repositories.Carousel;
using MVCBlogApp.Application.Repositories.Case;
using MVCBlogApp.Application.Repositories.Confession;
using MVCBlogApp.Application.Repositories.ConsultancyForm;
using MVCBlogApp.Application.Repositories.ConsultancyFormType;
using MVCBlogApp.Application.Repositories.Contact;
using MVCBlogApp.Application.Repositories.ContactCategory;
using MVCBlogApp.Application.Repositories.D_Appointment;
using MVCBlogApp.Application.Repositories.D_Specialties;
using MVCBlogApp.Application.Repositories.Days;
using MVCBlogApp.Application.Repositories.DietList;
using MVCBlogApp.Application.Repositories.Diseases;
using MVCBlogApp.Application.Repositories.DiseasesCardiovascular;
using MVCBlogApp.Application.Repositories.DiseasesDiabetes;
using MVCBlogApp.Application.Repositories.DiseasesDigestiveDisorders;
using MVCBlogApp.Application.Repositories.DiseasesFamilyMembers;
using MVCBlogApp.Application.Repositories.Event;
using MVCBlogApp.Application.Repositories.EventCategory;
using MVCBlogApp.Application.Repositories.Examination;
using MVCBlogApp.Application.Repositories.FemaleMentalState;
using MVCBlogApp.Application.Repositories.FixBmh;
using MVCBlogApp.Application.Repositories.FixBMI;
using MVCBlogApp.Application.Repositories.FixCalorieSch;
using MVCBlogApp.Application.Repositories.FixFeedPyramid;
using MVCBlogApp.Application.Repositories.FixHeartDiseases;
using MVCBlogApp.Application.Repositories.FixMealSize;
using MVCBlogApp.Application.Repositories.FixOptimum;
using MVCBlogApp.Application.Repositories.FixPulse;
using MVCBlogApp.Application.Repositories.FoodHabitMood;
using MVCBlogApp.Application.Repositories.FoodHabits;
using MVCBlogApp.Application.Repositories.FoodTime;
using MVCBlogApp.Application.Repositories.Form;
using MVCBlogApp.Application.Repositories.Genders;
using MVCBlogApp.Application.Repositories.HearAboutUS;
using MVCBlogApp.Application.Repositories.Image;
using MVCBlogApp.Application.Repositories.ImageBlog;
using MVCBlogApp.Application.Repositories.ImageCarousel;
using MVCBlogApp.Application.Repositories.Influencer;
using MVCBlogApp.Application.Repositories.Lab;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.MasterRoot;
using MVCBlogApp.Application.Repositories.Meal;
using MVCBlogApp.Application.Repositories.Members;
using MVCBlogApp.Application.Repositories.MembersAuth;
using MVCBlogApp.Application.Repositories.MembersInformation;
using MVCBlogApp.Application.Repositories.MetaKeyword;
using MVCBlogApp.Application.Repositories.Navigation;
using MVCBlogApp.Application.Repositories.NewsBulletin;
using MVCBlogApp.Application.Repositories.NewsPaper;
using MVCBlogApp.Application.Repositories.OurTeam;
using MVCBlogApp.Application.Repositories.Press;
using MVCBlogApp.Application.Repositories.PressType;
using MVCBlogApp.Application.Repositories.References;
using MVCBlogApp.Application.Repositories.ResultBMh;
using MVCBlogApp.Application.Repositories.ResultBMI;
using MVCBlogApp.Application.Repositories.ResultOptimum;
using MVCBlogApp.Application.Repositories.ResultPulse;
using MVCBlogApp.Application.Repositories.SeminarVisuals;
using MVCBlogApp.Application.Repositories.SLeftNavigation;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.Repositories.TaylanK;
using MVCBlogApp.Application.Repositories.User;
using MVCBlogApp.Application.Repositories.Video;
using MVCBlogApp.Application.Repositories.VideoCategory;
using MVCBlogApp.Application.Repositories.Workshop;
using MVCBlogApp.Application.Repositories.WorkShopApplicationForm;
using MVCBlogApp.Application.Repositories.WorkshopCategory;
using MVCBlogApp.Application.Repositories.WorkshopEducation;
using MVCBlogApp.Application.Repositories.WorkshopType;
using MVCBlogApp.Application.Repositories.X_BlogCategory;
using MVCBlogApp.Application.Repositories.X_BookCategory;
using MVCBlogApp.Persistence.Contexts;
using MVCBlogApp.Persistence.Repositories._DaysMeal;
using MVCBlogApp.Persistence.Repositories._Examination;
using MVCBlogApp.Persistence.Repositories.AllergyProducingFoods;
using MVCBlogApp.Persistence.Repositories.AppointmentDetail;
using MVCBlogApp.Persistence.Repositories.Article;
using MVCBlogApp.Persistence.Repositories.ArticleCategory;
using MVCBlogApp.Persistence.Repositories.Auth;
using MVCBlogApp.Persistence.Repositories.Banner;
using MVCBlogApp.Persistence.Repositories.Blog;
using MVCBlogApp.Persistence.Repositories.BlogCategory;
using MVCBlogApp.Persistence.Repositories.BlogType;
using MVCBlogApp.Persistence.Repositories.Book;
using MVCBlogApp.Persistence.Repositories.BookCategory;
using MVCBlogApp.Persistence.Repositories.CalcBmh;
using MVCBlogApp.Persistence.Repositories.CalcBMI;
using MVCBlogApp.Persistence.Repositories.CalcOptimum;
using MVCBlogApp.Persistence.Repositories.CalcPulse;
using MVCBlogApp.Persistence.Repositories.Carousel;
using MVCBlogApp.Persistence.Repositories.Case;
using MVCBlogApp.Persistence.Repositories.Confession;
using MVCBlogApp.Persistence.Repositories.ConsultancyForm;
using MVCBlogApp.Persistence.Repositories.ConsultancyFormType;
using MVCBlogApp.Persistence.Repositories.Contact;
using MVCBlogApp.Persistence.Repositories.ContactCategory;
using MVCBlogApp.Persistence.Repositories.D_Appointment;
using MVCBlogApp.Persistence.Repositories.D_Specialties;
using MVCBlogApp.Persistence.Repositories.Days;
using MVCBlogApp.Persistence.Repositories.DietList;
using MVCBlogApp.Persistence.Repositories.Diseases;
using MVCBlogApp.Persistence.Repositories.DiseasesCardiovascular;
using MVCBlogApp.Persistence.Repositories.DiseasesDiabetes;
using MVCBlogApp.Persistence.Repositories.DiseasesDigestiveDisorders;
using MVCBlogApp.Persistence.Repositories.DiseasesFamilyMembers;
using MVCBlogApp.Persistence.Repositories.Event;
using MVCBlogApp.Persistence.Repositories.EventCategory;
using MVCBlogApp.Persistence.Repositories.Examination;
using MVCBlogApp.Persistence.Repositories.FemaleMentalState;
using MVCBlogApp.Persistence.Repositories.FixBmh;
using MVCBlogApp.Persistence.Repositories.FixBMI;
using MVCBlogApp.Persistence.Repositories.FixCalorieSch;
using MVCBlogApp.Persistence.Repositories.FixFeedPyramid;
using MVCBlogApp.Persistence.Repositories.FixHeartDiseases;
using MVCBlogApp.Persistence.Repositories.FixMealSize;
using MVCBlogApp.Persistence.Repositories.FixOptimum;
using MVCBlogApp.Persistence.Repositories.FixPulse;
using MVCBlogApp.Persistence.Repositories.FoodHabitMood;
using MVCBlogApp.Persistence.Repositories.FoodHabits;
using MVCBlogApp.Persistence.Repositories.FoodTime;
using MVCBlogApp.Persistence.Repositories.Form;
using MVCBlogApp.Persistence.Repositories.Genders;
using MVCBlogApp.Persistence.Repositories.HearAboutUS;
using MVCBlogApp.Persistence.Repositories.Image;
using MVCBlogApp.Persistence.Repositories.ImageBlog;
using MVCBlogApp.Persistence.Repositories.ImageCarousel;
using MVCBlogApp.Persistence.Repositories.Influencer;
using MVCBlogApp.Persistence.Repositories.Lab;
using MVCBlogApp.Persistence.Repositories.Languages;
using MVCBlogApp.Persistence.Repositories.MasterRoot;
using MVCBlogApp.Persistence.Repositories.Meal;
using MVCBlogApp.Persistence.Repositories.Members;
using MVCBlogApp.Persistence.Repositories.MembersAuth;
using MVCBlogApp.Persistence.Repositories.MembersDetail;
using MVCBlogApp.Persistence.Repositories.MembersInformation;
using MVCBlogApp.Persistence.Repositories.Navigation;
using MVCBlogApp.Persistence.Repositories.NewsBulletin;
using MVCBlogApp.Persistence.Repositories.NewsPaper;
using MVCBlogApp.Persistence.Repositories.OurTeam;
using MVCBlogApp.Persistence.Repositories.Press;
using MVCBlogApp.Persistence.Repositories.PressType;
using MVCBlogApp.Persistence.Repositories.References;
using MVCBlogApp.Persistence.Repositories.ResultBMh;
using MVCBlogApp.Persistence.Repositories.ResultBMI;
using MVCBlogApp.Persistence.Repositories.ResultOptimum;
using MVCBlogApp.Persistence.Repositories.ResultPulse;
using MVCBlogApp.Persistence.Repositories.SeminarVisuals;
using MVCBlogApp.Persistence.Repositories.SLeftNavigation;
using MVCBlogApp.Persistence.Repositories.Status;
using MVCBlogApp.Persistence.Repositories.TaylanK;
using MVCBlogApp.Persistence.Repositories.User;
using MVCBlogApp.Persistence.Repositories.Video;
using MVCBlogApp.Persistence.Repositories.VideoCategory;
using MVCBlogApp.Persistence.Repositories.Workshop;
using MVCBlogApp.Persistence.Repositories.WorkShopApplicationForm;
using MVCBlogApp.Persistence.Repositories.WorkshopCategory;
using MVCBlogApp.Persistence.Repositories.WorkshopEducation;
using MVCBlogApp.Persistence.Repositories.WorkshopType;
using MVCBlogApp.Persistence.Repositories.X_BlogCategory;
using MVCBlogApp.Persistence.Repositories.X_BookCategory;
using MVCBlogApp.Persistence.Services;

namespace MVCBlogApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            
            services.AddDbContext<MVCBlogDbContext>(options => options.UseSqlServer(Configuration.ConfigurationString));

            #region Repository Services

            services.AddScoped<I_DaysMealReadRepository,_DaysMealReadRepository>();
            services.AddScoped<I_DaysMealWriteRepository,_DaysMealWriteRepository>();

            services.AddScoped<I_ExaminationReadRepository, _ExaminationReadRepository>();
            services.AddScoped<I_ExaminationWriteRepository, _ExaminationWriteRepository>();

            services.AddScoped<IAllergyProducingFoodsReadRepository, AllergyProducingFoodsReadRepository>();
            services.AddScoped<IAllergyProducingFoodsWriteRepository, AllergyProducingFoodsWriteRepository>();

            services.AddScoped<IAppointmentDetailReadRepository, AppointmentDetailReadRepository>();
            services.AddScoped<IAppointmentDetailWriteRepository, AppointmentDetailWriteRepository>();

            services.AddScoped<IArticleReadRepository, ArticleReadRepository>();
            services.AddScoped<IArticleWriteRepository, ArticleWriteRepository>();


            services.AddScoped<IArticleCategoryReadRepository, ArticleCategoryReadRepository>();
            services.AddScoped<IArticleCategoryWriteRepository, ArticleCategoryWriteRepository>();


            services.AddScoped<IAuthReadRepository, AuthReadRepository>();
            services.AddScoped<IAuthWriteRepository, AuthWriteRepository>();


            services.AddScoped<IBannerReadRepository, BannerReadRepository>();
            services.AddScoped<IBannerWriteRepository, BannerWriteRepository>();

            services.AddScoped<IBlogReadRepository, BlogReadRepository>();
            services.AddScoped<IBlogWriteRepository, BlogWriteRepository>();

            services.AddScoped<IBlogCategoryReadRepository, BlogCategoryReadRepository>();
            services.AddScoped<IBlogCategoryWriteRepository, BlogCategoryWriteRepository>();

            services.AddScoped<IBlogTypeReadRepository, BlogTypeReadRepository>();
            services.AddScoped<IBlogTypeWriteRepository, BlogTypeWriteRepository>();

            services.AddScoped<IBookReadRepository, BookReadRepository>();
            services.AddScoped<IBookWriteRepository, BookWriteRepository>();

            services.AddScoped<IBookCategoryReadRepository, BookCategoryReadRepository>();
            services.AddScoped<IBookCategoryWriteRepository, BookCategoryWriteRepository>();

            services.AddScoped<ICalcBmhReadRepository, CalcBmhReadRepository>();
            services.AddScoped<ICalcBmhWriteRepository, CalcBmhWriteRepository>();

            services.AddScoped<ICalcBMIReadRepository, CalcBMIReadRepository>();
            services.AddScoped<ICalcBMIWriteRepository, CalcBMIWriteRepository>();

            services.AddScoped<ICalcOptimumReadRepository, CalcOptimumReadRepository>();
            services.AddScoped<ICalcOptimumWriteRepository, CalcOptimumWriteRepository>();

            services.AddScoped<ICalcPulseReadRepository, CalcPulseReadRepository>();
            services.AddScoped<ICalcPulseWriteRepository, CalcPulseWriteRepository>();

            services.AddScoped<ICarouselReadRepository, CarouselReadRepository>();
            services.AddScoped<ICarouselWriteRepository, CarouselWriteRepository>();

            services.AddScoped<ICaseReadRepository, CaseReadRepository>();
            services.AddScoped<ICaseWriteRepository, CaseWriteRepository>();

            services.AddScoped<IConfessionReadRepository, ConfessionReadRepository>();
            services.AddScoped<IConfessionWriteRepository, ConfessionWriteRepository>();

            services.AddScoped<IConsultancyFormReadRepository, ConsultancyFormReadRepository>();
            services.AddScoped<IConsultancyFormWriteRepository, ConsultancyFormWriteRepository>();

            services.AddScoped<IConsultancyFormTypeReadRepository, ConsultancyFormTypeReadRepository>();
            services.AddScoped<IConsultancyFormTypeWriteRepository, ConsultancyFormTypeWriteRepository>();

            services.AddScoped<IContactReadRepository, ContactReadRepository>();
            services.AddScoped<IContactWriteRepository, ContactWriteRepository>();

            services.AddScoped<IContactCategoryReadRepository, ContactCategoryReadRepository>();
            services.AddScoped<IContactCategoryWriteRepository, ContactCategoryWriteRepository>();

            services.AddScoped<ID_AppointmentReadRepository, D_AppointmentReadRepository>();
            services.AddScoped<ID_AppointmentWriteRepository, D_AppointmentWriteRepository>();

            services.AddScoped<ID_SpecialtiesReadRepository, D_SpecialtiesReadRepository>();
            services.AddScoped<ID_SpecialtiesWriteRepository, D_SpecialtiesWriteRepository>();

            services.AddScoped<IDaysReadRepository, DaysReadRepository>();
            services.AddScoped<IDaysWriteRepository, DaysWriteRepository>();

            services.AddScoped<IDietListReadRepository, DietListReadRepository>();
            services.AddScoped<IDietListWriteRepository, DietListWriteRepository>();

            services.AddScoped<IDiseasesReadRepository, DiseasesReadRepository>();
            services.AddScoped<IDiseasesWriteRepository, DiseasesWriteRepository>();

            services.AddScoped<IDiseasesCardiovascularReadRepository, DiseasesCardiovascularReadRepository>();
            services.AddScoped<IDiseasesCardiovascularWriteRepository, DiseasesCardiovascularWriteRepository>();

            services.AddScoped<IDiseasesDiabetesReadRepository, DiseasesDiabetesReadRepository>();
            services.AddScoped<IDiseasesDiabetesWriteRepository, DiseasesDiabetesWriteRepository>();

            services.AddScoped<IDiseasesDigestiveDisordersReadRepository, DiseasesDigestiveDisordersReadRepository>();
            services.AddScoped<IDiseasesDigestiveDisordersWriteRepository, DiseasesDigestiveDisordersWriteRepository>();

            services.AddScoped<IDiseasesFamilyMembersReadRepository, DiseasesFamilyMembersReadRepository>();
            services.AddScoped<IDiseasesFamilyMembersWriteRepository, DiseasesFamilyMembersWriteRepository>();

            services.AddScoped<IEventReadRepository, EventReadRepository>();
            services.AddScoped<IEventWriteRepository, EventWriteRepository>();

            services.AddScoped<IEventCategoryReadRepository, EventCategoryReadRepository>();
            services.AddScoped<IEventCategoryWriteRepository, EventCategoryWriteRepository>();

            services.AddScoped<IExaminationReadRepository, ExaminationReadRepository>();
            services.AddScoped<IExaminationWriteRepository, ExaminationWriteRepository>();

            services.AddScoped<IFemaleMentalStateReadRepository, FemaleMentalStateReadRepository>();
            services.AddScoped<IFemaleMentalStateWriteRepository, FemaleMentalStateWriteRepository>();

            services.AddScoped<IFixBmhReadRepository, FixBmhReadRepository>();
            services.AddScoped<IFixBmhWriteRepository, FixBmhWriteRepository>();

            services.AddScoped<IFixBMIReadRepository, FixBMIReadRepository>();
            services.AddScoped<IFixBMIWriteRepository, FixBMIWriteRepository>();

            services.AddScoped<IFixCalorieSchReadRepository, FixCalorieSchReadRepository>();
            services.AddScoped<IFixCalorieSchWriteRepository, FixCalorieSchWriteRepository>();

            services.AddScoped<IFixFeedPyramidReadRepository, FixFeedPyramidReadRepository>();
            services.AddScoped<IFixFeedPyramidWriteRepository, FixFeedPyramidWriteRepository>();

            services.AddScoped<IFixHeartDiseasesReadRepository, FixHeartDiseasesReadRepository>();
            services.AddScoped<IFixHeartDiseasesWriteRepository, FixHeartDiseasesWriteRepository>();

            services.AddScoped<IFixMealSizeReadRepository, FixMealSizeReadRepository>();
            services.AddScoped<IFixMealSizeWriteRepository, FixMealSizeWriteRepository>();


            services.AddScoped<IFixOptimumReadRepository, FixOptimumReadRepository>();
            services.AddScoped<IFixOptimumWriteRepository, FixOptimumWriteRepository>();

            services.AddScoped<IFixPulseReadRepository, FixPulseReadRepository>();
            services.AddScoped<IFixPulseWriteRepository, FixPulseWriteRepository>();

            services.AddScoped<IFoodHabitMoodReadRepository, FoodHabitMoodReadRepository>();
            services.AddScoped<IFoodHabitMoodWriteRepository, FoodHabitMoodWriteRepository>();

            services.AddScoped<IFoodHabitsReadRepository, FoodHabitsReadRepository>();
            services.AddScoped<IFoodHabitsWriteRepository, FoodHabitsWriteRepository>();

            services.AddScoped<IFoodTimeReadRepository, FoodTimeReadRepository>();
            services.AddScoped<IFoodTimeWriteRepository, FoodTimeWriteRepository>();

            services.AddScoped<IFormReadRepository, FormReadRepository>();
            services.AddScoped<IFormWriteRepository, FormWriteRepository>();

            services.AddScoped<IGendersReadRepository, GendersReadRepository>();
            services.AddScoped<IGendersWriteRepository, GendersWriteRepository>();

            services.AddScoped<IHearAboutUSReadRepository, HearAboutUSReadRepository>();
            services.AddScoped<IHearAboutUSWriteRepository, HearAboutUSWriteRepository>();

            services.AddScoped<IImageReadRepository, ImageReadRepository>();
            services.AddScoped<IImageWriteRepository, ImageWriteRepository>();

            services.AddScoped<IImageBlogReadRepository, ImageBlogReadRepository>();
            services.AddScoped<IImageBlogWriteRepository, ImageBlogWriteRepository>();

            services.AddScoped<IImageCarouselReadRepository, ImageCarouselReadRepository>();
            services.AddScoped<IImageCarouselWriteRepository, ImageCarouselWriteRepository>();

            services.AddScoped<IInfluencerReadRepository, InfluencerReadRepository>();
            services.AddScoped<IInfluencerWriteRepository, InfluencerWriteRepository>();

            services.AddScoped<ILabReadRepository, LabReadRepository>();
            services.AddScoped<ILabWriteRepository, LabWriteRepository>();

            services.AddScoped<ILanguagesReadRepository, LanguagesReadRepository>();
            services.AddScoped<ILanguagesWriteRepository, LanguagesWriteRepository>();

            services.AddScoped<IMasterRootReadRepository, MasterRootReadRepository>();
            services.AddScoped<IMasterRootWriteRepository, MasterRootWriteRepository>();

            services.AddScoped<IMealReadRepository, MealReadRepository>();
            services.AddScoped<IMealWriteRepository, MealWriteRepository>();

            services.AddScoped<IMembersReadRepository, MembersReadRepository>();
            services.AddScoped<IMembersWriteRepository, MembersWriteRepository>();

            services.AddScoped<IMembersAuthReadRepository, MembersAuthReadRepository>();
            services.AddScoped<IMembersAuthWriteRepository, MembersAuthWriteRepository>();

            services.AddScoped<IMetaKeywordReadRepository, MetaKeywordReadRepository>();
            services.AddScoped<IMetaKeywordWriteRepository, MetaKeywordWriteRepository>();

            services.AddScoped<IMembersInformationReadRepository, MembersInformationReadRepository>();
            services.AddScoped<IMembersInformationWriteRepository, MembersInformationWriteRepository>();

            services.AddScoped<INavigationReadRepository, NavigationReadRepository>();
            services.AddScoped<INavigationWriteRepository, NavigationWriteRepository>();

            services.AddScoped<INewsBulletinReadRepository, NewsBulletinReadRepository>();
            services.AddScoped<INewsBulletinWriteRepository, NewsBulletinWriteRepository>();

            services.AddScoped<INewsPaperReadRepository, NewsPaperReadRepository>();
            services.AddScoped<INewsPaperWriteRepository, NewsPaperWriteRepository>();

            services.AddScoped<IOurTeamReadRepository, OurTeamReadRepository>();
            services.AddScoped<IOurTeamWriteRepository, OurTeamWriteRepository>();

            services.AddScoped<IPressReadRepository, PressReadRepository>();
            services.AddScoped<IPressWriteRepository, PressWriteRepository>();

            services.AddScoped<IPressTypeReadRepository, PressTypeReadRepository>();
            services.AddScoped<IPressTypeWriteRepository, PressTypeWriteRepository>();

            services.AddScoped<IReferencesReadRepository, ReferencesReadRepository>();
            services.AddScoped<IReferencesWriteRepository, ReferencesWriteRepository>();

            services.AddScoped<IResultBMhReadRepository, ResultBMhReadRepository>();
            services.AddScoped<IResultBMhWriteRepository, ResultBMhWriteRepository>();

            services.AddScoped<IResultBMIReadRepository, ResultBMIReadRepository>();
            services.AddScoped<IResultBMIWriteRepository, ResultBMIWriteRepository>();

            services.AddScoped<IResultOptimumReadRepository, ResultOptimumReadRepository>();
            services.AddScoped<IResultOptimumWriteRepository, ResultOptimumWriteRepository>();

            services.AddScoped<IResultPulseReadRepository, ResultPulseReadRepository>();
            services.AddScoped<IResultPulseWriteRepository, ResultPulseWriteRepository>();

            services.AddScoped<ISeminarVisualsReadRepository, SeminarVisualsReadRepository>();
            services.AddScoped<ISeminarVisualsWriteRepository, SeminarVisualsWriteRepository>();

            services.AddScoped<ISLeftNavigationReadRepository, SLeftNavigationReadRepository>();
            services.AddScoped<ISLeftNavigationWriteRepository, SLeftNavigationWriteRepository>();

            services.AddScoped<IStatusReadRepository, StatusReadRepository>();
            services.AddScoped<IStatusWriteRepository, StatusWriteRepository>();

            services.AddScoped<ITaylanKReadRepository, TaylanKReadRepository>();
            services.AddScoped<ITaylanKWriteRepository, TaylanKWriteRepository>();

            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();

            services.AddScoped<IVideoReadRepository, VideoReadRepository>();
            services.AddScoped<IVideoWriteRepository, VideoWriteRepository>();

            services.AddScoped<IVideoCategoryReadRepository, VideoCategoryReadRepository>();
            services.AddScoped<IVideoCategoryWriteRepository, VideoCategoryWriteRepository>();

            services.AddScoped<IWorkshopReadRepository, WorkshopReadRepository>();
            services.AddScoped<IWorkshopWriteRepository, WorkshopWriteRepository>();

            services.AddScoped<IWorkShopApplicationFormReadRepository, WorkShopApplicationFormReadRepository>();
            services.AddScoped<IWorkShopApplicationFormWriteRepository, WorkShopApplicationFormWriteRepository>();

            services.AddScoped<IWorkshopCategoryReadRepository, WorkshopCategoryReadRepository>();
            services.AddScoped<IWorkshopCategoryWriteRepository, WorkshopCategoryWriteRepository>();

            services.AddScoped<IWorkshopEducationReadRepository, WorkshopEducationReadRepository>();
            services.AddScoped<IWorkshopEducationWriteRepository, WorkshopEducationWriteRepository>();

            services.AddScoped<IWorkshopTypeReadRepository, WorkshopTypeReadRepository>();
            services.AddScoped<IWorkshopTypeWriteRepository, WorkshopTypeWriteRepository>();

            services.AddScoped<IX_BlogCategoryReadRepository, X_BlogCategoryReadRepository>();
            services.AddScoped<IX_BlogCategoryWriteRepository, X_BlogCategoryWriteRepository>();

            services.AddScoped<IX_BookCategoryReadRepository, X_BookCategoryReadRepository>();
            services.AddScoped<IX_BookCategoryWriteRepository, X_BookCategoryWriteRepository>();
            #endregion

            #region Services
            services.AddScoped<IAuthService,AuthService>();
            services.AddScoped<IYoneticiIslemleri,YoneticiIslemleri>();
            services.AddScoped<IGeneralOptionsService,GeneralOptionsService>();
            services.AddScoped<IBlogService,BlogService>();
            services.AddScoped<IBookService,BookService>();
            services.AddScoped<IUserIslemleriService,UserIslemleriService>();
            services.AddScoped<IArticleService,ArticleService>();
            services.AddScoped<IResultIslemleriService,ResultIslemleriService>();
            services.AddScoped<IFileProcessService,FileProcessService>();
            services.AddScoped<INewsService,NewsService>();
            services.AddScoped<IReferenceService,ReferenceService>();
            services.AddScoped<IWorkshopService,WorkshopService>();
            #endregion      
            
        }
    }
}
