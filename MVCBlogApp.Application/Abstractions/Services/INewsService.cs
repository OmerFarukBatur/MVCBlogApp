using MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinCreate;
using MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinDelete;
using MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinUpdate;
using MVCBlogApp.Application.Features.Commands.News.NewsPaper.NewsPaperCreate;
using MVCBlogApp.Application.Features.Commands.News.NewsPaper.NewsPaperDelete;
using MVCBlogApp.Application.Features.Commands.News.NewsPaper.NewsPaperUpdate;
using MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetAllNewsBulletin;
using MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetByIdNews;
using MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetNewsBulletinCreateItem;
using MVCBlogApp.Application.Features.Queries.News.NewsPaper.GetAllNewsPaper;
using MVCBlogApp.Application.Features.Queries.News.NewsPaper.GetByIdNewsPaper;
using MVCBlogApp.Application.Features.Queries.News.NewsPaper.GetNewsPaperCreateItems;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface INewsService
    {
        #region NewsBulletin

        Task<GetNewsBulletinCreateItemQueryResponse> GetNewsBulletinCreateItemAsync();
        Task<GetAllNewsBulletinQueryResponse> GetAllNewsBulletinAsync();
        Task<NewsBulletinCreateCommandResponse>NewsBulletinCreateAsync(NewsBulletinCreateCommandRequest request);
        Task<GetByIdNewsQueryResponse> GetByIdNewsAsync(int id);
        Task<NewsBulletinUpdateCommandResponse> NewsBulletinUpdateAsync(NewsBulletinUpdateCommandRequest request);
        Task<NewsBulletinDeleteCommandResponse> NewsBulletinDeleteAsync(int id);

        #endregion

        #region NewsPaper

        Task<GetNewsPaperCreateItemsQueryResponse> GetNewsPaperCreateItemsAsync();
        Task<GetAllNewsPaperQueryResponse> GetAllNewsPaperAsync();
        Task<NewsPaperCreateCommandResponse> NewsPaperCreateAsync(NewsPaperCreateCommandRequest request);
        Task<GetByIdNewsPaperQueryResponse> GetByIdNewsPaperAsync(int id);
        Task<NewsPaperUpdateCommandResponse> NewsPaperUpdateAsync(NewsPaperUpdateCommandRequest request);
        Task<NewsPaperDeleteCommandResponse> NewsPaperDeleteAsync(int id);

        #endregion
    }
}
