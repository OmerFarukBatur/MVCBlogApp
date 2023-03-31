using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Calc.CalcPulses.GetAllCalcPulses
{
    public class GetAllCalcPulsesQueryHandler : IRequestHandler<GetAllCalcPulsesQueryRequest, GetAllCalcPulsesQueryResponse>
    {
        private readonly ICalcService _calcService;

        public GetAllCalcPulsesQueryHandler(ICalcService calcService)
        {
            _calcService = calcService;
        }

        public async Task<GetAllCalcPulsesQueryResponse> Handle(GetAllCalcPulsesQueryRequest request, CancellationToken cancellationToken)
        {
            return await _calcService.GetAllCalcPulsesAsync();
        }
    }
}
