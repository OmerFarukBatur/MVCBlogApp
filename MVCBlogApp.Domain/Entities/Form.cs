using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Form : BaseEntity
    {
        public string FormName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int LangID { get; set; }
        public virtual IList<FixBmh> FixBmhs { get; set; }
        public virtual IList<FixBMI> FixBMIs { get; set; }
        public virtual IList<FixCalorieSch> FixCalorieSches { get; set; }
        public virtual IList<FixFeedPyramid> FixFeedPyramids { get; set; }
        public virtual IList<FixHeartDiseases> FixHeartDiseases { get; set; }
        public virtual IList<FixMealSize> FixMealSizes { get; set; }
        public virtual IList<FixOptimum> FixOptimums { get; set; }
        public virtual IList<FixPulse> FixPulses { get; set; }
    }
}
