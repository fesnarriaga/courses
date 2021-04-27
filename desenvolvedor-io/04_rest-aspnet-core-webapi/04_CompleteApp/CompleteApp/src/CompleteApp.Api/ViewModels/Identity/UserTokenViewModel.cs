using System.Collections.Generic;

namespace CompleteApp.Api.ViewModels.Identity
{
    public class UserTokenViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public IEnumerable<ClaimViewModel> Claims { get; set; }
    }
}
