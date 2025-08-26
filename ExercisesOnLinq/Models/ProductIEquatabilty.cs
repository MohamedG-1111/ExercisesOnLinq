using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesOnLinq.Models
{
    internal class ProductIEquatabilty : IEqualityComparer<Product>
    {
        public bool Equals(Product? x, Product? y)
        {
             if(ReferenceEquals(x, y)) return true;
             if(x is null || y is null) return false;   
              return x.Name == y.Name && x.Price == y.Price && x.Id==y.Id;    
        }

        public int GetHashCode([DisallowNull] Product obj)
        {
            return HashCode.Combine(obj.Id,obj.Name,obj.Price);
        }
    }
}
