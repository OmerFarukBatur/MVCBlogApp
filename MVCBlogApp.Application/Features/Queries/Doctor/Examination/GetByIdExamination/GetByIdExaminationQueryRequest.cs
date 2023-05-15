using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Examination.GetByIdExamination
{
    public class GetByIdExaminationQueryRequest : IRequest<GetByIdExaminationQueryResponse>
    {
        public int Id { get; set; }
    }
}