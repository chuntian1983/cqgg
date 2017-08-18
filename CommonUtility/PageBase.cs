using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Diagnostics;
namespace Utility
{
    class PageBase:Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new System.EventHandler(this.PageBase_Load);
            this.Error += new System.EventHandler(this.PageBase_Error);
        }

        protected void LogEvent(string message, EventLogEntryType entryType)
        {
            if (!EventLog.SourceExists("StarTech.COM"))
            {
                EventLog.CreateEventSource("StarTech.COM", "Application");
            }
            EventLog.WriteEntry("StarTech.COM", message, entryType);
        }
        private void PageBase_Error(object sender, System.EventArgs e)
        {
            //string errMsg;
            Exception currentError = Server.GetLastError();

            //errMsg = "<link rel=\"stylesheet\" href=\"/ThePhile/Styles/ThePhile.CSS\">";
            //errMsg += "<h1>Page Error</h1><hr/>An unexpected error has occurred on this page. The system " +
            //    "administrators have been notified. Please feel free to contact us with the information " +
            //    "surrounding this error.<br/>" +
            //    "The error occurred in: " + Request.Url.ToString() + "<br/>" +
            //    "Error Message: <font class=\"ErrorMessage\">" + currentError.Message.ToString() + "</font><hr/>" +
            //    "<b>Stack Trace:</b><br/>" +
            //    currentError.ToString();

            //if (!(currentError is AppException))
            //{
                // It is not one of ours, so we cannot guarantee that it has been logged
                // into the event log.
                LogEvent(currentError.ToString(), EventLogEntryType.Error);
            //}

            //Response.Write(errMsg);
            Server.ClearError();
        }


        private void PageBase_Load(object sender, System.EventArgs e)
        {
            //// TODO: Place any code that will take place BEFORE the Page_Load event
            //// in the regular page, e.g. cache management, authentication verification,
            //// etc.											
            //if (Context.User.Identity.IsAuthenticated)
            //{
            //    if (!(Context.User is PhilePrincipal))
            //    {
            //        // ASP.NET's regular forms authentication picked up our cookie, but we
            //        // haven't replaced the default context user with our own. Let's do that
            //        // now. We know that the previous context.user.identity.name is the e-mail
            //        // address (because we forced it to be as such in the login.aspx page)				
            //        PhilePrincipal newUser = new PhilePrincipal(Context.User.Identity.Name);
            //        Context.User = newUser;
            //    }
            //}
        }
    }
}
