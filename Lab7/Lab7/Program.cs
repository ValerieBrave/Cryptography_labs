using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            DES des = new DES();
            Console.Write($"Input text: ");
            string inputText = Console.ReadLine();

            var stopwatch = Stopwatch.StartNew();
            var encryptedText = des.Encrypt(inputText, "SMELOVAV");
            stopwatch.Stop();
            Console.WriteLine($"Encrypted text: {encryptedText}");
            Console.WriteLine($"Execution time: {stopwatch.ElapsedTicks} ticks");

            stopwatch.Restart();
            var decryptedText = des.Decrypt(encryptedText, "SMELOVAV");
            stopwatch.Stop();
            Console.WriteLine($"Decrypted text: {decryptedText}");
            Console.WriteLine($"Execution time: {stopwatch.ElapsedTicks} ticks");

            Console.Write("\nPress any key...");
            Console.ReadKey();
        }
    }
}
