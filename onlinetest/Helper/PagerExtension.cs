using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Text;
using System.Web.Mvc.Html;

namespace Helper
{
    public static class PagerExtension
    {
        public static string Pager<T>(this HtmlHelper html, PagedList<T> data)
        {
            //数字导航的开始数字
            int start = (data.PageIndex - 5) >= 1 ? (data.PageIndex - 5) : 1;
            //数字导航的结束数字
            int end = (data.TotalPages - start) > 10 ? start + 10 : data.TotalPages;

            //路由数据
            RouteValueDictionary vs = html.ViewContext.RouteData.Values;
            //URL数据
            var queryString = html.ViewContext.HttpContext.Request.QueryString;
            //合并URL数据
            foreach (string key in queryString.Keys)
                if (queryString[key] != null && !string.IsNullOrEmpty(key))
                    vs[key] = queryString[key];
            //合并表单数据
            var FormString = html.ViewContext.HttpContext.Request.Form;
            foreach (string key in FormString.Keys)
                vs[key] = FormString[key];
            //输出分页Html
            var builder = new StringBuilder();
            builder.AppendFormat("<div class=\"mvc_pager\">");
            //显示首页和上页
            if (data.HasPreviousPage)
            {
                vs["pageIndex"] = 1;
                builder.Append(LinkExtensions.ActionLink(html, "首页", vs["action"].ToString(), vs));
                vs["pageIndex"] = data.PageIndex - 1;
                builder.Append(LinkExtensions.ActionLink(html, "上页", vs["action"].ToString(), vs));
            }
            //显示数字页码
            for (int i = start; i <= end; i++)
            {
                vs["pageIndex"] = i;
                if (i == data.PageIndex)
                {
                    builder.Append("<font class='thispagethis'>" + i.ToString() + "</font>");
                }
                else
                {
                    builder.Append(LinkExtensions.ActionLink(html, i.ToString(), vs["action"].ToString(), vs));
                }
            }
            //显示下页和末页
            if (data.HasNextPage)
            {
                vs["pageIndex"] = data.PageIndex + 1;
                builder.Append(LinkExtensions.ActionLink(html, "下页", vs["action"].ToString(), vs));
                vs["pageIndex"] = data.TotalPages;
                builder.Append(LinkExtensions.ActionLink(html, "末页", vs["action"].ToString(), vs));
            }
            builder.Append("共" + data.TotalCount + "条 第" + data.PageIndex + "页/共" + data.TotalPages + "页 </div>");
            return builder.ToString();
        }
    }
}