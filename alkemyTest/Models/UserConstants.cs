using System.Collections.Generic;

namespace alkemyTest.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "admin", EmailAddress = "admin@email.com", Password = "MyPass_w0rd", GivenName = "Adminsitrator", Surname = "Adminsitrator", Role = "Administrator" },
            new UserModel() { Username = "jespinosa", EmailAddress = "jespinosa@smail.com", Password = "jespinosa123", GivenName = "Jessica", Surname = "Espinosa", Role = "Administrator" },
            new UserModel() { Username = "vanessa_espinosa", EmailAddress = "vanessa_espinosa@smail.com", Password = "MyPass_w0rd", GivenName = "Vanessa", Surname = "Espinosa", Role = "Seller" },

        };
    }
}
