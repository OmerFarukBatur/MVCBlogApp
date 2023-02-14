using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Domain.Entities;
using MVCBlogApp.Domain.Entities.Common;
using System.Reflection.Emit;

namespace MVCBlogApp.Persistence.Contexts
{
    public class MVCBlogDbContext : DbContext
    {
        public MVCBlogDbContext(DbContextOptions options) : base(options)
        {

        }

        #region DbSet
        public DbSet<User> User { get; set; }
        public DbSet<Auth> Auth { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<Navigation> Navigation { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<MembersDetail> MembersDetail { get; set; }
        public DbSet<MembersAuth> MembersAuth { get; set; }
        public DbSet<TaylanK> TaylanK { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<BlogCategory> BlogCategory { get; set; }
        public DbSet<X_BlogCategory> X_BlogCategory { get; set; }
        public DbSet<ImageBlog> ImageBlog { get; set; }
        public DbSet<BlogType> BlogType { get; set; }

        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleCategory> ArticleCategory { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookCategory> BookCategory { get; set; }
        public DbSet<Carousel> Carousel { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<ContactCategory> ContactCategory { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<NewsBulletin> NewsBulletin { get; set; }
        public DbSet<NewsPaper> NewsPaper { get; set; }
        public DbSet<OurTeam> OurTeam { get; set; }
        public DbSet<Press> Press { get; set; }
        public DbSet<PressType> PressType { get; set; }
        public DbSet<References> References { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<VideoCategory> VideoCategory { get; set; }
        public DbSet<X_BookCategory> X_BookCategory { get; set; }
        public DbSet<ImageCarousel> ImageCarousel { get; set; }
        public DbSet<Workshop> Workshop { get; set; }
        public DbSet<WorkshopCategory> WorkshopCategory { get; set; }
        public DbSet<WorkshopEducation> WorkshopEducation { get; set; }
        public DbSet<WorkshopType> WorkshopType { get; set; }

        public DbSet<CalcBmh> CalcBmh { get; set; }
        public DbSet<CalcBMI> CalcBMI { get; set; }
        public DbSet<CalcOptimum> CalcOptimum { get; set; }
        public DbSet<CalcPulse> CalcPulse { get; set; }
        public DbSet<FixBmh> FixBmh { get; set; }
        public DbSet<FixBMI> FixBMI { get; set; }
        public DbSet<FixCalorieSch> FixCalorieSch { get; set; }
        public DbSet<FixFeedPyramid> FixFeedPyramid { get; set; }
        public DbSet<FixHeartDiseases> FixHeartDiseases { get; set; }
        public DbSet<FixMealSize> FixMealSize { get; set; }
        public DbSet<FixOptimum> FixOptimum { get; set; }
        public DbSet<FixPulse> FixPulse { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<ResultBMh> ResultBMh { get; set; }
        public DbSet<ResultBMI> ResultBMI { get; set; }
        public DbSet<ResultOptimum> ResultOptimum { get; set; }
        public DbSet<ResultPulse> ResultPulse { get; set; }
        public DbSet<MasterRoot> MasterRoot { get; set; }

        public DbSet<WorkShopApplicationForm> WorkShopApplicationForm { get; set; }
        public DbSet<HearAboutUS> HearAboutUS { get; set; }

        public DbSet<Genders> Genders { get; set; }
        public DbSet<Case> Case { get; set; }


        public DbSet<Confession> Confession { get; set; }
        public DbSet<Influencer> Influencer { get; set; }
        public DbSet<ConsultancyForm> ConsultancyForm { get; set; }
        public DbSet<ConsultancyFormType> ConsultancyFormType { get; set; }

        public DbSet<SeminarVisuals> SeminarVisuals { get; set; }

        public DbSet<Event> Event { get; set; }

        public DbSet<EventCategory> EventCategory { get; set; }
        public DbSet<Banner> Banner { get; set; }

        public DbSet<D_Appointment> D_Appointment { get; set; }
        public DbSet<D_Specialties> D_Specialties { get; set; }

        public DbSet<MembersInformation> MembersInformation { get; set; }
        public DbSet<FoodHabitMood> FoodHabitMood { get; set; }
        public DbSet<AllergyProducingFoods> AllergyProducingFoods { get; set; }
        public DbSet<FoodTime> FoodTime { get; set; }
        public DbSet<FemaleMentalState> FemaleMentalState { get; set; }
        public DbSet<FoodHabits> FoodHabits { get; set; }
        public DbSet<Diseases> Diseases { get; set; }
        public DbSet<DiseasesCardiovascular> DiseasesCardiovascular { get; set; }
        public DbSet<DiseasesDiabetes> DiseasesDiabetes { get; set; }
        public DbSet<DiseasesDigestiveDisorders> DiseasesDigestiveDisorders { get; set; }
        public DbSet<DiseasesFamilyMembers> DiseasesFamilyMembers { get; set; }

        public DbSet<AppointmentDetail> AppointmentDetail { get; set; }
        public DbSet<DietList> DietList { get; set; }
        public DbSet<Days> Days { get; set; }
        public DbSet<Meal> Meal { get; set; }
        public DbSet<_DaysMeal> _DaysMeal { get; set; }
        public DbSet<Examination> Examination { get; set; }
        public DbSet<_Examination> _Examination { get; set; }
        public DbSet<Lab> Lab { get; set; }
        public DbSet<SLeftNavigation> SLeftNavigation { get; set; }
        #endregion


        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    //ChangeTracker: Entityler üzerinden yapılan değişiklikleri ya da yeni eklenen verinin yakalanmasını sağlayan propertdir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.
        //    var datas = ChangeTracker
        //        .Entries<BaseEntity>();
        //    foreach (var data in datas)
        //    {
        //        _ = data.State switch
        //        {
        //            EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
        //            EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
        //            _ => DateTime.UtcNow
        //        };
        //    }
        //    return await base.SaveChangesAsync(cancellationToken);
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #region Navigation

            builder.Entity<Navigation>()
                .HasOne(s => s.Languages)
                .WithMany(u => u.Navigation)
                .HasForeignKey(s => s.LangID);

            #endregion

            #region Users

            builder.Entity<User>()
                .HasOne(s => s.Auth)
                .WithMany(u => u.User)
                .HasForeignKey(s => s.AuthID);

            builder.Entity<User>()
               .HasOne(s => s.TaylanK)
               .WithOne(u => u.User)
               .HasForeignKey<TaylanK>(ad => ad.UserID);

            builder.Entity<User>()
              .HasMany(s => s.Blog)
              .WithOne(u => u.User)
              .HasForeignKey(s => s.CreateUserID);

            #endregion

            #region Members

            builder.Entity<Members>()
               .HasOne(s => s.MembersDetail)
               .WithOne(u => u.Members)
               .HasForeignKey<MembersDetail>(ad => ad.MembersID);

            builder.Entity<Members>()
               .HasOne(s => s.MembersAuth)
               .WithMany(u => u.Members)
               .HasForeignKey(s => s.MembersAuthID)
               .IsRequired(false);

            #endregion

            #region langues

            builder.Entity<Languages>()
                .HasMany(s => s.TaylanK)
                .WithOne(u => u.Languages)
                .HasForeignKey(s => s.LangID);

            builder.Entity<Languages>()
               .HasMany(s => s.Banner)
               .WithOne(u => u.Languages)
               .HasForeignKey(s => s.LangID);

            builder.Entity<Languages>()
               .HasMany(s => s.Carousel)
               .WithOne(u => u.Languages)
               .HasForeignKey(s => s.LangID);

            builder.Entity<Languages>()
               .HasMany(s => s.Video)
               .WithOne(u => u.Languages)
               .HasForeignKey(s => s.LangID);

            #endregion

            #region Blog

            builder.Entity<X_BlogCategory>()
                .HasOne(s => s.Blog)
                .WithMany(u => u.X_BlogCategory)
                .HasForeignKey(s => s.BlogID);

            builder.Entity<X_BlogCategory>()
              .HasOne(s => s.BlogCategory)
              .WithMany(u => u.X_BlogCategory)
              .HasForeignKey(s => s.BlogCategoryID);

            builder.Entity<Blog>()
                .HasOne(s => s.BlogType)
                .WithMany(s => s.Blogs)
                .HasForeignKey(s => s.BlogTypeID);

            builder.Entity<Blog>()
                .HasOne(s => s.Languages)
                .WithMany(s => s.Blogs)
                .HasForeignKey(s => s.LangID);


            #endregion

            #region Article

            builder.Entity<Article>()
                .HasOne(s => s.ArticleCategory)
                .WithMany(u => u.Article)
                .HasForeignKey(s => s.ArticleCategoryID);

            builder.Entity<Article>()
                .HasOne(s => s.Languages)
                .WithMany(u => u.Article)
                .HasForeignKey(s => s.LangID);


            #endregion

            #region Book

            builder.Entity<X_BookCategory>()
                .HasOne(s => s.Book)
                .WithMany(u => u.X_BookCategories)
                .HasForeignKey(s => s.BookID);

            builder.Entity<X_BookCategory>()
                .HasOne(s => s.BookCategory)
                .WithMany(u => u.X_BookCategories)
                .HasForeignKey(s => s.BookCategoryID);

            builder.Entity<Book>()
                .HasOne(s => s.Languages)
                .WithMany(u => u.Books)
                .HasForeignKey(s => s.LangID);

            #endregion

            #region Press

            builder.Entity<Press>()
                .HasOne(s => s.NewsPaper)
                .WithMany(u => u.Press)
                .HasForeignKey(s => s.NewsPaperID);

            builder.Entity<Press>()
               .HasOne(s => s.PressType)
               .WithMany(u => u.Press)
               .HasForeignKey(s => s.PressTypeID);

            builder.Entity<Press>()
                .HasOne(s => s.Languages)
                .WithMany(u => u.Presses)
                .HasForeignKey(s => s.LangID);

            #endregion

            #region Video

            builder.Entity<Video>()
                .HasOne(s => s.VideoCategory)
                .WithMany(u => u.Videos)
                .HasForeignKey(s => s.VideoCategoryID);

            #endregion

            #region WorkShop

            builder.Entity<Workshop>()
                .HasOne(s => s.WorkshopEducation)
                .WithMany(u => u.Workshop)
                .HasForeignKey(s => s.WSEducationID);

            builder.Entity<Workshop>()
               .HasOne(s => s.WorkshopType)
               .WithMany(u => u.WorkShop)
               .HasForeignKey(s => s.WSTypeID);

            builder.Entity<Workshop>()
                .HasOne(s => s.Languages)
                .WithMany(u => u.Workshops)
                .HasForeignKey(s => s.LangID);

            builder.Entity<WorkshopEducation>()
                .HasMany(s => s.WorkshopCategory)
                .WithOne(u => u.WorkshopEducation)
            .HasForeignKey(s => s.ID);

            builder.Entity<WorkshopEducation>()
                .HasOne(s => s.Languages)
                .WithMany(u => u.WorkshopEducations)
                .HasForeignKey(s => s.LangID);

            builder.Entity<WorkShopApplicationForm>()
                .HasOne(s => s.HearAboutUS)
                .WithMany(u => u.WorkShopApplicationForm)
                .HasForeignKey(s => s.HearAboutusID);

            builder.Entity<WorkShopApplicationForm>()
              .HasOne(s => s.Workshop)
              .WithMany(u => u.WorkShopApplicationForm)
              .HasForeignKey(s => s.WorkShopID);

            #endregion

            #region Contact

            builder.Entity<Contact>()
                .HasOne(s => s.ContactCategory)
                .WithMany(u => u.Contacts)
                .HasForeignKey(s => s.ContactCategoryID);

            #endregion

            #region Carousel

            builder.Entity<ImageCarousel>()
                .HasOne(s => s.Carousel)
                .WithMany(u => u.ImageCarousels)
                .HasForeignKey(s => s.CarouselID);

            #endregion

            #region Form

            builder.Entity<Form>()
                .HasMany(s => s.FixBmhs)
                .WithOne(s => s.Form)
                .HasForeignKey(s => s.FormID);

            builder.Entity<Form>()
                .HasMany(s => s.FixBMIs)
                .WithOne(s => s.Form)
                .HasForeignKey(s => s.FormID);

            builder.Entity<Form>()
                .HasMany(s => s.FixCalorieSches)
                .WithOne(s => s.Form)
                .HasForeignKey(s => s.FormID);

            builder.Entity<Form>()
                .HasMany(s => s.FixFeedPyramids)
                .WithOne(s => s.Form)
                .HasForeignKey(s => s.FormID);

            builder.Entity<Form>()
                .HasMany(s => s.FixHeartDiseases)
                .WithOne(s => s.Form)
                .HasForeignKey(s => s.FormID);

            builder.Entity<Form>()
                .HasMany(s => s.FixMealSizes)
                .WithOne(s => s.Form)
                .HasForeignKey(s => s.FormID);

            builder.Entity<Form>()
                .HasMany(s => s.FixOptimums)
                .WithOne(s => s.Form)
                .HasForeignKey(s => s.FormID);

            builder.Entity<Form>()
                .HasMany(s => s.FixPulses)
                .WithOne(s => s.Form)
                .HasForeignKey(s => s.FormID);

            #endregion

            #region Consultancy

            builder.Entity<ConsultancyForm>()
                .HasOne(s => s.ConsultancyFormType)
                .WithMany(s => s.ConsultancyForm)
                .HasForeignKey(s => s.ConsultancyFormTypeID);



            #endregion

            #region Calandar

            builder.Entity<Event>()
                         .HasOne(s => s.EventCategory)
                         .WithMany(s => s.Event)
                         .HasForeignKey(s => s.EventCategoryID);

            #endregion

            #region MemberInfo


            builder.Entity<MembersInformation>()
                .HasMany(s => s.FoodHabitsMoods)
                .WithOne(s => s.MembersInformation)
                .HasForeignKey(s => s.MembersInformationID);

            builder.Entity<MembersInformation>()
                .HasMany(s => s.AllergyProducingFoods)
                .WithOne(s => s.MembersInformation)
                .HasForeignKey(s => s.MembersInformationID);

            builder.Entity<MembersInformation>()
                .HasMany(s => s.FoodTimes)
                .WithOne(s => s.MembersInformation)
                .HasForeignKey(s => s.MembersInformationID);

            builder.Entity<MembersInformation>()
                .HasMany(s => s.FemaleMentalStates)
                .WithOne(s => s.MembersInformation)
                .HasForeignKey(s => s.MembersInformationID);

            builder.Entity<MembersInformation>()
                .HasMany(s => s.FoodHabits)
                .WithOne(s => s.MembersInformation)
                .HasForeignKey(s => s.MembersInformationID);

            builder.Entity<MembersInformation>()
                .HasMany(s => s.DiseasesCardiovasculars)
                .WithOne(s => s.MembersInformation)
                .HasForeignKey(s => s.MembersInformationID);

            builder.Entity<MembersInformation>()
                .HasMany(s => s.DiseasesDiabetes)
                .WithOne(s => s.MembersInformation)
                .HasForeignKey(s => s.MembersInformationID);

            builder.Entity<MembersInformation>()
                .HasMany(s => s.DiseasesDigestiveDisorders)
                .WithOne(s => s.MembersInformation)
                .HasForeignKey(s => s.MembersInformationID);

            builder.Entity<MembersInformation>()
                .HasMany(s => s.DiseasesFamilyMembers)
                .WithOne(s => s.MembersInformation)
                .HasForeignKey(s => s.MembersInformationID);

            #endregion

            #region Diseases

            builder.Entity<Diseases>()
                .HasMany(s => s.DiseasesCardiovasculars)
                .WithOne(s => s.Diseases)
                .HasForeignKey(s => s.DiseasesID);

            builder.Entity<Diseases>()
                .HasMany(s => s.DiseasesDiabetes)
                .WithOne(s => s.Diseases)
                .HasForeignKey(s => s.DiseasesID);

            builder.Entity<Diseases>()
                .HasMany(s => s.DiseasesDigestiveDisorders)
                .WithOne(s => s.Diseases)
                .HasForeignKey(s => s.DiseasesID);

            builder.Entity<Diseases>()
                .HasMany(s => s.DiseasesFamilyMembers)
                .WithOne(s => s.Diseases)
                .HasForeignKey(s => s.DiseasesID);

            #endregion

            #region AppointmentDetails

            builder.Entity<AppointmentDetail>()
               .HasOne(s => s.D_Appointment)
               .WithMany(s => s.AppointmentDetail)
               .HasForeignKey(s => s.AppointmentID);

            builder.Entity<AppointmentDetail>()
              .HasOne(s => s.Members)
              .WithMany(s => s.AppointmentDetail)
              .HasForeignKey(s => s.MembersID);

            builder.Entity<DietList>()
              .HasOne(s => s.AppointmentDetail)
              .WithMany(s => s.DietList)
              .HasForeignKey(s => s.AppointmentDetailID);

            builder.Entity<DietList>()
              .HasOne(s => s.Users)
              .WithMany(s => s.DietLists)
              .HasForeignKey(s => s.UserID);

            builder.Entity<_DaysMeal>()
             .HasOne(s => s.Days)
             .WithMany(s => s._DaysMeal)
             .HasForeignKey(s => s.DaysID);

            builder.Entity<_DaysMeal>()
            .HasOne(s => s.Meal)
            .WithMany(s => s._DaysMeal)
            .HasForeignKey(s => s.MealID);

            builder.Entity<_Examination>()
           .HasOne(s => s.Examination)
           .WithMany(s => s._Examination)
           .HasForeignKey(s => s.ExaminationID);

            builder.Entity<_Examination>()
            .HasOne(s => s.Lab)
            .WithMany(s => s._Examination)
            .HasForeignKey(s => s.LabID);

            builder.Entity<Lab>()
             .HasOne(s => s.Members)
             .WithMany(s => s.Lab)
             .HasForeignKey(s => s.MembersID);

            builder.Entity<Lab>()
             .HasOne(s => s.User)
             .WithMany(s => s.Lab)
             .HasForeignKey(s => s.UsersID);

            builder.Entity<DietList>()
           .HasMany(s => s._DaysMeal)
           .WithOne(s => s.DietList)
           .HasForeignKey(s => s.DietListID);

            builder.Entity<AppointmentDetail>()
            .HasOne(s => s.User)
            .WithMany(s => s.AppointmentDetail)
            .HasForeignKey(s => s.UserID);


            #endregion

            #region SeminarVisual

            builder.Entity<SeminarVisuals>()
                .HasOne(s => s.Languages)
                .WithMany(u => u.SeminarVisuals)
                .HasForeignKey(s => s.LangID);

            #endregion


            base.OnModelCreating(builder);
        }
    }
}
