using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            string file_latvian = @"D:\Crypto\Lab2\lv_utf8.txt";
            string file_tajik = @"D:\Crypto\Lab2\tj_utf8.txt";
            string text_latvian = File.ReadAllText(file_latvian);
            string text_tajik = File.ReadAllText(file_tajik);
            Console.WriteLine("Latvian alphabet entropy = "+Entropy.ShannonEntropy(text_latvian));
            Console.WriteLine("Tajik alphabet entropy = " + Entropy.ShannonEntropy(text_tajik));

            //2
            StringBuilder builder_lv = new StringBuilder();
            StringBuilder builder_tj = new StringBuilder();
            foreach(char c in text_latvian) builder_lv.Append(Convert.ToString(c, 2));
            foreach (char c in text_tajik) builder_tj.Append(Convert.ToString(c, 2));
            Console.WriteLine("Latvian alphabet entropy (binary) = " + Entropy.ShannonEntropy(builder_lv.ToString()));
            Console.WriteLine("Tajik alphabet entropy (binary) = " + Entropy.ShannonEntropy(builder_tj.ToString()));
            
            //3
            String myName = "Smelova Valeria Vladimirovna";
            string patternName = @"\s+";
            Regex regexName = new Regex(patternName);
            string resultName = regexName.Replace(myName, "");
            byte[] bytes = Encoding.ASCII.GetBytes(resultName);
            string ASCII = "";
            foreach (var b in bytes) ASCII += b;
            double name_entropy = Entropy.ShannonEntropy(resultName);
            Console.WriteLine($"Amount of information in russian name = {Entropy.AmountOfInformation(resultName, name_entropy)}");
            Console.WriteLine($"Amount of information in ASCII name = {Entropy.AmountOfInformation(ASCII, name_entropy)}");

            //4
            Console.WriteLine("Amount of information with mistake accurancy 0,1 " + Entropy.AmountOfInformationWithMistake(name_entropy, resultName, 0.9));
            Console.WriteLine("Amount of information with mistake accurancy 0,5 " + Entropy.AmountOfInformationWithMistake(name_entropy, resultName, 0.5));
            Console.WriteLine("Amount of information with mistake accurancy 1 " + Entropy.AmountOfInformationWithMistake(name_entropy, resultName, 1));
            
            Console.ReadKey();
        }
    }
}
