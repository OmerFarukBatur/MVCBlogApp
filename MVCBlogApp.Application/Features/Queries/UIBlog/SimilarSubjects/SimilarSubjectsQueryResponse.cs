using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UIBlog.SimilarSubjects
{
    public class SimilarSubjectsQueryResponse
    {
        public List<VM_Blog>? Blogs { get; set; }
    }
}