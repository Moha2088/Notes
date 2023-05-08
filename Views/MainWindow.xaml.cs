using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Notes.Models;

namespace Notes
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

        public string CurrentDate { get; set; } = DateTime.Now.ToString("dd/MMMM/yyyy / HH:mm ");

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            noteRepo.SaveFile(txtBox1.Text , FileNameBox.Text);
        }

        private void ReadBtn_Click(object sender, RoutedEventArgs e)
        {
            //noteRepo.ReadFile(ReadBox.Text, txtBox1.Text);

              string nameOfFile = $"\\{ReadBox.Text}.txt";
              string filePath = "C:\\Users\\maxam\\Desktop\\NoteFolder(NTApp)";
              string folderPath = filePath + nameOfFile;
             
              if (txtBox1.Text != string.Empty)
              {
                  MessageBox.Show("Clear the text before you read another!");
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
                      MessageBox.Show(
                          $"{notFound.Message} Go to {filePath} to check the files and their names, and type in a valid name");
                  }
              }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            noteRepo.UpdateFile(UpdateBox.Text, txtBox1.Text);
        }

        private void DeleteFileBtn_Click(object sender, RoutedEventArgs e)
        {
            noteRepo.DeleteFile(DeleteFileBox.Text);
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox1.Text == string.Empty)
            {
                MessageBox.Show("Nothing to clear");
            }

            txtBox1.Clear();
        }

        private void CreateNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            FileNameLabel.Visibility = Visibility.Visible;
            FileNameBox.Visibility = Visibility.Visible;
            CreateNoteBtn.Visibility = Visibility.Hidden;
            saveBtn.Visibility = Visibility.Visible;
            ReadBtn.Visibility = Visibility.Visible;
            clearBtn.Visibility = Visibility.Visible;
            txtBox1.Visibility = Visibility.Visible;
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
            FileNameLabel.Foreground = Brushes.Black;
            CreateNoteBtn.Foreground = Brushes.Black;
            CreateNoteBtn.BorderBrush = Brushes.Black;
            MainGrid.Background = Brushes.Wheat;
            AppLabel.Foreground = Brushes.Black;
            saveBtn.Foreground = Brushes.Black;
            saveBtn.BorderBrush = Brushes.Black;
            readFileLabel.Foreground = Brushes.Black;
            ReadBtn.Foreground = Brushes.Black;
            ReadBtn.BorderBrush = Brushes.Black;
            UpdateFileLabel.Foreground = Brushes.Black;
            UpdateBtn.Foreground = Brushes.Black;
            UpdateBtn.BorderBrush = Brushes.Black;
            DeleteFileLabel.Foreground = Brushes.Black;
            DeleteFileBtn.Foreground = Brushes.Black;
            DeleteFileBtn.BorderBrush = Brushes.Black;
            clearBtn.Foreground = Brushes.Black;
            clearBtn.BorderBrush = Brushes.Black;
        }

        private void WhiteBtn_Click(object sender, RoutedEventArgs e)
        {
            FileNameLabel.Foreground = Brushes.Black;
            CreateNoteBtn.Foreground = Brushes.Black;
            CreateNoteBtn.BorderBrush = Brushes.Black;
            MainGrid.Background = Brushes.White;
            AppLabel.Foreground = Brushes.Black;
            saveBtn.Foreground = Brushes.Black;
            saveBtn.BorderBrush = Brushes.Black;
            readFileLabel.Foreground = Brushes.Black;
            ReadBtn.Foreground = Brushes.Black;
            ReadBtn.BorderBrush = Brushes.Black;
            UpdateFileLabel.Foreground = Brushes.Black;
            UpdateBtn.Foreground = Brushes.Black;
            UpdateBtn.BorderBrush = Brushes.Black;
            DeleteFileLabel.Foreground = Brushes.Black;
            DeleteFileBtn.Foreground = Brushes.Black;
            DeleteFileBtn.BorderBrush = Brushes.Black;
            clearBtn.Foreground = Brushes.Black;
            clearBtn.BorderBrush = Brushes.Black;
        }

        private void BlackBtn_Click(object sender, RoutedEventArgs e)
        {
            FileNameLabel.Foreground = Brushes.White;
            CreateNoteBtn.Foreground = Brushes.White;
            CreateNoteBtn.BorderBrush = Brushes.White;
            MainGrid.Background = (Brush)(new BrushConverter().ConvertFrom("#FF2F2F2F"));
            AppLabel.Foreground = Brushes.White;
            saveBtn.Foreground = Brushes.White;
            saveBtn.BorderBrush = Brushes.White;
            readFileLabel.Foreground = Brushes.White;
            ReadBtn.Foreground = Brushes.White;
            ReadBtn.BorderBrush = Brushes.White;
            UpdateFileLabel.Foreground = Brushes.White;
            UpdateBtn.Foreground = Brushes.White;
            UpdateBtn.BorderBrush = Brushes.White;
            DeleteFileLabel.Foreground = Brushes.White;
            DeleteFileBtn.Foreground = Brushes.White;
            DeleteFileBtn.BorderBrush = Brushes.White;
            clearBtn.Foreground = Brushes.White;
            clearBtn.BorderBrush = Brushes.White;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Color startColor = (Color)ColorConverter.ConvertFromString("#FFFF7C60");
            Color endColor = (Color)ColorConverter.ConvertFromString("#FFFF4720");
            LinearGradientBrush gradientBrush = new LinearGradientBrush(startColor, endColor, 90);

            FileNameLabel.Foreground = Brushes.White;
            CreateNoteBtn.Foreground = Brushes.White;
            CreateNoteBtn.BorderBrush = Brushes.White;
            MainGrid.Background = gradientBrush;
            AppLabel.Foreground = Brushes.White;
            saveBtn.Foreground = Brushes.White;
            saveBtn.BorderBrush = Brushes.White;
            readFileLabel.Foreground = Brushes.White;
            ReadBtn.Foreground = Brushes.White;
            ReadBtn.BorderBrush = Brushes.White;
            UpdateFileLabel.Foreground = Brushes.White;
            UpdateBtn.Foreground = Brushes.White;
            UpdateBtn.BorderBrush = Brushes.White;
            DeleteFileLabel.Foreground = Brushes.White;
            DeleteFileBtn.Foreground = Brushes.White;
            DeleteFileBtn.BorderBrush = Brushes.White;
            clearBtn.Foreground = Brushes.White;
            clearBtn.BorderBrush = Brushes.White;
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}