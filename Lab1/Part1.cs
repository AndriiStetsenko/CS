using System;
using System.IO;
using System.Collections.Generic;
using System.Text;


namespace lab_1_1
{
    class TextInformation
    {
        static string Read(string path) //Метод зчитує текст з файлу
        {
            string text;
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            return text;
        }

        static List<double> SymbolProbability(string path) //Метод підраховує відносну частоту появи символу
        {
            List<char> symbol = new List<char>();
            string text = Read(path);
            List<int> counter = new List<int>();
            foreach (var ch in text)
            {
                if (symbol.Contains(ch))
                    counter[symbol.IndexOf(ch)]++;
                else
                {
                    symbol.Add(ch);
                    counter.Add(1);
                }
            }
            List<double> probability = new List<double>();
            double length = text.Length;
            foreach (var ch in counter)
            {
                probability.Add(ch / length);
            }
            for (int i = 0; i < symbol.Count; i++)
                Console.WriteLine("{0,-5}{1}", symbol[i], probability[i]);
            return probability;
        }

        static double AverageEnthropy(List<double> probability) //Метод підраховує середню ентропію нерівноймовірного алфавіту
        {
            double averageEnthropy = 0;
            for (int i = 0; i < probability.Count; i++)
            {
                if (probability[i] > 0)
                {
                    averageEnthropy += (probability[i] * Math.Log(probability[i], 2));
                }
            }
            return (averageEnthropy * -1);
        }
        static double AmountOfInformationn(double enthropy, string path) //Метод підраховує значення кількості інформації в тексті
        {
            string text = Read(path);
            int allSymbols = text.Length;
            return enthropy * allSymbols;
        }
        static void Out(string path)
        {
            Console.WriteLine("Відносна частота появи символу:");
            List<double> probability = SymbolProbability(path);

            double enthropy = AverageEnthropy(probability);
            Console.WriteLine("\nСередня ентропія нерівноймовірного алфавіту - {0} \n", enthropy);

            double amount = AmountOfInformationn(enthropy, path);
            FileInfo file = new FileInfo(path);
            double size = file.Length;
            Console.WriteLine("Кількість інформації в тексті - {0} байт\nЗагальний розмір файлу - {1} байт\nРозмір файлу в - {2} рази більший за кількість інформації", amount / 8, size, size / (amount / 8));
        }
        static void Main(string[] args)
        {
            string path1file = @"D:\Я\Универ\КИ 6\КС\Lab1\text_1.txt";
            string path2file = @"D:\Я\Универ\КИ 6\КС\Lab1\text_2.txt";
            string path3file = @"D:\Я\Универ\КИ 6\КС\Lab1\text_3.txt";
            Console.WriteLine("Перший файл");
            Out(path1file);
            Console.WriteLine("\nДругий файл");
            Out(path2file);
            Console.WriteLine("\nТретій файл");
            Out(path3file);
        }
    }
}
