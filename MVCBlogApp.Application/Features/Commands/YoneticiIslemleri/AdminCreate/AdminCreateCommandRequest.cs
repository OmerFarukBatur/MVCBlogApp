using MediatR;

namespace MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminCreate
{
    public class AdminCreateCommandRequest : IRequest<AdminCreateCommandResponse>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public int AuthID { get; set; }
        public int? CreateUserID { get; set; }
        public int? ModifiedUserID { get; set; }
    }
}