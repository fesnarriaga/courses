using CompleteApp.Mvc.Extensions.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace CompleteApp.Mvc.Extensions.TagHelpers
{
    [HtmlTargetElement("*", Attributes = "disable-link-by-claim-name")]
    [HtmlTargetElement("*", Attributes = "disable-link-by-claim-value")]
    public class DisableLinkByClaimTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DisableLinkByClaimTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HtmlAttributeName("disable-link-by-claim-name")]
        public string IdentityClaimName { get; set; }

        [HtmlAttributeName("disable-link-by-claim-value")]
        public string IdentityClaimValue { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            if (CustomAuthorization.ValidateUserClaims(_httpContextAccessor.HttpContext, IdentityClaimName, IdentityClaimValue))
                return;

            output.Attributes.RemoveAll("href");
            output.Attributes.Add(new TagHelperAttribute("style", "cursor: not-allowed"));
            output.Attributes.Add(new TagHelperAttribute("title", "You do not have permission"));
        }
    }
}
