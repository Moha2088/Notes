using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Notes.ViewModels;

namespace Notes.Views
{
    delegate void FileCrud(string a, string b);

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        MainViewModel mvm = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = mvm;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            FileCrud saveCrud = mvm.Save;
            saveCrud(txtBox1.Text, FileNameBox.Text);
            NamesBox.Items.Refresh();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NamesBox.SelectedItem is not null)
            {
                FileCrud updateCrud = mvm.Update;
                updateCrud(NamesBox.SelectedItem.ToString(), txtBox1.Text);
            }

            else
            {
                MessageBox.Show("You have to click on a file to update!", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void DeleteFileBtn_Click(object sender, RoutedEventArgs e)
        {
            mvm.Delete(NamesBox.SelectedItem.ToString());
            NamesBox.Items.Refresh();
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox1.Text == string.Empty)
            {
                MessageBox.Show("Nothing to clear");
            }

            txtBox1.Clear();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e) => Close();


        private void CreateNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            FileNameLabel.Visibility = Visibility.Visible;
            FileNameBox.Visibility = Visibility.Visible;
            CreateNoteBtn.Visibility = Visibility.Hidden;
            saveBtn.Visibility = Visibility.Visible;
            clearBtn.Visibility = Visibility.Visible;
            txtBox1.Visibility = Visibility.Visible;
            DeleteFileBtn.Visibility = Visibility.Visible;
            UpdateBtn.Visibility = Visibility.Visible;
            NamesBox.Visibility = Visibility.Visible;
            MainBackBtn.Visibility = Visibility.Visible;
            Circle1.Visibility = Visibility.Hidden;
            Circle2.Visibility = Visibility.Hidden;
            Circle3.Visibility = Visibility.Hidden;
            NamesBoxLabel.Visibility = Visibility.Visible;
            NamesBoxCount.Visibility = Visibility.Visible;
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
            UpdateBtn.Foreground = Brushes.Black;
            UpdateBtn.BorderBrush = Brushes.Black;
            DeleteFileBtn.Foreground = Brushes.Black;
            DeleteFileBtn.BorderBrush = Brushes.Black;
            clearBtn.Foreground = Brushes.Black;
            clearBtn.BorderBrush = Brushes.Black;
            MainBackBtn.Foreground = Brushes.Black;
            MainBackBtn.BorderBrush = Brushes.Black;
            NamesBoxLabel.Foreground = Brushes.Black;
            NamesBoxCount.Foreground = Brushes.Black;
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

            UpdateBtn.Foreground = Brushes.Black;
            UpdateBtn.BorderBrush = Brushes.Black;
            DeleteFileBtn.Foreground = Brushes.Black;
            DeleteFileBtn.BorderBrush = Brushes.Black;
            clearBtn.Foreground = Brushes.Black;
            clearBtn.BorderBrush = Brushes.Black;
            MainBackBtn.Foreground = Brushes.Black;
            MainBackBtn.BorderBrush = Brushes.Black;
            NamesBoxLabel.Foreground = Brushes.Black;
            NamesBoxCount.Foreground = Brushes.Black;
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
            UpdateBtn.Foreground = Brushes.White;
            UpdateBtn.BorderBrush = Brushes.White;
            DeleteFileBtn.Foreground = Brushes.White;
            DeleteFileBtn.BorderBrush = Brushes.White;
            clearBtn.Foreground = Brushes.White;
            clearBtn.BorderBrush = Brushes.White;
            MainBackBtn.Foreground = Brushes.White;
            MainBackBtn.BorderBrush = Brushes.White;
            NamesBoxLabel.Foreground = Brushes.White;
            NamesBoxCount.Foreground = Brushes.White;
        }

        private void OrangeGradientBtn_Click(object sender, RoutedEventArgs e)
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
            UpdateBtn.Foreground = Brushes.White;
            UpdateBtn.BorderBrush = Brushes.White;
            DeleteFileBtn.Foreground = Brushes.White;
            DeleteFileBtn.BorderBrush = Brushes.White;
            clearBtn.Foreground = Brushes.White;
            clearBtn.BorderBrush = Brushes.White;
            MainBackBtn.Foreground = Brushes.White;
            MainBackBtn.BorderBrush = Brushes.White;
            NamesBoxLabel.Foreground = Brushes.White;
            NamesBoxCount.Foreground = Brushes.White;
        }

        private void PurpleGradientBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Color startColor = (Color)ColorConverter.ConvertFromString("#2E2157");
            Color endColor = (Color)ColorConverter.ConvertFromString("#FF00ff");
            LinearGradientBrush gradientBrush = new LinearGradientBrush(startColor, endColor, 90);

            MainGrid.Background = gradientBrush;
            FileNameLabel.Foreground = Brushes.White;
            CreateNoteBtn.Foreground = Brushes.White;
            CreateNoteBtn.BorderBrush = Brushes.White;
            MainGrid.Background = gradientBrush;
            AppLabel.Foreground = (Brush)(new BrushConverter().ConvertFrom("#7AD7F0"));
            saveBtn.Foreground = Brushes.White;
            saveBtn.BorderBrush = Brushes.White;
            UpdateBtn.Foreground = Brushes.White;
            UpdateBtn.BorderBrush = Brushes.White;
            DeleteFileBtn.Foreground = Brushes.White;
            DeleteFileBtn.BorderBrush = Brushes.White;
            clearBtn.Foreground = Brushes.White;
            clearBtn.BorderBrush = Brushes.White;
            MainBackBtn.Foreground = Brushes.White;
            MainBackBtn.BorderBrush = Brushes.White;
            NamesBoxLabel.Foreground = Brushes.White;
            NamesBoxCount.Foreground = Brushes.White;
        }

        private void MainBackBtn_Click(object sender, RoutedEventArgs e)
        {
            FileNameLabel.Visibility = Visibility.Hidden;
            FileNameBox.Visibility = Visibility.Hidden;
            CreateNoteBtn.Visibility = Visibility.Visible;
            saveBtn.Visibility = Visibility.Hidden;
            clearBtn.Visibility = Visibility.Hidden;
            txtBox1.Visibility = Visibility.Hidden;
            UpdateBtn.Visibility = Visibility.Hidden;
            DeleteFileBtn.Visibility = Visibility.Hidden;
            NamesBox.Visibility = Visibility.Hidden;
            MainBackBtn.Visibility = Visibility.Hidden;
            Circle1.Visibility = Visibility.Visible;
            Circle2.Visibility = Visibility.Visible;
            Circle3.Visibility = Visibility.Visible;
            NamesBoxLabel.Visibility = Visibility.Hidden;
            NamesBoxCount.Visibility = Visibility.Hidden;
        }

        private void NamesBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //txtBox1.Clear();
            //mvm.DisplayFiles(NamesBox.SelectedItem.ToString(), txtBox1.Text);

            txtBox1.Clear();

            try
            {
                using (StreamReader sr = new StreamReader(NamesBox.SelectedItem.ToString()))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        txtBox1.Text += line;
                    }
                }
            }

            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}