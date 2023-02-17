using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminUpdate
{
    public class AdminUpdateCommandHandler : IRequestHandler<AdminUpdateCommandRequest, AdminUpdateCommandResponse>
    {
        private readonly IYoneticiIslemleri _yoneticiIslemleri;

        public AdminUpdateCommandHandler(IYoneticiIslemleri yoneticiIslemleri)
        {
            _yoneticiIslemleri = yoneticiIslemleri;
        }

        public async Task<AdminUpdateCommandResponse> Handle(AdminUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            AdminUpdateCommandValidator validations = new();
            ValidationResult result = validations.Validate(request);

            if (result.IsValid)
            {
                 return await _yoneticiIslemleri.UpdateAdminAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen bilgileri eksiksiz giriniz.",
                    Status = false
                };
            }
        }
    }
}
