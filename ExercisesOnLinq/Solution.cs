



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