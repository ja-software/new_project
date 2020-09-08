using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace UserManagement.Web.Code
{
    public class AuthorizedLinkViewModel
    {
        public AuthorizedLinkViewModel(string area,string page,string linkName,
            string htmlIcon, string parentElementStart="",string parentElementEnd="",string cssClass="")
        {
            Area = area;
            Page = page;
            LinkName = linkName;
            HtmlIcon = htmlIcon;
            ParentElementStart = parentElementStart;
            ParentElementEnd = parentElementEnd;
            CssClass = cssClass;
        }
        public string Area { set; get; }
        public string Page { set; get; }
        public string LinkName { set; get; }
       // [AllowHtml]
        public string HtmlIcon { set; get; }

       // [AllowHtml]
        public string ParentElementStart { set; get; }

       // [AllowHtml]
        public string ParentElementEnd { set; get; }
        public string CssClass { get; }
    }
}
