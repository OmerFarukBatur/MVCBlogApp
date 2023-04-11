using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.File.Carousel.CarouselCreate
{
    public class CarouselCreateCommandHandler : IRequestHandler<CarouselCreateCommandRequest, CarouselCreateCommandResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public CarouselCreateCommandHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<CarouselCreateCommandResponse> Handle(CarouselCreateCommandRequest request, CancellationToken cancellationToken)
        {
            CarouselCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fileProcessService.CarouselCreateAsync(request);
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
