using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Calc.CalcBmhs.GetAllCalcBmhs
{
    public class GetAllCalcBmhsQueryHandler : IRequestHandler<GetAllCalcBmhsQueryRequest, GetAllCalcBmhsQueryResponse>
    {
        private readonly ICalcService _calcService;

        public GetAllCalcBmhsQueryHandler(ICalcService calcService)
        {
            _calcService = calcService;
        }

        public async Task<GetAllCalcBmhsQueryResponse> Handle(GetAllCalcBmhsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _calcService.GetAllCalcBmhsAsync();
        }
    }
}
