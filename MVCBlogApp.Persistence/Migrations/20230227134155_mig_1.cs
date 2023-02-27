using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBlogApp.Persistence.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_DaysMeal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietListID = table.Column<int>(type: "int", nullable: true),
                    DaysID = table.Column<int>(type: "int", nullable: true),
                    TimeInterval = table.Column<TimeSpan>(type: "time", nullable: true),
                    MealID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DaysMeal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "_Examination",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExaminationID = table.Column<int>(type: "int", nullable: true),
                    LabID = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Examination", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentID = table.Column<int>(type: "int", nullable: true),
                    MembersID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Treatment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Size = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OilRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentDetail", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetaTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    CreateUserID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Auth",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Banner",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BannerName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    BannerUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerOrder = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    DateString = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BlogCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BlogType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PublicationYear = table.Column<int>(type: "int", nullable: true),
                    UrlRoot = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Controller = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserID = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    IsMainPage = table.Column<bool>(type: "bit", nullable: true),
                    Orders = table.Column<int>(type: "int", nullable: true),
                    NavigationID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserID = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CalcBmh",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Size = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NameSurname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Result = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalcBmh", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CalcBMI",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    NameSurname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Result = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalcBMI", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CalcOptimum",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Size = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NameSurname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Result1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Result2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Result3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Result4 = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalcOptimum", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CalcPulse",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    NameSurname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ResultMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ResultMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalcPulse", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Carousel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlRoot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Orders = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    MetaKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carousel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Confession",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberConfession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: true),
                    IsAprove = table.Column<bool>(type: "bit", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: true),
                    CreateDatetime = table.Column<DateTime>(type: "datetime", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confession", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ConsultancyForm",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultancyFormTypeID = table.Column<int>(type: "int", nullable: true),
                    NameSurname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nchar(14)", fixedLength: true, maxLength: 14, nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultancyForm", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ConsultancyFormType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultancyFormTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultancyFormType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ContactCategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContactCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactCategoryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "D_Appointment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembersID = table.Column<int>(type: "int", nullable: true),
                    AppointmentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Subject = table.Column<byte[]>(type: "varbinary(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interval = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Appointment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "D_Specialties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specialties = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Specialties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DietList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDetailID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseasesName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDatetime = table.Column<DateTime>(type: "datetime", nullable: true),
                    FinishDatetime = table.Column<DateTime>(type: "datetime", nullable: true),
                    EventCategoryID = table.Column<int>(type: "int", nullable: true),
                    CreateUserID = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EventCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventCategoryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Examination",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExaminatioName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examination", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FoodHabitMood",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembersInformationID = table.Column<int>(type: "int", nullable: true),
                    Sad = table.Column<bool>(type: "bit", nullable: true),
                    Stress = table.Column<bool>(type: "bit", nullable: true),
                    Doomy = table.Column<bool>(type: "bit", nullable: true),
                    Happy = table.Column<bool>(type: "bit", nullable: true),
                    All = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodHabitMood", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Controller = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Action = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Gender = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "HearAboutUS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HearAboutUSName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HearAboutUS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCover = table.Column<bool>(type: "bit", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserID = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ImageBlog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogID = table.Column<int>(type: "int", nullable: true),
                    IsCover = table.Column<bool>(type: "bit", nullable: true),
                    ImgName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageBlog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ImageCarousel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarouselID = table.Column<int>(type: "int", nullable: true),
                    ImgName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageCarousel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Influencer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanySector = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDatetime = table.Column<DateTime>(type: "datetime", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Influencer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lab",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDetailID = table.Column<int>(type: "int", nullable: true),
                    MembersID = table.Column<int>(type: "int", nullable: true),
                    UsersID = table.Column<int>(type: "int", nullable: true),
                    LabDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lab", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MasterRoot",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Controller = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UrlRoot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterRoot", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Phone = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: true),
                    Lacation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MembersAuthID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MembersAuth",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembersAuthName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersAuth", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MembersInformation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembersID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Job = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    HistoryOfWeigh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPreviousDisease = table.Column<bool>(type: "bit", nullable: true),
                    OneDaySummary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheQuantityConsumedWater = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheQuantityConsumedTea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheQuantityConsumedCoffe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheQuantityConsumedFizzy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheQuantityConsumedAlchol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoYouUseCigarettes = table.Column<bool>(type: "bit", nullable: true),
                    HaveYouGainedWeight = table.Column<bool>(type: "bit", nullable: true),
                    FoodLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodMade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManTheNeedForEatingVaries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DidYouGainWeightInTheArmy = table.Column<bool>(type: "bit", nullable: true),
                    IsBloodCoagulationDisorders = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoYouHaveHormonalProblem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HowDoYouFeel = table.Column<int>(type: "int", nullable: true),
                    HowIsYourEnergy = table.Column<int>(type: "int", nullable: true),
                    HowFrequencyOfActivity = table.Column<int>(type: "int", nullable: true),
                    ConsumedVegetables = table.Column<int>(type: "int", nullable: true),
                    GetDrugged = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DoYouUseVitaminAndMinerals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersInformation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MetaKeyword",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Page = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Canonical = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaKeyword", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Navigation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    OrderNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsHeader = table.Column<bool>(type: "bit", nullable: true),
                    IsSubHeader = table.Column<bool>(type: "bit", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UrlRoot = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NavigationName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Controller = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Action = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FontAwesomeIcon = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navigation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NewsBulletin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserID = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsBulletin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NewsPaper",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsPaperName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsPaper", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OurTeam",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserID = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurTeam", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Press",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlRoot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsPaperID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PressTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Press", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PressType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PressTypeName = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PressType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "References",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UrlLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserID = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ResultBmh",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resulttext = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultBmh", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ResultBMI",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntervalMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IntervalMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IntervalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultBMI", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ResultOptimum",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Result1text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result2text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result3text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result4text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultOptimum", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ResultPulse",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResultMaxText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultMinText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultPulse", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SeminarVisuals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeminarVisuals", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SLeftNavigation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(1250)", maxLength: 1250, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(1250)", maxLength: 1250, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLeftNavigation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TaylanK",
                columns: table => new
                {
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nchar(24)", fixedLength: true, maxLength: 24, nullable: true),
                    Phone2 = table.Column<string>(type: "nchar(24)", fixedLength: true, maxLength: 24, nullable: true),
                    Fax = table.Column<string>(type: "nchar(24)", fixedLength: true, maxLength: 24, nullable: true),
                    Email1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    GoogleMap = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pinterest = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    Metakey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Metatitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Metadescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AuthID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VideoCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoCategoryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Workshop",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    FinishDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WSEducationID = table.Column<int>(type: "int", nullable: true),
                    WSTypeID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    IsMainPage = table.Column<bool>(type: "bit", nullable: true),
                    Orders = table.Column<int>(type: "int", nullable: true),
                    NavigationID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workshop", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WorkShopApplicationForm",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkShopID = table.Column<int>(type: "int", nullable: true),
                    NameSurname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nchar(14)", fixedLength: true, maxLength: 14, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Job = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HearAboutusID = table.Column<int>(type: "int", nullable: true),
                    AttendancePurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LifeContented = table.Column<int>(type: "int", nullable: true),
                    Diet = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApprove = table.Column<bool>(type: "bit", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShopApplicationForm", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WSCategoryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopEducation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WSCategoryID = table.Column<int>(type: "int", nullable: true),
                    WsEducationName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopEducation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WSTypeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "X_BlogCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogID = table.Column<int>(type: "int", nullable: true),
                    BlogCategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_X_BlogCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetaTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleCategoryID = table.Column<int>(type: "int", nullable: true),
                    UrlRoot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorUserID = table.Column<int>(type: "int", nullable: true),
                    Orders = table.Column<int>(type: "int", nullable: true),
                    CoverImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserID = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserID = table.Column<int>(type: "int", nullable: true),
                    NavigationID = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true),
                    IsMainPage = table.Column<bool>(type: "bit", nullable: true),
                    IsMenu = table.Column<bool>(type: "bit", nullable: true),
                    IsComponent = table.Column<bool>(type: "bit", nullable: true),
                    IsNewsComponent = table.Column<bool>(type: "bit", nullable: true),
                    FontAwesomeIcon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Article_ArticleCategory",
                        column: x => x.ArticleCategoryID,
                        principalTable: "ArticleCategory",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetaTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MetaKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlRoot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: true),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Controller = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateUserID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserID = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BlogCategoryID = table.Column<int>(type: "int", nullable: true),
                    CoverImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    BlogTypeID = table.Column<int>(type: "int", nullable: true),
                    IsMainPage = table.Column<bool>(type: "bit", nullable: true),
                    Orders = table.Column<int>(type: "int", nullable: true),
                    NavigationID = table.Column<int>(type: "int", nullable: true),
                    IsMenu = table.Column<bool>(type: "bit", nullable: true),
                    IsComponent = table.Column<bool>(type: "bit", nullable: true),
                    IsNewsComponent = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Blog_BlogCategory",
                        column: x => x.BlogCategoryID,
                        principalTable: "BlogCategory",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Blog_BlogType",
                        column: x => x.BlogTypeID,
                        principalTable: "BlogType",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "X_BookCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookID = table.Column<int>(type: "int", nullable: true),
                    BookCategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_X_BookCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_X_BookCategory_Book",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_X_BookCategory_BookCategory",
                        column: x => x.BookCategoryID,
                        principalTable: "BookCategory",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FixBmh",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixBmh", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FixBmh_Form",
                        column: x => x.FormID,
                        principalTable: "Form",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FixBMI",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixBMI", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FixBMI_Form",
                        column: x => x.FormID,
                        principalTable: "Form",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FixCalorieSch",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixCalorieSch", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FixCalorieSch_Form",
                        column: x => x.FormID,
                        principalTable: "Form",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FixFeedPyramid",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixFeedPyramid", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FixFeedPyramid_Form",
                        column: x => x.FormID,
                        principalTable: "Form",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FixHeartDiseases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixHeartDiseases", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FixHeartDiseases_Form",
                        column: x => x.FormID,
                        principalTable: "Form",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FixMealSize",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixMealSize", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FixMealSize_Form",
                        column: x => x.FormID,
                        principalTable: "Form",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FixOptimum",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixOptimum", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FixOptimum_Form",
                        column: x => x.FormID,
                        principalTable: "Form",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FixPulse",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixPulse", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FixPulse_Form",
                        column: x => x.FormID,
                        principalTable: "Form",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AllergyProducingFoods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembersInformationID = table.Column<int>(type: "int", nullable: true),
                    Like = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dislike = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allergen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergyProducingFoods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AllergyProducingFoods_MembersInformation",
                        column: x => x.MembersInformationID,
                        principalTable: "MembersInformation",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DiseasesCardiovascular",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembersInformationID = table.Column<int>(type: "int", nullable: true),
                    DiseasesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseasesCardiovascular", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DiseasesCardiovascular_Diseases",
                        column: x => x.DiseasesID,
                        principalTable: "Diseases",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DiseasesCardiovascular_MembersInformation",
                        column: x => x.MembersInformationID,
                        principalTable: "MembersInformation",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DiseasesDiabetes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembersInformationID = table.Column<int>(type: "int", nullable: true),
                    DiseasesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseasesDiabetes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DiseasesDiabetes_Diseases",
                        column: x => x.DiseasesID,
                        principalTable: "Diseases",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DiseasesDiabetes_MembersInformation",
                        column: x => x.MembersInformationID,
                        principalTable: "MembersInformation",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DiseasesDigestiveDisorders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembersInformationID = table.Column<int>(type: "int", nullable: true),
                    DiseasesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseasesDigestiveDisorders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DiseasesDigestiveDisorders_Diseases",
                        column: x => x.DiseasesID,
                        principalTable: "Diseases",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DiseasesDigestiveDisorders_MembersInformation",
                        column: x => x.MembersInformationID,
                        principalTable: "MembersInformation",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DiseasesFamilyMembers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembersInformationID = table.Column<int>(type: "int", nullable: true),
                    DiseasesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseasesFamilyMembers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DiseasesFamilyMembers_Diseases",
                        column: x => x.DiseasesID,
                        principalTable: "Diseases",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DiseasesFamilyMembers_MembersInformation",
                        column: x => x.MembersInformationID,
                        principalTable: "MembersInformation",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FemaleMentalState",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembersInformationID = table.Column<int>(type: "int", nullable: true),
                    Menstruation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Menopause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gravidity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreastFeeding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBreastFeedingPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMenstruatioRegular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHormontherapy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGiveBirthTo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FemaleMentalState", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FemaleMentalState_MembersInformation",
                        column: x => x.MembersInformationID,
                        principalTable: "MembersInformation",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FoodHabit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembersInformationID = table.Column<int>(type: "int", nullable: true),
                    Breakfast = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreakfastSnack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lunch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LunchSnack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dinner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DinnerSnack = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodHabit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FoodHabits_MembersInformation",
                        column: x => x.MembersInformationID,
                        principalTable: "MembersInformation",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FoodTime",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembersInformationID = table.Column<int>(type: "int", nullable: true),
                    WeekdayMorning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeekdayNoon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeekdayNight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeekendMorning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeekendNoon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeekendNight = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTime", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FoodTime_MembersInformation",
                        column: x => x.MembersInformationID,
                        principalTable: "MembersInformation",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoCategoryID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoEmbedCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserID = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    LangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Video_VideoCategory",
                        column: x => x.VideoCategoryID,
                        principalTable: "VideoCategory",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergyProducingFoods_MembersInformationID",
                table: "AllergyProducingFoods",
                column: "MembersInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_Article_ArticleCategoryID",
                table: "Article",
                column: "ArticleCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_BlogCategoryID",
                table: "Blog",
                column: "BlogCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_BlogTypeID",
                table: "Blog",
                column: "BlogTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_DiseasesCardiovascular_DiseasesID",
                table: "DiseasesCardiovascular",
                column: "DiseasesID");

            migrationBuilder.CreateIndex(
                name: "IX_DiseasesCardiovascular_MembersInformationID",
                table: "DiseasesCardiovascular",
                column: "MembersInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_DiseasesDiabetes_DiseasesID",
                table: "DiseasesDiabetes",
                column: "DiseasesID");

            migrationBuilder.CreateIndex(
                name: "IX_DiseasesDiabetes_MembersInformationID",
                table: "DiseasesDiabetes",
                column: "MembersInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_DiseasesDigestiveDisorders_DiseasesID",
                table: "DiseasesDigestiveDisorders",
                column: "DiseasesID");

            migrationBuilder.CreateIndex(
                name: "IX_DiseasesDigestiveDisorders_MembersInformationID",
                table: "DiseasesDigestiveDisorders",
                column: "MembersInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_DiseasesFamilyMembers_DiseasesID",
                table: "DiseasesFamilyMembers",
                column: "DiseasesID");

            migrationBuilder.CreateIndex(
                name: "IX_DiseasesFamilyMembers_MembersInformationID",
                table: "DiseasesFamilyMembers",
                column: "MembersInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_FemaleMentalState_MembersInformationID",
                table: "FemaleMentalState",
                column: "MembersInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_FixBmh_FormID",
                table: "FixBmh",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_FixBMI_FormID",
                table: "FixBMI",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_FixCalorieSch_FormID",
                table: "FixCalorieSch",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_FixFeedPyramid_FormID",
                table: "FixFeedPyramid",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_FixHeartDiseases_FormID",
                table: "FixHeartDiseases",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_FixMealSize_FormID",
                table: "FixMealSize",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_FixOptimum_FormID",
                table: "FixOptimum",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_FixPulse_FormID",
                table: "FixPulse",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodHabit_MembersInformationID",
                table: "FoodHabit",
                column: "MembersInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTime_MembersInformationID",
                table: "FoodTime",
                column: "MembersInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_Video_VideoCategoryID",
                table: "Video",
                column: "VideoCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_X_BookCategory_BookCategoryID",
                table: "X_BookCategory",
                column: "BookCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_X_BookCategory_BookID",
                table: "X_BookCategory",
                column: "BookID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_DaysMeal");

            migrationBuilder.DropTable(
                name: "_Examination");

            migrationBuilder.DropTable(
                name: "AllergyProducingFoods");

            migrationBuilder.DropTable(
                name: "AppointmentDetail");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Auth");

            migrationBuilder.DropTable(
                name: "Banner");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "CalcBmh");

            migrationBuilder.DropTable(
                name: "CalcBMI");

            migrationBuilder.DropTable(
                name: "CalcOptimum");

            migrationBuilder.DropTable(
                name: "CalcPulse");

            migrationBuilder.DropTable(
                name: "Carousel");

            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropTable(
                name: "Confession");

            migrationBuilder.DropTable(
                name: "ConsultancyForm");

            migrationBuilder.DropTable(
                name: "ConsultancyFormType");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "ContactCategory");

            migrationBuilder.DropTable(
                name: "D_Appointment");

            migrationBuilder.DropTable(
                name: "D_Specialties");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "DietList");

            migrationBuilder.DropTable(
                name: "DiseasesCardiovascular");

            migrationBuilder.DropTable(
                name: "DiseasesDiabetes");

            migrationBuilder.DropTable(
                name: "DiseasesDigestiveDisorders");

            migrationBuilder.DropTable(
                name: "DiseasesFamilyMembers");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "EventCategory");

            migrationBuilder.DropTable(
                name: "Examination");

            migrationBuilder.DropTable(
                name: "FemaleMentalState");

            migrationBuilder.DropTable(
                name: "FixBmh");

            migrationBuilder.DropTable(
                name: "FixBMI");

            migrationBuilder.DropTable(
                name: "FixCalorieSch");

            migrationBuilder.DropTable(
                name: "FixFeedPyramid");

            migrationBuilder.DropTable(
                name: "FixHeartDiseases");

            migrationBuilder.DropTable(
                name: "FixMealSize");

            migrationBuilder.DropTable(
                name: "FixOptimum");

            migrationBuilder.DropTable(
                name: "FixPulse");

            migrationBuilder.DropTable(
                name: "FoodHabit");

            migrationBuilder.DropTable(
                name: "FoodHabitMood");

            migrationBuilder.DropTable(
                name: "FoodTime");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "HearAboutUS");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "ImageBlog");

            migrationBuilder.DropTable(
                name: "ImageCarousel");

            migrationBuilder.DropTable(
                name: "Influencer");

            migrationBuilder.DropTable(
                name: "Lab");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "MasterRoot");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "MembersAuth");

            migrationBuilder.DropTable(
                name: "MetaKeyword");

            migrationBuilder.DropTable(
                name: "Navigation");

            migrationBuilder.DropTable(
                name: "NewsBulletin");

            migrationBuilder.DropTable(
                name: "NewsPaper");

            migrationBuilder.DropTable(
                name: "OurTeam");

            migrationBuilder.DropTable(
                name: "Press");

            migrationBuilder.DropTable(
                name: "PressType");

            migrationBuilder.DropTable(
                name: "References");

            migrationBuilder.DropTable(
                name: "ResultBmh");

            migrationBuilder.DropTable(
                name: "ResultBMI");

            migrationBuilder.DropTable(
                name: "ResultOptimum");

            migrationBuilder.DropTable(
                name: "ResultPulse");

            migrationBuilder.DropTable(
                name: "SeminarVisuals");

            migrationBuilder.DropTable(
                name: "SLeftNavigation");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "TaylanK");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Workshop");

            migrationBuilder.DropTable(
                name: "WorkShopApplicationForm");

            migrationBuilder.DropTable(
                name: "WorkshopCategory");

            migrationBuilder.DropTable(
                name: "WorkshopEducation");

            migrationBuilder.DropTable(
                name: "WorkshopType");

            migrationBuilder.DropTable(
                name: "X_BlogCategory");

            migrationBuilder.DropTable(
                name: "X_BookCategory");

            migrationBuilder.DropTable(
                name: "ArticleCategory");

            migrationBuilder.DropTable(
                name: "BlogCategory");

            migrationBuilder.DropTable(
                name: "BlogType");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "Form");

            migrationBuilder.DropTable(
                name: "MembersInformation");

            migrationBuilder.DropTable(
                name: "VideoCategory");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "BookCategory");
        }
    }
}
