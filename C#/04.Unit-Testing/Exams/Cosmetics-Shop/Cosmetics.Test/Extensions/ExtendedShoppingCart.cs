using Cosmetics.Contracts;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Test.Extensions
{
    internal class ExtendedShoppingCart : ShoppingCart
    {
        public IList<IProduct> Products
        {
            get
            {
                return products;
            }
        }
    }
}
