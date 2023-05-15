using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Examination.GetAllExamination
{
    public class GetAllExaminationQueryResponse
    {
        public List<VM_Examination> Examinations { get; set; }
    }
}