using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class UserList : IEnumerable<User>
    {
        public IList<User> RegisteredUsers { get; private set; }

        public UserList()
        {
            RegisteredUsers = new List<User>
            {
                new RegisteredUser("Registered User", "Login1",  "Password1",  "firstName1",  "lastName1",  "address1",  "email1",  "phoneNumber1"),
                new RegisteredUser("Registered User", "Login2",  "Password2",  "firstName2",  "lastName2",  "address2",  "email2",  "phoneNumber2"),
                new RegisteredUser("Registered User", "Login3",  "Password3",  "firstName3",  "lastName3",  "address3",  "email3",  "phoneNumber3"),
                new RegisteredUser("Registered User", "Login4",  "Password4",  "firstName4",  "lastName4",  "address4",  "email4",  "phoneNumber4"),
                new RegisteredUser("Registered User", "Login5",  "Password5",  "firstName5",  "lastName5",  "address5",  "email5",  "phoneNumber5"),
                new RegisteredUser("Registered User", "Login6",  "Password6",  "firstName6",  "lastName6",  "address6",  "email6",  "phoneNumber6"),
                new RegisteredUser("Registered User", "Login7",  "Password7",  "firstName7",  "lastName7",  "address7",  "email7",  "phoneNumber7"),
                new RegisteredUser("Registered User", "Login8",  "Password8",  "firstName8",  "lastName8",  "address8",  "email8",  "phoneNumber8"),
                new RegisteredUser("Registered User", "Login9",  "Password9",  "firstName9",  "lastName9",  "address9",  "email9",  "phoneNumber9"),
                new RegisteredUser("Registered User", "Login10", "Password10", "firstName10", "lastName10", "address10", "email10", "phoneNumber10"),
                new RegisteredUser("Registered User", "Login11", "Password11", "firstName11", "lastName11", "address11", "email11", "phoneNumber11"),
                new RegisteredUser("Registered User", "Login12", "Password12", "firstName12", "lastName12", "address12", "email12", "phoneNumber12"),
                new RegisteredUser("Registered User", "Login13", "Password13", "firstName13", "lastName13", "address13", "email13", "phoneNumber13"),
                new RegisteredUser("Registered User", "Login14", "Password14", "firstName14", "lastName14", "address14", "email14", "phoneNumber14"),
                new RegisteredUser("Registered User", "Login15", "Password15", "firstName15", "lastName15", "address15", "email15", "phoneNumber15"),
                new RegisteredUser("Registered User", "Login16", "Password16", "firstName16", "lastName16", "address16", "email16", "phoneNumber16"),
                new RegisteredUser("Registered User", "Login17", "Password17", "firstName17", "lastName17", "address17", "email17", "phoneNumber17"),
                new RegisteredUser("Registered User", "Login18", "Password18", "firstName18", "lastName18", "address18", "email18", "phoneNumber18"),
                new RegisteredUser("Registered User", "Login20", "Password20", "firstName20", "lastName20", "address20", "email20", "phoneNumber20"),
                          new Admin("Admin", "aLogin1", "aPassword1", "aFirstName1", "aLastName1", "aAddress1", "aEmail1",  "aPhoneNumber1"),
                          new Admin("Admin", "aLogin2", "aPassword2", "aFirstName2", "aLastName2", "aAddress2", "aEmail2",  "aPhoneNumber2"),
                          new Admin("Admin", "aLogin3", "aPassword3", "aFirstName3", "aLastName3", "aAddress3", "aEmail3",  "aPhoneNumber3"),
                          new Admin("Admin", "aLogin4", "aPassword4", "aFirstName4", "aLastName4", "aAddress4", "aEmail4",  "aPhoneNumber4"),
                          new Admin("Admin", "aLogin5", "aPassword5", "aFirstName5", "aLastName5", "aAddress5", "aEmail5",  "aPhoneNumber5"),
            };
        }
        

        internal void AddUser(RegisteredUser u)
        {
            RegisteredUsers.Add(u);
        }

        internal void RemoveUser(RegisteredUser u)
        {
            RegisteredUsers.Remove(u);
        }

        public IEnumerator<User> GetEnumerator()
        {
            return RegisteredUsers.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return RegisteredUsers.GetEnumerator();
        }
    }
}


