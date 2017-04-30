namespace Cosmetics.Test.Extensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Cosmetics.Contracts;
    using Cosmetics.Engine;
    using Cosmetics.Products;
    using Common;
    using Extensions;

    internal class ExtendedCategory : Category
    {
        public ExtendedCategory(string name) : base(name)
        {
        }

        public IList<IProduct> Products
        {
            get
            {
                return products;
            }
        }
    }
}
