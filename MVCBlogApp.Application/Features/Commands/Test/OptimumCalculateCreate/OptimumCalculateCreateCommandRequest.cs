using MediatR;
using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Commands.Test.OptimumCalculateCreate
{
    public class OptimumCalculateCreateCommandRequest : IRequest<OptimumCalculateCreateCommandResponse>
    {
        public VM_CalcOptimum CalcOptimum { get; set; }
    }
}