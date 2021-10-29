using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    class Order
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string OrderStatus { get; set; }
        public DateTime DateOfCreation { get; private set; }
        public string PName { get; private set; }
        public decimal PCost { get; private set; }
        public int PQuntity { get; private set; }
        public decimal TotalSum { get; private set; }

        public Order(string fn, string ln, string orderStatus, DateTime ddmmyy, string pn, decimal c, int q)
        {
            FirstName = fn;
            LastName = ln;
            
            DateOfCreation = ddmmyy;
            PName = pn;
            PCost = c;
            PQuntity = q;
            TotalSum = q * c;
            OrderStatus = orderStatus;

        }

        public void Display()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("First Name  : {0}", FirstName);
            Console.WriteLine("Last Name   : {0}", LastName);
            Console.WriteLine("Date        : {0}", DateOfCreation);
            Console.WriteLine("Product     : {0}", PName);
            Console.WriteLine("Cost        : {0}", PCost);
            Console.WriteLine("Quntity     : {0}", PQuntity);
            Console.WriteLine("Total Sum   : {0}", TotalSum);
            Console.WriteLine("Status      : {0}", OrderStatus);
        }


    }
}
