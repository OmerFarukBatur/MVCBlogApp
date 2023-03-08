using MediatR;

namespace MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserUpdate
{
    public class UserUpdateCommandRequest : IRequest<UserUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Lacation { get; set; }
        public string Address { get; set; }
        public int MembersAuthId { get; set; }
        public bool IsActive { get; set; }
    }
}