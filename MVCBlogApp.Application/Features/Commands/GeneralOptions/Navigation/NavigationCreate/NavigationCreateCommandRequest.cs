﻿using MediatR;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationCreate
{
    public class NavigationCreateCommandRequest : IRequest<NavigationCreateCommandResponse>
    {
        public int? ParentID { get; set; }
        public string? OrderNo { get; set; }
        public bool? IsHeader { get; set; }
        public bool? IsSubHeader { get; set; }

        public string MetaTitle { get; set; }
        public string? MetaKey { get; set; }
        public string? UrlRoot { get; set; }
        public string NavigationName { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public string? FontAwesomeIcon { get; set; }
        public bool IsActive { get; set; }
        public int LangID { get; set; }
        public bool IsAdmin { get; set; }
    }
}