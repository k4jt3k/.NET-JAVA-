using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Item
    {
        public int Id;
        public int Value;
        public int Weight;


        public Item(int id, int value, int weight)
        {
            Id = id;
            Value = value;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"Id: {Id} V: {Value} W: {Weight}";
        }
    }

}
