﻿using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Workshop : BaseEntity
    {
        public string? Title { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? FinishDateTime { get; set; }
        public string? Address { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public int? WseducationId { get; set; }
        public int? WstypeId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public int? LangId { get; set; }
        public int? StatusId { get; set; }
        public bool? IsMainPage { get; set; }
        public int? Orders { get; set; }
        public int? NavigationId { get; set; }
    }
}
