﻿#pragma checksum "..\..\..\pages\UserMainPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02472C17484D28ACE0F456634D9C89FCCE76650F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using kursProjectV3.pages;


namespace kursProjectV3.pages {
    
    
    /// <summary>
    /// UserMainPage
    /// </summary>
    public partial class UserMainPage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\pages\UserMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock GreetingsText;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\pages\UserMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DirectionsControl;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\pages\UserMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AccountControl;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\pages\UserMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Messages;
        
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
            System.Uri resourceLocater = new System.Uri("/kursProjectV3;component/pages/usermainpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\pages\UserMainPage.xaml"
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
            this.GreetingsText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            
            #line 20 "..\..\..\pages\UserMainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ToUserCabinet);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 27 "..\..\..\pages\UserMainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ToFindDirection);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DirectionsControl = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\pages\UserMainPage.xaml"
            this.DirectionsControl.Click += new System.Windows.RoutedEventHandler(this.ToRunsControl);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AccountControl = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\pages\UserMainPage.xaml"
            this.AccountControl.Click += new System.Windows.RoutedEventHandler(this.ToAccountControl);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Messages = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\pages\UserMainPage.xaml"
            this.Messages.Click += new System.Windows.RoutedEventHandler(this.ToMessages);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

