using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Puzzles
{
    internal class Day02CubeConundrum
    {
        private const string PracticeFile = @"data\Day02Practice.txt";
        private const string DataFile = @"./data/Day02.txt";

        public static int Part1()
        {
            string[] lines = File.ReadAllLines(DataFile);

            Dictionary<char, int> map = new();
            map.Add('r', 0);
            map.Add('g', 0);
            map.Add('b', 0);

            int sum = 0;

            foreach (string line in lines) 
            {
                map['r'] = 0; map['g'] = 0; map['b'] = 0;

                int gameId = Convert.ToInt32(line.Split(':')[0].Split(' ')[1]);

                string[] items = line.Split(':')[1].Replace(';', ',').Split(',');

                foreach (var item in items)
                {
                    string[] parts = item.Trim().Split(' ');
                    int quantity = Convert.ToInt32(parts[0]);
                    map[parts[1][0]] = map[parts[1][0]] > quantity ? map[parts[1][0]] : quantity;
                }

                if (map['r'] <= 12 && map['g'] <= 13 && map['b'] <= 14)
                    sum += gameId;
            }

            return sum;
        }

        public static int Part2()
        {
            string[] lines = File.ReadAllLines(DataFile);

            Dictionary<char, int> map = new();
            map.Add('r', 0);
            map.Add('g', 0);
            map.Add('b', 0);

            int sum = 0;

            foreach (string line in lines)
            {
                map['r'] = 0; map['g'] = 0; map['b'] = 0;

                int gameId = Convert.ToInt32(line.Split(':')[0].Split(' ')[1]);

                string[] items = line.Split(':')[1].Replace(';', ',').Split(',');

                foreach (var item in items)
                {
                    string[] parts = item.Trim().Split(' ');
                    int quantity = Convert.ToInt32(parts[0]);
                    map[parts[1][0]] = map[parts[1][0]] > quantity ? map[parts[1][0]] : quantity;
                }

                sum += map['r'] * map['g'] * map['b'];
            }

            return sum;
        }
    }
}
