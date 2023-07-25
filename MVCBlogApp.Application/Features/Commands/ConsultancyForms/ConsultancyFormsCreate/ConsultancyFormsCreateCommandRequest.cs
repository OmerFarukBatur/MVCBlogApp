using MediatR;

namespace MVCBlogApp.Application.Features.Commands.ConsultancyForms.ConsultancyFormsCreate
{
    public class ConsultancyFormsCreateCommandRequest : IRequest<ConsultancyFormsCreateCommandResponse>
    {
        public string id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}