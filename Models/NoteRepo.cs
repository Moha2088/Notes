using System;
using System.IO;
using System.Windows;


namespace Notes.Models
{
    internal class NoteRepo
    {
        public void SaveFile(string file, string fileName)
        {
            if (file == string.Empty)
            {
                MessageBox.Show("Type something in the box before you save");
            }

            if (file.Length < 10)
            {
                MessageBox.Show("Please write a longer text");
            }

            else
            {
                string nameOfFile = $"\\{fileName}.txt";
                string filePath = "C:\\Users\\maxam\\Desktop\\NoteFolder(NTApp)";
                string folderPath = filePath + nameOfFile;
                
                /*int fileNumber = 1;
                while (File.Exists(folderPath))
                {
                    fileName = $"\\notes{fileNumber}.txt";
                    folderPath = filePath + fileName;
                    fileNumber++;
                }*/

                using (StreamWriter sw = new StreamWriter(folderPath))
                {
                    sw.WriteLine(file);
                    MessageBox.Show($"Note saved: {fileName}");
                }
            }
        }

        public void ReadFile(string fileName, string outputBox)
        {
            string nameOfFile = $"\\{fileName}.txt";
            string filePath = "C:\\Users\\maxam\\Desktop\\NoteFolder(NTApp)";
            string folderPath = filePath + nameOfFile;

            if (outputBox != string.Empty)
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
                            outputBox += line;
                        }
                    }
                }

                catch (FileNotFoundException notFound)
                {
                    MessageBox.Show($"{notFound.Message} Go to {filePath} to check the files and their names, and type in a valid name");
                }
            }
        }

        public void UpdateFile(string file, string outputBox)
        {
            string nameOfFile = $"\\{file}.txt";
            string filePath = "C:\\Users\\maxam\\Desktop\\NoteFolder(NTApp)";
            string folderPath = filePath + nameOfFile;
            File.Delete(folderPath);

            using (StreamWriter sw = new StreamWriter(folderPath))
            {
                sw.WriteLine(outputBox);
                MessageBox.Show($"Note updated: {file}");
            }
        }

        public void DeleteFile(string file)
        {
            string nameOfFile = $"\\{file}.txt";
            string filePath = "C:\\Users\\maxam\\Desktop\\NoteFolder(NTApp)";
            string folderPath = filePath + nameOfFile;

            try
            {
                File.Delete(folderPath);
                MessageBox.Show($"File deleted: {file}");
            }

            catch (FileNotFoundException notFound)
            {
                MessageBox.Show(
                    $"{notFound.Message} Go to {filePath} to check the files and their names, and type in a valid name");
            }
        }
    }
}