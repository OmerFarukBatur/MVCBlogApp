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

                .NotNull()
                .WithMessage("Lütfen Meslek alanını boş bırakmayınız.")
                .MaximumLength(250)
                .WithMessage("Girilen değer en fazla 250 karakter olmalıdır.");

            RuleFor(x => x.PhoneNumber)

                .NotNull()
                .WithMessage("Lütfen Telefon Numarası'nı boş geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(10)
                .WithMessage("Lütfen Telefon Numarasını enaz 10 en çok 150 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Email)

                .NotNull()
                .WithMessage("Lütfen Email'i boş geçmeyiniz.")
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir email adresi giriniz.");

            RuleFor(x => x.HistoryOfWeigh)

                .NotNull()
                .WithMessage("Lütfen Kilo Öykünüz alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Kilo Öykünüz ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.DiseasesFamilyDiabetes)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesFamilyHeart)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesFamilyTiroid)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesFamilyHormone)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesFamilyCancer)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesFamilyGout)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesFamilyEpilepsy)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.CpreviousDisease)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.FoodHabitsBreakfast)

                .NotNull()
                .WithMessage("Lütfen Sabah öğünü alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Sabah öğünü alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodHabitsBreakfastSnack)

                .NotNull()
                .WithMessage("Lütfen Sabah ara öğünü alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Sabah ara öğünü alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodHabitsLunch)

                .NotNull()
                .WithMessage("Lütfen Öğlen öğün alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Öğlen öğün alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodHabitsLunchSnack)

                .NotNull()
                .WithMessage("Lütfen Öğlen ara öğün alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Öğlen ara öğün alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodHabitsDinner)

                .NotNull()
                .WithMessage("Lütfen Akşam öğün alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Akşam öğün alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodHabitsDinnerSnack)

                .NotNull()
                .WithMessage("Lütfen Akşam ara öğün alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Akşam ara öğün alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.OneDaySummary)

                .NotNull()
                .WithMessage("Lütfen Geçmiş diyet alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Geçmiş diyet alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.TheQuantityConsumedWater)

                .NotNull()
                .WithMessage("Lütfen Su alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Su alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.TheQuantityConsumedTea)

                .NotNull()
                .WithMessage("Lütfen Çay alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Çay alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.TheQuantityConsumedCoffe)

                .NotNull()
                .WithMessage("Lütfen Kahve alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Kahve alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.TheQuantityConsumedFizzy)

                .NotNull()
                .WithMessage("Lütfen Gazlı içecek alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Gazlı içecek alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.TheQuantityConsumedAlchol)

                .NotNull()
                .WithMessage("Lütfen Alkol alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Alkol alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.DoYouUseCigarettes)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.HaveYouGainedWeight)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.AllergyProducingFoodsLike)

                .NotNull()
                .WithMessage("Lütfen Sevdikleri alanını boş geçmeyiniz.")
                .MaximumLength(450)
                .WithMessage("Sevdikleri alanı ençok 450 karakter olacak şekilde giriniz.");

            RuleFor(x => x.AllergyProducingDislike)

                .NotNull()
                .WithMessage("Lütfen Sevmedikleri alanını boş geçmeyiniz.")
                .MaximumLength(450)
                .WithMessage("Sevmedikleri alanı ençok 450 karakter olacak şekilde giriniz.");

            RuleFor(x => x.AllergyProducingFoodsAllergen)

                .NotNull()
                .WithMessage("Lütfen Alerjisi olan alanını boş geçmeyiniz.")
                .MaximumLength(450)
                .WithMessage("Alerjisi olan alanı ençok 450 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodLocation)

                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.")
                .MaximumLength(450)
                .WithMessage("Lütfen alanı ençok 450 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodMade)

                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.")
                .MaximumLength(450)
                .WithMessage("Lütfen alanı ençok 450 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodTimeWeekdayMorning)

                .NotNull()
                .WithMessage("Lütfen Sabah alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Sabah alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodTimeWeekdayNoon)

                .NotNull()
                .WithMessage("Lütfen Öğlen alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Öğlen alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodTimeWeekdayNight)

                .NotNull()
                .WithMessage("Lütfen Akşam alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Akşam alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodTimeWeekendMorning)

                .NotNull()
                .WithMessage("Lütfen Sabah alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Sabah alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodTimeWeekendNoon)

                .NotNull()
                .WithMessage("Lütfen Öğlen alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Öğlen alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodTimeWeekendNight)

                .NotNull()
                .WithMessage("Lütfen Akşam alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Akşam alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FoodHabitsMoodSad)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.FoodHabitsMoodStress)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.FoodHabitsMoodDoomy)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.FoodHabitsMoodHappy)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.FoodHabitsMoodAll)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.FemaleMentalStateMenstruation)

                .NotNull()
                .WithMessage("Lütfen Mensturasyon alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Lütfen Mensturasyon alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FemaleMentalStateMenopause)

                .NotNull()
                .WithMessage("Lütfen Menapoz alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Menapoz alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FemaleMentalStateGravidity)

                .NotNull()
                .WithMessage("Lütfen Hamilelik alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Hamilelik alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FemaleMentalStateBreastFeeding)

                .NotNull()
                .WithMessage("Lütfen Emzirme alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Emzirme alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FemaleMentalStateIsBreastFeedingPeriod)

                .NotNull()
                .WithMessage("Lütfen Emzirme dönemi alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Emzirme dönemi alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FemaleMentalStateIsMenstruatioRegular)

                .NotNull()
                .WithMessage("Lütfen Mensturasyon düzeni alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Mensturasyon düzeni alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FemaleMentalStateIsHormontherapy)

                .NotNull()
                .WithMessage("Lütfen Hormon tedavisi alanını boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Hormon tedavisi alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FemaleMentalStateIsGiveBirthTo)

                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Lütfen alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.ManTheNeedForEatingVaries)

                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Lütfen alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.DidYouGainWeightInTheArmy)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesReflux)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesDifaji)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesRegurgitation)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesHernia)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesDyspepsia)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesHelicobacterPylori)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesGastritis)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesUlcer)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesGastricCancer)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesIntestinalObstruction)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesAcuteDiarrhea)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesChronicDiarrhea)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesConstipation)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesSpasticColon)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesGas)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesIntestinalParasites)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesUlcerativeColitis)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesCrohn)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesColonCancer)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesCardiovascularHypertension)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesCardiovascularHypotension)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesCardiovascularPalpitation)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesCardiovascularHeart)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesDiabetesHypoglycemia)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesDiabetesTypeOneDiabetes)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.DiseasesDiabetesTypeTwoDiabetes)

                .NotNull()
                .WithMessage("Lütfen bir değer seçiniz.")
                .Must(x => x == false || x == true);

            RuleFor(x => x.IsBloodCoagulationDisorders)

                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.")
                .MaximumLength(450)
                .WithMessage("Lütfen alanı ençok 450 karakter olacak şekilde giriniz.");

            RuleFor(x => x.DoYouHaveHormonalProblem)

                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.")
                .MaximumLength(450)
                .WithMessage("Lütfen alanı ençok 450 karakter olacak şekilde giriniz.");

            RuleFor(x => x.HowDoYouFeel)
                .InclusiveBetween(0, 4)
                .WithMessage("Lütfen alanı boş geçmeyiniz.");

            RuleFor(x => x.HowIsYourEnergy)
                .InclusiveBetween(0, 4)
                .WithMessage("Lütfen alanı boş geçmeyiniz.");

            RuleFor(x => x.HowFrequencyOfActivity)
                .InclusiveBetween(0, 4)
                .WithMessage("Lütfen alanı boş geçmeyiniz.");

            RuleFor(x => x.ConsumedVegetables)
                .InclusiveBetween(0, 4)
                .WithMessage("Lütfen alanı boş geçmeyiniz.");

            RuleFor(x => x.GetDrugged)

                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.")
                .MaximumLength(250)
                .WithMessage("Lütfen alanı ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.DoYouUseVitaminAndMinerals)

                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.")
                .MaximumLength(350)
                .WithMessage("Lütfen alanı ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(x => x.OtherMessage)

                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.")
                .MaximumLength(450)
                .WithMessage("Lütfen alanı ençok 450 karakter olacak şekilde giriniz.");
        }
    }
}
