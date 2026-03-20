using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab1
{
    internal class Result
    {
        public int sumweight;
        public int sumvalue;
        public List<int> Items = new List<int>();


        public override string ToString()
        {
            string ids = string.Join(" ", Items);
            return $"Items: {ids}\ntotal value: {sumvalue}\ntotal weight: {sumweight}";
        }

    }

  
    }
