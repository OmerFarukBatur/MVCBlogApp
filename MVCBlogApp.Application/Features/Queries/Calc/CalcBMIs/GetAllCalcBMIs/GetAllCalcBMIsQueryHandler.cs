using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Calc.CalcBMIs.GetAllCalcBMIs
{
    public class GetAllCalcBMIsQueryHandler : IRequestHandler<GetAllCalcBMIsQueryRequest, GetAllCalcBMIsQueryResponse>
    {
        private readonly ICalcService _calcService;

        public GetAllCalcBMIsQueryHandler(ICalcService calcService)
        {
            _calcService = calcService;
        }

        public async Task<GetAllCalcBMIsQueryResponse> Handle(GetAllCalcBMIsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _calcService.GetAllCalcBMIsAsync();
        }
    }
}
