﻿using MediatR;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.UpdateLanguage
{
    public class UpdateLanguageCommandRequest : IRequest<UpdateLanguageCommandResponse>
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public bool IsActive { get; set; }
    }
}