using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Vml;
using iTextSharp.text.pdf.parser;
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

        private void clearBtn_Click(object sender, RoutedEventArgs e) => txtBox1.Clear();

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            string fileName = "\\notes.txt";
            string filePath = "C:\\Users\\maxam\\OneDrive\\Skrivebord\\NoteFolder(NTApp)" + fileName;
            using (StreamWriter sw = new StreamWriter(filePath))
            {                           
                sw.WriteLine(txtBox1.Text);
                MessageBox.Show("Note saved");
            }
        }

        private void ReadBtn_Click(object sender, RoutedEventArgs e)
        {
            string fileName = "\\notes.txt";
            string filePath = "C:\\Users\\maxam\\OneDrive\\Skrivebord\\NoteFolder(NTApp)" + fileName;

            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string line;
                try
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        txtBox1.Text += line;
                    }
                }

                catch (Exception srError) 
                {
                    MessageBox.Show(srError.Message);
                }              
            }         
        }

        private void colorBtn_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = Brushes.AliceBlue;

            if (DkModeBtn.IsPressed) 
            {
                
            }
        }

        private void DkModeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = Brushes.LightGray;
        }
    }
}
