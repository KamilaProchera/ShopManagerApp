using System;
using System.Collections.Generic;
using System.Text;
using Shop_Application;
using Shop_Infrastructure;

namespace Shop
{
    internal class Menu
    {
        private readonly Dictionary<uint, string> _dictionary = new Dictionary<uint, string>
        {
            {1, "Add a product"},
            {2, "Delivery of product"},
            {3, "Order"},
            {4,"Report" },
            {0,"Exit" }
        };




        private readonly ConsoleUserOperations _consoleUser = new ConsoleUserOperations();
        
        private readonly ProductTableRepository _repository = new ProductTableRepository("Shop");

        private readonly TableOperations _tableOperation;


        public Menu()
        {


            _consoleUser = new ConsoleUserOperations();
            _repository = new ProductTableRepository("Shop");

        }

        public void Run()
        {
            var shouldExit = false;
            do
            {
                foreach (var option in _dictionary) Console.WriteLine($"{option.Key} - {option.Value}");

                var input = Console.ReadLine();
                if (!uint.TryParse(input, out var choice))
                {
                    Console.WriteLine("You entered an incorrect number");
                    continue;
                }

                switch (choice)
                {
                    case 0:
                        shouldExit = true;
                        break;
                    case 1:
                        _consoleUser.AddProduct();
                        break;
                    case 2:
                        _consoleUser.EditQuantity();
                        break;
                    case 3:
                        _consoleUser.Order();
                        break;
                    case 4:
                        Console.WriteLine("Inventories:");
                        _consoleUser.Raport();
                        break;
                    default:
                        continue;
                }
            } while (!shouldExit);
        }

    }
}
