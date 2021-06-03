using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    //Linear Congruent Generator3
    public class LCG
    {
        private const long n = 7875;
        private const long a = 421;
        private const long c = 1663;
        private long _last;

        public LCG()
        {
            _last = DateTime.Now.Ticks % n;
        }

        public LCG(long seed)
        {
            _last = seed;
        }

        public long Next()
        {
            _last = ((a * _last) + c) % n;
            return _last;
        }

        public long Next(long maxValue)
        {
            return Next() % maxValue;
        }
    }
}
