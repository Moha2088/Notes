using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;

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

        NoteRepo noteRepo = new NoteRepo();
        public string currentDate { get; set; } = DateTime.Now.ToString("dd/MMMM/yyyy / HH:mm ");

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            noteRepo.SaveFile(txtBox1.Text);

        }

        private void ReadBtn_Click(object sender, RoutedEventArgs e)
        {
            // noteRepo.ReadFile(ReadBox.Text, txtBox1.Text);

            string nameOfFile = $"\\{ReadBox.Text}.txt";
            string filePath = "C:\\Users\\maxam\\Desktop\\NoteFolder(NTApp)";
            string folderPath = filePath + nameOfFile;

            try
            {
                using (StreamReader sr = new StreamReader(folderPath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        txtBox1.Text += line;
                    }
                }
            }

            catch (FileNotFoundException notFound)
            {
                MessageBox.Show($"{notFound.Message} Go to {filePath} to check the files and their names, and type in a valid name");
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e) => txtBox1.Clear();

        private void CreateNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            saveBtn.Visibility = Visibility.Visible;
            ReadBtn.Visibility = Visibility.Visible;
            clearBtn.Visibility = Visibility.Visible;
            txtBox1.Visibility = Visibility.Visible;
            LightCoralBtn.Visibility = Visibility.Visible;
            CreateNoteBtn.Visibility = Visibility.Hidden;
            ReadBox.Visibility = Visibility.Visible;
            readFileLabel.Visibility = Visibility.Visible;
            DeleteFileLabel.Visibility = Visibility.Visible;
            DeleteFileBox.Visibility = Visibility.Visible;
            DeleteFileBtn.Visibility = Visibility.Visible;
        }

        private void LightCoralBtn_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = Brushes.LightCoral;
        }

        private void WheatBtn_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = Brushes.Wheat;
        }

        private void WhiteBtn_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = Brushes.White;
            AppLabel.Foreground = Brushes.Black;
            readFileLabel.Foreground = Brushes.Black;
            DeleteFileLabel.Foreground = Brushes.Black;
        }

        private void BlackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = (Brush)(new BrushConverter().ConvertFrom("#FF2F2F2F"));
            AppLabel.Foreground = Brushes.White;
            readFileLabel.Foreground = Brushes.White;
            DeleteFileLabel.Foreground = Brushes.White;
            
            
        }

        private void DeleteFileBtn_Click(object sender, RoutedEventArgs e)
        {
           noteRepo.DeleteFile(DeleteFileBox.Text);
        }

        
    }
}