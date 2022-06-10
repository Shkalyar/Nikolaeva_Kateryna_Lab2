using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2_task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products =
            {
                new Product("pepsi", "juice and lemonades", 30.99m, new DateTime(2020,1,2), new DateTime(2022, 7,20)),
                new Product("apple", "fruit", 35.50m, new DateTime(2022,4,2), new DateTime(2022, 4,20)),
                new Product("orange", "fruit", 56m, new DateTime(2022,4,9), new DateTime(2022, 4,30)),
                new Product("chicken", "meat", 85.99m, new DateTime(2022,4,20), new DateTime(2022, 5,6)),
                new Product("grechka", "bakalea", 28m, new DateTime(2022,4,2), new DateTime(2023, 4,23)),
                new Product("milk", "milk products", 46.70m, new DateTime(2020,1,20), new DateTime(2022, 4,29)),
                new Product("lemon", "fruit", 40.99m, new DateTime(2022,4,9), new DateTime(2022, 4,30)),
                new Product("pork", "meat", 120.60m, new DateTime(2022,4,20), new DateTime(2022, 5,6)),
                new Product("apple juice", "juice and lemonades", 27.80m, new DateTime(2022,4,2), new DateTime(2022, 7,28)),
                new Product("spaggetti", "bakalea", 25.99m, new DateTime(2020,1,9), new DateTime(2023, 4,26)),
            };

            GroceryStore groceryStore = new GroceryStore();
            groceryStore.products = products;

            Console.WriteLine("Вiдсортованi за типом:");
            groceryStore.sortBytype(products);
            groceryStore.show_products(products);
            Console.WriteLine();

            Console.WriteLine("Вiдсортованi за вартiстю:");
            groceryStore.sortByprice(ref products);
            groceryStore.show_products(products);
            Console.WriteLine();

            Console.WriteLine("Товари, термiн придатностi яких знаходиться в діапазонi вiд 20.04.2022 до 29.04.2022:");
            groceryStore.find_expDate_products(new DateTime(2022, 4, 20), new DateTime(2022, 4, 29), products);
            Console.WriteLine();

            groceryStore.find_expired(products);
            Console.WriteLine();

            groceryStore.find_manufactedIn_January2020(products);

            Console.ReadLine();
        }
    }

    class GroceryStore
    {
        public Product[] products { get; set; }
        public void sortBytype(Product[] products)
        {
            Array.Sort(products, new TypeComparer());
        }

        public void sortByprice(ref Product[] products)
        {
            var t = products.OrderBy(a => a.price).ToArray();
            products = t;
        }

        public void find_expDate_products(DateTime dateStart, DateTime dateEnd, Product [] products)
        {
            Console.WriteLine("{0,10}   |{1,20}  |{2,20}  |{3,18}  |{4,10}","Назва","Тип","Вартiсть","Дата виготовлення","Термiн придатностi");
            for (int i=0; i<products.Length; i++)
            {
                var t = products[i];
                if (dateStart <= products[i].expirationDate && products[i].expirationDate<=dateEnd)
                { 
                    Console.WriteLine("{0,10}   |{1,20}  |{2,20}  |{3,10}  |{4,10}", t.name, t.type, t.price, t.manufactureDate, t.expirationDate);
                }

            }
        }

        public void find_expired(Product[] products)
        {
            Console.WriteLine("Просроченi товари: ");
            for (int i = 0; i < products.Length; i++)
            {
                var t = products[i];
                if (products[i].expirationDate<DateTime.Today)
                    Console.WriteLine("{0,15}   |{1,20}  |{2,20}  |{3,10}  |{4,10}", t.name, t.type, t.price, t.manufactureDate, t.expirationDate);
            }
        }

        public void find_manufactedIn_January2020(Product[] products)
        {
            Console.WriteLine("Tовари, виготовленi у сiчнi 2020: ");
            for (int i = 0; i < products.Length; i++)
            {
                var t = products[i];
                if (products[i].manufactureDate >= new DateTime(2020, 1,1) && products[i].manufactureDate<=new DateTime(2020,1,31))
                    Console.WriteLine("{0,15}   |{1,20}  |{2,20}  |{3,10}  |{4,10}", t.name, t.type, t.price, t.manufactureDate, t.expirationDate);
            }
        }

        public void show_products(Product[] products)
        {
            Console.WriteLine("{0,10}   |{1,20}  |{2,20}  |{3,18}  |{4,10}", "Назва", "Тип", "Вартiсть", "Дата виготовлення", "Термiн придатностi");
            for (int i = 0; i < products.Length; i++)
            {
                var t = products[i];
                    Console.WriteLine("{0,10}   |{1,20}  |{2,20}  |{3,10}  |{4,10}", t.name, t.type, t.price, t.manufactureDate, t.expirationDate);
            }
        }
    }

    class Product
    {
        public string name { get; private set; }
        public string type { get; private set; }
        public decimal price { get; private set; }
        public DateTime expirationDate { get; private set; }
        public DateTime manufactureDate { get; private set; }

        public Product(string name, string type, decimal price, DateTime manDate, DateTime expDate)
        {
            this.name = name;
            this.type = type;
            this.price = price;
            manufactureDate = manDate;
            expirationDate = expDate;
        }
    }

    class TypeComparer : IComparer<Product>
    {
        public int Compare(Product? p1, Product? p2)
        {
            if (p1 is null || p2 is null)
                throw new ArgumentException("Некорректное значение параметра");
            return p1.type.Length - p2.type.Length;
        }
    }
}
