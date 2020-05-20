using System;
using System.IO;

namespace laba6._3
{

    /*
        Вариант 1.
        Считать текстовый файл, сформировать новый файл, в котором несколько подряд идущих пустых
        строк заменены одной. Вывести на консоль количество удаленных строк
    */
    class Program
    {
        static void Main(string[] args)
        {
            string directory = @"C:\laba6\Lab6.3 variant 1";

            string firstFilePath = directory + "\\lab1.txt";
            string secondFilePath = directory + "\\lab2.txt";

            FileInfo fileInf1 = new FileInfo(firstFilePath);
            FileInfo fileInf2 = new FileInfo(secondFilePath);


            var directoryInfo = new DirectoryInfo(directory);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
                Console.WriteLine("[SUCCESS] Каталог был успешно создан, но файлов в нём нет(");
            }
            if (fileInf1.Exists && fileInf2.Exists)
            {
                string newText = String.Empty;
                int countOfVoidStrings = 0;
                string[] text = File.ReadAllLines(firstFilePath);
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] != "")
                    {
                        countOfVoidStrings++;
                        newText += text[i] + "\n";
                    }
                    else if (text[i + 1] != "")
                    {
                        countOfVoidStrings++;
                        newText += "\n" + text[i + 1] + "\n";
                        i++;
                    }
                    
                }


                newText = System.Text.RegularExpressions.Regex.Replace(newText, @"\s{2,}", " ");


                File.WriteAllLines(secondFilePath, newText.Split('\n'));
                Console.WriteLine();
                Console.WriteLine("Количество замененных пустых строк: " + countOfVoidStrings);
            }

            else Console.WriteLine("[ERROR] В папке файлов нет");
            if (Directory.Exists(directory))
            {
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(directory);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }
            Console.WriteLine();
        }
    }
}  
