﻿#pragma checksum "C:\Users\Dom\Downloads\Notld3\Rko\Rko\Loop\CzyPogotowie.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "74B450D019947ED209B8A1D705DDA58E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rko.Loop
{
    partial class CzyPogotowie : 
        global::Windows.UI.Xaml.Controls.Page, 
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
                    this.textBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 2:
                {
                    this.yesButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 13 "..\..\..\Loop\CzyPogotowie.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.yesButton).Click += this.pogotowieYES;
                    #line default
                }
                break;
            case 3:
                {
                    this.noButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 14 "..\..\..\Loop\CzyPogotowie.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.noButton).Click += this.pogotowieNO;
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
