using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> stones = new List<int>(new int[] { 1, 1, 1, 1, 2, 2, 2, 2, 2, 4 });
            Dictionary<int, int> fusion = Magic(stones);

            foreach (var item in fusion)
            {
                Console.Write(item.Key);
                Console.Write("=======>");
                Console.WriteLine(item.Value);
            }




            Console.ReadKey();
        }

        public static Dictionary<int, int> Magic(List<int> stones)
        {
            var fusion = stones.GroupBy(e => e).ToDictionary(e => e.Key, e => e.ToList().Count);
            var touched = true;

            while (touched)
            {
                touched = false;
                var list = new List<KeyValuePair<int, int>>();
                foreach (var item in fusion)
                {
                    int next = item.Value / 2;

                    if (item.Value > 1)
                        touched = true;

                    fusion[item.Key] = item.Value % 2;

                    if (next > 0)
                        list.Add(new KeyValuePair<int, int>(item.Key + 1, next));
                }

                foreach (var addfusion in list)
                {
                    Console.WriteLine(addfusion.Key);
                    if (fusion.ContainsKey(addfusion.Key))
                    {
                        fusion[addfusion.Key] += addfusion.Value;
                    }
                    else
                    {
                        fusion.Add(addfusion.Key, addfusion.Value);
                    }
                }
                //----

            }

            return fusion;
        }
    }
}
