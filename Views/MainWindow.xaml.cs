﻿using System;
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

        public string currentDate { get; set; } = DateTime.Now.ToString("dd/MMMM/yyyy / HH:mm");

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            string fileName = $"\\notes.txt";
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
            string nameOfFile = $"\\{ReadBox.Text}.txt";
            string filePath = "C:\\Users\\maxam\\Desktop\\NoteFolder(NTApp)";
            string folderPath = filePath + nameOfFile;


            using (StreamReader sr = new StreamReader(folderPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    txtBox1.Text += line;
                }
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e) => txtBox1.Clear();

        private void ReadComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) // Not functional
        {
            Directory.EnumerateFiles("C:\\Users\\maxam\\Desktop\\NoteFolder(NTApp)");
            List<string> files = new List<string>();
            foreach (string file in files)
            {
                ReadComboBox.Items.Add($"\\{file}.txt");
            }
        }

        private void CreateNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            saveBtn.Visibility = Visibility.Visible;
            ReadBtn.Visibility = Visibility.Visible;
            clearBtn.Visibility = Visibility.Visible;
            txtBox1.Visibility = Visibility.Visible;
            LightCoralBtn.Visibility = Visibility.Visible;
            CreateNoteBtn.Visibility = Visibility.Hidden;
            ReadBox.Visibility = Visibility.Visible;
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
        }
    }
}