using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Product
    {
        public string PName { get; set; }
        public string PCategory { get; set; }
        public string PDescription { get; set; }
        public decimal PCost { get; set; }
        public int PCount { get; set; }

        public Product(string pName, string pGategory, string pDescription, decimal pCost, int pCount)
        {
            PName = pName;
            PCategory = pGategory;
            PDescription = pDescription;
            PCost = pCost;
            PCount = pCount;
        }

        public void Display()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Product      : {0}",PName);
            Console.WriteLine("Category     : {0}",PCategory);
            Console.WriteLine("Description  : {0}",PDescription);
            Console.WriteLine("Cost         : {0}",PCost);
            Console.WriteLine("Count        : {0}",PCount);
        }
    }
}
