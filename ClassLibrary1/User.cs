using System;

namespace ClassLibrary1
{
    public abstract class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }

        protected User() { }
        protected User(string status, string login, string password, string firstName, string lastName,
                        string adress, string eMail, string phoneNumber) : this()
        {
            Status = status;
            Login = login;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Adress = adress;
            EMail = eMail;
            PhoneNumber = phoneNumber;
        }

        public virtual void DisplayUserData()
        {
            Console.WriteLine("Status        : {0}", Status);
            Console.WriteLine("Login         : {0}", Login);
            Console.WriteLine("Password      : {0}", Password);
            Console.WriteLine("First name    : {0}", FirstName);
            Console.WriteLine("Last name     : {0}", LastName);
            Console.WriteLine("Adress        : {0}", Adress);
            Console.WriteLine("E-Mail        : {0}", EMail);
            Console.WriteLine("Phone  number : {0}", PhoneNumber);
        }



        public abstract void ShowUserStatus();
        public abstract void ShowStartMenue();
       



    }
}
