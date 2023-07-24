using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UIBlog.SimilarSubjects
{
    public class SimilarSubjectsQueryRequest : IRequest<SimilarSubjectsQueryResponse>
    {
        public int blogID { get; set; }
    }
}