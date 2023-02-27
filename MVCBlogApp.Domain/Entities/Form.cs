using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Form : BaseEntity
    {
        public Form()
        {
            FixBmhs = new HashSet<FixBmh>();
            FixBmis = new HashSet<FixBMI>();
            FixCalorieSches = new HashSet<FixCalorieSch>();
            FixFeedPyramids = new HashSet<FixFeedPyramid>();
            FixHeartDiseases = new HashSet<FixHeartDiseases>();
            FixMealSizes = new HashSet<FixMealSize>();
            FixOptimums = new HashSet<FixOptimum>();
            FixPulses = new HashSet<FixPulse>();
        }

        public string? FormName { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public int? LangId { get; set; }

        public virtual ICollection<FixBmh> FixBmhs { get; set; }
        public virtual ICollection<FixBMI> FixBmis { get; set; }
        public virtual ICollection<FixCalorieSch> FixCalorieSches { get; set; }
        public virtual ICollection<FixFeedPyramid> FixFeedPyramids { get; set; }
        public virtual ICollection<FixHeartDiseases> FixHeartDiseases { get; set; }
        public virtual ICollection<FixMealSize> FixMealSizes { get; set; }
        public virtual ICollection<FixOptimum> FixOptimums { get; set; }
        public virtual ICollection<FixPulse> FixPulses { get; set; }
    }
}
