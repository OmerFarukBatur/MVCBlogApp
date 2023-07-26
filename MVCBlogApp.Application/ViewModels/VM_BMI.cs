namespace MVCBlogApp.Application.ViewModels
{
    public class VM_BMI
    {
        public VM_FixBMI? FixBMI { get; set; }
        public VM_CalcBMI? CalcBMI { get; set; }
        public List<VM_ResultBMI>? ResultBMIs { get; set; }
    }
}
