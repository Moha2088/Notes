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
            string filePath = "C:\\Users\\maxam\\OneDrive\\Skrivebord\\NoteFolder(NTApp)\\notes.txt";
            using (StreamWriter sw = new StreamWriter(filePath))
            {         
                if (File.Exists(filePath))
                {
                  
                }

                sw.WriteLine(txtBox1.Text);


                MessageBox.Show("Note saved");
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e) => txtBox1.Clear();




        private void colorBtn_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void colorBtn_Click_1(object sender, RoutedEventArgs e)
        {
            for (int count = 0; count < 100; count++)
            {
                if (colorBtn.IsMouseOver && count % 1 == 0)
                {
                    MainGrid.Background = Brushes.AliceBlue;
                }

                if (colorBtn.IsMouseOver && count % 1 != 0)
                {
                    MainGrid.Background = Brushes.LightGray;
                }
            }
        }
    }
}
