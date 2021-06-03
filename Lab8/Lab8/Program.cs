using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("ПСП с помощью линейного конгруэнтного генератора: ");
            var lcg = new LCG();
            for (int i = 0; i < 10; i++)
            {
                var rnd = lcg.Next(20);
                Console.Write("{0}, ", rnd);
            }

           
            Console.WriteLine();

            Console.WriteLine("\nRC4\nКлюч: 13, 19, 90, 92, 240;\nСообщение: Valeria Smelova");
            int[] key = { 13, 19, 90, 92, 240 };
            var stopwatch = Stopwatch.StartNew();
            byte[] encrypted = RC4.Encrypt(Encoding.Default.GetBytes("Valeria Smelova"), key.SelectMany(BitConverter.GetBytes).ToArray());
            stopwatch.Stop();
            Console.WriteLine($"Зашифрованное сообщение: {Encoding.Default.GetString(encrypted)}");
            Console.WriteLine($"Время зашифрования: {stopwatch.ElapsedTicks} ticks");

            stopwatch.Restart();
            byte[] decrypted = RC4.Decrypt(encrypted, key.SelectMany(BitConverter.GetBytes).ToArray());
            stopwatch.Stop();
            Console.WriteLine($"Расшифрованное сообщение: {Encoding.Default.GetString(decrypted)}");
            Console.WriteLine($"Время расшифрования: {stopwatch.ElapsedTicks} ticks");

            Console.ReadKey();
        }
    }
}
