using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Variant 11: у2 = х3 – х  + 1 (mod 751): а = –1, b = 1, р = 751, Е751(–1, 1), xmin = 586, xmax = 620\n");

            //task 1.1
            int xmin = 586, xmax = 620, a = -1, b = 1, p = 751;
            for (int x = xmin; x <= xmax; x++)
            {
                Console.WriteLine($"x = {x}, y = {Math.Sqrt((x * x * x - x + b) % p)}");
            }
            Console.WriteLine();

            //task 1.2
            int[] P = { 59, 365 }, Q = { 59, 386 }, R = { 105, 382 };
            Console.WriteLine($"P({P[0]}, {P[1]}), Q({Q[0]}, {Q[1]}), R({R[0]}, {R[1]})");
            int[] kP = EllipticCurves.kP(7, P, a, p);
            int[] lQ = EllipticCurves.kP(7, Q, a, p);
            Console.WriteLine($"kP = 7P = {kP.Select(el => el.ToString()).Aggregate((prev, current) => "R(" + prev + ", " + current + ")")}");
            Console.WriteLine($"P + Q = {EllipticCurves.CalculateSum(P, Q, p).Select(el => el.ToString()).Aggregate((prev, current) => "R(" + prev + ", " + current + ")")}");
            Console.WriteLine($"kP + lQ - R = 7P + 7Q - R = {EllipticCurves.CalculateSum(EllipticCurves.CalculateSum(kP, lQ, p), EllipticCurves.InversePoint(R), p).Select(el => el.ToString()).Aggregate((prev, current) => "R(" + prev + ", " + current + ")")}");
            Console.WriteLine($"P - Q + R = {EllipticCurves.CalculateSum(EllipticCurves.CalculateSum(P, EllipticCurves.InversePoint(Q), p), R, p).Select(el => el.ToString()).Aggregate((prev, current) => "R(" + prev + ", " + current + ")")}");
            Console.WriteLine();

            //task 2
            string text = "криптография";
            Console.WriteLine($"Text: {text}");
            var stopwatch = Stopwatch.StartNew();
            int[,] encryptedText = EllipticCurves.Encrypt(text, new int[] { 0, 1 }, a, p, 19);
            stopwatch.Stop();
            Console.WriteLine($"Encrypted text: {string.Join(" ", encryptedText.Cast<int>())}");
            Console.WriteLine($"Encryption time: {stopwatch.ElapsedTicks} ticks");
            stopwatch.Restart();
            Console.WriteLine($"Decrypted text: {EllipticCurves.Decrypt(encryptedText, a, p, 19)}");
            stopwatch.Stop();
            Console.WriteLine($"Decryption time: {stopwatch.ElapsedTicks} ticks");
            Console.WriteLine();

            ////task 3
            stopwatch.Restart();
            int[] digitalSign = EllipticCurves.CreateDigitalSign(new int[] { 416, 55 }, 13, 12, a, p);
            stopwatch.Stop();
            Console.WriteLine($"Digital sign: {digitalSign.Select(el => el.ToString()).Aggregate((prev, current) => prev + " " + current)}");
            Console.WriteLine($"Creating digital sign time: {stopwatch.ElapsedTicks} ticks");
            stopwatch.Restart();
            Console.WriteLine($"Result of checking digital sign: {EllipticCurves.VerifyDigitalSign(digitalSign, new int[] { 416, 55 }, 13, 12, a, p)}");
            stopwatch.Stop();
            Console.WriteLine($"Checking digital sign time: {stopwatch.ElapsedTicks} ticks");

            Console.ReadKey();
        }
    }
}
