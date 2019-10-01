using System;
using Shop_Domain;

namespace Shop_Application
{
    public class TableOperations : IPrintTable
    {

        public TableOperations()
        {

        }
        private readonly IPrintTable _printTable;
        public TableOperations(IPrintTable printTable)
        {
            _printTable = printTable;
        }
        public Product CreateProduct(string messageName, string messagePrice, string errorMessage)
        {
            string name = GetString(messageName);
            double price = GetPrice(messagePrice, errorMessage);
            var product = new Product(name, price, 0);

            return product;

        }

       
        public string GetString(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            return input;
        }


        public double GetPrice(string question, string errorMessage)
        {
            Console.WriteLine(question);
            var input = Console.ReadLine();
            double choice;
            if (!double.TryParse(input, out choice))
            {
                Console.WriteLine(errorMessage);
                choice = (uint)GetPrice(question, errorMessage);

            }

            return choice;


        }



        public uint ReadNumberUint(string message,string errorMessage)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();
            bool check = uint.TryParse(input, out uint output);
            if (!check)
            {
                Console.WriteLine(errorMessage);
                output = ReadNumberUint(message,errorMessage);
            }
            return output;

        }



    }
}
