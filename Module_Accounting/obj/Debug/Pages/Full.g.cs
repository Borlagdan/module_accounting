﻿#pragma checksum "..\..\..\Pages\Full.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "456A291E2620314E18E83AED732CDBC8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using Module_Accounting.Pages;
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


namespace Module_Accounting.Pages {
    
    
    /// <summary>
    /// Full
    /// </summary>
    public partial class Full : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\Pages\Full.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lbl_Fee;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Pages\Full.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lbl_Amount;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Pages\Full.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Amount;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Pages\Full.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Cash;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\Pages\Full.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lbl_Change;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\Pages\Full.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lbl_Total;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\Pages\Full.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lbl_Balance;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\Pages\Full.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Confirm;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Module_Accounting;component/pages/full.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Full.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lbl_Fee = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.lbl_Amount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txt_Amount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txt_Cash = ((System.Windows.Controls.TextBox)(target));
            
            #line 89 "..\..\..\Pages\Full.xaml"
            this.txt_Cash.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_Cash_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lbl_Change = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.lbl_Total = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.lbl_Balance = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.btn_Confirm = ((System.Windows.Controls.Button)(target));
            
            #line 132 "..\..\..\Pages\Full.xaml"
            this.btn_Confirm.Click += new System.Windows.RoutedEventHandler(this.btn_Confirm_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

