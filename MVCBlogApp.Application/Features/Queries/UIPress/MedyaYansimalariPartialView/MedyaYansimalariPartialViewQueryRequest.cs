using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UIPress.MedyaYansimalariPartialView
{
    public class MedyaYansimalariPartialViewQueryRequest : IRequest<MedyaYansimalariPartialViewQueryResponse>
    {
        public int page { get; set; } = 1;
    }
}