﻿#pragma checksum "C:\Users\Dom\Downloads\Notld3\Rko\Rko\Controls\PageController.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CDDD0C067C88868057A3915549B58AC4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rko.Controls
{
    partial class PageController : 
        global::Windows.UI.Xaml.Controls.UserControl, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.UserControl element1 = (global::Windows.UI.Xaml.Controls.UserControl)(target);
                    #line 10 "..\..\..\Controls\PageController.xaml"
                    ((global::Windows.UI.Xaml.Controls.UserControl)element1).Unloaded += this.UserControl_Unloaded;
                    #line default
                }
                break;
            case 2:
                {
                    this.audioPlayer = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 3:
                {
                    this.BackButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 23 "..\..\..\Controls\PageController.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.BackButton).Click += this.BackButton_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.PauseButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 24 "..\..\..\Controls\PageController.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.PauseButton).Click += this.PauseButton_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.SkipButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 25 "..\..\..\Controls\PageController.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.SkipButton).Click += this.SkipButton_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
