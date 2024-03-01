using Sitecore.Pipelines.HttpRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Sites.Headless;

namespace XmCloudSXAStarter
{
    public class SwitchHeadlessMode: HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            if (Sitecore.Context.HeadlessContext.GetMode() == HeadlessMode.Preview)
            {
                Sitecore.Context.HeadlessContext.SetMode(new HeadlessModeParameters()
                {
                    Duration = HeadlessModeDuration.Persistent,
                    Mode = HeadlessMode.Edit,
                });
            }
        }
    }
}