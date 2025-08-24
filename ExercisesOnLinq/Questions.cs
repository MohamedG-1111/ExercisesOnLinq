//LINQ Questions (Intermediate → Advanced)

//1. From the orders, find the first order where the `TotalAmount` is above the average total amount of all orders, and convert the result to a list.
//2. Select all customers and create an anonymous object including `CustomerName`, number of orders, total amount of orders, and a list of distinct products they bought.
//3. Find products whose price is either below 100 or above 1000 and project them into a list of anonymous objects containing `Name` and `Price`.
//4. Retrieve the first order with `TotalAmount > 1000`, the first order for customer 5, and the last order in the repository.
//5. Retrieve all distinct customer IDs from orders, then get customers with those IDs and sort them by `FullName`.
//6. Sort products by the length of their name ascending, then by price descending using a custom comparer.
//7. Combine two sets of product IDs from different categories and return the distinct IDs in ascending order.
//8. Group all orders by `CustomerId`, calculate the total `TotalAmount` for each customer, and order the results by total descending.
//9. Check if any customer has placed no orders, and if all orders placed by customer 3 have a total amount greater than 50.
//10. Retrieve orders in a paginated fashion: skip orders until `TotalAmount > 300`, then take orders while `TotalAmount < 1000`.
//11. Join `Orders` and `Customers` on `CustomerId`, filter orders with `TotalAmount > 500`, and project the result to include `CustomerName` and `OrderId`.
//12. Retrieve the top 5 most expensive products in the "Accessories" category after skipping the first 2 most expensive ones.
//13. From the products list, skip products with price less than 100, take the next 5 products, and convert the result to a dictionary with `ProductId` as key and `Name` as value.
//14. Merge two lists of products (e.g., category 1 and category 3), remove duplicates, and convert the result to a dictionary with `Id` as key.
//15. Find all unique products ordered by all customers, selecting only the product names.
//16. Retrieve all products in category "Electronics" with a price greater than 500, ordered by price descending, selecting only the product name and price.
//17. Display all customers with the count of orders they have placed, including customers with zero orders.
//18. Partition all orders by their `OrderDate` month: take the first 3 months with the highest total orders and skip the remaining months.
//19. For each product, check if **any** order item exists with quantity > 5, and project `ProductName` along with a boolean flag.
//20. Sort all orders by `CustomerId` ascending, then by `TotalAmount` descending, and reverse the entire list.
//21. From the orders, group them by `CustomerId` and select customers whose **all orders** have `TotalAmount > 300`.
//22. List all products from categories 1 and 2, find products that appear in both categories, and remove products that belong only to category 2.
//23. Join `OrderItems`, `Orders`, and `Products` to calculate the total quantity of each product ordered across all orders, ordered by quantity descending.
//24. Retrieve orders partitioned by `TotalAmount`: take orders while `TotalAmount < 500`, then skip orders until `TotalAmount > 800`.
//25. Find all customers whose total spending is above the average total spending of all customers.
//26. Find all customers who have placed at least one order above 1000, and ensure all their orders are above 50.
//27. Group orders by the month of `OrderDate`, calculate sum, average, min, and max of `TotalAmount` for each month, and return a list of anonymous objects.
//28. From the products, select names and prices, then convert the list of anonymous objects to an array.
//29. Select customers whose email ends with "example.com" and check if **all** of them have at least one order above 200.
//30. Join `Products` and `OrderItems`, filter to show only products with quantity > 1, then select product name, quantity, and order ID.
//31. Calculate the total amount spent by all customers on products in category "Office Supplies" and count the total number of orders.
//32. Find customers where all their orders have `TotalAmount` less than 1000, but they have at least one order with `TotalAmount > 200`.
//33. For each customer, find the top 3 products they bought most by quantity. Return `CustomerName`, `ProductName`, and `TotalQuantity`.
//34. Get all products from categories 1 and 2, find products that appear in both categories, and remove products that belong only to category 2.
//35. Find all products that exist in both category "Electronics" and "Accessories" using a set operation. Select only their names.
