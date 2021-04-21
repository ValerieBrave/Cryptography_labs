using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static string ALPHABETH = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        static StringBuilder BETTA_ROTOR = new StringBuilder("LEYJVCNIXWPBQMDRTAKZGFUHOS");
        static StringBuilder ROTOR_VIII = new  StringBuilder("FKQHTLXOCBJSPDZRAMEWNIUYGV");
        static StringBuilder ROTOR_I = new     StringBuilder("EKMFLGDQVZNTOWYHXUSPAIBRCJ");

        static string REFLECTOR_B_DUNN = "AE-BN-CK-DQ-FU-GY-HW-IJ-LO-MP-RX-SZ-TV";

        static void SetupRoters(string startPosition)
        {
            char[] startPosArr = startPosition.ToCharArray();
            ChangeRotorPosition(BETTA_ROTOR, BETTA_ROTOR.Length - BETTA_ROTOR.ToString().IndexOf(startPosArr[0]));
            ChangeRotorPosition(ROTOR_VIII, ROTOR_VIII.Length - ROTOR_VIII.ToString().IndexOf(startPosArr[1]));
            ChangeRotorPosition(ROTOR_I, ROTOR_I.Length - ROTOR_I.ToString().IndexOf(startPosArr[2]));

            Console.WriteLine($"\nBETTA_ROTOR: {BETTA_ROTOR}");
            Console.WriteLine($"ROTOR_VIII: {ROTOR_VIII}");
            Console.WriteLine($"ROTOR_I: {ROTOR_I}");
            Console.WriteLine($"REFLECTOR_B_DUNN: {REFLECTOR_B_DUNN}\n");
        }

        static void ChangeRotorPosition(StringBuilder rotor, int step)
        {
            rotor.Insert(0, rotor.ToString().Substring(rotor.Length - step, step));
            rotor.Remove(rotor.Length - step, step);
        }

        static char PressKey(char inputLetter)
        {
            char afterRotor_I = ROTOR_I[ALPHABETH.IndexOf(inputLetter)];
            char afterRotor_VIII = ROTOR_VIII[ALPHABETH.IndexOf(afterRotor_I)];
            char afterBettaRotor = BETTA_ROTOR[ALPHABETH.IndexOf(afterRotor_VIII)];

            char afterReflector_B_DUNN;
            int indexInReflector = REFLECTOR_B_DUNN.IndexOf(afterBettaRotor);
            if (indexInReflector == 0 || REFLECTOR_B_DUNN[indexInReflector - 1] == '-')
            {
                afterReflector_B_DUNN = REFLECTOR_B_DUNN[indexInReflector + 1];
            }
            else
            {
                afterReflector_B_DUNN = REFLECTOR_B_DUNN[indexInReflector - 1];
            }

            char afterReverseBettaRotor = BETTA_ROTOR[ALPHABETH.IndexOf(afterReflector_B_DUNN)];
            char afterReverseRotor_VIII = ROTOR_VIII[ALPHABETH.IndexOf(afterReverseBettaRotor)];
            char afterReverseRotor_I = ROTOR_I[ALPHABETH.IndexOf(afterReverseRotor_VIII)];

            ChangeRotorPosition(BETTA_ROTOR, 3);
            ChangeRotorPosition(ROTOR_VIII, 1);
            ChangeRotorPosition(ROTOR_I, 3);

            return afterReverseRotor_I;
        }

        static void CalculateFrequency(string text, string fileName)
        {
            var map = new Dictionary<char, int>();
            foreach (char c in text)
            {
                if (!map.ContainsKey(c))
                {
                    map.Add(c, 1);
                }
                else
                {
                    map[c] += 1;
                }
            }

            int len = text.Length;
            var frequency_map = new SortedDictionary<char, double>();
            foreach (var item in map)
            {
                var frequency = (double)item.Value / len;
                frequency_map.Add(item.Key, frequency);
            }

            using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.Default))
            {
                foreach (var item in frequency_map)
                {
                    sw.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Start position: ");
                string startPosition = Console.ReadLine().ToUpper();
                SetupRoters(startPosition);
                Console.Write("Input text: ");
                string inputText = Console.ReadLine().ToUpper();
                StringBuilder outputText = new StringBuilder();
                foreach (var letter in inputText)
                {
                    outputText.Append(PressKey(letter));
                }
                Console.WriteLine("Output text: " + outputText + "\n");

                CalculateFrequency(inputText, "InFrequency.txt");
                CalculateFrequency(outputText.ToString(), "OutFrequency.txt");
            }
        }
    }
}
