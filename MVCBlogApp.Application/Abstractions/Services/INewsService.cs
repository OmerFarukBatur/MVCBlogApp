﻿using MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinCreate;
using MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinDelete;
using MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinUpdate;
using MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetAllNewsBulletin;
using MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetByIdNews;
using MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetNewsBulletinCreateItem;

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



        #endregion
    }
}
