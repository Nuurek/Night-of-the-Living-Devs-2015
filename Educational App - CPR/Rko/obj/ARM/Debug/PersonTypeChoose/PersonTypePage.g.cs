﻿#pragma checksum "C:\Users\Dom\Downloads\Notld3\Rko\Rko\PersonTypeChoose\PersonTypePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "15D120408957A0CA9724ED3453B1B172"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rko.PersonTypeChoose
{
    partial class PersonTypePage : 
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
                    this.InfoPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 2:
                {
                    this.KontrolkaSeby = (global::Rko.Controls.PageController)(target);
                }
                break;
            case 3:
                {
                    this.Adult = (global::Rko.Controls.PersonTypeElement)(target);
                    #line 23 "..\..\..\PersonTypeChoose\PersonTypePage.xaml"
                    ((global::Rko.Controls.PersonTypeElement)this.Adult).PointerPressed += this.Adult_PointerPressed;
                    #line default
                }
                break;
            case 4:
                {
                    this.Child = (global::Rko.Controls.PersonTypeElement)(target);
                    #line 25 "..\..\..\PersonTypeChoose\PersonTypePage.xaml"
                    ((global::Rko.Controls.PersonTypeElement)this.Child).PointerPressed += this.Child_PointerPressed;
                    #line default
                }
                break;
            case 5:
                {
                    this.Infant = (global::Rko.Controls.PersonTypeElement)(target);
                    #line 27 "..\..\..\PersonTypeChoose\PersonTypePage.xaml"
                    ((global::Rko.Controls.PersonTypeElement)this.Infant).PointerPressed += this.Infant_PointerPressed;
                    #line default
                }
                break;
            case 6:
                {
                    this.something = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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
