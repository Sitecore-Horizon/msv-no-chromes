using Sitecore.Mvc.Pipelines.MvcEvents.ActionExecuting;
using Sitecore.Mvc.Pipelines.Request.RequestEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XmCloudSXAStarter
{
    public class BypassCorsProcessor
    {
        public void Process(ActionExecutingArgs args)
        {
            var originHeader = args.Context.HttpContext.Request.Headers["Origin"];
            var path = args.Context.HttpContext.Request.Path;
            if (string.IsNullOrEmpty(originHeader) || !path.Contains("sitecore/api/layout/render"))
            {
                return;
            }

            args.Context.HttpContext.Response.Headers["Access-Control-Allow-Origin"] = originHeader;
            args.Context.HttpContext.Response.Headers["Access-Control-Allow-Headers"] = "*";
            args.Context.HttpContext.Response.Headers["Access-Control-Allow-Credentials"] = "true";
            args.Context.HttpContext.Response.Headers["Access-Control-Max-Age"] = "10";
        }
    }
}