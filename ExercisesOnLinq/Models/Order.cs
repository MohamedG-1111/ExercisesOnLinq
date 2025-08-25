using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesOnLinq.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public override string ToString()
        {
            return $"OrderId: {Id}, CustomerId: {CustomerId}, Date: {OrderDate:yyyy-MM-dd}, TotalAmount: {TotalAmount:C}";
        }
    }
}
