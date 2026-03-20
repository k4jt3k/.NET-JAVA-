using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("lab1_testy")]
[assembly:InternalsVisibleTo("lab1_win"), InternalsVisibleTo("GUI")]

namespace lab1
{
    internal class Problem
    {

        public int N;

        public List<Item> Items = new List<Item>();

        public Problem(int n, int seed)
        {

            N = n;
            Random random = new Random(seed);

            for (int i = 0; i < n; i++)
            {
                int v = random.Next(1, 11);
                int w = random.Next(1, 11);
                Items.Add(new Item(i, v, w));
            }
        }

        public Result Solve(int capacity)
        {
            Result result = new Result();

            var posortowane = Items.OrderByDescending(p => (double)p.Value / p.Weight).ToList();

            foreach (var p in posortowane)
            {
                if (result.sumweight + p.Weight <= capacity)
                {
                    result.Items.Add(p.Id);
                    result.sumweight += p.Weight;
                    result.sumvalue += p.Value;
                }


            }
            return result;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Items);
        }

    }


}
