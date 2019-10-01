using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_Domain
{
    public interface IPrintTable
    {
        Product CreateProduct(string messageName, string messagePrice, string errorMessage);
    }
}
