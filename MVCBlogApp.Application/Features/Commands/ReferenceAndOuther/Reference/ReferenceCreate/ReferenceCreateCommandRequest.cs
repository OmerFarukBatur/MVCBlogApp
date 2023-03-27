using MediatR;
using Microsoft.AspNetCore.Http;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceCreate
{
    public class ReferenceCreateCommandRequest : IRequest<ReferenceCreateCommandResponse>
    {
        public string Title { get; set; }
        public string UrlLink { get; set; }
        public IFormFileCollection FormFile { get; set; }
        public int StatusId { get; set; }
        public  int? CreatedUserId { get; set; }
    }
}