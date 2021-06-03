using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Knapsack knapsack = new Knapsack();
            string text = "Smelova Valeria Vladimirovna";
            Console.WriteLine($"Text: {text}");
            Console.Write("Encrypted: ");
            var stopwatch = Stopwatch.StartNew();
            BigInteger[] encryptedText = knapsack.Encrypt(text);
            stopwatch.Stop();
            Console.WriteLine($"Encrypted text: {encryptedText.Select(el => el.ToString()).Aggregate((prev, current) => prev + " " + current)}");
            Console.WriteLine($"Encryption time: {stopwatch.ElapsedTicks} ticks");

            stopwatch.Restart();
            Console.WriteLine($"Decrypted: {knapsack.Decrypt(encryptedText)}");
            stopwatch.Stop();
            Console.WriteLine($"Decryption time: {stopwatch.ElapsedTicks} ticks");

            Console.ReadKey();
        }
    }
}
