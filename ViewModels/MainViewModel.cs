using Notes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            TxtFileNames = Directory.GetFiles("C:\\Users\\maxam\\Desktop\\NoteFolder(Notes)");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        NoteRepo noteRepo = new NoteRepo();

        public string CurrentDate { get; set; } = DateTime.Now.ToString("dd/MMMM/yyyy / HH:mm ");

        //string[] TxtFileNames = Directory.GetFiles("C:\\Users\\maxam\\Desktop\\NoteFolder(Notes)");

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

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
