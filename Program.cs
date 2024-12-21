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
using System.Diagnostics;

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
            Console.WriteLine("\nC4:");
            ChallengeFour();
        }

        static void ChallengeOne()
        {
            List<int> list0 = new List<int>();
            List<int> list1 = new List<int>();
            int total = 0;

            StreamReader sr = new StreamReader("D:\\0.College\\Computer Science\\programs\\adventofcode24\\input1.txt");
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
            StreamReader sr = new StreamReader("D:\\0.College\\Computer Science\\programs\\adventofcode24\\input2.txt");
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
            StreamReader sr = new StreamReader("D:\\0.College\\Computer Science\\programs\\adventofcode24\\input3.txt");
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
        static void ChallengeFour()
        {
            StreamReader sr = new StreamReader("D:\\0.College\\Computer Science\\programs\\adventofcode24\\input4.txt");
            List<List<string>> list = new List<List<string>>();
            int total = 0;
            int k = 0;

            while (!sr.EndOfStream)
            {
                list.Add(new List<string>());
                string data = sr.ReadLine();
                for (int i = 0; i < data.Length; i++)
                {
                    list[k].Add(data.Substring(i, 1));
                }
                k++;
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Count; j++)
                {
                    Console.Write(list[i][j]);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Count; j++)
                {
                    try
                    {
                        if (list[i][j] == "X" && list[i + 1][j] == "M" && list[i + 2][j] == "A" && list[i + 3][j] == "S") { total++; }
                    }
                    catch {}
                    try
                    {
                        if (list[i][j] == "X" && list[i - 1][j] == "M" && list[i - 2][j] == "A" && list[i - 3][j] == "S") { total++; }
                    }
                    catch {}
                    try
                    {
                        if (list[i][j] == "X" && list[i][j + 1] == "M" && list[i][j + 2] == "A" && list[i][j + 3] == "S") { total++; }
                    }
                    catch { }
                    try
                    {
                        if (list[i][j] == "X" && list[i][j - 1] == "M" && list[i][j - 2] == "A" && list[i][j - 3] == "S") { total++; }
                    }
                    catch { }
                    try
                    {
                        if (list[i][j] == "X" && list[i + 1][j + 1] == "M" && list[i + 2][j + 2] == "A" && list[i + 3][j + 3] == "S") { total++; }
                    }
                    catch { }
                    try
                    {
                        if (list[i][j] == "X" && list[i + 1][j - 1] == "M" && list[i + 2][j - 2] == "A" && list[i + 3][j - 3] == "S") { total++; }
                    }
                    catch { }
                    try
                    {
                        if (list[i][j] == "X" && list[i - 1][j - 1] == "M" && list[i - 2][j - 2] == "A" && list[i - 3][j - 3] == "S") { total++; }
                    }
                    catch { }
                    try
                    {
                        if (list[i][j] == "X" && list[i - 1][j + 1] == "M" && list[i - 2][j + 2] == "A" && list[i - 3][j + 3] == "S") { total++; }
                    }
                    catch { }
                }
            }
            Console.WriteLine(total);
        }
    }
}
