using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class ImageCarousel
    {
        [Key]
        public int ID { get; set; }
        public int CarouselID { get; set; }
        public string ImgName { get; set; }
        public string ImgUrl { get; set; }
        public int StatusID { get; set; }
        public virtual Carousel Carousel { get; set; }
    }
}
