using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Collections;
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace adventofcode2024_1
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("C1:");
            ChallengeOne();
            Console.WriteLine("\nC2:");
            ChallengeTwo();
            Console.WriteLine("\nC3:");
            ChallengeThree();
        }

        static void ChallengeOne()
        {
            List<int> list0 = new List<int>();
            List<int> list1 = new List<int>();
            int total = 0;

            StreamReader sr = new StreamReader("input1.txt");
            while (!sr.EndOfStream)
            {
                string[] data = sr.ReadLine().Split(' ');
                list0.Add(Convert.ToInt32(data[0]));
                list1.Add(Convert.ToInt32(data[3]));
            }
            list0.Sort();
            list1.Sort();

            for (int i = 0; i < list0.Count; i++)
            {
                total += Math.Abs(list0[i] - list1[i]);
            }
            Console.WriteLine(total);
        }

        static void ChallengeTwo()
        {
            StreamReader sr = new StreamReader("input2.txt");
            string[] originalData = new string[] { "test" };
            int totalSafe = 0;

            while (!sr.EndOfStream)
            {
                bool safe = true;
                int[] data = Array.ConvertAll(sr.ReadLine().Split(' '), delegate(string s) { return int.Parse(s); });
                int[] diff = new int[data.Length - 1];

                for (int i = 0; i < data.Length-1; i++)
                {
                    diff[i] = data[i] - data[i + 1];
                }

                for (int i = 0; i < diff.Length-1; i++)
                {
                    if (Math.Abs(diff[0]) > 3) { safe = false; }
                    if (Math.Sign(diff[i]) != Math.Sign(diff[i + 1]) || Math.Abs(diff[i+1]) > 3)
                    {
                        safe = false;
                    }
                }
                if (safe == true)
                {
                    totalSafe++;
                }
            }
            Console.WriteLine(totalSafe);
        }

        static void ChallengeThree()
        {
            StreamReader sr = new StreamReader("input3.txt");
            Regex rg1 = new Regex(@"mul\((\d|\d\d|\d\d\d),(\d|\d\d|\d\d\d)\)");
            Regex rg2 = new Regex(@"\d+");
            int total = 0;

            while (!sr.EndOfStream)
            {
                string data = sr.ReadLine();
                var instructions = rg1.Matches(data);
                for (int i = 0; i < instructions.Count; i++)
                {
                    var operands = rg2.Matches(Convert.ToString(instructions[i]));
                    total += Convert.ToInt32(Convert.ToString(operands[0])) * Convert.ToInt32(Convert.ToString(operands[1]));
                }
            }
            Console.WriteLine(total);
        }
    }
}
