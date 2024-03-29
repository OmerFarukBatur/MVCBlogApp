﻿using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Meal.GetByIdMeal
{
    public class GetByIdMealQueryHandler : IRequestHandler<GetByIdMealQueryRequest, GetByIdMealQueryResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public GetByIdMealQueryHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<GetByIdMealQueryResponse> Handle(GetByIdMealQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _optionsService.GetByIdMealAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Meal = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
