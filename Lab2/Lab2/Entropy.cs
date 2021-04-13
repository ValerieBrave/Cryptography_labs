using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public static class Entropy
    {
        public static double ShannonEntropy(string text)
        {
            double result = 0.0;    //возвращаем
            int len = text.Length;
            var map = new Dictionary<char, int>();  //список всех букв и количество их появлений
            foreach (char c in text)
            {
                if (!map.ContainsKey(c)) map.Add(c, 1); //впервые встречаем букву
                else map[c] += 1;   // встретили букву еще раз - наращиваем счетчик
            }
            foreach (var item in map)
            {
                var i = (double)item.Value / len;   //частота появления символа
                result -= i * Math.Log(i, 2);
            }
            return result;
        }

        public static double AmountOfInformation(string message, double shannonEntropy)
        {
            return message.Length * shannonEntropy;
        }

        public static double AmountOfInformationWithMistake(double entropy, string message, double q)
        {
            return message.Length * (entropy - (-(1 - q) * Math.Log((1 - q), 2) - q * Math.Log(q, 2)));
        }
    }
}
