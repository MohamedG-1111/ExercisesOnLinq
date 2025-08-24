using System.Security.Cryptography;
using ExercisesOnLinq.Data;
using ExercisesOnLinq.Models;

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

            #region Q3
            /* Group all orders by `CustomerId`, calculate the total `TotalAmount`
             * for each customer, and order the results by total descending.*/
            //var result = Orders.GroupBy(g => g.CustomerId, (key, g) => new
            //{
            //    CustomerId = key,
            //    TotalAmount = g.Sum(g => g.TotalAmount),
            //}).OrderByDescending(res=>res.TotalAmount);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Q4
            /*3. Join `Orders` and `Customers` on `CustomerId`, filter orders with 
             * `TotalAmount > 500`, and project the result to include `CustomerName` and
             * `OrderId`.*/
            //var result = from o in Orders
            //             join c in Customers
            //             on o.CustomerId equals c.Id
            //             where o.TotalAmount > 500
            //             select new
            //             {
            //                 CustomerName = c.FullName,
            //                 OrderID = o.Id

            //             };
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Customer: {item.CustomerName}, Order ID: {item.OrderID}");
            //}
            #endregion

            #region Q5
            /*4. Join `OrderItems`, `Orders`, and `Products` to calculate the total
             * quantity of each product ordered across all orders, ordered by 
             * quantity descending.*/
            //var result = from oi in OrderItem
            //             join p in Products on oi.ProductId equals p.Id
            //             group oi by new { oi.ProductId, p.Name } into g
            //             orderby g.Sum(x => x.Quantity) descending
            //             select new
            //             {
            //                 ProductId = g.Key.ProductId,
            //                 ProductName = g.Key.Name,
            //                 TotalQuantity = g.Sum(x => x.Quantity)
            //             };

            //var result01 = OrderItem.Join(Products, oi => oi.ProductId, p => p.Id,
            //    (oi, p) => new
            //    {
            //        oi.ProductId,
            //        p.Name,
            //        oi.Quantity,
            //    })
            //    .GroupBy(res => new { res.ProductId, res.Name }).
            //Select(g => new
            //{
            //    g.Key.ProductId,
            //    g.Key.Name,
            //    TotalSum = g.Sum(x => x.Quantity)
            //}).OrderByDescending(res => res.TotalSum);

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("\n\n");
            //foreach (var item in result01)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region Q6
            /*Display all customers with the count of orders they have placed,
             * including customers with zero orders.*/
            //var result = from c in Customers
            //             join o in Orders
            //             on c.Id equals o.CustomerId
            //             into gj
            //             select new
            //             {
            //                 CustomerId = c.Id,
            //                 CustomerName = c.FullName,
            //                 CountOfOrders = gj.Count(),
            //             };
            //var result = Customers.GroupJoin(Orders, c => c.Id, o => o.CustomerId,
            //    (c, orders) =>new
            //    {
            //        CustomerId = c.Id,
            //        CustomerName = c.FullName,    
            //        CountOfOrders= orders.Count()
            //    });

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Q7
            /*Find all customers who have placed at least one order above 1000, 
             * and ensure all their orders are above 50.*/
    //        var result = Customers
    //.GroupJoin(
    //    Orders,
    //    c => c.Id,
    //    o => o.CustomerId,
    //    (customer, orders) => new
    //    {
    //        Customer = customer,
    //        Orders = orders
    //    }
    //)
    //.Where(x =>
    //    x.Orders.Any(o => o.TotalAmount > 1000)
    //    &&
    //    x.Orders.All(o => o.TotalAmount > 50)
    //);

    //        var result01 = from c in Customers
    //                     join o in Orders
    //                     on c.Id equals o.CustomerId
    //                      into CustomerOrders
    //                     where CustomerOrders.Any(co => co.TotalAmount > 1000)
    //                     && CustomerOrders.All(co => co.TotalAmount > 50)
    //                     select new
    //                     {
    //                         c = c
    //                     };

    //        foreach (var item in result01)
    //        {
    //            Console.WriteLine(item);
    //        }
    //        Console.WriteLine();
    //        foreach (var item in result)
    //        {
    //            Console.WriteLine(item.Customer);
    //        }
           
            #endregion
        }
    }
}
