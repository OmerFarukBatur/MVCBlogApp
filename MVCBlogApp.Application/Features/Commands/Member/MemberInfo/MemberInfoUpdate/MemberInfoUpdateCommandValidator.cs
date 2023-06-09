using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Member.MemberInfo.MemberInfoUpdate
{
    public class MemberInfoUpdateCommandValidator : AbstractValidator<MemberInfoUpdateCommandRequest>
    {
        public MemberInfoUpdateCommandValidator()
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
                .WithMessage("Lütfen Kilo Öykünüz alanını boş geçmeyiniz.");

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
                .WithMessage("Lütfen Sabah öğünü alanını boş geçmeyiniz.");

            RuleFor(x => x.FoodHabitsBreakfastSnack)

                .NotNull()
                .WithMessage("Lütfen Sabah ara öğünü alanını boş geçmeyiniz.");

            RuleFor(x => x.FoodHabitsLunch)

                .NotNull()
                .WithMessage("Lütfen Öğlen öğün alanını boş geçmeyiniz.");

            RuleFor(x => x.FoodHabitsLunchSnack)

                .NotNull()
                .WithMessage("Lütfen Öğlen ara öğün alanını boş geçmeyiniz.");

            RuleFor(x => x.FoodHabitsDinner)

                .NotNull()
                .WithMessage("Lütfen Akşam öğün alanını boş geçmeyiniz.");

            RuleFor(x => x.FoodHabitsDinnerSnack)

                .NotNull()
                .WithMessage("Lütfen Akşam ara öğün alanını boş geçmeyiniz.");

            RuleFor(x => x.OneDaySummary)

                .NotNull()
                .WithMessage("Lütfen Geçmiş diyet alanını boş geçmeyiniz.");

            RuleFor(x => x.TheQuantityConsumedWater)

                .NotNull()
                .WithMessage("Lütfen Su alanını boş geçmeyiniz.");

            RuleFor(x => x.TheQuantityConsumedTea)

                .NotNull()
                .WithMessage("Lütfen Çay alanını boş geçmeyiniz.");

            RuleFor(x => x.TheQuantityConsumedCoffe)

                .NotNull()
                .WithMessage("Lütfen Kahve alanını boş geçmeyiniz.");

            RuleFor(x => x.TheQuantityConsumedFizzy)

                .NotNull()
                .WithMessage("Lütfen Gazlı içecek alanını boş geçmeyiniz.");

            RuleFor(x => x.TheQuantityConsumedAlchol)

                .NotNull()
                .WithMessage("Lütfen Alkol alanını boş geçmeyiniz.");

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
                .WithMessage("Lütfen Sevdikleri alanını boş geçmeyiniz.");

            RuleFor(x => x.AllergyProducingDislike)

                .NotNull()
                .WithMessage("Lütfen Sevmedikleri alanını boş geçmeyiniz.");

            RuleFor(x => x.AllergyProducingFoodsAllergen)

                .NotNull()
                .WithMessage("Lütfen Alerjisi olan alanını boş geçmeyiniz.");

            RuleFor(x => x.FoodLocation)

                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.");

            RuleFor(x => x.FoodMade)

                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.");

            RuleFor(x => x.FoodTimeWeekdayMorning)

                .NotNull()
                .WithMessage("Lütfen Sabah alanını boş geçmeyiniz.");

            RuleFor(x => x.FoodTimeWeekdayNoon)

                .NotNull()
                .WithMessage("Lütfen Öğlen alanını boş geçmeyiniz.");

            RuleFor(x => x.FoodTimeWeekdayNight)

                .NotNull()
                .WithMessage("Lütfen Akşam alanını boş geçmeyiniz.");

            RuleFor(x => x.FoodTimeWeekendMorning)

                .NotNull()
                .WithMessage("Lütfen Sabah alanını boş geçmeyiniz.");

            RuleFor(x => x.FoodTimeWeekendNoon)

                .NotNull()
                .WithMessage("Lütfen Öğlen alanını boş geçmeyiniz.");

            RuleFor(x => x.FoodTimeWeekendNight)

                .NotNull()
                .WithMessage("Lütfen Akşam alanını boş geçmeyiniz.");

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
                .WithMessage("Lütfen Mensturasyon alanını boş geçmeyiniz.");

            RuleFor(x => x.FemaleMentalStateMenopause)

                .NotNull()
                .WithMessage("Lütfen Menapoz alanını boş geçmeyiniz.");

            RuleFor(x => x.FemaleMentalStateGravidity)

                .NotNull()
                .WithMessage("Lütfen Hamilelik alanını boş geçmeyiniz.");

            RuleFor(x => x.FemaleMentalStateBreastFeeding)

                .NotNull()
                .WithMessage("Lütfen Emzirme alanını boş geçmeyiniz.");

            RuleFor(x => x.FemaleMentalStateIsBreastFeedingPeriod)

                .NotNull()
                .WithMessage("Lütfen Emzirme dönemi alanını boş geçmeyiniz.");

            RuleFor(x => x.FemaleMentalStateIsMenstruatioRegular)

                .NotNull()
                .WithMessage("Lütfen Mensturasyon düzeni alanını boş geçmeyiniz.");

            RuleFor(x => x.FemaleMentalStateIsHormontherapy)

                .NotNull()
                .WithMessage("Lütfen Hormon tedavisi alanını boş geçmeyiniz.");

            RuleFor(x => x.FemaleMentalStateIsGiveBirthTo)

                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.");

            RuleFor(x => x.ManTheNeedForEatingVaries)

                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.");

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
                .WithMessage("Lütfen alanı boş geçmeyiniz.");

            RuleFor(x => x.DoYouHaveHormonalProblem)

                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.");

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
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.")
                .MaximumLength(250)
                .WithMessage("Lütfen alanı ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.DoYouUseVitaminAndMinerals)

                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.");

            RuleFor(x => x.OtherMessage)

                .NotNull()
                .WithMessage("Lütfen alanı boş geçmeyiniz.");
        }
    }
}
