using System;
using System.Collections.Generic;
using ExercisesOnLinq.Models;

namespace ExercisesOnLinq.Data
{
    public static class Repository
    {
        public static IEnumerable<Product> LoadProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 1500, CategoryId = 1 },
                new Product { Id = 2, Name = "Smartphone", Price = 800, CategoryId = 1 },
                new Product { Id = 3, Name = "Keyboard", Price = 50, CategoryId = 2 },
                new Product { Id = 4, Name = "Mouse", Price = 25, CategoryId = 2 },
                new Product { Id = 5, Name = "Monitor", Price = 300, CategoryId = 2 },
                new Product { Id = 6, Name = "Printer", Price = 200, CategoryId = 3 },
                new Product { Id = 7, Name = "Desk", Price = 400, CategoryId = 4 },
                new Product { Id = 8, Name = "Chair", Price = 150, CategoryId = 4 },
                new Product { Id = 9, Name = "Notebook", Price = 5, CategoryId = 5 },
                new Product { Id = 10, Name = "Pen", Price = 2, CategoryId = 5 },
                new Product { Id = 11, Name = "Tablet", Price = 600, CategoryId = 1 },
                new Product { Id = 12, Name = "Headphones", Price = 120, CategoryId = 2 },
                new Product { Id = 13, Name = "Camera", Price = 700, CategoryId = 1 },
                new Product { Id = 14, Name = "USB Cable", Price = 10, CategoryId = 2 },
                new Product { Id = 15, Name = "Projector", Price = 900, CategoryId = 3 },
            };
        }

        public static IEnumerable<Category> LoadCategories()
        {
            return new List<Category>
            {
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Accessories" },
                new Category { Id = 3, Name = "Office Supplies" },
                new Category { Id = 4, Name = "Furniture" },
                new Category { Id = 5, Name = "Stationery" },
                new Category { Id = 6, Name = "Home Appliances" },
                new Category { Id = 7, Name = "Sports" },
                new Category { Id = 8, Name = "Clothing" },
                new Category { Id = 9, Name = "Books" },
                new Category { Id = 10, Name = "Toys" },
                new Category { Id = 11, Name = "Garden" },
                new Category { Id = 12, Name = "Health" },
                new Category { Id = 13, Name = "Beauty" },
                new Category { Id = 14, Name = "Music" },
                new Category { Id = 15, Name = "Automotive" },
            };
        }

        public static IEnumerable<Customer> LoadCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, FullName = "Mohamed Ali", Email = "mohamed@example.com" },
                new Customer { Id = 2, FullName = "Sara Ibrahim", Email = "sara@example.com" },
                new Customer { Id = 3, FullName = "Omar Khaled", Email = "omar@example.com" },
                new Customer { Id = 4, FullName = "Mona Hassan", Email = "mona@example.com" },
                new Customer { Id = 5, FullName = "Ali Mostafa", Email = "ali@example.com" },
                new Customer { Id = 6, FullName = "Hana Adel", Email = "hana@example.com" },
                new Customer { Id = 7, FullName = "Youssef Kamal", Email = "youssef@example.com" },
                new Customer { Id = 8, FullName = "Nora Tarek", Email = "nora@example.com" },
                new Customer { Id = 9, FullName = "Khaled Mohamed", Email = "khaled@example.com" },
                new Customer { Id = 10, FullName = "Salma Reda", Email = "salma@example.com" },
                new Customer { Id = 11, FullName = "Hossam Fathy", Email = "hossam@example.com" },
                new Customer { Id = 12, FullName = "Aya Ahmed", Email = "aya@example.com" },
                new Customer { Id = 13, FullName = "Mustafa Gamal", Email = "mustafa@example.com" },
                new Customer { Id = 14, FullName = "Laila Saeed", Email = "laila@example.com" },
                new Customer { Id = 15, FullName = "Ziad Hassan", Email = "ziad@example.com" },
                new Customer { Id = 16, FullName = "Mohamed Gomaa", Email = "Mohamed@example.com" },
            };
        }

        public static IEnumerable<Order> LoadOrders()
        {
            int orderId = 1;
            for (int c = 1; c <= 16; c++)
            {
                for (int j = 0; j < 2; j++) 
                {
                    yield return new Order
                    {
                        Id = orderId++,
                        CustomerId = c,
                        OrderDate = DateTime.Now.AddDays(-orderId).AddMonths(-j),
                        TotalAmount = 100 * orderId
                    };
                }
            }
        }

        public static IEnumerable<OrderItem> LoadOrderItems()
        {
            return new List<OrderItem>
    {
        new OrderItem { Id = 1,  OrderId = 1,  ProductId = 1,  Quantity = 2 },
        new OrderItem { Id = 2,  OrderId = 1,  ProductId = 2,  Quantity = 1 },
        new OrderItem { Id = 3,  OrderId = 1,  ProductId = 3,  Quantity = 1 },
        new OrderItem { Id = 4,  OrderId = 2,  ProductId = 1,  Quantity = 1 },
        new OrderItem { Id = 5,  OrderId = 2,  ProductId = 4,  Quantity = 2 },
        new OrderItem { Id = 6,  OrderId = 2,  ProductId = 5,  Quantity = 1 },
        new OrderItem { Id = 7,  OrderId = 3,  ProductId = 2,  Quantity = 2 },
        new OrderItem { Id = 8,  OrderId = 3,  ProductId = 3,  Quantity = 1 },
        new OrderItem { Id = 9,  OrderId = 3,  ProductId = 4,  Quantity = 1 },
        new OrderItem { Id = 10, OrderId = 4,  ProductId = 1,  Quantity = 3 },
        new OrderItem { Id = 11, OrderId = 4,  ProductId = 5,  Quantity = 2 },
        new OrderItem { Id = 12, OrderId = 5,  ProductId = 2,  Quantity = 1 },
        new OrderItem { Id = 13, OrderId = 5,  ProductId = 3,  Quantity = 2 },
        new OrderItem { Id = 14, OrderId = 5,  ProductId = 4,  Quantity = 1 },
        new OrderItem { Id = 15, OrderId = 6,  ProductId = 1,  Quantity = 2 },
        new OrderItem { Id = 16, OrderId = 6,  ProductId = 5,  Quantity = 1 },
        new OrderItem { Id = 17, OrderId = 7,  ProductId = 2,  Quantity = 3 },
        new OrderItem { Id = 18, OrderId = 7,  ProductId = 3,  Quantity = 1 },
        new OrderItem { Id = 19, OrderId = 7,  ProductId = 4,  Quantity = 2 },
        new OrderItem { Id = 20, OrderId = 8,  ProductId = 1,  Quantity = 1 },
        new OrderItem { Id = 21, OrderId = 8,  ProductId = 5,  Quantity = 2 },
        new OrderItem { Id = 22, OrderId = 9,  ProductId = 2,  Quantity = 1 },
        new OrderItem { Id = 23, OrderId = 9,  ProductId = 3,  Quantity = 3 },
        new OrderItem { Id = 24, OrderId = 9,  ProductId = 4,  Quantity = 1 },
        new OrderItem { Id = 25, OrderId = 10, ProductId = 1,  Quantity = 2 },
        new OrderItem { Id = 26, OrderId = 10, ProductId = 5,  Quantity = 1 },
        new OrderItem { Id = 27, OrderId = 11, ProductId = 2,  Quantity = 2 },
        new OrderItem { Id = 28, OrderId = 11, ProductId = 3,  Quantity = 1 },
        new OrderItem { Id = 29, OrderId = 11, ProductId = 4,  Quantity = 1 },
        new OrderItem { Id = 30, OrderId = 12, ProductId = 1,  Quantity = 3 },
        new OrderItem { Id = 31, OrderId = 12, ProductId = 5,  Quantity = 2 },
        new OrderItem { Id = 32, OrderId = 13, ProductId = 2,  Quantity = 1 },
        new OrderItem { Id = 33, OrderId = 13, ProductId = 3,  Quantity = 2 },
        new OrderItem { Id = 34, OrderId = 13, ProductId = 4,  Quantity = 1 },
        new OrderItem { Id = 35, OrderId = 14, ProductId = 1,  Quantity = 2 },
        new OrderItem { Id = 36, OrderId = 14, ProductId = 5,  Quantity = 1 },
        new OrderItem { Id = 37, OrderId = 15, ProductId = 2,  Quantity = 3 },
        new OrderItem { Id = 38, OrderId = 15, ProductId = 3,  Quantity = 1 },
        new OrderItem { Id = 39, OrderId = 15, ProductId = 4,  Quantity = 2 },
        new OrderItem { Id = 40, OrderId = 16, ProductId = 1,  Quantity = 1 },
        new OrderItem { Id = 41, OrderId = 16, ProductId = 5,  Quantity = 2 },
        new OrderItem { Id = 42, OrderId = 17, ProductId = 2,  Quantity = 1 },
        new OrderItem { Id = 43, OrderId = 17, ProductId = 3,  Quantity = 2 },
        new OrderItem { Id = 44, OrderId = 17, ProductId = 4,  Quantity = 1 },
        new OrderItem { Id = 45, OrderId = 18, ProductId = 1,  Quantity = 2 },
        new OrderItem { Id = 46, OrderId = 18, ProductId = 5,  Quantity = 1 },
        new OrderItem { Id = 47, OrderId = 19, ProductId = 2,  Quantity = 3 },
        new OrderItem { Id = 48, OrderId = 19, ProductId = 3,  Quantity = 1 },
        new OrderItem { Id = 49, OrderId = 20, ProductId = 4,  Quantity = 2 },
        new OrderItem { Id = 50, OrderId = 20, ProductId = 1,  Quantity = 1 }
    };
        }


        public static IEnumerable<Payment> LoadPayments()
        {
            for (int i = 1; i <= 15; i++)
            {
                yield return new Payment
                {
                    Id = i,
                    OrderId = i,
                    Amount = 100 * i,
                    PaymentDate = DateTime.Now.AddDays(-i)
                };
            }
        }

        public static IEnumerable<Shipment> LoadShipments()
        {
            for (int i = 1; i <= 15; i++)
            {
                yield return new Shipment
                {
                    Id = i,
                    OrderId = i,
                    TrackingNumber = $"TRK{i:000}",
                    ShippedDate = DateTime.Now.AddDays(-i)
                };
            }
        }
        public static void PrintList<T>(List<T> items)
        {
            foreach (var item in items)
            {
                
                if (item is string || item.GetType().IsPrimitive)
                {
                    Console.WriteLine(item);
                }
                else
                {
     
                    var properties = item.GetType().GetProperties();
                    foreach (var prop in properties)
                    {
                        var value = prop.GetValue(item, null);
                        Console.WriteLine($"{prop.Name}: {value}");
                    }
                    Console.WriteLine("-----------");
                }
            }
        }

    }
}
