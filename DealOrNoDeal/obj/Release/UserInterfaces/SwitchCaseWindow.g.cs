#pragma checksum "..\..\..\UserInterfaces\SwitchCaseWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C1B8961788AEF9B0F4EC815C1D398B30FF6536A08279E3611D745521906EB93D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using DealOrNoDeal.UserInterfaces;
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


namespace DealOrNoDeal.UserInterfaces {
    
    
    /// <summary>
    /// SwitchCaseWindow
    /// </summary>
    public partial class SwitchCaseWindow : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\UserInterfaces\SwitchCaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid firstCaseGrid;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\UserInterfaces\SwitchCaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image firstCaseImage;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\UserInterfaces\SwitchCaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock firstCaseText;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\UserInterfaces\SwitchCaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock firstMoneyText;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\UserInterfaces\SwitchCaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid secondCaseGrid;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\UserInterfaces\SwitchCaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image secondCaseImage;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\UserInterfaces\SwitchCaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock secondCaseText;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\UserInterfaces\SwitchCaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock secondMoneyText;
        
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
            System.Uri resourceLocater = new System.Uri("/DealOrNoDeal;component/userinterfaces/switchcasewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserInterfaces\SwitchCaseWindow.xaml"
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
            this.firstCaseGrid = ((System.Windows.Controls.Grid)(target));
            
            #line 14 "..\..\..\UserInterfaces\SwitchCaseWindow.xaml"
            this.firstCaseGrid.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.firstCaseGrid_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.firstCaseImage = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.firstCaseText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.firstMoneyText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.secondCaseGrid = ((System.Windows.Controls.Grid)(target));
            
            #line 19 "..\..\..\UserInterfaces\SwitchCaseWindow.xaml"
            this.secondCaseGrid.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.secondCaseGrid_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.secondCaseImage = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.secondCaseText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.secondMoneyText = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

