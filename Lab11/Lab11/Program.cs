using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string source = Console.ReadLine();

            using (MD5 md5Hash = MD5.Create())
            {
                var stopwatch = Stopwatch.StartNew();
                string hash = GetMd5Hash(md5Hash, source);
                stopwatch.Stop();
                Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".");
                Console.WriteLine($"Calculation time: {stopwatch.ElapsedTicks} ticks");
                Console.WriteLine("Verifying the hash...");
                if (VerifyMd5Hash(md5Hash, source, hash))
                {
                    Console.WriteLine("The hashes are the same.");
                }
                else
                {
                    Console.WriteLine("The hashes are not same.");
                }

                Console.ReadKey();
            }
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                //форматирует строку как два строчных шестнадцатеричных символа в верхнем регистре
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
