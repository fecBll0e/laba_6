using System;
using System.IO;
using System.Text.RegularExpressions;

namespace laba6._2
{
    /*  
        Вариант 1.
        Программно записать в бинарный файл набор пар «N – 2^N» для N от 1 до 100. Написать функцию,
        которая считывает из этого файла все вторые числа из каждой пары и записывает во второй файл.
    */
    class Program
    {
        static void Main(string[] args)
        {
            string directory = @"C:\laba6\Lab6.2 variant 1";

            string firstFilePath = directory + "\\lab1.dat";
            string secondFilePath = directory + "\\lab2.dat";

            string setOfCouples = String.Empty;
            string secondNumbers = String.Empty;
            string textFromFile = String.Empty;
            if (Directory.Exists(directory)) 
                Console.WriteLine("[SUCCESS] Каталог уже создан и файлы в нём будут перезаписаны");
            var directoryInfo = new DirectoryInfo(directory);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
                Console.WriteLine("[SUCCESS] Каталог был успешно создан");
            }

            using (BinaryWriter writeToTheFirstFile = new BinaryWriter(new FileStream(firstFilePath, FileMode.OpenOrCreate)))
            {
                for (int N = 1; N <= 100; N++)
                {
                    setOfCouples += N + " - 2^" + N + "\n";
                }
                writeToTheFirstFile.Write(setOfCouples);
                Console.WriteLine("[SUCCESS] Набор успешно записан в файл 'laba1.dat'");
                writeToTheFirstFile.Close();
            }

            using (BinaryReader readFromTheFirstFile = new BinaryReader(new FileStream(firstFilePath, FileMode.Open)))
            {
                textFromFile = readFromTheFirstFile.ReadString();
                Regex numbers = new Regex(@"(\b2)(\^)(\d*\b)");
                MatchCollection matches = numbers.Matches(textFromFile);
                foreach (Match match in matches)
                {
                    secondNumbers += match.Value + "\n";
                }
                Console.WriteLine("[SUCCESS] Все числа найдены");
                readFromTheFirstFile.Close();
            }

            using (BinaryWriter writeToTheSecondFile = new BinaryWriter(new FileStream(secondFilePath, FileMode.Create)))
            {
                writeToTheSecondFile.Write(secondNumbers);
                Console.WriteLine("[SUCCESS] Числа записаны в файл 'lab2.dat'\n");
                writeToTheSecondFile.Close();
            }

            if (Directory.Exists(directory))
            {
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(directory);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(directory);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
