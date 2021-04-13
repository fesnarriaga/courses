using CompleteApp.Business.Models;
using Microsoft.AspNetCore.Mvc.Razor;
using System;

namespace CompleteApp.Mvc.Extensions.Razor
{
    public static class RazorExtensions
    {
        public static string DocumentMask(this RazorPage page, int documentType, string document)
        {
            return documentType == (int)SupplierType.Person ?
                Convert.ToUInt64(document).ToString(@"000\.000\.000\-00") :
                Convert.ToUInt64(document).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}
