using ExercisesOnLinq.Data;

namespace ExercisesOnLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Customers= Repository.LoadCustomers();
            var Products= Repository.LoadProducts();
            var Category= Repository.LoadCategories();
            var Orders= Repository.LoadOrders();
            var OrderItem=Repository.LoadOrderItems();
            var Payments= Repository.LoadPayments();
            var Shipment=Repository.LoadShipments();

            #region Q1
            //1. From the orders, find the first order where the
            //`TotalAmount` is above the average total amount of all orders,
            //var result=Orders.FirstOrDefault(o=>o.TotalAmount > Orders.Average(o=>o.TotalAmount));
            //Repository.PrintList([result]);

            #endregion

            #region Q2
            /*Retrieve all products in category "Electronics" with a price greater than 500,
             * ordered by price descending, selecting only the product name and price.*/
            //var result = Products.Join(Category,p=>p.CategoryId,c=>c.Id,
            //    (p, c) => new
            //    {
            //        Product = p,
            //        Category = c,

            //    }).Where(res => res.Product.Price > 500 && res.Category.Name == "Electronics")
            //    .OrderByDescending(res => res.Product.Price)
            //    .Select(res => new { res.Product.Name, res.Product.Price });
            // foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
        }
    }
}
