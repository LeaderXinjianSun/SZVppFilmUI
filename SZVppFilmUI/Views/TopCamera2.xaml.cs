﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SZVppFilmUI.Views
{
    /// <summary>
    /// TopCamera2.xaml 的交互逻辑
    /// </summary>
    public partial class TopCamera2 : UserControl
    {
        public TopCamera2()
        {
            InitializeComponent();
            Global.TopCameraImageViewer2 = this.TopCameraImageViewer2;
        }
    }
}
