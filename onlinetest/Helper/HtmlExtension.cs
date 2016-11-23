using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookShopMVCThreeLayer4.Helper
{
    public static class HtmlExtension
    {
        public static string Submit(this HtmlHelper helper,string name,string value)
        {
            var buider = new TagBuilder("input");
            buider.MergeAttribute("type", "submit");
            buider.MergeAttribute("value", value);
            buider.MergeAttribute("name", name);
            buider.GenerateId(name);
            return buider.ToString();
        
        }
        public static string Submit(this HtmlHelper helper, string name, string value,object htmlAttributes)
        {
            var buider = new TagBuilder("input");
            buider.MergeAttribute("type", "submit");
            buider.MergeAttribute("value", value);
            buider.MergeAttribute("name", name);
            buider.GenerateId(name);
            buider.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return buider.ToString();

        }
    }
}