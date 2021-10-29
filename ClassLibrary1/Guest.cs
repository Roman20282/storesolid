using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    class Guest : User
    {
        public Guest() : base("Guest", "", "", "", "", "", "", "") { }

        public override void DisplayUserData()
        {
            Console.WriteLine("Status     : Guest");
            Console.WriteLine("First name : - ");
            Console.WriteLine("Last  name : - ");
        }
        public override void ShowUserStatus()
        {
            Console.WriteLine($"                                    Your status is 'Guest'");
        }
        public override void ShowStartMenue()
        {
            Console.WriteLine("==============================================================================================================\n");
            Console.WriteLine("1) Search product by name    2) View List of products    3) Log into account     4) Registration     5) Exit");
        }
        public void PromptToLogIntoAccaunt()
        {
           
                Console.Write("Login   : "); var login = Console.ReadLine();
                Console.Write("Password: "); var password = Console.ReadLine();
                if (Utilities.StatusOfUserCheking(login, password) == "Admin")
                    Engine.MenueForAdmin();
                else if (Utilities.StatusOfUserCheking(login, password) == "Registered User")
                    Engine.MenueForRegisteredUsers();
                else
                {
                    Console.WriteLine("User whith this login and password is absent. Your status 'Guest'.");
                    Utilities.PromptToPressAnyKey();
                    Engine.MenueForGuest();
                }
        }
        public RegisteredUser Registration()
        {
            bool ok = false;
            RegisteredUser regUser = null;
            do
            {
                var data = Utilities.PersonalData();
                if (Utilities.FindUser(data.Item1, data.Item2) != null)
                {
                    Console.WriteLine("User whith this login already exist.");
                    Utilities.PromptToPressAnyKey();
                }
                else
                {
                    Utilities.DataForCreationInstance(data);

                    regUser = new RegisteredUser("Registered User",data.Item1, data.Item2, data.Item3, data.Item4, data.Item5, data.Item6, data.Item7);
                    ok = true;
                }
            } while (!ok);
            return regUser;
        }
    }
}
