using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetAllNewsBulletin
{
    public class GetAllNewsBulletinQueryResponse
    {
        public List<VM_NewsBulletin> NewsBulletins { get; set; }
    }
}