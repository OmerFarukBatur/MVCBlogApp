using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Examination.GetByIdExamination
{
    public class GetByIdExaminationQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_Examination? Examination { get; set; }
    }
}