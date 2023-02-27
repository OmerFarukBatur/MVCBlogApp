using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Domain.Entities;
using MVCBlogApp.Domain.Entities.Common;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace MVCBlogApp.Persistence.Contexts
{
    public class MVCBlogDbContext : DbContext
    {
        public MVCBlogDbContext(DbContextOptions options) : base(options)
        {

        }

        #region DbSet
        public virtual DbSet<AllergyProducingFoods> AllergyProducingFoods { get; set; } = null!;
        public virtual DbSet<AppointmentDetail> AppointmentDetail { get; set; } = null!;
        public virtual DbSet<Article> Article { get; set; } = null!;
        public virtual DbSet<ArticleCategory> ArticleCategory { get; set; } = null!;
        public virtual DbSet<Auth> Auth { get; set; } = null!;
        public virtual DbSet<Banner> Banner { get; set; } = null!;
        public virtual DbSet<Blog> Blog { get; set; } = null!;
        public virtual DbSet<BlogCategory> BlogCategory { get; set; } = null!;
        public virtual DbSet<BlogType> BlogType { get; set; } = null!;
        public virtual DbSet<Book> Book { get; set; } = null!;
        public virtual DbSet<BookCategory> BookCategory { get; set; } = null!;
        public virtual DbSet<CalcBmh> CalcBmh { get; set; } = null!;
        public virtual DbSet<CalcBMI> CalcBMI { get; set; } = null!;
        public virtual DbSet<CalcOptimum> CalcOptimum { get; set; } = null!;
        public virtual DbSet<CalcPulse> CalcPulse { get; set; } = null!;
        public virtual DbSet<Carousel> Carousel { get; set; } = null!;
        public virtual DbSet<Case> Case { get; set; } = null!;
        public virtual DbSet<Confession> Confession { get; set; } = null!;
        public virtual DbSet<ConsultancyForm> ConsultancyForm { get; set; } = null!;
        public virtual DbSet<ConsultancyFormType> ConsultancyFormType { get; set; } = null!;
        public virtual DbSet<Contact> Contact { get; set; } = null!;
        public virtual DbSet<ContactCategory> ContactCategory { get; set; } = null!;
        public virtual DbSet<D_Appointment> D_Appointment { get; set; } = null!;
        public virtual DbSet<D_Specialties> D_Specialties { get; set; } = null!;
        public virtual DbSet<Days> Days { get; set; } = null!;
        public virtual DbSet<_DaysMeal> _DaysMeal { get; set; } = null!;
        public virtual DbSet<DietList> DietList { get; set; } = null!;
        public virtual DbSet<Diseases> Diseases { get; set; } = null!;
        public virtual DbSet<DiseasesCardiovascular> DiseasesCardiovascular { get; set; } = null!;
        public virtual DbSet<DiseasesDiabetes> DiseasesDiabetes { get; set; } = null!;
        public virtual DbSet<DiseasesDigestiveDisorders> DiseasesDigestiveDisorders { get; set; } = null!;
        public virtual DbSet<DiseasesFamilyMembers> DiseasesFamilyMembers { get; set; } = null!;
        public virtual DbSet<Event> Event { get; set; } = null!;
        public virtual DbSet<EventCategory> EventCategory { get; set; } = null!;
        public virtual DbSet<Examination> Examination { get; set; } = null!;
        public virtual DbSet<_Examination> _Examination { get; set; } = null!;
        public virtual DbSet<FemaleMentalState> FemaleMentalState { get; set; } = null!;
        public virtual DbSet<FixBmh> FixBmh { get; set; } = null!;
        public virtual DbSet<FixBMI> FixBMI { get; set; } = null!;
        public virtual DbSet<FixCalorieSch> FixCalorieSch { get; set; } = null!;
        public virtual DbSet<FixFeedPyramid> FixFeedPyramid { get; set; } = null!;
        public virtual DbSet<FixHeartDiseases> FixHeartDiseases { get; set; } = null!;
        public virtual DbSet<FixMealSize> FixMealSize { get; set; } = null!;
        public virtual DbSet<FixOptimum> FixOptimum { get; set; } = null!;
        public virtual DbSet<FixPulse> FixPulse { get; set; } = null!;
        public virtual DbSet<FoodHabits> FoodHabit { get; set; } = null!;
        public virtual DbSet<FoodHabitMood> FoodHabitMood { get; set; } = null!;
        public virtual DbSet<FoodTime> FoodTime { get; set; } = null!;
        public virtual DbSet<Form> Form { get; set; } = null!;
        public virtual DbSet<Genders> Genders { get; set; } = null!;
        public virtual DbSet<HearAboutUS> HearAboutUS { get; set; } = null!;
        public virtual DbSet<Image> Image { get; set; } = null!;
        public virtual DbSet<ImageBlog> ImageBlog { get; set; } = null!;
        public virtual DbSet<ImageCarousel> ImageCarousel { get; set; } = null!;
        public virtual DbSet<Influencer> Influencer { get; set; } = null!;
        public virtual DbSet<Lab> Lab { get; set; } = null!;
        public virtual DbSet<Languages> Languages { get; set; } = null!;
        public virtual DbSet<MasterRoot> MasterRoot { get; set; } = null!;
        public virtual DbSet<Meal> Meal { get; set; } = null!;
        public virtual DbSet<Members> Members { get; set; } = null!;
        public virtual DbSet<MembersAuth> MembersAuth { get; set; } = null!;
        public virtual DbSet<MembersInformation> MembersInformation { get; set; } = null!;
        public virtual DbSet<MetaKeyword> MetaKeyword { get; set; } = null!;
        public virtual DbSet<Navigation> Navigation { get; set; } = null!;
        public virtual DbSet<NewsBulletin> NewsBulletin { get; set; } = null!;
        public virtual DbSet<NewsPaper> NewsPaper { get; set; } = null!;
        public virtual DbSet<OurTeam> OurTeam { get; set; } = null!;
        public virtual DbSet<Press> Press { get; set; } = null!;
        public virtual DbSet<PressType> PressType { get; set; } = null!;
        public virtual DbSet<References> References { get; set; } = null!;
        public virtual DbSet<ResultBmh> ResultBmhs { get; set; } = null!;
        public virtual DbSet<ResultBMI> ResultBMI { get; set; } = null!;
        public virtual DbSet<ResultOptimum> ResultOptimum { get; set; } = null!;
        public virtual DbSet<ResultPulse> ResultPulse { get; set; } = null!;
        public virtual DbSet<SeminarVisuals> SeminarVisuals { get; set; } = null!;
        public virtual DbSet<SLeftNavigation> SLeftNavigation { get; set; } = null!;
        public virtual DbSet<Status> Status { get; set; } = null!;
        public virtual DbSet<TaylanK> TaylanK { get; set; } = null!;
        public virtual DbSet<User> User { get; set; } = null!;
        public virtual DbSet<Video> Video { get; set; } = null!;
        public virtual DbSet<VideoCategory> VideoCategory { get; set; } = null!;
        public virtual DbSet<WorkShopApplicationForm> WorkShopApplicationForm { get; set; } = null!;
        public virtual DbSet<Workshop> Workshop { get; set; } = null!;
        public virtual DbSet<WorkshopCategory> WorkshopCategory { get; set; } = null!;
        public virtual DbSet<WorkshopEducation> WorkshopEducation { get; set; } = null!;
        public virtual DbSet<WorkshopType> WorkshopType { get; set; } = null!;
        public virtual DbSet<X_BlogCategory> X_BlogCategory { get; set; } = null!;
        public virtual DbSet<X_BookCategory> X_BookCategory { get; set; } = null!;
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}

            modelBuilder.Entity<AllergyProducingFoods>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MembersInformationId).HasColumnName("MembersInformationID");

                entity.HasOne(d => d.MembersInformation)
                    .WithMany(p => p.AllergyProducingFoods)
                    .HasForeignKey(d => d.MembersInformationId)
                    .HasConstraintName("FK_AllergyProducingFoods_MembersInformation");
            });

            modelBuilder.Entity<AppointmentDetail>(entity =>
            {
                entity.ToTable("AppointmentDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");

                entity.Property(e => e.MembersId).HasColumnName("MembersID");

                entity.Property(e => e.OilRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Size).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("Article");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArticleCategoryId).HasColumnName("ArticleCategoryID");

                entity.Property(e => e.ArticleDate).HasColumnType("datetime");

                entity.Property(e => e.AuthorUserId).HasColumnName("AuthorUserID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.FontAwesomeIcon).HasMaxLength(100);

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.MetaKey).HasMaxLength(250);

                entity.Property(e => e.MetaTitle).HasMaxLength(250);

                entity.Property(e => e.NavigationId).HasColumnName("NavigationID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.SubTitle).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.HasOne(d => d.ArticleCategory)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.ArticleCategoryId)
                    .HasConstraintName("FK_Article_ArticleCategory");
            });

            modelBuilder.Entity<ArticleCategory>(entity =>
            {
                entity.ToTable("ArticleCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryName).HasMaxLength(250);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.MetaKey).HasMaxLength(250);

                entity.Property(e => e.MetaTitle).HasMaxLength(250);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<Auth>(entity =>
            {
                entity.ToTable("Auth");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.AuthName).HasMaxLength(250);
            });

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.ToTable("Banner");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BannerName).HasMaxLength(150);

                entity.Property(e => e.DateString).HasMaxLength(150);

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Action).HasMaxLength(100);

                entity.Property(e => e.BlogCategoryId).HasColumnName("BlogCategoryID");

                entity.Property(e => e.BlogTypeId).HasColumnName("BlogTypeID");

                entity.Property(e => e.Controller).HasMaxLength(100);

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.MetaKey).HasMaxLength(250);

                entity.Property(e => e.MetaTitle).HasMaxLength(150);

                entity.Property(e => e.NavigationId).HasColumnName("NavigationID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.SubTitle).HasMaxLength(750);

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.HasOne(d => d.BlogCategory)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.BlogCategoryId)
                    .HasConstraintName("FK_Blog_BlogCategory");

                entity.HasOne(d => d.BlogType)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.BlogTypeId)
                    .HasConstraintName("FK_Blog_BlogType");
            });

            modelBuilder.Entity<BlogCategory>(entity =>
            {
                entity.ToTable("BlogCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryName).HasMaxLength(50);

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<BlogType>(entity =>
            {
                entity.ToTable("BlogType");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.TypeName).HasMaxLength(150);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Action).HasMaxLength(100);

                entity.Property(e => e.BookName).HasMaxLength(250);

                entity.Property(e => e.Controller).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.NavigationId).HasColumnName("NavigationID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.UrlRoot).HasMaxLength(250);
            });

            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.ToTable("BookCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryName).HasMaxLength(250);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<CalcBmh>(entity =>
            {
                entity.ToTable("CalcBmh");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Gender).HasMaxLength(250);

                entity.Property(e => e.NameSurname).HasMaxLength(250);

                entity.Property(e => e.Result).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<CalcBMI>(entity =>
            {
                entity.ToTable("CalcBMI");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.NameSurname).HasMaxLength(250);

                entity.Property(e => e.Result).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<CalcOptimum>(entity =>
            {
                entity.ToTable("CalcOptimum");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Gender).HasMaxLength(250);

                entity.Property(e => e.NameSurname).HasMaxLength(250);

                entity.Property(e => e.Result1).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Result2).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Result3).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Result4).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<CalcPulse>(entity =>
            {
                entity.ToTable("CalcPulse");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Gender).HasMaxLength(250);

                entity.Property(e => e.NameSurname).HasMaxLength(250);

                entity.Property(e => e.ResultMax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ResultMin).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Carousel>(entity =>
            {
                entity.ToTable("Carousel");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.ImgName).HasMaxLength(250);

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.MetaKey).HasMaxLength(250);

                entity.Property(e => e.MetaTitle).HasMaxLength(250);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<Case>(entity =>
            {
                entity.ToTable("Case");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.CaseName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LangId).HasColumnName("LangID");
            });

            modelBuilder.Entity<Confession>(entity =>
            {
                entity.ToTable("Confession");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.MemberName).HasMaxLength(250);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<ConsultancyForm>(entity =>
            {
                entity.ToTable("ConsultancyForm");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ConsultancyFormTypeId).HasColumnName("ConsultancyFormTypeID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.NameSurname).HasMaxLength(250);

                entity.Property(e => e.Phone)
                    .HasMaxLength(14)
                    .IsFixedLength();

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Subject).HasMaxLength(500);
            });

            modelBuilder.Entity<ConsultancyFormType>(entity =>
            {
                entity.ToTable("ConsultancyFormType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ConsultancyFormTypeName).HasMaxLength(250);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ContactCategoryId).HasColumnName("ContactCategoryID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.NameSurname).HasMaxLength(250);

                entity.Property(e => e.Phone).HasMaxLength(250);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Subject).HasMaxLength(100);
            });

            modelBuilder.Entity<ContactCategory>(entity =>
            {
                entity.ToTable("ContactCategory");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.ContactCategoryName).HasMaxLength(150);

                entity.Property(e => e.LangId).HasColumnName("LangID");
            });

            modelBuilder.Entity<D_Appointment>(entity =>
            {
                entity.ToTable("D_Appointment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppointmentDate).HasColumnType("datetime");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.MembersId).HasColumnName("MembersID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Subject).HasMaxLength(250);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<D_Specialties>(entity =>
            {
                entity.ToTable("D_Specialties");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Days>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.DayName).HasMaxLength(50);
            });

            modelBuilder.Entity<_DaysMeal>(entity =>
            {
                entity.ToTable("_DaysMeal");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DaysId).HasColumnName("DaysID");

                entity.Property(e => e.DietListId).HasColumnName("DietListID");

                entity.Property(e => e.MealId).HasColumnName("MealID");
            });

            modelBuilder.Entity<DietList>(entity =>
            {
                entity.ToTable("DietList");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppointmentDetailId).HasColumnName("AppointmentDetailID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Diseases>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiseasesName).HasMaxLength(250);
            });

            modelBuilder.Entity<DiseasesCardiovascular>(entity =>
            {
                entity.ToTable("DiseasesCardiovascular");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiseasesId).HasColumnName("DiseasesID");

                entity.Property(e => e.MembersInformationId).HasColumnName("MembersInformationID");

                entity.HasOne(d => d.Diseases)
                    .WithMany(p => p.DiseasesCardiovasculars)
                    .HasForeignKey(d => d.DiseasesId)
                    .HasConstraintName("FK_DiseasesCardiovascular_Diseases");

                entity.HasOne(d => d.MembersInformation)
                    .WithMany(p => p.DiseasesCardiovasculars)
                    .HasForeignKey(d => d.MembersInformationId)
                    .HasConstraintName("FK_DiseasesCardiovascular_MembersInformation");
            });

            modelBuilder.Entity<DiseasesDiabetes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiseasesId).HasColumnName("DiseasesID");

                entity.Property(e => e.MembersInformationId).HasColumnName("MembersInformationID");

                entity.HasOne(d => d.Diseases)
                    .WithMany(p => p.DiseasesDiabetes)
                    .HasForeignKey(d => d.DiseasesId)
                    .HasConstraintName("FK_DiseasesDiabetes_Diseases");

                entity.HasOne(d => d.MembersInformation)
                    .WithMany(p => p.DiseasesDiabetes)
                    .HasForeignKey(d => d.MembersInformationId)
                    .HasConstraintName("FK_DiseasesDiabetes_MembersInformation");
            });

            modelBuilder.Entity<DiseasesDigestiveDisorders>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiseasesId).HasColumnName("DiseasesID");

                entity.Property(e => e.MembersInformationId).HasColumnName("MembersInformationID");

                entity.HasOne(d => d.Diseases)
                    .WithMany(p => p.DiseasesDigestiveDisorders)
                    .HasForeignKey(d => d.DiseasesId)
                    .HasConstraintName("FK_DiseasesDigestiveDisorders_Diseases");

                entity.HasOne(d => d.MembersInformation)
                    .WithMany(p => p.DiseasesDigestiveDisorders)
                    .HasForeignKey(d => d.MembersInformationId)
                    .HasConstraintName("FK_DiseasesDigestiveDisorders_MembersInformation");
            });

            modelBuilder.Entity<DiseasesFamilyMembers>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiseasesId).HasColumnName("DiseasesID");

                entity.Property(e => e.MembersInformationId).HasColumnName("MembersInformationID");

                entity.HasOne(d => d.Diseases)
                    .WithMany(p => p.DiseasesFamilyMembers)
                    .HasForeignKey(d => d.DiseasesId)
                    .HasConstraintName("FK_DiseasesFamilyMembers_Diseases");

                entity.HasOne(d => d.MembersInformation)
                    .WithMany(p => p.DiseasesFamilyMembers)
                    .HasForeignKey(d => d.MembersInformationId)
                    .HasConstraintName("FK_DiseasesFamilyMembers_MembersInformation");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.EventCategoryId).HasColumnName("EventCategoryID");

                entity.Property(e => e.FinishDatetime).HasColumnType("datetime");

                entity.Property(e => e.StartDatetime).HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<EventCategory>(entity =>
            {
                entity.ToTable("EventCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EventCategoryName).HasMaxLength(250);
            });

            modelBuilder.Entity<_Examination>(entity =>
            {
                entity.ToTable("_Examination");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ExaminationId).HasColumnName("ExaminationID");

                entity.Property(e => e.LabId).HasColumnName("LabID");

                entity.Property(e => e.Value).HasMaxLength(50);
            });

            modelBuilder.Entity<Examination>(entity =>
            {
                entity.ToTable("Examination");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ExaminatioName).HasMaxLength(50);
            });

            modelBuilder.Entity<FemaleMentalState>(entity =>
            {
                entity.ToTable("FemaleMentalState");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MembersInformationId).HasColumnName("MembersInformationID");

                entity.HasOne(d => d.MembersInformation)
                    .WithMany(p => p.FemaleMentalStates)
                    .HasForeignKey(d => d.MembersInformationId)
                    .HasConstraintName("FK_FemaleMentalState_MembersInformation");
            });

            modelBuilder.Entity<FixBmh>(entity =>
            {
                entity.ToTable("FixBmh");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FixBmhs)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK_FixBmh_Form");
            });

            modelBuilder.Entity<FixBMI>(entity =>
            {
                entity.ToTable("FixBMI");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FixBmis)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK_FixBMI_Form");
            });

            modelBuilder.Entity<FixCalorieSch>(entity =>
            {
                entity.ToTable("FixCalorieSch");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FixCalorieSches)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK_FixCalorieSch_Form");
            });

            modelBuilder.Entity<FixFeedPyramid>(entity =>
            {
                entity.ToTable("FixFeedPyramid");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FixFeedPyramids)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK_FixFeedPyramid_Form");
            });

            modelBuilder.Entity<FixHeartDiseases>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FixHeartDiseases)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK_FixHeartDiseases_Form");
            });

            modelBuilder.Entity<FixMealSize>(entity =>
            {
                entity.ToTable("FixMealSize");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FixMealSizes)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK_FixMealSize_Form");
            });

            modelBuilder.Entity<FixOptimum>(entity =>
            {
                entity.ToTable("FixOptimum");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FixOptimums)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK_FixOptimum_Form");
            });

            modelBuilder.Entity<FixPulse>(entity =>
            {
                entity.ToTable("FixPulse");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FixPulses)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK_FixPulse_Form");
            });

            modelBuilder.Entity<FoodHabits>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MembersInformationId).HasColumnName("MembersInformationID");

                entity.HasOne(d => d.MembersInformation)
                    .WithMany(p => p.FoodHabits)
                    .HasForeignKey(d => d.MembersInformationId)
                    .HasConstraintName("FK_FoodHabits_MembersInformation");
            });

            modelBuilder.Entity<FoodHabitMood>(entity =>
            {
                entity.ToTable("FoodHabitMood");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MembersInformationId).HasColumnName("MembersInformationID");
            });

            modelBuilder.Entity<FoodTime>(entity =>
            {
                entity.ToTable("FoodTime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MembersInformationId).HasColumnName("MembersInformationID");

                entity.HasOne(d => d.MembersInformation)
                    .WithMany(p => p.FoodTimes)
                    .HasForeignKey(d => d.MembersInformationId)
                    .HasConstraintName("FK_FoodTime_MembersInformation");
            });

            modelBuilder.Entity<Form>(entity =>
            {
                entity.ToTable("Form");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Action).HasMaxLength(250);

                entity.Property(e => e.Controller).HasMaxLength(250);

                entity.Property(e => e.FormName).HasMaxLength(250);

                entity.Property(e => e.LangId).HasColumnName("LangID");
            });

            modelBuilder.Entity<Genders>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("Gender")
                    .IsFixedLength();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LangId).HasColumnName("LangID");
            });

            modelBuilder.Entity<HearAboutUS>(entity =>
            {
                entity.ToTable("HearAboutUS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.HearAboutUsname)
                    .HasMaxLength(150)
                    .HasColumnName("HearAboutUSName");

                entity.Property(e => e.LangId).HasColumnName("LangID");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<ImageBlog>(entity =>
            {
                entity.ToTable("ImageBlog");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BlogId).HasColumnName("BlogID");

                entity.Property(e => e.ImgName).HasMaxLength(250);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<ImageCarousel>(entity =>
            {
                entity.ToTable("ImageCarousel");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CarouselId).HasColumnName("CarouselID");

                entity.Property(e => e.ImgName).HasMaxLength(250);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<Influencer>(entity =>
            {
                entity.ToTable("Influencer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyName).HasMaxLength(250);

                entity.Property(e => e.CompanySector).HasMaxLength(250);

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.NameSurname).HasMaxLength(250);

                entity.Property(e => e.Phone).HasMaxLength(250);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<Lab>(entity =>
            {
                entity.ToTable("Lab");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppointmentDetailId).HasColumnName("AppointmentDetailID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LabDateTime).HasColumnType("datetime");

                entity.Property(e => e.MembersId).HasColumnName("MembersID");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.UsersId).HasColumnName("UsersID");
            });

            modelBuilder.Entity<Languages>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Language)
                    .HasMaxLength(100)
                    .HasColumnName("Language");
            });

            modelBuilder.Entity<MasterRoot>(entity =>
            {
                entity.ToTable("MasterRoot");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.Controller).HasMaxLength(50);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.ToTable("Meal");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .HasColumnName("EMail");

                entity.Property(e => e.Lacation).HasMaxLength(50);

                entity.Property(e => e.MembersAuthId).HasColumnName("MembersAuthID");

                entity.Property(e => e.NameSurname).HasMaxLength(250);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsFixedLength();
            });

            modelBuilder.Entity<MembersAuth>(entity =>
            {
                entity.ToTable("MembersAuth");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.MembersAuthName).HasMaxLength(250);
            });

            modelBuilder.Entity<MembersInformation>(entity =>
            {
                entity.ToTable("MembersInformation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Birthdate).HasColumnType("datetime");

                entity.Property(e => e.CpreviousDisease).HasColumnName("CPreviousDisease");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.GetDrugged).HasMaxLength(250);

                entity.Property(e => e.ImageUrl).HasMaxLength(250);

                entity.Property(e => e.Job).HasMaxLength(250);

                entity.Property(e => e.MembersId).HasColumnName("MembersID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.PhoneNumber).HasMaxLength(250);

                entity.Property(e => e.Surname).HasMaxLength(250);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MetaKeyword>(entity =>
            {
                entity.ToTable("MetaKeyword");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.Page).HasMaxLength(250);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title).HasMaxLength(80);
            });

            modelBuilder.Entity<Navigation>(entity =>
            {
                entity.ToTable("Navigation");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.Action).HasMaxLength(250);

                entity.Property(e => e.Controller).HasMaxLength(250);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FontAwesomeIcon).HasMaxLength(250);

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.MetaKey).HasMaxLength(250);

                entity.Property(e => e.MetaTitle).HasMaxLength(250);

                entity.Property(e => e.NavigationName).HasMaxLength(250);

                entity.Property(e => e.OrderNo).HasMaxLength(250);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.UrlRoot).HasMaxLength(250);
            });

            modelBuilder.Entity<NewsBulletin>(entity =>
            {
                entity.ToTable("NewsBulletin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<NewsPaper>(entity =>
            {
                entity.ToTable("NewsPaper");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.NewsPaperName).HasMaxLength(250);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<OurTeam>(entity =>
            {
                entity.ToTable("OurTeam");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.NameSurname).HasMaxLength(250);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<Press>(entity =>
            {
                entity.ToTable("Press");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.MetaKey).HasMaxLength(250);

                entity.Property(e => e.MetaTitle).HasMaxLength(250);

                entity.Property(e => e.NewsPaperId).HasColumnName("NewsPaperID");

                entity.Property(e => e.PressTypeId).HasColumnName("PressTypeID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<PressType>(entity =>
            {
                entity.ToTable("PressType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PressTypeName)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<References>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.ImgUrl).HasMaxLength(250);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.UrlLink).HasMaxLength(250);
            });

            modelBuilder.Entity<ResultBmh>(entity =>
            {
                entity.ToTable("ResultBmh");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<ResultBMI>(entity =>
            {
                entity.ToTable("ResultBMI");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IntervalMax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IntervalMin).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<ResultOptimum>(entity =>
            {
                entity.ToTable("ResultOptimum");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<ResultPulse>(entity =>
            {
                entity.ToTable("ResultPulse");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<SeminarVisuals>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.Location).HasMaxLength(250);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<SLeftNavigation>(entity =>
            {
                entity.ToTable("SLeftNavigation");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.Title).HasMaxLength(1250);

                entity.Property(e => e.Url).HasMaxLength(1250);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.StatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<TaylanK>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TaylanK");

                entity.Property(e => e.CompanyName).HasMaxLength(250);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email1).HasMaxLength(250);

                entity.Property(e => e.Email2).HasMaxLength(250);

                entity.Property(e => e.Facebook).HasMaxLength(250);

                entity.Property(e => e.Fax)
                    .HasMaxLength(24)
                    .IsFixedLength();

                entity.Property(e => e.GoogleMap).HasMaxLength(250);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Instagram).HasMaxLength(250);

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.Phone1)
                    .HasMaxLength(24)
                    .IsFixedLength();

                entity.Property(e => e.Phone2)
                    .HasMaxLength(24)
                    .IsFixedLength();

                entity.Property(e => e.Pinterest).HasMaxLength(250);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Twitter).HasMaxLength(250);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthId).HasColumnName("AuthID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedUserId).HasColumnName("ModifiedUserID");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(150);
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.ToTable("Video");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.VideoCategoryId).HasColumnName("VideoCategoryID");

                entity.HasOne(d => d.VideoCategory)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.VideoCategoryId)
                    .HasConstraintName("FK_Video_VideoCategory");
            });

            modelBuilder.Entity<VideoCategory>(entity =>
            {
                entity.ToTable("VideoCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.VideoCategoryName).HasMaxLength(250);
            });

            modelBuilder.Entity<WorkShopApplicationForm>(entity =>
            {
                entity.ToTable("WorkShopApplicationForm");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.HearAboutusId).HasColumnName("HearAboutusID");

                entity.Property(e => e.Job).HasMaxLength(250);

                entity.Property(e => e.NameSurname).HasMaxLength(250);

                entity.Property(e => e.Phone)
                    .HasMaxLength(14)
                    .IsFixedLength();

                entity.Property(e => e.WorkShopId).HasColumnName("WorkShopID");
            });

            modelBuilder.Entity<Workshop>(entity =>
            {
                entity.ToTable("Workshop");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.FinishDateTime).HasColumnType("datetime");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.NavigationId).HasColumnName("NavigationID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.WseducationId).HasColumnName("WSEducationID");

                entity.Property(e => e.WstypeId).HasColumnName("WSTypeID");
            });

            modelBuilder.Entity<WorkshopCategory>(entity =>
            {
                entity.ToTable("WorkshopCategory");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.WscategoryName)
                    .HasMaxLength(150)
                    .HasColumnName("WSCategoryName");
            });

            modelBuilder.Entity<WorkshopEducation>(entity =>
            {
                entity.ToTable("WorkshopEducation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.WsEducationName).HasMaxLength(250);

                entity.Property(e => e.WscategoryId).HasColumnName("WSCategoryID");
            });

            modelBuilder.Entity<WorkshopType>(entity =>
            {
                entity.ToTable("WorkshopType");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.LangId).HasColumnName("LangID");

                entity.Property(e => e.WstypeName)
                    .HasMaxLength(150)
                    .HasColumnName("WSTypeName");
            });

            modelBuilder.Entity<X_BlogCategory>(entity =>
            {
                entity.ToTable("X_BlogCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BlogCategoryId).HasColumnName("BlogCategoryID");

                entity.Property(e => e.BlogId).HasColumnName("BlogID");
            });

            modelBuilder.Entity<X_BookCategory>(entity =>
            {
                entity.ToTable("X_BookCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookCategoryId).HasColumnName("BookCategoryID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.HasOne(d => d.BookCategory)
                    .WithMany(p => p.X_BookCategory)
                    .HasForeignKey(d => d.BookCategoryId)
                    .HasConstraintName("FK_X_BookCategory_BookCategory");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.X_BookCategory)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_X_BookCategory_Book");
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
