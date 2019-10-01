using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using Shop_Application;
using Shop_Infrastructure;

namespace Shop
{
    public class ConsoleUserOperations
    {
        ProductTableRepository repository_operations = new ProductTableRepository("Shop");
        TableOperations tableOperations = new TableOperations();


        public void AddProduct()
        {
            string name = tableOperations.GetString("Enter the name of product");
            double price = tableOperations.GetPrice("Enter the price", "The price is incorrect");
            var product = new Product(name, price, 0);
            repository_operations.InsertRecord("Products", product);
        }

        public void Raport()
        {
            var listOfProducts = repository_operations.LoadRecords<Product>("Products");
            for (int i = 0; i < listOfProducts.Count; i++)
            {
                if (listOfProducts[i].Quantity > 0)
                {
                    Console.WriteLine($"{i + 1} - {listOfProducts[i].Name} - Price: {listOfProducts[i].Price} zł - Quantity:{listOfProducts[i].Quantity}");
                }

               
            }
           
        }


        //Edit quantity
        public void EditQuantity()
        {
            Console.WriteLine("Which product was delivered");

            //Print table

            var listOfProducts = repository_operations.LoadRecords<Product>("Products");
            for (int i = 0; i < listOfProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {listOfProducts[i].Name} - Price: {listOfProducts[i].Price} zł - Quantity:{listOfProducts[i].Quantity}");
            }
            Console.WriteLine("0 - Exit");

            //Choose a product
            uint choice = tableOperations.ReadNumberUint("Enter the number of product","The number is incorrect, try again");

            switch (choice)
            {
                case 0:
                    return;
                case uint n when n <= listOfProducts.Count:

                    var recond = listOfProducts[(int)n - 1].Name;

                    uint productsQuantity = tableOperations.ReadNumberUint("Enter the quantity","The quantity is incorrect, try again");
                    uint productsQt = listOfProducts[(int)n - 1].Quantity + productsQuantity;
                    repository_operations.UpdateRecord("Products", recond, productsQt);

                    break;
                default:
                    Console.WriteLine("Something went wrong");
                    break;
            }


        }

        //ORDER
        public void Order()
        {
            bool shouldExit = false;
            double sumTheWholeOrder = 0;
            do
            {
                double oneProduct = 0;
                Console.WriteLine("Which product do you want to order?");

                //Print table
                var listOfProducts = repository_operations.LoadRecords<Product>("Products");
                for (int i = 0; i < listOfProducts.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {listOfProducts[i].Name} - Price: {listOfProducts[i].Price} zł - Quantity:{listOfProducts[i].Quantity}");
                }
                Console.WriteLine("0 - Exit");

                //Choose a product
                uint choice = tableOperations.ReadNumberUint("Enter the number of product","The number is incorrect, try again");

                switch (choice)
                {
                    case 0:
                        return;
                    case uint n when n <= listOfProducts.Count:


                        var recond = listOfProducts[(int)n - 1].Name;
                        var price = listOfProducts[(int)n - 1].Price;

                        MongoClient client = new MongoClient();

                        Console.WriteLine("How many products do you want to order?");
                        uint quantity = Convert.ToUInt32(Console.ReadLine());


                        if (quantity > listOfProducts[(int)n - 1].Quantity)
                        {
                            Console.WriteLine("The stock quantity is less than you want to order");
                            break;
                        }
                        uint productsQt = listOfProducts[(int)n - 1].Quantity - quantity;
                        repository_operations.UpdateRecord("Products", recond, productsQt);
                        oneProduct = quantity * price;
                        break;
                    default:
                        Console.WriteLine("Something went wrong");
                        break;
                }

                sumTheWholeOrder = sumTheWholeOrder + oneProduct;
                Console.WriteLine($"Total: {sumTheWholeOrder} zł");

            } while (!shouldExit);


        }


    }

}
