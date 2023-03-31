using MediatR;
using Microsoft.AspNetCore.Http;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Press.PressUpdate
{
    public class PressUpdateCommandRequest : IRequest<PressUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlRoot { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKey { get; set; }
        public string MetaDescription { get; set; }
        public string UrlLink { get; set; }
        public int NewsPaperId { get; set; }
        public int PressTypeId { get; set; }
        public IFormFileCollection? FormFile { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public int LangId { get; set; }
        public int StatusId { get; set; }
    }
}