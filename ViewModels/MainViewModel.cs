using Notes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace Notes.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            TxtFileNames = Directory.GetFiles("C:\\Users\\maxam\\Desktop\\NoteFolder(Notes)");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public NoteRepo noteRepo = new NoteRepo();

        public string CurrentDate { get; set; } = DateTime.Now.ToString("dd/MMMM/yyyy / HH:mm ");


        private string[] _txtFileNames;

        public string[] TxtFileNames
        {
            get { return _txtFileNames; }

            set
            {
                _txtFileNames = value;
                OnPropertyChanged(nameof(TxtFileNames));
            }
        }

        public void Save(string file, string fileName)
        {
            noteRepo.SaveFile(file, fileName);
        }

        public void Update(string selectedItem, string inputBox)
        {
            noteRepo.UpdateFile(selectedItem, inputBox);
        }

        public void Delete(string file)
        {
            noteRepo.DeleteFile(file);
        }

        /*public void DisplayFiles(string selectedItem, string outputBox)
        {
            using (StreamReader sr = new StreamReader(selectedItem))
            {
                string line;

                if (outputBox != string.Empty)
                {
                    MessageBox.Show("Clear the text before you read another!");
                }

                else
                {
                    while((line = sr.ReadLine()) != null)
                    {
                        outputBox += line;
                    }
                }
            }
        }*/

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
