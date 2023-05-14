using System.IO;
using System.Windows;


namespace Notes.Models
{
    public class NoteRepo
    {
        public void SaveFile(string file, string fileName)
        {
          
                
            if (fileName == string.Empty)
            {
                MessageBox.Show("The file needs a name");
            }

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
                        MessageBox.Show($"File saved: {fileName}");
                    }
                }
            }
        }

        public void UpdateFile(string selectedItem, string inputBox)
        {
            File.Delete(selectedItem);
            using(StreamWriter sw = new StreamWriter(selectedItem)) 
            { 
                sw.WriteLine(inputBox);
            }

            MessageBox.Show($"File updated: {selectedItem}");
        }

        public void DeleteFile(string file)
        {
            File.Delete(file);

            MessageBox.Show($"{file} deleted");
        }
    }
}