using System;
using System.IO;

namespace laba6._4
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = @"C:\laba6\Lab6_Temp";
            string firstFilePath = @"C:\laba6\lab.dat";
            string copyFilePath = @"C:\laba6\Lab6_Temp\lab.dat";
            string backupFilePath = directory + "\\lab_backup.dat";
            var directoryInfo = new DirectoryInfo(directory);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            if (File.Exists(copyFilePath))
            {
                File.Delete(copyFilePath);
            }
            File.Copy(firstFilePath, copyFilePath);
            FileStream originalFile = new FileStream(copyFilePath, FileMode.Open);
            FileStream backupFile = new FileStream(backupFilePath, FileMode.Create);
            originalFile.CopyTo(backupFile);
            FileInfo fileInf = new FileInfo(backupFilePath);
            Console.WriteLine("Размер файла: " + fileInf.Length);
            Console.WriteLine("Время последнего изменения: " + fileInf.LastWriteTime);
            Console.WriteLine("Время последнего доступа: " + fileInf.LastAccessTime);
            Console.ReadKey();
        }
    }
}
