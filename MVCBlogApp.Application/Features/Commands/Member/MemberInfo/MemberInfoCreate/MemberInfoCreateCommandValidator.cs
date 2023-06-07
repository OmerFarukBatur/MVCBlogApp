using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Member.MemberInfo.MemberInfoCreate
{
    public class MemberInfoCreateCommandValidator : AbstractValidator<MemberInfoCreateCommandRequest>
    {
        public MemberInfoCreateCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Ad alanını boş bırakmayınız.")
                .MaximumLength(100)
                .WithMessage("Girilen değer en fazla 100 karakter olmalıdır.");

            RuleFor(x => x.Surname)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Soyad alanını boş bırakmayınız.")
                .MaximumLength(100)
                .WithMessage("Girilen değer en fazla 100 karakter olmalıdır.");

            RuleFor(x => x.Birthdate)
               .NotNull()
               .WithMessage("Lütfen bir Doğum Tarihi giriniz.");

            RuleFor(x => x.Job)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Meslek alanını boş bırakmayınız.")
                .MaximumLength(250)
                .WithMessage("Girilen değer en fazla 250 karakter olmalıdır.");
            
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Telefon Numarası'nı boş geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(10)
                .WithMessage("Lütfen Telefon Numarasını enaz 10 en çok 150 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Email'i boş geçmeyiniz.")
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir email adresi giriniz.");

            RuleFor(x => x.HistoryOfWeigh)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Kilo Öykünüz alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Kilo Öykünüz ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.DiseasesFamilyDiabetes)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesFamilyHeart)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesFamilyTiroid)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesFamilyHormone)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesFamilyCancer)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesFamilyGout)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesFamilyEpilepsy)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.CpreviousDisease)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.FoodHabitsBreakfast)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Sabah öğünü alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Sabah öğünü alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodHabitsBreakfastSnack)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Sabah ara öğünü alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Sabah ara öğünü alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodHabitsLunch)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Öğlen öğün alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Öğlen öğün alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodHabitsLunchSnack)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Öğlen ara öğün alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Öğlen ara öğün alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodHabitsDinner)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Akşam öğün alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Akşam öğün alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodHabitsDinnerSnack)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Akşam ara öğün alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Akşam ara öğün alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.OneDaySummary)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Geçmiş diyet alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Geçmiş diyet alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.TheQuantityConsumedWater)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Su alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Su alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.TheQuantityConsumedTea)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Çay alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Çay alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.TheQuantityConsumedCoffe)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Kahve alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Kahve alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.TheQuantityConsumedFizzy)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Gazlı içecek alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Gazlı içecek alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.TheQuantityConsumedAlchol)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Alkol alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Alkol alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.DoYouUseCigarettes)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.HaveYouGainedWeight)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.AllergyProducingFoodsLike)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Sevdikleri alanını boş geçmeyiniz.")
                .MaximumLength(450)
                .WithMessage("Sevdikleri alanı ençok 450 karakter olacak şekilde giriniz.");

            RuleFor(x => x.AllergyProducingDislike)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Sevmedikleri alanını boş geçmeyiniz.")
                .MaximumLength(450)
                .WithMessage("Sevmedikleri alanı ençok 450 karakter olacak şekilde giriniz.");

            RuleFor(x => x.AllergyProducingFoodsAllergen)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Alerjisi olan alanını boş geçmeyiniz.")
                .MaximumLength(450)
                .WithMessage("Alerjisi olan alanı ençok 450 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodLocation)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.")
                .MaximumLength(450)
                .WithMessage("Lütfen alanı ençok 450 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodMade)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.")
                .MaximumLength(450)
                .WithMessage("Lütfen alanı ençok 450 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodTimeWeekdayMorning)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Sabah alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Sabah alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodTimeWeekdayNoon)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Öğlen alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Öğlen alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodTimeWeekdayNight)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Akşam alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Akşam alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodTimeWeekendMorning)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Sabah alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Sabah alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodTimeWeekendNoon)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Öğlen alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Öğlen alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodTimeWeekendNight)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Akşam alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Akşam alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodHabitsMoodSad)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.FoodHabitsMoodStress)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.FoodHabitsMoodDoomy)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.FoodHabitsMoodHappy)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.FoodHabitsMoodAll)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.FemaleMentalStateMenstruation)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Mensturasyon alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Lütfen Mensturasyon alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FemaleMentalStateMenopause)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Menapoz alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Menapoz alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FemaleMentalStateGravidity)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Hamilelik alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Hamilelik alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FemaleMentalStateBreastFeeding)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Emzirme alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Emzirme alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FemaleMentalStateIsBreastFeedingPeriod)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Emzirme dönemi alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Emzirme dönemi alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FemaleMentalStateIsMenstruatioRegular)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Mensturasyon düzeni alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Mensturasyon düzeni alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FemaleMentalStateIsHormontherapy)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Hormon tedavisi alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Hormon tedavisi alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FemaleMentalStateIsGiveBirthTo)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Lütfen alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.ManTheNeedForEatingVaries)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Lütfen alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.DidYouGainWeightInTheArmy)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);
        }
    }
}
