using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.File.Carousel.CarouselUpdate
{
    public class CarouselUpdateCommandHandler : IRequestHandler<CarouselUpdateCommandRequest, CarouselUpdateCommandResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public CarouselUpdateCommandHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<CarouselUpdateCommandResponse> Handle(CarouselUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            CarouselUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fileProcessService.CarouselUpdateAsync(request);
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
