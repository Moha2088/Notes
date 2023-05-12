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

            if (fileName == string.Empty)
            {
                MessageBox.Show("The file needs a name");
            }

            if (file.Length < 10)
            {
                MessageBox.Show("Please write a longer text");
            }

            else
            {
                string nameOfFile = $"\\{fileName}.txt";
                string filePath = "C:\\Users\\maxam\\Desktop\\NoteFolder(Notes)";
                string folderPath = filePath + nameOfFile;

                if (File.Exists(folderPath))
                {
                    MessageBox.Show("File already exists. Please use another name");
                }

                else
                {
                    using (StreamWriter sw = new StreamWriter(folderPath))
                    {
                        sw.WriteLine(file);
                        MessageBox.Show($"Note saved: {fileName}");
                    }
                }
            }
        }

        public void ReadFile(string fileName, string outputBox)
        {
            string nameOfFile = $"\\{fileName}.txt";
            string filePath = "C:\\Users\\maxam\\Desktop\\NoteFolder(Notes)";
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
                    MessageBox.Show(
                        $"{notFound.Message} Go to {filePath} to check the files and their names, and type in a valid name");
                }
            }
        }

        public void UpdateFile(string file, string outputBox)
        {
            string nameOfFile = $"\\{file}.txt";
            string filePath = "C:\\Users\\maxam\\Desktop\\NoteFolder(Notes)";
            string folderPath = filePath + nameOfFile;
            

            if (File.Exists(folderPath) == false)
            {
                FileNotFoundException notFoundException = new FileNotFoundException();
                MessageBox.Show($"{notFoundException.Message} Only existing files can be updated");
            }

            if (outputBox == string.Empty)
            {
                MessageBox.Show("Type something in the box before you update");
            }

            else
            {
                File.Delete(folderPath);
                using (StreamWriter sw = new StreamWriter(folderPath))
                {
                    sw.WriteLine(outputBox);
                    MessageBox.Show($"Note updated: {file}");
                }
            }
        }

        public void DeleteFile(string file)
        {
            string nameOfFile = $"\\{file}.txt";
            string filePath = "C:\\Users\\maxam\\Desktop\\NoteFolder(Notes)";
            string folderPath = filePath + nameOfFile;

            if(File.Exists(folderPath) == false)
            {
                FileNotFoundException notFoundException = new FileNotFoundException();
                MessageBox.Show($"{notFoundException.Message} Only existing files can be deleted");
            }

            else 
            {
                File.Delete(folderPath);
                MessageBox.Show($"File deleted: {file}");
            }
        }
    }
}