﻿#pragma checksum "E:\Code\SilverlightClient\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "309DC291C171E7A80E4AD14F0972F6B6"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34003
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using SLMitsuControls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace SilverlightClient {
    
    
    public partial class MainPage : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Canvas layout;
        
        internal System.Windows.Controls.Canvas canvasBook;
        
        internal SLMitsuControls.UCBook book;
        
        internal System.Windows.Controls.Canvas canvChanging;
        
        internal System.Windows.Controls.TextBlock changingText;
        
        internal System.Windows.Controls.ProgressBar changingProgressBar;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/SilverlightClient;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.layout = ((System.Windows.Controls.Canvas)(this.FindName("layout")));
            this.canvasBook = ((System.Windows.Controls.Canvas)(this.FindName("canvasBook")));
            this.book = ((SLMitsuControls.UCBook)(this.FindName("book")));
            this.canvChanging = ((System.Windows.Controls.Canvas)(this.FindName("canvChanging")));
            this.changingText = ((System.Windows.Controls.TextBlock)(this.FindName("changingText")));
            this.changingProgressBar = ((System.Windows.Controls.ProgressBar)(this.FindName("changingProgressBar")));
        }
    }
}

