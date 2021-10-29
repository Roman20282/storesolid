using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public static class Utilities
    {
        public static void ShowProgramTitle()
        {
            Console.Clear();
            Console.WriteLine("**********************************OnlineStoreApplication******************************************************");
            Console.WriteLine("==============================================================================================================");
        }
        public static Product SearchProductByName(string pName)
        {
            Product p = null;
            var products = new ProductList();
            foreach (var g in products)
            {
                if (g.PName == pName)
                {
                    p = g;
                    break;
                }

            }
            return p;
        }

        public static void ViewListOfProducts()
        {
            var products = new ProductList();
            foreach (var p in products)
            {
                p.Display();
            }
        }

        public static string StatusOfUserCheking(string login, string pword)
        {
            var st = "Guest";

            var users = new UserList();
            foreach (var u in users)
            {
                if (u.Login == login && u.Password == pword)
                {
                    st = u.Status;
                    break;

                }
            }
            return st;
        }

        public static RegisteredUser FindUser(string login, string pword)
        {
            RegisteredUser u = null;

            var users = new UserList();
            foreach (var regUser in users)
            {
                if (regUser.Login == login && regUser.Password == pword)
                {
                    u = (RegisteredUser)regUser;
                    break;
                }
            }
            return u;
        }

        
        public static Tuple<string, string, string, string, string, string,string > PersonalData()
        {
            string lg;
            string pw;
            string fn;
            string ln;
            string ad;
            string em;
            string pn;

            Console.Clear();
            Console.Write("Login       : "); lg = Console.ReadLine();
            Console.Write("Password    : "); pw = Console.ReadLine();
            Console.Write("First Name  : "); fn = Console.ReadLine();
            Console.Write("Last Name   : "); ln = Console.ReadLine();
            Console.Write("Adress      : "); ad = Console.ReadLine();
            Console.Write("e-mail      : "); em = Console.ReadLine();
            Console.Write("Phone Number: "); pn = Console.ReadLine();

            return Tuple.Create(lg, pw, fn, ln, ad, em, pn);
        }
        public static void DataForCreationInstance(Tuple<string, string, string, string, string, string, string> data)
        {
            _ = data.Item1;
            _ = data.Item2;
            _ = data.Item3;
            _ = data.Item4;
            _ = data.Item5;
            _ = data.Item6;
            _ = data.Item7;
        }

        public static void PromptToPressAnyKey()
        {
            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
