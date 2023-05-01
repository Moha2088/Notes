using NTApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace NTApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        MainWindow mw = new MainWindow();
        Notebook nb = new Notebook();

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SaveTxtFile()
        {
            string fileName = "\\notes.txt";
            string filePath = "C:\\Users\\maxam\\Desktop\\NoteFolder(NTApp)";
            string folderPath = Path.Combine(filePath, fileName);

            //while(File.Exists(folderPath))
            //{
            //    int fileNumber = 0;
            //    fileName = $"notes{fileNumber}.txt";
            //    folderPath = Path.Combine(filePath, fileName);
            //}       

            using (StreamWriter sw = new StreamWriter(folderPath))
            {
                sw.WriteLine(mw.txtBox1.Text);
                MessageBox.Show("Note saved");
            }
        }

        public void ReadTxtFile()
        {
            string fileName = "\\notes1.txt";
            string filePath = "C:\\Users\\maxam\\Desktop\\NoteFolder(NTApp)";
            string folderPath = Path.Combine(filePath, fileName);

            using (StreamReader streamReader = new StreamReader(folderPath))
            {
                string line;
                try
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        mw.txtBox1.Text += line;
                    }
                }

                catch (Exception srError)
                {
                    MessageBox.Show(srError.Message);
                }
            }
        }

        public void DkMode()
        {
            mw.MainGrid.Background = Brushes.DarkGray;
        }

        public void LtMode()
        {
            mw.MainGrid.Background = Brushes.AliceBlue;
        }


    }
}
