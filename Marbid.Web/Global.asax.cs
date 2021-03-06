﻿using System;
using System.Configuration;
using System.Web.Configuration;
using System.Web;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Web;
using DevExpress.Web;
using DevExpress.ExpressApp.Web.Controls;
using System.Web.UI.WebControls;
using DevExpress.XtraReports.Security;

namespace Marbid.Web
{
    public class Global : System.Web.HttpApplication
    {
        public Global()
        {
            InitializeComponent();
        }
        protected void Application_Start(Object sender, EventArgs e)
        {
            SecurityAdapterHelper.Enable();
            ASPxWebControl.CallbackError += new EventHandler(Application_Error);
            WebApplication.EnableMultipleBrowserTabsSupport = true;
            //XafPopupWindowControl.PopupTemplateType = PopupTemplateType.FindDialog;
            //XafPopupWindowControl.ShowPopupMode = ShowPopupMode.Centered;
            //XafPopupWindowControl.DefaultWidth = Unit.Percentage(80);
            //XafPopupWindowControl.DefaultHeight = Unit.Percentage(80);
#if EASYTEST
            DevExpress.ExpressApp.Web.TestScripts.TestScriptsManager.EasyTestEnabled = true;
#endif
        }
        protected void Session_Start(Object sender, EventArgs e)
        {
            Tracing.Initialize();
            WebApplication.SetInstance(Session, new MarbidAspNetApplication());

            WebApplication.Instance.Settings.DefaultVerticalTemplateContentPath = "MareinDefaultVerticalTemplateContent.ascx";
            //WebApplication.Instance.Settings.LogonTemplateContentPath = "MarbidLogonTemplateContext.ascx";
            //DevExpress.ExpressApp.Web.Templates.DefaultVerticalTemplateContentNew.ClearSizeLimit();
            WebApplication.Instance.SwitchToNewStyle();
            WebApplication.Instance.LinkNewObjectToParentImmediately = true;
            if (ConfigurationManager.ConnectionStrings["ConnectionString"] != null)
            {
                WebApplication.Instance.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
#if EASYTEST
            if(ConfigurationManager.ConnectionStrings["EasyTestConnectionString"] != null) {
                WebApplication.Instance.ConnectionString = ConfigurationManager.ConnectionStrings["EasyTestConnectionString"].ConnectionString;
            }
#endif
            if (System.Diagnostics.Debugger.IsAttached && WebApplication.Instance.CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema)
            {
                WebApplication.Instance.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
            }
            ScriptPermissionManager.GlobalInstance = new ScriptPermissionManager(ExecutionMode.Unrestricted);
            WebApplication.Instance.Setup();
            WebApplication.Instance.Start();
        }
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
        }
        protected void Application_EndRequest(Object sender, EventArgs e)
        {
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
        }
        protected void Application_Error(Object sender, EventArgs e)
        {
            ErrorHandling.Instance.ProcessApplicationError();
        }
        protected void Session_End(Object sender, EventArgs e)
        {
            WebApplication.LogOff(Session);
            WebApplication.DisposeInstance(Session);
        }
        protected void Application_End(Object sender, EventArgs e)
        {
        }
        #region Web Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        }
        #endregion
    }
}
