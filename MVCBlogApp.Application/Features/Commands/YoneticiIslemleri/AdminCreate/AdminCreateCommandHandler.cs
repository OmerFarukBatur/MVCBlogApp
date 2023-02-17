using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminCreate
{
    public class AdminCreateCommandHandler : IRequestHandler<AdminCreateCommandRequest, AdminCreateCommandResponse>
    {
        private readonly IYoneticiIslemleri _yoneticiIslemleri;

        public AdminCreateCommandHandler(IYoneticiIslemleri yoneticiIslemleri)
        {
            _yoneticiIslemleri = yoneticiIslemleri;
        }

        public async Task<AdminCreateCommandResponse> Handle(AdminCreateCommandRequest request, CancellationToken cancellationToken)
        {
            AdminCreateCommandValidator validations = new();
            ValidationResult result = validations.Validate(request);

            if (result.IsValid)
            {
                return await _yoneticiIslemleri.CreateAdminAsync(request);
            }
            else
            {
                return new AdminCreateCommandResponse()
                {
                    Message = "Girilen bilgiler geçerli değil lüften tekrardan gerekli alanları doldurunuz.",
                    Status = false
                };
            }
        }
    }
}
