using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DesignPatterns.AbstractFactory;
using DesignPatterns.Adapter;
using DesignPatterns.Bridge;
using DesignPatterns.Builder;
using DesignPatterns.FactoryMethod;
using DesignPatterns.Prototype;
using DesignPatterns.Singleton;

namespace DesignPatterns
{
    public partial class Program
    {
        private static void Main(string[] args)
        {
            MethodInfo[] demoMethods =
                typeof (Program)
                    .GetMethods()
                    .Where(method => !method.GetGenericArguments().Any())
                    .Where(method => method.IsStatic)
                    .ToArray();

            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine("Press apropriate LETTER key to run demo or ESC to quit:");
                PrintMethodNames(demoMethods);
                key = Console.ReadKey();
                int methodIndex = char.ToUpper(key.KeyChar) - 'A';
                if (methodIndex < 0 || methodIndex >= demoMethods.Length) continue;
                MethodInfo method = demoMethods[methodIndex];
                InvokeDemo(method);
            } while (key.Key != ConsoleKey.Escape);
        }

        private static void InvokeDemo(MethodInfo method)
        {
            Console.Clear();
            Console.WriteLine("-----------{0}-----------", method.Name);
            method.Invoke(null, new object[] {});
            Console.WriteLine();
            Console.WriteLine("Press any key to RETURN ...");
            Console.ReadKey();
        }

        private static void PrintMethodNames(MethodInfo[] methods)
        {
            for (int index = 0; index < methods.Length; index++)
            {
                MethodInfo method = methods[index];
                var keyChar = (char) (index + 'A');
                Console.WriteLine("{0}: {1}", keyChar, method.Name);
            }
        }

        #region Creational Patterns

        public static void AbstractFactory()
        {
            // Language agnostic version
            CarFactory audiFactory = new AudiFactory();
            var driver1 = new Driver(audiFactory);
            driver1.CompareSpeed();
            ;

            CarFactory mercedesFactory = new MercedesFactory();
            var driver2 = new Driver(mercedesFactory);
            driver2.CompareSpeed();

            // C# specific version using generics
            var factory = new GenericFactory<MercedesSportsCar>();
            MercedesSportsCar mercedesSportsCar = factory.CreateObject();
            Console.WriteLine(mercedesSportsCar.GetType().ToString());

            Console.ReadKey();
        }

        private static void Builder()
        {
            var computerShop = new ComputerShop();
            ComputerBuilder computerBuilder;

            computerBuilder = new LaptopBuilder();
            computerShop.ConstructComputer(computerBuilder);
            computerBuilder.Computer.DisplayConfiguration();

            computerBuilder = new DesktopBuilder();
            computerShop.ConstructComputer(computerBuilder);
            computerBuilder.Computer.DisplayConfiguration();

            computerBuilder = new AppleBuilder();
            computerShop.ConstructComputer(computerBuilder);
            computerBuilder.Computer.DisplayConfiguration();
            Console.ReadKey();
        }

        private static void FactoryMethod()
        {
            var bookReaderList = new List<BookReader>();

            bookReaderList.Add(new AdventureBookReader());
            bookReaderList.Add(new FantasyBookReader());
            bookReaderList.Add(new HorrorBookReader());

            foreach (BookReader reader in bookReaderList)
            {
                Console.WriteLine(reader.GetType().ToString());
                // Language agnostic solution
                reader.DisplayOwnedBooks();

                Console.WriteLine();
            }

            // C# specific solution using generics
            var genericReader = new AdventureBookReader();
            Book book = genericReader.BuyBook<Encyclopedia>();
            Console.WriteLine(book.GetType().ToString());

            Console.ReadKey();
        }

        private static void Prototype()
        {
            // Language agnostic solution
            var supermarket = new Supermarket();

            supermarket.AddProduct("Milk", new Milk(0.89m));
            supermarket.AddProduct("Bread", new Bread(1.10m));

            decimal sourcePrice;
            decimal currentPrice;

            var clonedMilk = (Milk) supermarket.GetProduct("Milk");
            clonedMilk.Price = 1;
            sourcePrice = supermarket.GetProduct("Milk").Price;
            currentPrice = clonedMilk.Price;
            Console.WriteLine("{0} | {1}", sourcePrice, currentPrice);

            var clonedBread = (Bread) supermarket.GetProduct("Bread");
            clonedBread.Price = 2;
            sourcePrice = supermarket.GetProduct("Bread").Price;
            currentPrice = clonedBread.Price;
            Console.WriteLine("{0} | {1}", sourcePrice, currentPrice);

            // C# specific solution using the ICloneable interface
            var cloneableProduct = new CloneableProduct(100);
            var clonedProduct = (CloneableProduct) cloneableProduct.Clone();
            clonedProduct.Price = 200;
            sourcePrice = cloneableProduct.Price;
            currentPrice = clonedProduct.Price;
            Console.WriteLine("{0} | {1}", sourcePrice, currentPrice);

            Console.ReadKey();
        }

        private static void Singleton()
        {
            ConfigurationManager configurationManager = ConfigurationManager.GetInstance;
            configurationManager.DisplayConfiguration();

            BusinessRulesManager businessRulesManager = BusinessRulesManager.GetInstance;
            businessRulesManager.DisplayRules();

            Console.ReadKey();
        }

        #endregion

        #region Structural Patterns

        public static void Adapter()
        {
            var tradingdataImporter = new TradingDataImporter();

            Connector databaseConnector = new DatabaseConnector();
            tradingdataImporter.ImportData(databaseConnector);

            Connector xmlfileConnector = new XmlFileConnector();
            tradingdataImporter.ImportData(xmlfileConnector);

            Connector httpstreamConnector = new HttpStreamConnector();
            tradingdataImporter.ImportData(httpstreamConnector);

            Console.ReadKey();
        }

        public static void Bridge()
        {
            var clientRepository = new ClientRepository();
            var productRepository = new ProductRepository();

            var clientDataObject = new ClientDataObject();
            clientRepository.AddObject(clientDataObject);
            clientRepository.SaveChanges();

            clientRepository.CopyObject(clientDataObject);

            clientRepository.RemoveObject(clientDataObject);
            clientRepository.SaveChanges();

            var productDataObject = new ProductDataObject();
            productRepository.AddObject(productDataObject);
            clientRepository.SaveChanges();

            productRepository.CopyObject(productDataObject);

            productRepository.RemoveObject(productDataObject);
            productRepository.SaveChanges();

            Console.ReadKey();
        }

        #endregion
    }
}