﻿#pragma checksum "..\..\..\..\Windows\DataSourceViewer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3F4F1EA1C26AC4F204493C11F74722DF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace HL7Parser.Windows {
    
    
    /// <summary>
    /// DataSourceViewer
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class DataSourceViewer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Windows\DataSourceViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLoadDataSource;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Windows\DataSourceViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnShowFilterColumns;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Windows\DataSourceViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbxSearchbox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Windows\DataSourceViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgHL7SourceData;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Windows\DataSourceViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HL7Parser2;component/windows/datasourceviewer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\DataSourceViewer.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnLoadDataSource = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\..\Windows\DataSourceViewer.xaml"
            this.btnLoadDataSource.Click += new System.Windows.RoutedEventHandler(this.btnLoadDataSource_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnShowFilterColumns = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\Windows\DataSourceViewer.xaml"
            this.btnShowFilterColumns.Click += new System.Windows.RoutedEventHandler(this.btnShowFilterColumns_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtbxSearchbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.dgHL7SourceData = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\Windows\DataSourceViewer.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

