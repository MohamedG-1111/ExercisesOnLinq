using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesOnLinq.Models
{
    internal class ProductComparer : IComparer<Product>
    {
        public int Compare(Product? x, Product? y)
        {

            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return x.Price.CompareTo(y.Price);
        }
    }
}
