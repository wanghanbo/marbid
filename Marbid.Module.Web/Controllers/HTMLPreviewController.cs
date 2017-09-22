﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.Web;

namespace Marbid.Module.Web.Controllers
{
  // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
  public partial class HTMLPreviewController : ViewController
  {
    public HTMLPreviewController()
    {
      InitializeComponent();
      // Target required Views (via the TargetXXX properties) and create their Actions.
      TargetViewType = ViewType.ListView;
    }
    protected override void OnActivated()
    {
      base.OnActivated();
      // Perform various tasks depending on the target View.

    }
    protected override void OnViewControlsCreated()
    {
      base.OnViewControlsCreated();
      // Access and customize the target View control.
      ASPxGridListEditor listEditor = ((ListView)View).Editor as ASPxGridListEditor;
      if (listEditor != null)
      {
        ASPxGridView gridView = (ASPxGridView)listEditor.Grid;
        gridView.PreviewEncodeHtml = false;
      }
    }

    protected override void OnDeactivated()
    {
      // Unsubscribe from previously subscribed events and release other references and resources.
      base.OnDeactivated();
    }
  }
}
