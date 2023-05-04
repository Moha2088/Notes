using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NTApp
{
    internal class NoteRepo
    {
        public void SaveFile(string file)
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
                sw.WriteLine(file);
                MessageBox.Show("Note saved");
            }
        }

        public void ReadFile(string file, string outputBox)
        {
            string nameOfFile = $"\\{file}.txt";
            string filePath = "C:\\Users\\maxam\\Desktop\\NoteFolder(NTApp)";
            string folderPath = filePath + nameOfFile;

            try
            {
                using (StreamReader sr = new StreamReader(folderPath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        outputBox += line;
                    }
                }
            }

            catch (FileNotFoundException notFound)
            {
                MessageBox.Show($"{notFound.Message} Go to {filePath} to check the files and their names, and type in a valid name");
            }
        }

        public void DeleteFile(string file)
        {
            string nameOfFile = $"\\{file}.txt";
            string filePath = "C:\\Users\\maxam\\Desktop\\NoteFolder(NTApp)";
            string folderPath = filePath + nameOfFile;

            File.Delete(folderPath);
            MessageBox.Show("File deleted");
        }
    }
}
