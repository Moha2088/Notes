using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Vml;
using iTextSharp.text.pdf.parser;
using NTApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
using Path = System.IO.Path;

namespace NTApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        MainViewModel mvm = new MainViewModel();

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            mvm.SaveTxtFile();
        }

        private void ReadBtn_Click(object sender, RoutedEventArgs e)
        {
            mvm.ReadTxtFile();
        }

        private void DkModeBtn_Click(object sender, RoutedEventArgs e)
        {
            mvm.DkMode();
        }

        private void LtModeBtn_Click(object sender, RoutedEventArgs e)
        {
            mvm.LtMode();
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e) => txtBox1.Clear();
    }
}
