﻿#pragma checksum "..\..\..\..\View\User\AddInvPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B36CB882AC1E6FDFBAD82A7CF37B38157E83D57C970316A15308886F10D92B53"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
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
using ZarządzanieBudżetem.View.User;


namespace ZarządzanieBudżetem.View.User {
    
    
    /// <summary>
    /// AddInvPage
    /// </summary>
    public partial class AddInvPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\View\User\AddInvPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NrFakturyTextBox;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\View\User\AddInvPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddInv;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\View\User\AddInvPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox KwotaTextBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\View\User\AddInvPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox OpisTextBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\View\User\AddInvPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DataFakturyDatePicker;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\View\User\AddInvPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox JednostkaTextBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\View\User\AddInvPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BudynekTextBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\View\User\AddInvPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PokojTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/ZarządzanieBudżetem;component/view/user/addinvpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\User\AddInvPage.xaml"
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
            this.NrFakturyTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.AddInv = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\View\User\AddInvPage.xaml"
            this.AddInv.Click += new System.Windows.RoutedEventHandler(this.AddInv_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.KwotaTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.OpisTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.DataFakturyDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.JednostkaTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.BudynekTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.PokojTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            
            #line 35 "..\..\..\..\View\User\AddInvPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

