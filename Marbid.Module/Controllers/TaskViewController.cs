using System;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Templates;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Model.NodeGenerators;
using Marbid.Module.BusinessObjects;
using Marbid.Module.BusinessObjects.HRM;

namespace Marbid.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
    public partial class TaskViewController : ViewController
    {
        public TaskViewController()
        {
            InitializeComponent();
            RegisterActions(components);
            TargetObjectType = typeof(Task);
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            if (View is ListView && !View.IsRoot && View.ObjectTypeInfo.Type == typeof(TaskNote))
            {

                Frame.GetController<DevExpress.ExpressApp.SystemModule.LinkUnlinkController>().LinkAction.Active.SetItemValue("myReason", false);
                Frame.GetController<DevExpress.ExpressApp.SystemModule.LinkUnlinkController>().UnlinkAction.Active.SetItemValue("myReason", false);

            }
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
