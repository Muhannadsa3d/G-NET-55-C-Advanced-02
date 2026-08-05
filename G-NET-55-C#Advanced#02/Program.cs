namespace G_NET_55_C_Advanced_02
{
    internal class Program
    {
        public static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
        {
            return products.Where(filter).ToList();
        }

        public static void PrintReport(List<Product> products, Action<Product> formatter)
        {
            foreach (var p in products)
            {
                formatter(p);
            }
        }

        public static List<string> TransformProducts(List<Product> products, Func<Product, string> transformer)
        {
            return products.Select(transformer).ToList();
        }

        public static List<Product> FilterProducts(List<Product> products, Predicate<Product> condition)
        {
            return products.FindAll(condition);
        }
        static void Main(string[] args)
        {
            #region Online Store

         List<Product> catalog = new()
            {
                new Product { Id=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
                new Product { Id=2, Name="Phone", Category="Electronics", Price=800, Stock=25 },
                new Product { Id=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
                new Product { Id=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
                new Product { Id=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
                new Product { Id=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
                new Product { Id=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
                new Product { Id=8, Name="Novel", Category="Books", Price=20, Stock=60 },
                new Product { Id=9, Name="Headphones", Category="Electronics", Price=150, Stock=40 },
                new Product { Id=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }
            };


        var electronics = SearchProducts(catalog, p => p.Category == "Electronics");
        var cheapProducts = SearchProducts(catalog, p => p.Price < 50);
        var inStock = SearchProducts(catalog, p => p.Stock > 0);
        var clothingUnder100 = SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);

        Console.WriteLine("--- Electronics ---");
        foreach (var p in electronics) Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");

        Console.WriteLine("\n--- Under $50 ---");
        foreach (var p in cheapProducts) Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");

        Console.WriteLine("\n--- In Stock ---");
        foreach (var p in inStock) Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");

        Console.WriteLine("\n--- Clothing Under $100 ---");
        foreach (var p in clothingUnder100) Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");



   

            Console.WriteLine("--- Short Report ---");
            PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));

            Console.WriteLine("\n--- Detailed Report ---");
            PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));


                
                Console.WriteLine("--- Summary List ---");
                var summaryList = TransformProducts(catalog, p => $"{p.Name} (${p.Price})");
                foreach (var item in summaryList) Console.WriteLine(item);

                
                Console.WriteLine("\n--- Price Labels ---");
                var priceLabels = TransformProducts(catalog,
                    p => $"{p.Name}: {(p.Price > 100 ? "Expensive!" : "Affordable")}");
                foreach (var item in priceLabels) Console.WriteLine(item);



                    Console.WriteLine("--- Low-Stock Alert ---");
                    var lowStockProducts = FilterProducts(catalog, p => p.Stock < 20);

                    foreach (var p in lowStockProducts)
                    {
                        Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");
                    }


            #endregion


        }
    }
}
