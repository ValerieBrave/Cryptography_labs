using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Simple
    {
        public static bool IsSimple(int N)
        {
            for (int i = 2; i <= (int)(N / 2); i++)
              if (N % i == 0)
                    return false;
            return true;
        }
        public static void FindSimples(int m, int n)
        {
            int count = 0;
            Console.WriteLine($"Простые числа промежутка [{m}, {n}]: ");
            for (int i = m; i <= n; i++)
            {
                if (IsSimple(i))
                {
                    Console.Write(i.ToString() + "\t");
                    count++;
                }
            }
            Console.WriteLine($"\nКоличество в промежутке [{m}, {n}]: {count} обычным подсчетом");
            
        }
    }
}
