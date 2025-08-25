
//14. Join `Products` and `OrderItems`, filter to show only products with quantity > 1, then select product name, quantity, and order ID.

//```csharp
//var result = from oi in OrderItemRepository.OrderItems
//             join p in ProductRepository.Products on oi.ProductId equals p.Id
//             where oi.Quantity > 1
//             select new { p.Name, oi.Quantity, oi.OrderId };
//```

//15. Select all customers and create an anonymous object including `CustomerName`, number of orders, total amount of orders, and a list of distinct products they bought.

//```csharp
//var result = CustomerRepository.Customers.Select(c => new {
//    c.FullName,
//    OrderCount = OrderRepository.Orders.Count(o => o.CustomerId == c.Id),
//    TotalAmount = OrderRepository.Orders.Where(o => o.CustomerId == c.Id).Sum(o => o.TotalAmount),
//    Products = OrderItemRepository.OrderItems
//        .Where(oi => OrderRepository.Orders.Any(o => o.Id == oi.OrderId && o.CustomerId == c.Id))
//        .Join(ProductRepository.Products, oi => oi.ProductId, p => p.Id, (oi, p) => p.Name)
//        .Distinct()
//        .ToList()
//});
//```

//16. Find all customers whose total spending is above the average total spending of all customers.

//```csharp
//var avgSpending = CustomerRepository.Customers
//    .Select(c => OrderRepository.Orders.Where(o => o.CustomerId == c.Id).Sum(o => o.TotalAmount))
//    .Average();
//var result = CustomerRepository.Customers
//    .Where(c => OrderRepository.Orders.Where(o => o.CustomerId == c.Id).Sum(o => o.TotalAmount) > avgSpending);
//```

//17. Find customers where all their orders have `TotalAmount` less than 1000, but they have at least one order with `TotalAmount > 200`.

//```csharp
//var result = CustomerRepository.Customers
//    .Where(c => OrderRepository.Orders.Where(o => o.CustomerId == c.Id).All(o => o.TotalAmount < 1000)
//                && OrderRepository.Orders.Where(o => o.CustomerId == c.Id).Any(o => o.TotalAmount > 200));
//```

//18. Sort products by the length of their name ascending, then by price descending using a custom comparer.

//```csharp
//var result = ProductRepository.Products
//    .OrderBy(p => p.Name.Length)
//    .ThenByDescending(p => p.Price);
//```

//19. Retrieve orders in a paginated fashion: skip orders until `TotalAmount > 300`, then take orders while `TotalAmount < 1000`.

//```csharp
//var result = OrderRepository.Orders
//    .SkipWhile(o => o.TotalAmount <= 300)
//    .TakeWhile(o => o.TotalAmount < 1000);
//```

//20. For each customer, find the top 3 products they bought most by quantity. Return `CustomerName`, `ProductName`, and `TotalQuantity`.

//```csharp
//var result = CustomerRepository.Customers.Select(c => new {
//    c.FullName,
//    TopProducts = OrderItemRepository.OrderItems
//        .Where(oi => OrderRepository.Orders.Any(o => o.Id == oi.OrderId && o.CustomerId == c.Id))
//        .GroupBy(oi => oi.ProductId)
//        .Select(g => new {
//            ProductName = ProductRepository.Products.First(p => p.Id == g.Key).Name,
//            TotalQuantity = g.Sum(oi => oi.Quantity)
//        })
//        .OrderByDescending(p => p.TotalQuantity)
//        .Take(3)
//        .ToList()
//});
//```
//21. From the orders, group them by CustomerId and select customers whose all orders have TotalAmount
//> 300.
//var result = orders
// .GroupBy(o => o.CustomerId)
// .Where(g => g.All(o => o.TotalAmount > 300))
// .Select(g => g.Key);

//22. List all products from categories 1 and 2, find products that appear in both categories, and remove
//products that belong only to category 2.
//var cat1 = products.Where(p => p.CategoryId == 1);
//var cat2 = products.Where(p => p.CategoryId == 2);
//var result = cat1.Intersect(cat2).ToList();


//23. Join OrderItems, Orders, and Products to calculate the total quantity of each product ordered across all
//orders, ordered by quantity descending.
//var result = orderItems
// .Join(orders, oi => oi.OrderId, o => o.Id, (oi, o) => new { oi, o })
// .Join(products, x => x.oi.ProductId, p => p.Id, (x, p) => new { p.Name, x.oi.Quantity })
// .GroupBy(x => x.Name)
// .Select(g => new { ProductName = g.Key, TotalQuantity = g.Sum(i => i.Quantity) })
// .OrderByDescending(r => r.TotalQuantity);


//24. Retrieve orders partitioned by TotalAmount: take orders while TotalAmount < 500, then skip orders
//until TotalAmount > 800.
//var result = orders
// .TakeWhile(o => o.TotalAmount < 500)
// .Concat(orders.SkipWhile(o => o.TotalAmount <= 800));


//25. Find all customers whose total spending is above the average total spending of all customers.
//var avgSpending = orders.GroupBy(o => o.CustomerId)
// .Average(g => g.Sum(o => o.TotalAmount));
//var result = orders.GroupBy(o => o.CustomerId)
// .Where(g => g.Sum(o => o.TotalAmount) > avgSpending)
// .Select(g => g.Key);



//26. Find all customers who have placed at least one order above 1000, and ensure all their orders are
//above 50.
//var result = orders
// .GroupBy(o => o.CustomerId)
// .Where(g => g.Any(o => o.TotalAmount > 1000) && g.All(o => o.TotalAmount > 50))
// .Select(g => g.Key);




//27. Group orders by the month of OrderDate, calculate sum, average, min, and max of TotalAmount for
//each month, and return a list of anonymous objects.
//var result = orders
// .GroupBy(o => o.OrderDate.Month)
// .Select(g => new {
// Month = g.Key,
// Sum = g.Sum(o => o.TotalAmount),
// Avg = g.Average(o => o.TotalAmount),
// Min = g.Min(o => o.TotalAmount),
// Max = g.Max(o => o.TotalAmount)
// });




//28. From the products, select names and prices, then convert the list of anonymous objects to an array.
//var result = products
// .Select(p => new { p.Name, p.Price })
// .ToArray();
//29. Select customers whose email ends with "example.com" and check if all of them have at least one
//order above 200.
//bool allHaveOrderAbove200 = customers
// .Where(c => c.Email.EndsWith("example.com"))
// .All(c => orders.Any(o => o.CustomerId == c.Id && o.TotalAmount > 200));





//30. Join Products and OrderItems, filter to show only products with quantity > 1, then select product name,
//quantity, and order ID.
//var result = products
// .Join(orderItems, p => p.Id, oi => oi.ProductId, (p, oi) => new { p.Name, oi.Quantity, oi.Order .Where(x => x.Quantity > 1);



//31. Calculate the total amount spent by all customers on products in category "Office Supplies" and count
//the total number of orders.
//var result = (from oi in orderItems
// join p in products on oi.ProductId equals p.Id
// join o in orders on oi.OrderId equals o.Id
// where p.Category == "Office Supplies"
// group new { oi, o } by 1 into g
// select new {
// TotalAmount = g.Sum(x => x.oi.Quantity * products.First(p => p.Id == x.oi.Product OrderCount = g.Select(x => x.o.Id).Distinct().Count()
// }).FirstOrDefault();





//32. Find customers where all their orders have TotalAmount less than 1000, but they have at least one
//order with TotalAmount > 200.
//var result = orders
// .GroupBy(o => o.CustomerId)
// .Where(g => g.All(o => o.TotalAmount < 1000) && g.Any(o => o.TotalAmount > 200))
// .Select(g => g.Key);





//33. For each customer, find the top 3 products they bought most by quantity.
//var result = orders
// .GroupBy(o => o.CustomerId)
// .SelectMany(g => orderItems
// .Join(products, oi => oi.ProductId, p => p.Id, (oi, p) => new { oi, p })
// .Where(x => orders.First(o => o.Id == x.oi.OrderId).CustomerId == g.Key)
// .GroupBy(x => x.p.Name)
// .Select(pg => new { CustomerId = g.Key, ProductName = pg.Key, TotalQuantity = pg.Sum(i => i .OrderByDescending(pg => pg.TotalQuantity)
// .Take(3));








//34. Get all products from categories 1 and 2, find products that appear in both categories, and remove
//products that belong only to category 2.
//var cat1 = products.Where(p => p.CategoryId == 1);
//var cat2 = products.Where(p => p.CategoryId == 2);
//var result = cat1.Intersect(cat2);



//35. Find all products that exist in both category "Electronics" and "Accessories" using a set operation.
//Select only their names.
//var electronics = products.Where(p => p.Category == "Electronics").Select(p => p.Name);
//var accessories = products.Where(p => p.Category == "Accessories").Select(p => p.Name);
//var result = electronics.Intersect(accessories