using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using NTApp.Models;


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

            if (txtBox1.Text != string.Empty)
            {
                MessageBox.Show("Clear the text box before you read another");
            }

            else
            {
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
        }

        

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox1.Text == string.Empty)
            {
                MessageBox.Show("Nothing to clear");
            }

            txtBox1.Clear();
        }

        private void DeleteFileBtn_Click(object sender, RoutedEventArgs e)
        {
            noteRepo.DeleteFile(DeleteFileBox.Text);
        }

        private void CreateNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            saveBtn.Visibility = Visibility.Visible;
            ReadBtn.Visibility = Visibility.Visible;
            clearBtn.Visibility = Visibility.Visible;
            txtBox1.Visibility = Visibility.Visible;
            CreateNoteBtn.Visibility = Visibility.Hidden;
            ReadBox.Visibility = Visibility.Visible;
            readFileLabel.Visibility = Visibility.Visible;
            DeleteFileLabel.Visibility = Visibility.Visible;
            DeleteFileBox.Visibility = Visibility.Visible;
            DeleteFileBtn.Visibility = Visibility.Visible;
            UpdateFileLabel.Visibility = Visibility.Visible;
            UpdateBox.Visibility = Visibility.Visible;
            UpdateBtn.Visibility = Visibility.Visible;
        }

        private void WheatBtn_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = Brushes.Wheat;
            AppLabel.Foreground = Brushes.Black;
            readFileLabel.Foreground = Brushes.Black;
            DeleteFileLabel.Foreground = Brushes.Black;
            UpdateFileLabel.Foreground = Brushes.Black;
        }

        private void WhiteBtn_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = Brushes.White;
            AppLabel.Foreground = Brushes.Black;
            readFileLabel.Foreground = Brushes.Black;
            DeleteFileLabel.Foreground = Brushes.Black;
            UpdateFileLabel.Foreground = Brushes.Black;
        }

        private void BlackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = (Brush)(new BrushConverter().ConvertFrom("#FF2F2F2F"));
            AppLabel.Foreground = Brushes.White;
            readFileLabel.Foreground = Brushes.White;
            DeleteFileLabel.Foreground = Brushes.White;
            UpdateFileLabel.Foreground = Brushes.White;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Color startColor = (Color)ColorConverter.ConvertFromString("#FFFF7C60");
            Color endColor = (Color)ColorConverter.ConvertFromString("#FFFF4720");
            LinearGradientBrush gradientBrush = new LinearGradientBrush(startColor, endColor, 90);
            MainGrid.Background = gradientBrush;
            AppLabel.Foreground = Brushes.White;
            readFileLabel.Foreground = Brushes.White;
            DeleteFileLabel.Foreground = Brushes.White;
            UpdateFileLabel.Foreground = Brushes.White;
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            noteRepo.UpdateFile(UpdateBox.Text, txtBox1.Text);
        }
    }
}