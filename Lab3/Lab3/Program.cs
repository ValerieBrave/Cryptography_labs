using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("НОД 555 и 591 = "+Nod.GetNOD2(555, 591).ToString());
            Simple.FindSimples(555, 591);
            Console.ReadLine();
        }
    }
}
