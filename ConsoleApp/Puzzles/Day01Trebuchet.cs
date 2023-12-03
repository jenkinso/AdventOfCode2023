using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Puzzles
{
    public static class Day01Trebuchet
    {
        private const string PracticeFile = @"data\Day01Practice.txt";
        private const string PracticeFile2 = @"data\Day01Practice2.txt";
        private const string DataFile = @"data\Day01.txt";

        public static int Part1()
        {
            string[] lines = File.ReadAllLines(DataFile);

            int sum = 0;
            bool foundFirstDigit;
            int first = 0;
            int last = 0;

            foreach (string line in lines) 
            {
                foundFirstDigit = false;

                foreach (char c in line)
                {
                    if (c.IsNumericDigit())
                    {
                        if (!foundFirstDigit)
                        {
                            foundFirstDigit = true;
                            first = c.ToDigit();
                        }
                        
                        last = c.ToDigit();
                    }
                }

                sum += first * 10 + last;
            }

            return sum;
        }

        public static int Part2()
        {
            string[] lines = File.ReadAllLines(DataFile);

            int sum = 0;
            bool foundFirstDigit;
            int first = 0;
            int last = 0;
            string sub;
            int number = 0;

            foreach (string line in lines)
            {
                foundFirstDigit = false;

                for (int c = 0; c < line.Length; c++)
                {
                    sub = line.Substring(c);

                    if (sub.StartsWithNumberString(out number))
                    {
                        if (!foundFirstDigit)
                        {
                            foundFirstDigit = true;
                            first = number;
                        }

                        last = number;
                    }

                    if (line[c].IsNumericDigit())
                    {
                        if (!foundFirstDigit)
                        {
                            foundFirstDigit = true;
                            first = line[c].ToDigit();
                        }

                        last = line[c].ToDigit();
                    }
                }

                sum += first * 10 + last;
            }

            return sum;
        }

        public static int Part2Attempt2()
        {
            string[] lines = File.ReadAllLines(DataFile);

            int sum = 0;
            int number = 0;
            Stack<int> stack = new();
            Queue<int> queue = new();            

            foreach (string line in lines)
            {
                for (int c = 0; c < line.Length; c++)
                {
                    if (line[c].IsNumericDigitOut(out number) || line.Substring(c).StartsWithNumberString(out number))
                    {
                        queue.Enqueue(number);  // dequeue for first
                        stack.Push(number);     // pop for last
                    }
                }

                sum += queue.Dequeue() * 10 + stack.Pop();
                queue.Clear();
            }

            return sum;
        }

        public static int Part2Attempt3()
        {
            string[] lines = File.ReadAllLines(DataFile);

            int sum = 0;
            int number = 0;
            List<int> list = new();

            foreach (string line in lines)
            {
                for (int c = 0; c < line.Length; c++)
                {
                    if (line[c].IsNumericDigitOut(out number) || line.Substring(c).StartsWithNumberString(out number))
                    {
                        list.Add(number);
                    }
                }

                sum += list[0] * 10 + list.Last();
                list.Clear();
            }

            return sum;
        }

        public static bool IsNumericDigit(this char c) => (int)(c) >= 48 && (int)(c) <= 57;

        public static int ToDigit(this char c) => (int)(c) - 48;

        public static bool StartsWithNumberString(this string s, out int number)
        {
            string[] numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            number = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (s.StartsWith(numbers[i]))
                {
                    number = i + 1;
                    return true;
                }
            }

            return false;
        }

        public static bool IsNumericDigitOut(this char c, out int number)
        {
            number = 0;
            
            if ((int)(c) >= 48 && (int)(c) <= 57)
            {
                number = (int)(c) - 48;
                return true;
            }

            return false;
        }
    }
}
