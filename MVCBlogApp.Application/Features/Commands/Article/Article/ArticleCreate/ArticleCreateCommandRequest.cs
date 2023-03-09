using MediatR;
using Microsoft.AspNetCore.Http;

namespace MVCBlogApp.Application.Features.Commands.Article.Article.ArticleCreate
{
    public class ArticleCreateCommandRequest : IRequest<ArticleCreateCommandResponse>
    { 
        public string Title { get; set; } 
        public string UrlRoot { get; set; }
        public int ArticleCategoryId { get; set; } 
        public int NavigationId { get; set; }
        public int? Orders { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKey { get; set; }
        public string MetaDescription { get; set; }
        public bool IsMainPage { get; set; }
        public bool IsMenu { get; set; }
        public bool IsComponent { get; set; }
        public bool IsNewsComponent { get; set; }
        public IFormFileCollection FormFile { get; set; }       
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public int LangId { get; set; }
        public int StatusId { get; set; }
        public int? CreateUserId { get; set; }
    }
}