namespace MVCBlogApp.Application.ViewModels
{
    public class VM_WorkShopApplicationFormModel
    {
        public int ID { get; set; }

        public int WorkShopID { get; set; }

        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
        public string Job { get; set; }
        public string Address { get; set; }

        //FK
        public int HearAboutusID { get; set; }

        public string HearAboutus { get; set; }

        public string AttendancePurpose { get; set; }
        public int LifeContented { get; set; }
        public int Diet { get; set; }

        public string Note { get; set; }

        public bool IsApprove { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
