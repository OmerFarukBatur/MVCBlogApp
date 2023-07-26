using MediatR;
using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Commands.Test.BMICalculateCreate
{
    public class BMICalculateCreateCommandRequest : IRequest<BMICalculateCreateCommandResponse>
    {
        public VM_FixBMI? FixBMI { get; set; }
        public VM_CalcBMI CalcBMI { get; set; }
        public List<VM_ResultBMI>? ResultBMIs { get; set; }
    }
}