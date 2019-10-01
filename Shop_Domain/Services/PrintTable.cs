using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_Domain.Services
{
    public class PrintTable
    {
        private readonly List<Product> _products = new List<Product>();

        public PrintTable(List<Product> product)
        {
            _products = product;

        }


    }
}
