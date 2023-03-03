
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Application.ViewModels
{
    public class VM_MasterRoot
    {
        public int? Id { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public string? UrlRoot { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
