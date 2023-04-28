using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.TK.TKBiographyUpdate
{
    public class TKBiographyUpdateCommandHandler : IRequestHandler<TKBiographyUpdateCommandRequest, TKBiographyUpdateCommandResponse>
    {
        private readonly IYoneticiIslemleri _yoneticiIslemleri;

        public TKBiographyUpdateCommandHandler(IYoneticiIslemleri yoneticiIslemleri)
        {
            _yoneticiIslemleri = yoneticiIslemleri;
        }

        public async Task<TKBiographyUpdateCommandResponse> Handle(TKBiographyUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            TKBiographyUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _yoneticiIslemleri.TKBiographyUpdateAsync(request);
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
