using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Calc.CalcOptimums.GetAllCalcOptimums
{
    public class GetAllCalcOptimumsQueryHandler : IRequestHandler<GetAllCalcOptimumsQueryRequest, GetAllCalcOptimumsQueryResponse>
    {
        private readonly ICalcService _calcService;

        public GetAllCalcOptimumsQueryHandler(ICalcService calcService)
        {
            _calcService = calcService;
        }

        public async Task<GetAllCalcOptimumsQueryResponse> Handle(GetAllCalcOptimumsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _calcService.GetAllCalcOptimumsAsync();
        }
    }
}
