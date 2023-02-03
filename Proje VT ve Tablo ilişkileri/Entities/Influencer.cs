using System;
using System.Collections.Generic;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class Influencer
    {
        public int ID { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string CompanySector { get; set; }
        public string Message { get; set; }
        public int StatusID { get; set; }
        public DateTime CreateDatetime { get; set; }
    }
}
