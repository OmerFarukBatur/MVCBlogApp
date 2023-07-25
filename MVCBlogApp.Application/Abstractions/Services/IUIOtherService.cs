﻿using MVCBlogApp.Application.Features.Queries.UIArticle.UIArticleIndex;
using MVCBlogApp.Application.Features.Queries.UIArticle.UILeftNavigation;
using MVCBlogApp.Application.Features.Queries.UIBlog.BasariHikayeleriPartialView;
using MVCBlogApp.Application.Features.Queries.UIBlog.BlogCategoryIndex;
using MVCBlogApp.Application.Features.Queries.UIBlog.SimilarSubjects;
using MVCBlogApp.Application.Features.Queries.UIBlog.TagCloudAndSocialMedia;
using MVCBlogApp.Application.Features.Queries.UIBlog.UIBlogPartialView;
using MVCBlogApp.Application.Features.Queries.UIBlog.YemekTarifleriPartialView;
using MVCBlogApp.Application.Features.Queries.UIBook.GetAllActiveBooks;
using MVCBlogApp.Application.Features.Queries.UIBook.GetBookDetail;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IUIOtherService
    {
        #region Article

        Task<UILeftNavigationQueryResponse> UILeftNavigationAsync(UILeftNavigationQueryRequest request);
        Task<UIArticleIndexQueryResponse> UIArticleIndexAsync(UIArticleIndexQueryRequest request);

        #endregion

        #region Blog

        Task<UIBlogPartialViewQueryResponse> UIBlogPartialViewAsync(UIBlogPartialViewQueryRequest request);
        Task<TagCloudAndSocialMediaQueryResponse> TagCloudAndSocialMediaAsync(TagCloudAndSocialMediaQueryRequest request);
        Task<SimilarSubjectsQueryResponse> SimilarSubjectsAsync(SimilarSubjectsQueryRequest request);
        Task<BlogCategoryIndexQueryResponse> BlogCategoryIndexAsync(BlogCategoryIndexQueryRequest request);
        Task<BasariHikayeleriPartialViewQueryResponse> BasariHikayeleriPartialViewAsync(BasariHikayeleriPartialViewQueryRequest request);
        Task<YemekTarifleriPartialViewQueryResponse> YemekTarifleriPartialViewAsync(YemekTarifleriPartialViewQueryRequest request);

        #endregion

        #region Book

        Task<GetAllActiveBlogQueryResponse> GetAllActiveBooksAsync();
        Task<GetBookDetailQueryResponse> GetBookDetailAsync(GetBookDetailQueryRequest request);

        #endregion
    }
}
