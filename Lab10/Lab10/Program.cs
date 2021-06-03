using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            RSA rsa = new RSA();
            string text = "Smelova Valeria Vladimirovna";
            Console.WriteLine($"Text: {text}");
            var stopwatch = Stopwatch.StartNew();
            BigInteger[] encryptedTextRSA = rsa.Encrypt(text);
            stopwatch.Stop();
            Console.WriteLine($"Encrypted text: {encryptedTextRSA.Select(el => el.ToString()).Aggregate((prev, current) => prev + " " + current)}");
            Console.WriteLine($"Encryption time: {stopwatch.ElapsedTicks} ticks");
            stopwatch.Restart();
            Console.WriteLine($"Decrypted text: {rsa.Decrypt(encryptedTextRSA)}");
            stopwatch.Stop();
            Console.WriteLine($"Decryption time: {stopwatch.ElapsedTicks} ticks");

            Console.WriteLine();

            ElGamal elGamal = new ElGamal();
            Console.WriteLine($"Text: {text}");
            stopwatch.Restart();
            BigInteger[,] encryptedTextElGamal = elGamal.Encrypt(text);
            stopwatch.Stop();
            Console.WriteLine($"Encrypted text: {string.Join(" ", encryptedTextElGamal.Cast<BigInteger>())}");
            stopwatch.Restart();
            Console.WriteLine($"Encryption time: {stopwatch.ElapsedTicks} ticks");
            Console.WriteLine($"Decrypted text: {elGamal.Decrypt(encryptedTextElGamal)}");
            stopwatch.Stop();
            Console.WriteLine($"Decryption time: {stopwatch.ElapsedTicks} ticks");
            Console.ReadKey();
        }
    }
}
