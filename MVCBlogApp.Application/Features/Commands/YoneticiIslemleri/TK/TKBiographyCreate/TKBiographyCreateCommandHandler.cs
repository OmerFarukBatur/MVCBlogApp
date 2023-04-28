using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.TK.TKBiographyCreate
{
    public class TKBiographyCreateCommandHandler : IRequestHandler<TKBiographyCreateCommandRequest, TKBiographyCreateCommandResponse>
    {
        private readonly IYoneticiIslemleri _yoneticiIslemleri;

        public TKBiographyCreateCommandHandler(IYoneticiIslemleri yoneticiIslemleri)
        {
            _yoneticiIslemleri = yoneticiIslemleri;
        }

        public async Task<TKBiographyCreateCommandResponse> Handle(TKBiographyCreateCommandRequest request, CancellationToken cancellationToken)
        {
            TKBiographyCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _yoneticiIslemleri.TKBiographyCreateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanları geçerli değerlerle doldurunuz.",
                    State = false
                };
            }
        }
    }
}
