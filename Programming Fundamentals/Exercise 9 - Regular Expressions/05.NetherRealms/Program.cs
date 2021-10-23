using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Deamon> deamons = new List<Deamon>();

            string[] names = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string pattern1 = @"[0-9\+\-\*\/\.]";
            Regex regex1 = new Regex(pattern1);

            string pattern2 = @"-?[0-9]+\.?[0-9]*";
            Regex regex2 = new Regex(pattern2);

            string pattern3 = @"[\*]|[\/]";
            Regex regex3 = new Regex(pattern3);

            foreach (var item in names)
            {
                Match match = regex1.Match(item);
                string pointsStr = regex1.Replace(item, "");

                int sum = 0;

                for (int i = 0; i < pointsStr.Length; i++)
                {
                    sum = sum + pointsStr[i];
                }

                MatchCollection matches = regex2.Matches(item);
                double damage = 0;
                foreach (Match mat in matches)
                {
                    damage = damage + double.Parse(mat.Value);
                }

                var multiplyOrDivide = regex3.Matches(item);
                foreach (Match symbol in multiplyOrDivide)
                {
                    if(symbol.ToString() == "*")
                    {
                        damage = damage * 2;
                    }
                    else
                    {
                        damage = damage / 2;
                    }
                }

                Deamon deamon = new Deamon(item, sum, damage);
                deamons.Add(deamon);
            }
            foreach (var deamon in deamons.OrderBy(x=>x.Name))
            {
                Console.WriteLine(deamon);
            }
        }
    }
    class Deamon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }

        public Deamon(string name, int health, double damage)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
        }

        public override string ToString()
        {
            return $"{Name} - {Health} health, {Damage:f2} damage";
        }
    }
}
