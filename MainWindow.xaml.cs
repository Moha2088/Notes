using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Vml;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "C:\\Users\\maxam\\OneDrive\\Skrivebord\\NoteFolder\\notes.txt";
            int count = 0;
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                if (File.Exists(filePath)) 
                {
                   
                }

                sw.WriteLine(txtBox1.Text);
                Close();
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            txtBox1.Clear();
        }

        private void colorBtnRed_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = Brushes.Red;
        }
    }
}
