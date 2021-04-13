using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Nod
    {
        public static int GetNOD2(int val1, int val2)
        {
            val1 = Math.Abs(val1);
            val2 = Math.Abs(val2);
            if (val2 == 0)  //последний ненулевой остаток вернется
                return val1;
            else
                return GetNOD2(val2, val1 % val2);
        }
    }
}
