using MediatR;
using Microsoft.AspNetCore.Http;

namespace MVCBlogApp.Application.Features.Commands.File.Carousel.CarouselUpdate
{
    public class CarouselUpdateCommandRequest : IRequest<CarouselUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlRoot { get; set; }
        public string? TitleClass { get; set; }
        public IFormFileCollection? FormFile { get; set; }
        public string? Description { get; set; }
        public int Orders { get; set; }
        public int StatusId { get; set; }
        public string MetaKey { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public int LangId { get; set; }
    }
}