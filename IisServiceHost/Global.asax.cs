namespace IisServiceHost
{
    using System;
    using System.Web;

    using StructureMap;

    public class Global : HttpApplication
    {
        #region Methods

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            // pass our registry to the object factory
            ObjectFactory.Initialize(x => x.AddRegistry<ServiceHostRegistry>());
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        #endregion
    }
}