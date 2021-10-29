using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    class Admin : User
    {
        public Admin(string status, string login, string password, string firstName, string lastName, string adress, string eMail, string phoneNumber)
                    : base("Admin", login, password, firstName, lastName, adress, eMail, phoneNumber)
        { }

        public override void ShowUserStatus()
        {
            Console.WriteLine($"                                    Your status is 'Admin'");
        }
        public override void ShowStartMenue()
        {
            Console.WriteLine("===================================================================================================\n");
            Console.WriteLine("1) Search product by name                                2) View List of products");
            Console.WriteLine("3) Create a new order                                    4) Cancellation of order");
            Console.WriteLine("5) Viewing and changing personal information of users;   6) View the history of orders and it status");
            Console.WriteLine("7) Adding a new product(name,category,description,cost)  8) Change of information about the product");
            Console.WriteLine("9) Change the status of the order                       10) Ordering");
            Console.WriteLine("11) Sign out of the account                             12) Exit");
            Console.WriteLine("===================================================================================================\n");
        }

        public void ChangePersonalInformation()
        {
            Console.Write("Input login of user: "); var login = Console.ReadLine();
            var users = new UserList();
            foreach (var u in users)
            {
                if (u.Login == login)
                {
                    u.DisplayUserData(); 
                    break;
                }
            }
            
            Console.Write("Do you wont change something?  y/n ");
            if (Console.ReadLine() != "y") Engine.MenueForAdmin();
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

                Console.WriteLine("Personal data chenged...");
                Utilities.PromptToPressAnyKey();

            }

        }
        public void ChangeTheStatusOfTheOrder(string fn, string ln, Product p)
        {
            var orderList = new OrderList();
            var order = orderList.FindOrder(fn, ln, p.PName);
            if (order == null)
            {
                Console.WriteLine("This order not exist.");
                Utilities.PromptToPressAnyKey();
            }
            else
            {
                order.Display();
                Console.Write("Set status as : "); order.OrderStatus = Console.ReadLine();
                Console.WriteLine("Status chenged.");
                Utilities.PromptToPressAnyKey();
            }
        }
        public void ViewHistoryOfOrdersAndItStatus(string fn, string ln)
        {
            var orderList = new OrderList();
            bool f = false;
            foreach (var order in orderList)
            {
                if (order.FirstName == fn && order.LastName == ln)
                {
                    order.Display();
                    f = true;
                }

            }
            if (!f) Console.WriteLine("List of orders for this user is empty.");
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
            else Engine.MenueForAdmin();
        }
        public void CancellationOfOrder(Product p)
        {
            var orderList = new OrderList();
            foreach (var order in orderList)
            {
                if (order.FirstName == FirstName && order.LastName == LastName && order.PName == p.PName)
                    orderList.RemoveOrder(order);
            }
        }
        public void Ordering()
        {
            var orderList = new OrderList();
            bool f = false;

            foreach (var order in orderList)
            {
                if (order.OrderStatus == "New")
                {
                    order.OrderStatus = "Complected and Sent";
                    f = true;
                }
                else if (order.OrderStatus == "Received")
                {
                    order.OrderStatus = "Payment received";
                }
                else if (order.OrderStatus == "Payment received" && (DateTime.Now - order.DateOfCreation).TotalDays > 14)
                {
                    order.OrderStatus = "Completed";
                }
                else if (order.OrderStatus == "Canceled") order.OrderStatus = "Canceled by user";
                order.Display();
            }
            if (!f) Console.WriteLine("List of new orders is empty.");
        }
        public void AddNewProduct()
        {
            string pn;
            string pc;
            string pd;
            decimal c;
                int q;
            Product p;

            bool ok = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Input product data :");
                Console.WriteLine("------------------------------");
                Console.Write("Product  name: "); pn = Console.ReadLine();
                Console.Write("Category     : "); pc = Console.ReadLine();
                Console.Write("Description  : "); pd = Console.ReadLine();
                Console.Write("Cost         : "); c = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Count        : "); q = Convert.ToInt32(Console.ReadLine());
                if (Utilities.SearchProductByName(pn) == null) ok = true;
                else
                {
                    Console.WriteLine("Product with this name exist.");
                    Utilities.PromptToPressAnyKey();
                }
            } while (!ok);
            var products = new ProductList();
            p = new Product(pn, pc, pd, c, q);
            products.AddProduct(p);
        }
        public void ChangeInformationAboutTheProduct(Product product)
        {
            product.Display();
            Console.Write("Do you wont change something?  y/n ");
            if (Console.ReadLine() != "y") Engine.MenueForAdmin();
            else
            {
                Console.Write("-------------------------------------------\n");
                Console.Write("Product name: "); var pn = Console.ReadLine();
                Console.Write("Category    : "); var pc = Console.ReadLine();
                Console.Write("Description : "); var pd = Console.ReadLine();
                Console.Write("Cost        : "); var c = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Count       : "); var q = Convert.ToInt32(Console.ReadLine());
                product.PName = pn;
                product.PCategory = pc;
                product.PDescription = pd;
                product.PCost = c;
                product.PCount = q;
                Console.WriteLine("Product data chenged...");
                Utilities.PromptToPressAnyKey();

            }
        }
    }
}

