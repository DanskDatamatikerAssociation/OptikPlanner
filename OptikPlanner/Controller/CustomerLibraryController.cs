﻿using System;
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
        
        public USERS GetUser()
        {
            USERS user = new USERS();
            user.US_CPRNO = "2001927891";
            user.US_USERNAME = "MyUserName";
            user.US_STAMP = 1;

            return user;
        }

        public CUSTOMERS GetCustomer()
        {
            CUSTOMERS customer = new CUSTOMERS();
            customer.CS_CPRNO = "2001926754";
            customer.CS_FIRSTNAME = "Børge";
            customer.CS_LASTNAME = "Jensen";
            
            return customer;
        }



    }
}
