using MediatR;

namespace MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminUpdate
{
    public class AdminUpdateCommandRequest : IRequest<AdminUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public int AuthID { get; set; }
        public int? ModifiedUserID { get; set; }
        public bool IsActive { get; set; }
    }
}