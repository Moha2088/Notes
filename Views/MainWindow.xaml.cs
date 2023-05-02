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

        public string currentDate { get; set; } = DateTime.Now.ToString("dd/MMMM/yyyy / HH:mm");

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            string fileName = "\\notes.txt";
            string filePath = "C:\\Users\\maxam\\Desktop\\NoteFolder(NTApp)";
            string folderPath = filePath + fileName;
            int fileNumber = 1;
            while (File.Exists(folderPath))
            {
                fileName = $"\\notes{fileNumber}.txt";
                folderPath = filePath + fileName;
                fileNumber++;
            }

            using (StreamWriter sw = new StreamWriter(folderPath))
            {
                sw.WriteLine(txtBox1.Text);
                MessageBox.Show("Note saved");
            }
        }

        private void ReadBtn_Click(object sender, RoutedEventArgs e)
        {
            string fileName = "\\notes.txt";
            string filePath = "C:\\Users\\maxam\\Desktop\\NoteFolder(NTApp)";
            string folderPath = filePath + fileName;

            using (StreamReader streamReader = new StreamReader(folderPath))
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

        private void DkModeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = Brushes.DarkGray;
        }

        private void LtModeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = Brushes.AliceBlue;
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e) => txtBox1.Clear();

        private void CreateNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            saveBtn.Visibility = Visibility.Visible;
            ReadBtn.Visibility = Visibility.Visible;
            clearBtn.Visibility = Visibility.Visible;
            txtBox1.Visibility = Visibility.Visible;
            DkModeBtn.Visibility = Visibility.Visible;
            LtModeBtn.Visibility = Visibility.Visible;
            DkModeCircle.Visibility = Visibility.Visible;
            LtModeCircle.Visibility = Visibility.Visible;
            CreateNoteBtn.Visibility = Visibility.Hidden;
        }
    }
}