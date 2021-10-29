using System;
using static ClassLibrary1.Utilities;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public static class Engine
    {
        
        
        static string currentLogin;
        static string currentPassword;
        static string currentFirstName;
        static string currentLastName;
        static string currentAddress;
        static string currentEmail;
        static string currentPhoneNumber;
        static string currentStatus;

        
        public static void MenueForGuest()
        {
            string numberOfChoise;
            bool Exit = false;
            while (!Exit)
            {
                var guest = new Guest();
                ShowProgramTitle();
                guest.ShowUserStatus();
                guest.ShowStartMenue();
                Console.Write("Make your choice :   "); numberOfChoise = Console.ReadLine();
                switch (numberOfChoise)
                {
                    case "1":
                        {
                            Console.Write("Enter product name: "); var pName = Console.ReadLine();
                            if (SearchProductByName(pName) == null)
                                Console.WriteLine("Product with this name is absent.");
                            else SearchProductByName(pName).Display();
                            PromptToPressAnyKey();
                            break;
                        }
                    case "2":
                        {
                            ViewListOfProducts();
                            PromptToPressAnyKey();
                            break;
                        }
                    case "3":
                        {
                            guest.PromptToLogIntoAccaunt();
                            break;
                        }
                    case "4":
                        {
                            var u = guest.Registration();
                            var userList = new UserList();
                            userList.AddUser(u);
                            Console.WriteLine("User added...");
                            PromptToPressAnyKey();
                            MenueForRegisteredUsers();
                            break;
                        }
                    case "5":
                        {
                            Exit = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Uncorect menue chois.");
                            PromptToPressAnyKey();
                            break;
                        }
                }

            }

        }
        public static void MenueForRegisteredUsers()
        {
            string numberOfChoise;
            bool Exit = false;
            while (!Exit)
            {
                var regUser = new RegisteredUser(currentStatus, currentLogin, currentPassword, currentFirstName,
                                                     currentLastName, currentAddress, currentEmail, currentPhoneNumber);
                ShowProgramTitle();
                regUser.ShowUserStatus();
                regUser.ShowStartMenue();
                Console.Write("Make your choice :   "); numberOfChoise = Console.ReadLine();
                switch (numberOfChoise)
                {
                   case "1":
                       {
                           Console.Write("Enter product name: "); var pName = Console.ReadLine();
                            if (SearchProductByName(pName) == null)
                                Console.WriteLine("Product with this name is absent.");
                            else SearchProductByName(pName).Display();
                            PromptToPressAnyKey();
                           break;
                       }
                   case "2":
                       {
                           ViewListOfProducts();
                           PromptToPressAnyKey();
                           break;
                       }
                   case "3":
                       {
                           regUser.CreateNewOrder();
                           break;
                       }
                   case "4":
                       {
                           Console.Write("Input name of product: "); var pn = Console.ReadLine();
                           regUser.CancellationOfOrder(SearchProductByName(pn));
                           break;
                       }
                   case "5":
                       {
                           regUser.ChangePersonalInformation();
                           PromptToPressAnyKey();
                           break;
                       }
                   case "6":
                       {
                            regUser.ViewHistoryOfOrdersAndItStatus();
                           PromptToPressAnyKey();
                           break;
                       }
                   case "7":
                       {
                           Console.Write("Input name of product: "); var pn = Console.ReadLine();
                           regUser.SetStatusOfOrderAsReceived(SearchProductByName(pn));
                           PromptToPressAnyKey();
                           break;
                       }
                   case "8":
                       {
                           LogOutFromAccaunt();
                           MenueForGuest();
                           break;
                       }
                   case "9":
                       {
                           Exit = true;
                           break;
                       }
                   default:
                       {
                           Console.WriteLine("Uncorect menue chois.");
                           PromptToPressAnyKey();
                           break;
                       }
                   
                }
            }
        }
        public static void MenueForAdmin()
        {
            string numberOfChoise;
            bool Exit = false;
            while (!Exit)
            {
                var admin = new Admin(currentStatus, currentLogin, currentPassword, currentFirstName,
                                currentLastName, currentAddress, currentEmail, currentPhoneNumber);
                ShowProgramTitle();
                admin.ShowUserStatus();
                admin.ShowStartMenue();
                Console.Write("Make your choice :   "); numberOfChoise = Console.ReadLine();
                switch (numberOfChoise)
                {
                    case "1":
                        {
                            Console.Write("Enter product name: "); var pName = Console.ReadLine();
                            if (SearchProductByName(pName) == null)
                                Console.WriteLine("Product with this name is absent.");
                            else SearchProductByName(pName).Display();
                            PromptToPressAnyKey();
                            break;
                        }
                    case "2":
                        {
                            ViewListOfProducts();
                            PromptToPressAnyKey();
                            break;
                        }
                    case "3":
                        {
                            admin.CreateNewOrder();
                            break;
                        }
                    case "4":
                        {
                            Console.Write("Input name of product: "); var pn = Console.ReadLine();
                            admin.CancellationOfOrder(SearchProductByName(pn));
                            break;
                        }
                    case "5":
                        {
                            admin.ChangePersonalInformation();
                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("For which user show list of orders?");
                            Console.Write("First name of user : "); var fn = Console.ReadLine();
                            Console.Write("Last name of user : "); var ln = Console.ReadLine();
                            admin.ViewHistoryOfOrdersAndItStatus(fn, ln);
                            PromptToPressAnyKey();

                            break;
                        }
                    case "7":
                        {
                            admin.AddNewProduct();
                            PromptToPressAnyKey();
                            break;
                        }
                    case "8":
                        {
                            Console.Write("Input name of product: "); var pn = Console.ReadLine();
                            admin.ChangeInformationAboutTheProduct(SearchProductByName(pn));
                            break;
                        }
                    case "9":
                        {
                            Console.WriteLine("Which one order to change?");
                            Console.Write("First name of user : "); var fn = Console.ReadLine();
                            Console.Write("Last name of user : "); var ln = Console.ReadLine();
                            Console.Write("Input name of product: "); var pn = Console.ReadLine();
                            admin.ChangeTheStatusOfTheOrder(fn, ln, SearchProductByName(pn));
                            break;
                        }
                    case "10":
                        {
                            admin.Ordering();
                            PromptToPressAnyKey();
                            break;
                        }
                    case "11":
                        {
                            LogOutFromAccaunt();
                            MenueForGuest();
                            break;
                        }
                    case "12":
                        {
                            Exit = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Uncorect menue chois.");
                            PromptToPressAnyKey();
                            break;
                        }
                }
            }
        }


        private static void LogOutFromAccaunt()
        {
            currentLogin = "";
            currentPassword = "";
            currentFirstName = "";
            currentLastName = "";
            currentAddress = "";
            currentEmail = "";
            currentPhoneNumber = "";
            currentStatus = "Guest";
        }

    }

}

