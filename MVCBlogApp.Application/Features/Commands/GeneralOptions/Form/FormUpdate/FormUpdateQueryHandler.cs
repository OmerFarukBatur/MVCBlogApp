using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Form.FormUpdate
{
    public class FormUpdateQueryHandler : IRequestHandler<FormUpdateQueryRequest, FormUpdateQueryResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public FormUpdateQueryHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<FormUpdateQueryResponse> Handle(FormUpdateQueryRequest request, CancellationToken cancellationToken)
        {
            FormUpdateQueryValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _generalOptionsService.FormUpdateAsync(request);
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
