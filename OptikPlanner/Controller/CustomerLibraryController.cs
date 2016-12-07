using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptikPlanner.Model;

namespace OptikPlanner.Controller
{
    class CustomerLibraryController
    {
        OptikItDbContext db = new OptikItDbContext();
        
        public static USERS GetUser()
        {
            USERS user = new USERS();
            user.US_CPRNO = "2001927891";
            user.US_USERNAME = "MyUserName";
            user.US_STAMP = 1;

            return user;
        }

        public static List<CUSTOMERS> GetCustomer()
        {
            
            CUSTOMERS customer = new CUSTOMERS();
            customer.CS_CPRNO = "20019267454";
            customer.CS_FIRSTNAME = "Børge";
            customer.CS_LASTNAME = "Jensen";
            customer.CS_ADRESS1 = "Børgevej 210";
            customer.CS_PHONEMOBILE = "28706520";
            customer.CS_EMAIL = "enemail@gmail.com";
            CUSTOMERS customer1 = new CUSTOMERS();
            customer1.CS_CPRNO = "2113926994";
            customer1.CS_FIRSTNAME = "Daniel";
            customer1.CS_LASTNAME = "Parbst";
            customer1.CS_ADRESS1 = "Danielvej 210";
            customer1.CS_PHONEMOBILE = "28706520";
            customer1.CS_EMAIL = "enemail@gmail.com";
            CUSTOMERS customer2 = new CUSTOMERS();
            customer2.CS_CPRNO = "2001916774";
            customer2.CS_FIRSTNAME = "Danny";
            customer2.CS_LASTNAME = "Nielsen";
            customer2.CS_ADRESS1 = "Dannyvej 210";
            customer2.CS_PHONEMOBILE = "28706520";
            customer2.CS_EMAIL = "enemail@gmail.com";
            CUSTOMERS customer3 = new CUSTOMERS();
            customer3.CS_CPRNO = "2001944224";
            customer3.CS_FIRSTNAME = "Andreas";
            customer3.CS_LASTNAME = "Edelmann";
            customer3.CS_ADRESS1 = "Andreasvej 210";
            customer3.CS_PHONEMOBILE = "28706520";
            customer3.CS_EMAIL = "enemail@gmail.com";

            List<CUSTOMERS> customerlist = new List<CUSTOMERS>();
            customerlist.Add(customer);
            customerlist.Add(customer1);
            customerlist.Add(customer2);
            customerlist.Add(customer3);

            return customerlist;
        }



    }
}
