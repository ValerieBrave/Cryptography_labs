using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Knapsack
    {
        private BigInteger[] d = GFG.GenerateSequence(8), e = new BigInteger[8];
        private BigInteger n, a;

        public Knapsack()
        {
            GeneratePrivateKey();
            Console.WriteLine();
            GeneratePublicKey();
            Console.WriteLine();
        }

        private BigInteger GenerateA(BigInteger n)
        {
            Random random = new Random();
            BigInteger a = random.Next(1, (int)n), nod = GCD.GetNOD(a, n);
            while (nod != 1)
            {
                a = random.Next(1, (int)n);
                nod = GCD.GetNOD(a, n);
            }
            return a;
        }

        private void GeneratePrivateKey()
        {
            Console.WriteLine((new string('-', 35)) + "PRIVATE KEY" + (new string('-', 34)));
            Random random = new Random();
            BigInteger sum = d.Aggregate(BigInteger.Add);
            Console.Write($"d (lenght = {d.Length}, sum = {sum}): ");
            for (int i = 0; i < d.Length; i++)
            {
                Console.Write(d[i] + " ");
            }
            Console.WriteLine();
            n = random.Next((int)sum, (int)BigInteger.Multiply(sum, 2));
            a = GenerateA(n);
            Console.WriteLine($"n = {n}, a = {a}");
            Console.WriteLine(new string('-', 80));
        }

        private void GeneratePublicKey()
        {
            Console.WriteLine((new string('-', 35)) + "PUBLIC KEY" + (new string('-', 35)));
            Console.Write($"e (lenght = {e.Length}): ");
            for (int i = 0; i < d.Length; i++)
            {
                e[i] = (d[i] * a) % n;
                Console.Write(e[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 80));
        }

        public BigInteger[] Encrypt(string text)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            BigInteger[] encryptedText = new BigInteger[bytes.Length];
            for (int i = 0; i < bytes.Length; i++)
            {
                StringBuilder strByte = new StringBuilder(Convert.ToString(bytes[i], 2));
                if (strByte.Length < 8)
                    strByte.Insert(0, "0", 8 - strByte.Length);
                for (int j = 0; j < strByte.Length; j++)
                {
                    encryptedText[i] += BigInteger.Multiply((int)char.GetNumericValue(strByte[j]), e[j]);
                }
            }
            return encryptedText;
        }

        public string Decrypt(BigInteger[] encryptedText)
        {
            byte[] decryptedText = new byte[encryptedText.Length];
            for (int i = 0; i < encryptedText.Length; i++)
            {
                StringBuilder symbol = new StringBuilder("00000000");
                BigInteger s = BigInteger.ModPow(BigInteger.Multiply(encryptedText[i], GCD.ModInverse(a, n)), 1, n);
                BigInteger diff = s;
                while (diff > 0)
                {
                    BigInteger[] lessThenDiff = d.Where(el => el <= diff).ToArray();
                    if (lessThenDiff.Length > 0)
                    {
                        BigInteger maxItem = lessThenDiff.Max();
                        diff -= maxItem;
                        if (diff >= 0)
                        {
                            symbol.Remove(Array.IndexOf(d, maxItem), 1);
                            symbol.Insert(Array.IndexOf(d, maxItem), "1");
                        }
                    }
                    else break;
                }
                decryptedText[i] = Convert.ToByte(symbol.ToString(), 2);
            }
            return Encoding.ASCII.GetString(decryptedText);
        }
    }
}
