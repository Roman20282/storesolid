using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class ProductList : IEnumerable<Product>
    {
        public IList<Product> products { get; set; }
        public ProductList()
        {
           products = new List<Product>
           {
               new Product("pName1",   "pCategory1",   "pDescription1",   10,  1),
               new Product("pName2",   "pCategory1",   "pDescription2",   20,  2),
               new Product("pName3",   "pCategory1",   "pDescription3",   30,  3),
               new Product("pName4",   "pCategory1",   "pDescription4",   40,  4),
               new Product("pName5",   "pCategory1",   "pDescription5",   50,  5),

               new Product("pName6",   "pCategory2",   "pDescription6",   60,  1),
               new Product("pName7",   "pCategory2",   "pDescription7",   70,  2),
               new Product("pName8",   "pCategory2",   "pDescription8",   80,  3),
               new Product("pName9",   "pCategory2",   "pDescription9",   90,  4),
               new Product("pName10",  "pCategory2",   "pDescription10", 100,  5),

               new Product("pName11",  "pCategory3",  "pDescription11",  110,  1),
               new Product("pName12",  "pCategory3",  "pDescription12",  120,  2),
               new Product("pName13",  "pCategory3",  "pDescription13",  130,  3),
               new Product("pName14",  "pCategory3",  "pDescription14",  140,  4),
               new Product("pName15",  "pCategory3",  "pDescription15",  150,  5),

               new Product("pName16",  "pCategory4",  "pDescription16",  160,  1),
               new Product("pName17",  "pCategory4",  "pDescription17",  170,  2),
               new Product("pName18",  "pCategory4",  "pDescription18",  180,  3),
               new Product("pName19",  "pCategory4",  "pDescription19",  190,  4),
               new Product("pName20",  "pCategory4",  "pDescription20",  200,  5),

               new Product("pName21",  "pCategory5",  "pDescription20",  210,  1),
               new Product("pName22",  "pCategory5",  "pDescription20",  220,  2),
               new Product("pName23",  "pCategory5",  "pDescription20",  230,  3),
               new Product("pName24",  "pCategory5",  "pDescription20",  240,  4),
               new Product("pName25",  "pCategory5",  "pDescription20",  250,  5),

           };
        }

        internal void AddProduct(Product p)
        {
            products.Add(p);
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return products.GetEnumerator();
        }
    }
}

