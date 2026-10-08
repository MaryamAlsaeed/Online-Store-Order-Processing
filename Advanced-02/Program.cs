namespace Advanced_02
{
    internal class Program
    {
        #region Searchproduct method
        static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
        {
            List<Product> result = new();
            foreach (Product product in products)
            {
                if (filter(product))
                    result.Add(product);

            }
            return result;
        }
        #endregion

        #region Display Products
        public static void DisplayProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} - ${product.Price} (Stock: {product.Stock})");
            }
            PrintSpace();
        }
        #endregion

        #region Print reports method
        // in main function we will decide wether we need to implement the short report or the detailed one.
        public static void PrintReports(List<Product> products, Action<Product> Printer)
        {
            foreach (Product product in products)
            {
                Printer(product);
            }
        }
        #endregion

        #region Transform Products
        public static List<string> TransformProducts(List<Product> products, Func<Product, string> transformer)
        {
            List<string> result = new();
            foreach (Product product in products)
            {
                result.Add(transformer(product));
            }
            return result;
        }
        #endregion
        #region Filter products
        public static List<Product> FilterProduct (List<Product> products, Func<Product, bool> filter)
        {
            List<Product> result = new();
            foreach (Product product in products)
            {
                if (filter(product))
                    result.Add(product);
            }
            return result;
        }
        #endregion
        public static void PrintSpace()
        {
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            #region Product Catalog
            List<Product> catalog = new()
            {
            new Product { Id=1,  Name="Laptop",     Category="Electronics", Price=1200, Stock=10  },
            new Product { Id=2,  Name="Phone",      Category="Electronics", Price=800,  Stock=25  },
            new Product { Id=3,  Name="T-Shirt",    Category="Clothing",    Price=30,   Stock=100 },
            new Product { Id=4,  Name="Jeans",      Category="Clothing",    Price=60,   Stock=50  },
            new Product { Id=5,  Name="Chocolate",  Category="Food",        Price=5,    Stock=200 },
            new Product { Id=6,  Name="Coffee Beans", Category="Food",      Price=15,   Stock=80  },
            new Product { Id=7,  Name="C# Book",    Category="Books",       Price=45,   Stock=30  },
            new Product { Id=8,  Name="Novel",      Category="Books",       Price=20,   Stock=60  },
            new Product { Id=9,  Name="Headphones", Category="Electronics", Price=150,  Stock=40  },
            new Product { Id=10, Name="Jacket",     Category="Clothing",    Price=120,  Stock=15  },
            };
            #endregion

            #region Search Product by category
            Console.WriteLine("--Electronics--");
            var electronics = SearchProducts(catalog, p => p.Category == "Electronics");
            DisplayProducts(electronics);

            Console.WriteLine("--Under $50--");
            var under50 = SearchProducts(catalog, p => p.Price < 50);
            DisplayProducts(under50);

            Console.WriteLine("--In Stock--");
            var inStock = SearchProducts(catalog, p => p.Stock > 0);
            DisplayProducts(inStock);

            Console.WriteLine("--Clothing under $100--");
            var clothingUnder100 = SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
            DisplayProducts(clothingUnder100);
            #endregion

            #region Short Report
            Console.WriteLine("--Short Report--");
            PrintReports(catalog, product => Console.WriteLine($"{product.Name} - ${product.Price}"));
            #endregion

            PrintSpace();

            #region Detailed Report
            Console.WriteLine("--Detailed Report--");
            PrintReports(catalog, product => Console.WriteLine($"[{product.Category}] {product.Name} | Price: ${product.Price} | Stock: {product.Stock}"));
            #endregion

            PrintSpace();

            #region Summary
            Console.WriteLine("--Summary Report--");
            foreach (string s in TransformProducts(catalog, p => $"{p.Name} (${p.Price})"))
                Console.WriteLine(s);
            #endregion

            PrintSpace();
            #region Print lables
            Console.WriteLine("--Price labels--");
            foreach (string s in TransformProducts(catalog, p => $"{p.Name}: {(p.Price > 100 ? "Expensive!" : "Affordable")}"))
                Console.WriteLine(s);
            #endregion

            PrintSpace();
            #region Low stock Alert
            Console.WriteLine("--Low-Stock Alert--");
            foreach (Product product in FilterProduct(catalog, p => p.Stock < 20))
                Console.WriteLine($"[LOW STOCK] {product.Name}: only {product.Stock} left!");
            #endregion
        }
    }
}
