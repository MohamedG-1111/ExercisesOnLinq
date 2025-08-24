using System;
using System.Collections.Generic;
using ExercisesOnLinq.Models;

namespace ExercisesOnLinq.Data
{
    public static class Repository
    {
        public static List<Product> LoadProducts()
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

        public static List<Category> LoadCategories()
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

        public static List<Customer> LoadCustomers()
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
            };
        }

        public static List<Order> LoadOrders()
        {
            var orders = new List<Order>();
            for (int i = 1; i <= 15; i++)
            {
                orders.Add(new Order
                {
                    Id = i,
                    CustomerId = (i % 15) + 1,
                    OrderDate = DateTime.Now.AddDays(-i),
                    TotalAmount = 100 * i
                });
            }
            return orders;
        }

        public static List<OrderItem> LoadOrderItems()
        {
            var orderItems = new List<OrderItem>();
            int id = 1;
            for (int i = 1; i <= 35; i++)
            {
                orderItems.Add(new OrderItem
                {
                    Id = id++,
                    OrderId = (i % 15) + 1,
                    ProductId = (i % 15) + 1,
                    Quantity = (i % 5) + 1
                });
            }
            return orderItems;
        }

        public static List<Payment> LoadPayments()
        {
            var payments = new List<Payment>();
            for (int i = 1; i <= 15; i++)
            {
                payments.Add(new Payment
                {
                    Id = i,
                    OrderId = i,
                    Amount = 100 * i,
                    PaymentDate = DateTime.Now.AddDays(-i)
                });
            }
            return payments;
        }

        public static List<Shipment> LoadShipments()
        {
            var shipments = new List<Shipment>();
            for (int i = 1; i <= 15; i++)
            {
                shipments.Add(new Shipment
                {
                    Id = i,
                    OrderId = i,
                    TrackingNumber = $"TRK{i:000}",
                    ShippedDate = DateTime.Now.AddDays(-i)
                });
            }
            return shipments;
        }
    }
}
