﻿namespace MVCBlogApp.Application.ViewModels
{
    public class VM_DiseasesFamilyMembers
    {
        public int? Id { get; set; }
        public int? MembersInformationId { get; set; }
        public int? DiseasesId { get; set; }

        public string? DiseasesName { get; set; }
        public int? Type { get; set; }
    }
}
