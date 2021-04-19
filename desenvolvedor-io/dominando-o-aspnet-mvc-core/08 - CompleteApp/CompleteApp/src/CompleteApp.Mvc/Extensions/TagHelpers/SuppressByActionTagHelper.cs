﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using System;

namespace CompleteApp.Mvc.Extensions.TagHelpers
{
    [HtmlTargetElement("*", Attributes = "suppress-by-action")]
    public class SuppressByActionTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SuppressByActionTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HtmlAttributeName("suppress-by-action")]
        public string ActionName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(_httpContextAccessor));

            if (output == null)
                throw new ArgumentNullException(nameof(_httpContextAccessor));

            var action = _httpContextAccessor.HttpContext.GetRouteData().Values["action"].ToString();

            if (ActionName.Contains(action)) return;

            output.SuppressOutput();
        }
    }
}
