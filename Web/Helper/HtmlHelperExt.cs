using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc.Html
{
    public static class HtmlHelperExt
    {
        public static MvcHtmlString IIf(this HtmlHelper htmlHelper, bool condition, string truePart, string falsePart)
        {
            return new MvcHtmlString(condition ? truePart : falsePart);
        }
    }
}