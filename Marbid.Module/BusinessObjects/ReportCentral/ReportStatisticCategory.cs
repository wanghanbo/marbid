﻿using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace Marbid.Module.BusinessObjects.ReportCentral
{
    [DefaultClassOptions]
    [NavigationItem("Reports and Statistics")]
    [ImageName("BO_Category")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ReportStatisticCategory : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ReportStatisticCategory(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue("PersistentProperty", ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
        string title;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                SetPropertyValue("Title", ref title, value);
            }
        }
        string description;
        [Size(SizeAttribute.Unlimited)]
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                SetPropertyValue("Description", ref description, value);
            }
        }

        [Association("ReportStatisticCategory-BIDashboard")]
        public XPCollection<BIDashboard> BIDashboard
        {
            get
            {
                return GetCollection<BIDashboard>("BIDashboard");
            }
        }
        [Association("ReportStatisticCategory-Reporting")]
        public XPCollection<Reporting> Reporting
        {
            get
            {
                return GetCollection<Reporting>("Reporting");
            }
        }
        [Association("ReportStatisticCategory-PivotTool")]
        public XPCollection<PivotTool> PivotTool
        {
            get
            {
                return GetCollection<PivotTool>("PivotTool");
            }
        }

        [Association("ReportStatisticCategory-ReportCentral")]
        [ModelDefault("Caption","Data Explorer")]
        public XPCollection<ReportCentral> ReportCentral
        {
            get
            {
                return GetCollection<ReportCentral>("ReportCentral");
            }
        }
    }
}