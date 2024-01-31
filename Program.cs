namespace VatCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // chiedere una lista di prodotti
                Console.Write("Quanti sono i prodotti? ");
                int numberProducts = int.Parse(Console.ReadLine());
                Product[] products = new Product[numberProducts];

                for (int i = 0; i < numberProducts; i++)
                {
                    Console.Write($"Nome prodotto {i + 1}: ");
                    string name = Console.ReadLine();
                    Console.Write($"Iva prodotto {i + 1}: ");
                    int vat = int.Parse(Console.ReadLine());
                    Console.Write($"Prezzo prodotto {i + 1}: ");
                    double price = double.Parse(Console.ReadLine());

                    products[i] = new Product(name, vat, price);
                }

                // stampare lo scontrino con il vat
                foreach (Product product in products)
                {
                    Console.WriteLine($"{product.Name}      {product.Vat}      {product.Price} -------> {product.CalculateFinalPrice()}");
                }

                Console.Write("Hai altri prodotti? <no to stop> ");
                string keepGoing = Console.ReadLine();
                if (keepGoing.ToLower() == "no")
                {
                    return;
                } else
                {
                    Console.Clear();
                }
            }
            
        }
    }

    class Product
    {
        string _name;
        int _vat;
        double _price;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Vat
        {
            get { return _vat;}
            set { _vat = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public Product(string name, int vat, double price)
        {
            Name = name;
            Vat = vat;
            Price = price;
        }

        public double CalculateFinalPrice()
        {
            double vat = (_price * _vat) / 100;
            return _price + vat;
        }
    }
}
