using Notes.Models;
using Notes.ViewModels.Commands;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Notes.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            TxtFileNames = Directory.GetFiles("C:\\Users\\maxam\\Desktop\\NoteFolder(Notes)");
            FileCount = TxtFileNames.Count();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public NoteRepo noteRepo = new NoteRepo();


        public int FileCount { get; set; }

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


        public ICommand NoteCommand { get; } = new NoteCommands();

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

        public void DisplayFiles(string selectedItem, string outputBox)
        {
            try
            {
                using (StreamReader sr = new StreamReader(selectedItem))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        outputBox += line;
                    }
                }
            }

            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

