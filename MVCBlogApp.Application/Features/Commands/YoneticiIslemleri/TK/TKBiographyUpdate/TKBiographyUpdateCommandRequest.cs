using MediatR;
using Microsoft.AspNetCore.Http;

namespace MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.TK.TKBiographyUpdate
{
    public class TKBiographyUpdateCommandRequest : IRequest<TKBiographyUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string About { get; set; }
        public string Bio { get; set; }
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public string Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string Fax { get; set; }
        public string Email1 { get; set; }
        public string? Email2 { get; set; }
        public string? GoogleMap { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public string? Pinterest { get; set; }
        public IFormFileCollection? FormFile { get; set; }
        public int StatusId { get; set; }
        public string Metakey { get; set; }
        public string Metatitle { get; set; }
        public string Metadescription { get; set; }
        public int LangId { get; set; }
    }
}