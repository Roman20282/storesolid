using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class RegisteredUser : User
    {
        public RegisteredUser(string status, string login, string password, string firstName, string lastName, string adress, string eMail, string phoneNumber)
                            : base("Registered User", login, password, firstName, lastName, adress, eMail, phoneNumber)
        { }

        public override void ShowUserStatus()
        {
            Console.WriteLine($"                                    Your status is 'Registered User'");
        }
        public override void ShowStartMenue()
        {
            Console.WriteLine("===================================================================================================\n");
            Console.WriteLine("1) Search product by name                            2) View List of products");
            Console.WriteLine("3) Create a new order                                4) Cancellation of order");
            Console.WriteLine("5) Change of personal information;                   6) View the history of orders and it status");
            Console.WriteLine("7) Set the status of the order \"Received\"            8) Sign out of the account");
            Console.WriteLine("                                         9) Exit");
            Console.WriteLine("===================================================================================================\n");
        }

        public void ChangePersonalInformation()
        {
            
            Console.WriteLine("Your personal information: ");
            DisplayUserData();
            Console.Write("Do you wont change something?  y/n ");
            if (Console.ReadLine() != "y") Engine.MenueForRegisteredUsers();
            else
            {
                Console.Write("-------------------------------------------\n");
                Console.Write("First Name  : "); var fn = Console.ReadLine();
                Console.Write("Last Name   : "); var ln = Console.ReadLine();
                Console.Write("Adress      : "); var ad = Console.ReadLine();
                Console.Write("e-mail      : "); var em = Console.ReadLine();
                Console.Write("Phone Number: "); var pn = Console.ReadLine();
                FirstName = fn;
                LastName = ln;
                Adress = ad;
                EMail = em;
                PhoneNumber = pn;

                Console.WriteLine("Your personal data chenged...");

            }

        }
        public void SetStatusOfOrderAsReceived(Product p)
        {
            var orderList = new OrderList();
            var order = orderList.FindOrder(FirstName, LastName, p.PName);

            order.OrderStatus = "Resived";
        }
        public void ViewHistoryOfOrdersAndItStatus()
        {
            var orderList = new OrderList();
            bool f = false;
            foreach (var order in orderList)
            {
                if (order.FirstName == FirstName && order.LastName == LastName)
                {
                    order.Display();
                    f = true;
                }

            }
            if (!f) Console.WriteLine("List of orders is empty.");
        }
        public void CreateNewOrder()
        {
            bool f = false;
            string pn;
            Product p;
            int q;
            do
            {
                Console.Clear();
                Console.Write("What product do you wont to bay? Product Name: "); pn = Console.ReadLine();
                p = Utilities.SearchProductByName(pn);
                if (p == null)
                {
                    Console.WriteLine("This product in store is absent.");
                    Utilities.PromptToPressAnyKey();
                }
                else f = true;
            } while (!f);

            f = false;
            do
            {
                Console.Clear();
                Console.WriteLine($"You wont to bay product: {pn}");
                Console.Write("How many? N = "); q = Convert.ToInt32(Console.ReadLine());
                if (q > p.PCount)
                {
                    Console.WriteLine($"Only {p.PCount} available.");
                    Utilities.PromptToPressAnyKey();
                }
                else f = true;
            } while (!f);

            var order = new Order(FirstName, LastName, "New", DateTime.Now, pn, p.PCost, q);

            Console.Clear();
            Console.WriteLine("Your order:"); order.Display();
            Console.Write("Add this order to order list?  y/n  ");
            if (Console.ReadLine() == "y")
            {
                var orderList = new OrderList();
                orderList.AddOrder(order);
            }
            else Engine.MenueForRegisteredUsers();
        }
        public void CancellationOfOrder(Product p)
        {
            var orderList = new OrderList();
            foreach (var order in orderList)
            {
                if (order.FirstName == FirstName && order.LastName == LastName && order.PName == p.PName)
                {
                    order.OrderStatus = "Canceled";
                    
                }
                    
            }
        }


    }
}

