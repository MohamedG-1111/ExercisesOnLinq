using System.Collections.Generic;
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

            #region Q8
            ///*List all unique products ordered by all customers, selecting only the product names.*/
            //var result = Customers.Join(Orders, c => c.Id, o => o.CustomerId,
            //    (customer, Order) => new
            //    {
            //        CustomerId = customer.Id,
            //        OrderId = Order.Id
            //    }).Join(OrderItem, res => res.OrderId, oi => oi.OrderId,
            //    (order, orderItems) => new
            //    {
            //        order.CustomerId,
            //        orderItems.ProductId,
            //        order.OrderId,
            //    }).Join(Products, res => res.ProductId, p => p.Id,
            //    (res, Products) => Products.Name).Distinct();
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);

            //}
            //var result = (from c in Customers
            //              join o in Orders
            //              on c.Id equals o.CustomerId
            //              join OI in OrderItem
            //              on o.Id equals OI.OrderId
            //              join P in Products
            //              on OI.ProductId equals P.Id
            //              select P.Name).Distinct();
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);

            //}
            #endregion

            #region Q9
            ////8. Retrieve the top 5 most expensive products in the 
            ///"Accessories" category after skipping the first 2 most 
            ///expensive ones.
            //        var result = Category
            //.Join(Products,
            //    c => c.Id,
            //    p => p.CategoryId,
            //    (c, p) => new { c, p })
            //.Where(res => res.c.Name == "Accessories")
            //.OrderByDescending(res => res.p.Price)
            //.Skip(2)
            //.Take(5);
            //var result = (from p in Products
            //              join c in Category
            //              on p.CategoryId equals c.Id
            //              where c.Name == "Accessories"
            //              orderby p.Price descending
            //              select p)
            //           .Skip(2)
            //           .Take(5);




            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}


            #endregion

            #region Q10
            //9. Retrieve the first order with `TotalAmount > 1000`,
            //the first order for customer 5,
            //and the last order in the repository.
            //var one=Orders.FirstOrDefault(o=>o.TotalAmount>1000);
            //var Two=Orders.FirstOrDefault(o=>o.CustomerId == 5);
            //var three=Orders.LastOrDefault();
            //  var results = new List<Order?> { one, Two, three };

            //  foreach (var item in results)
            //  {
            //      Console.WriteLine($"OrderId: {item?.Id}, CustomerId: {item?.CustomerId}, Total: {item?.TotalAmount}");
            //  }


            #endregion

            #region Q11
            /* Get all products from categories 1 and 2, find products that appear 
             * in both categories, and remove products that belong only to 
             * category 2.*/
            //var Pc1 = Products.Where(p => p.CategoryId == 1);
            //var Pc2 = Products.Where(p => p.CategoryId == 2);
            //var Interect=Pc1.IntersectBy(Pc2.Select(P=>P.Id),Pc1=>Pc1.Id);
            //var Final = Pc1.Except(Pc1.Except(Pc2));
            #endregion

            #region Q12
            /*11. Sort all orders by `CustomerId` ascending, then by `TotalAmount`
             * descending, and reverse the entire list.*/
            //var result01=Orders.OrderBy(c=>c.Id).ThenByDescending(o=>o.TotalAmount).Reverse();
            //foreach (var item in result01)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region Q13
            /*Calculate the total amount spent by all customers on products in category
             * "Office Supplies" and count the total number of orders.*/
            //var result = from c in Category
            //             join p in Products
            //             on c.Id equals p.CategoryId
            //             join oi in OrderItem
            //             on p.Id equals oi.ProductId
            //             where c.Name == "Office Supplies"
            //             select new
            //             {
            //                 oi.OrderId,
            //                 Amount = p.Price * oi.Quantity,

            //             };
            //var TotalAmount = result.Sum(x => x.Amount);
            //var Count = result.Select(x=>x.OrderId).Distinct().Count();
            //Console.WriteLine($"TotalAmount : {TotalAmount} , Count : {Count}");

            //var result = OrderItem.Join(Orders, oi => oi.OrderId, o => o.Id,
            //    (OrderItem, order) => new
            //    {
            //        OrderItem.ProductId,
            //        OrderId = order.Id,
            //        OrderItem.Quantity,
            //    }).Join(Products, res => res.ProductId, p => p.Id,
            //    (res, Product) => new
            //    {
            //        res.Quantity,
            //        res.OrderId,
            //        Product.CategoryId,
            //        Product.Price,

            //    }).Join(Category, res => res.CategoryId, c => c.Id,
            //    (res, cate) => new
            //    {
            //        res.OrderId,
            //        res.Price,
            //        res.Quantity,
            //        cate.Name
            //    }).Where(res => res.Name == "Office Supplies")
            //    .Select(res => new
            //    {
            //        Amount = res.Quantity * res.Price,
            //        OrderID = res.OrderId

            //    });
            //var TotalAmount=result.Sum(x => x.Amount);
            //var Count=result.Select(res=>res.OrderID).Distinct().Count();
            //Console.WriteLine($"TotalAmount : {TotalAmount} , Count : {Count}");






            #endregion

            #region Q14
            /*Group orders by the month of `OrderDate`, calculate sum, average, min, 
             * and max of `TotalAmount` for each month, and return a list of anonymous objects.*/
            //var result = Orders.GroupBy(o => o.OrderDate.Month, (key, g) =>new
            //{
            //    MonthName = new DateTime(1, key, 1).ToString("MMMM"),
            //    TotalAmount =g.Sum(o=>o.TotalAmount),
            //    AverageTotalAmount=g.Average(o=>o.TotalAmount),
            //    MinTotalAmount=g.Min(o=>o.TotalAmount),
            //    MaxTotalAmount=g.Max(o=>o.TotalAmount),
            //});
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Month Name            : {item.MonthName}");
            //    Console.WriteLine($"\t TotalAmount        : {item.TotalAmount}");
            //    Console.WriteLine($"\t AverageTotalAmount : {item.AverageTotalAmount}");
            //    Console.WriteLine($"\t MinTotalAmount     : {item.MinTotalAmount}");
            //    Console.WriteLine($"\t MaxTotalAmount     : {item.MaxTotalAmount}");
            //    Console.WriteLine();
            //}
            #endregion

            #region Q15
            /*Join `Products` and `OrderItems`, filter to show only products with quantity > 1, 
             * then select product name, quantity, and order ID.*/
            //var result = Products.Join(OrderItem, p => p.Id, oi => oi.ProductId,
            //    (p, oi) => new
            //    {
            //        p.Name,
            //        oi.OrderId,
            //        oi.Quantity
            //    }).Where(res => res.Quantity > 1);
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Name : {item.Name} , OrderId : {item.OrderId} , Quantity : {item.Quantity}");
            //}


            #endregion

            #region Q16
            ///*Select all customers and create an anonymous object including `CustomerName`,
            // * number of orders, total amount of orders, and a list of distinct products they bought.*/
            //var result = Customers.GroupJoin(Orders, c => c.Id, o => o.CustomerId,
            //    (Customer, CustOrders) => new
            //    {
            //        Customer.FullName,
            //        NumOfOrder = CustOrders.Count(),
            //        TotalAmount = CustOrders.Sum(o => o.TotalAmount),
            //        CustOrders=CustOrders.Select(c=>c.Id).ToList(),
            //        products = CustOrders
            //            .Join(OrderItem, o => o.Id, oi => oi.OrderId,
            //            (CustOrders, OrderItem) => new
            //            {
            //                OrderItem.ProductId
            //            }).Join(Products, ou => ou.ProductId, p => p.Id,
            //            (ou, p) =>
            //                p.Name
            //            ).Distinct().ToList()
            //    });

            //        var result =
            //from c in Customers
            //join o in Orders on c.Id equals o.CustomerId into CustOrders
            //select new
            //{
            //    CustomerName = c.FullName,
            //    NumOfOrder = CustOrders.Count(),
            //    TotalAmount = CustOrders.Sum(x => x.TotalAmount),
            //    CustOrders = CustOrders.Select(x => x.Id).ToList(),
            //    products =
            //        (from o in CustOrders
            //         join oi in OrderItem on o.Id equals oi.OrderId
            //         join p in Products on oi.ProductId equals p.Id
            //         select p.Name).Distinct().ToList()
            //};


            //foreach (var item in result)
            //{
            //    Console.WriteLine($"CustomerName : {item.FullName} , NumOfOrder : {item.NumOfOrder}" +
            //        $" , TotalAmount : {item.TotalAmount} , Products : {String.Join(',',item.products)}");
            //}


            #endregion

            #region Q17
            /*Find all customers whose total spending is above the average total spending of all customers.*/

            //var avgSpending = Orders.Average(o => o.TotalAmount);
            //var result = Customers.GroupJoin(Orders, c => c.Id, o => o.CustomerId,
            //    (customer, CustOrders) => new
            //    {
            //        customer,
            //        totalAmount = CustOrders.Sum(o => o.TotalAmount)
            //    }).Where(res => res.totalAmount > avgSpending);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.customer.Id +" - "+item.customer.FullName + " - " + item.totalAmount);
            //}
            #endregion

            #region Q18
            //Find customers where all their orders have `TotalAmount` less than 1000,
            //but they have at least one order with `TotalAmount > 200`
            //var result = Customers.GroupJoin(Orders, c => c.Id, o => o.CustomerId,
            //    (cust, Orders) => new
            //    {
            //        cust,
            //        Orders
            //    }).Where(res => res.Orders.Any() && res.Orders.All(o => o.TotalAmount < 1000)
            //    && res.Orders.Any(o => o.TotalAmount > 200));
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.cust);
            //}
            //var res = from c in Customers
            //           join o in Orders
            //           on c.Id equals o.CustomerId
            //           into CustomerOrders
            //           where CustomerOrders.All(o => o.TotalAmount < 1000)
            //           && CustomerOrders.Any(o => o.TotalAmount > 200) 
            //           select c;
            //Console.WriteLine(" ------------------------------------- ");
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region Q19
            /* Sort products by the length of their name ascending, then by price descending
             * using a custom comparer.*/
            //var result = Products.OrderBy(x => x.Name.Length)
            //    .ThenByDescending(x => x, new ProductComparer());
            //var result =Products
            //    .OrderBy(p => p.Name.Length)
            //    .ThenByDescending(p => p.Price);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region Q20
            /* Retrieve orders in a paginated fashion: skip orders until `TotalAmount > 300`,
             * then take orders while `TotalAmount < 1000`.*/
    //     var result = Orders
    //.SkipWhile(o => o.TotalAmount <= 300)
    //.TakeWhile(o => o.TotalAmount < 1000);
    //        foreach (var item in result)
    //        {
    //            Console.WriteLine(item);
    //        }
            #endregion

        }
    }
}
