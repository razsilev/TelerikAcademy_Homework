namespace _3_OnlineMarket
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Wintellect.PowerCollections;

    public class Product : IComparable<Product>
    {
        public Product(string name, double price, string productType)
        {
            this.Name = name;
            this.Price = price;
            this.Type = productType;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price);
        }

        public int CompareTo(Product other)
        {
            int result = 0;

            if (other.Price > this.Price)
            {
                result = -1;
            }
            else if (other.Price < this.Price)
            {
                result = 1;
            }
            else
            {
                if (other.Name.CompareTo(this.Name) > 0)
                {
                    result = -1;
                }
                else if (other.Name.CompareTo(this.Name) < 0)
                {
                    result = 1;
                }
                else
                {
                    if (other.Type.CompareTo(this.Type) > 0)
                    {
                        result = -1;
                    }
                    else if (other.Type.CompareTo(this.Type) < 0)
                    {
                        result = 1;
                    }
                    else
                    {
                        result = 0;
                    }
                }
            }

            return result;
        }
    }

    public class OnlineMarket
    {
        private static HashSet<string> productsNames = new HashSet<string>();

        private static Dictionary<string, SortedSet<Product>> typeFilterColection =
                                                new Dictionary<string, SortedSet<Product>>();

        private static OrderedBag<Product> sortedByPriceProducts = new OrderedBag<Product>();

        public static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
                System.Globalization.CultureInfo.InvariantCulture;

            string command = Console.ReadLine().Trim();
            
            StringBuilder result = new StringBuilder();

            while (command != "end")
            {
                var commandTokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // add command
                if (commandTokens[0].Trim() == "add")
                {
                    result.AppendLine(AddCommand(command));
                }
                else
                {
                    // filter command

                    // filter by type clothes
                    if (commandTokens[2].Trim() == "type")
                    {
                        result.AppendLine(ProductTypeFilter(command));
                    }
                    else
                    {
                        // filter by price to 2.00
                        if (commandTokens[3].Trim() == "to")
                        {
                            result.AppendLine(FilterByPriceTo(command));
                        }
                        else
                        {
                            // filter by price from 1.00 to 2.00
                            if (commandTokens.Length == 7)
                            {
                                result.AppendLine(FilterByPriceFromTo(command));
                            }
                            // filter by price from 1.50
                            else
                            {
                                result.AppendLine(FilterByPriceFrom(command));
                            }
                        }
                    }
                }

                command = Console.ReadLine().Trim();
            }

            //result.Length -= 2;

            Console.WriteLine(result.ToString().Trim());
        }

        private static string FilterByPriceFrom(string command)
        {
            var commandTokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var result = new StringBuilder();
            result.Append("Ok: ");

            double fromPrice = double.Parse(commandTokens[4]);

            var product = new Product("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", fromPrice, "");

            var elements = sortedByPriceProducts.RangeFrom(product, true).ToArray();

            if (elements.Length > 0)
            {
                if (elements.Length >= 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        result.AppendFormat("{0}, ", elements[i].ToString());
                    }
                }
                else
                {
                    for (int i = 0; i < elements.Length; i++)
                    {
                        result.AppendFormat("{0}, ", elements[i].ToString());
                    }
                }

                result.Length -= 2;
            }

            return result.ToString();
        }

        private static string FilterByPriceFromTo(string command)
        {
            var commandTokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var result = new StringBuilder();
            result.Append("Ok: ");

            double toPrice = double.Parse(commandTokens[6]);
            double fromPrice = double.Parse(commandTokens[4]);

            var toProduct = new Product("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz", toPrice, "");
            var fromProduct = new Product("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", fromPrice, "");

            var elements = sortedByPriceProducts.Range(fromProduct, true, toProduct, true).ToArray();

            if (elements.Length > 0)
            {
                if (elements.Length >= 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        result.AppendFormat("{0}, ", elements[i].ToString());
                    }
                }
                else
                {
                    for (int i = 0; i < elements.Length; i++)
                    {
                        result.AppendFormat("{0}, ", elements[i].ToString());
                    }
                }

                result.Length -= 2;
            }

            return result.ToString().Trim();
        }

        private static string FilterByPriceTo(string command)
        {
            var commandTokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var result = new StringBuilder();
            result.Append("Ok: ");

            double toPrice = double.Parse(commandTokens[4]);

            var product = new Product("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz", toPrice, "");

            var elements = sortedByPriceProducts.RangeTo(product, true).ToArray();

            if (elements.Length > 0)
            {
                if (elements.Length >= 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        result.AppendFormat("{0}, ", elements[i].ToString());
                    }
                }
                else
                {
                    for (int i = 0; i < elements.Length; i++)
                    {
                        result.AppendFormat("{0}, ", elements[i].ToString());
                    }
                }

                result.Length -= 2;
            }

            return result.ToString().Trim();
        }

        // filter by type clothes
        private static string ProductTypeFilter(string command)
        {
            var tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string productType = tokens[tokens.Length - 1];

            string result = string.Format("Error: Type {0} does not exists", productType);

            if (typeFilterColection.ContainsKey(productType))
            {
                int count = 0;
                var products = typeFilterColection[productType];
                var newResult = new StringBuilder();
                newResult.Append("Ok: ");

                foreach (var product in products)
                {
                    count++;
                    newResult.AppendFormat("{0}, ", product.ToString());

                    if (count == 10)
                    {
                        break;
                    }
                }

                newResult.Length -= 2;

                result = newResult.ToString();
            }

            return result.Trim();
        }

        private static string AddCommand(string command)
        {
            var tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string name = tokens[1].Trim();

            if (productsNames.Contains(name))
            {
                return string.Format("Error: Product {0} already exists", name);
            }

            productsNames.Add(name);

            string pType = tokens[3];
            double price = double.Parse(tokens[2]);

            var newProduct = new Product(name, price, pType);

            // add in typeFilterColection
            if (!typeFilterColection.ContainsKey(pType))
            {
                typeFilterColection.Add(pType, new SortedSet<Product>());
            }

            typeFilterColection[pType].Add(newProduct);

            sortedByPriceProducts.Add(newProduct);

            return string.Format("Ok: Product {0} added successfully", name);
        }
    }
}
