using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptikPlanner.Model;

namespace OptikPlanner.Controller
{
    /// <summary>
    /// Manages the connection between the CustomerLibrary and the model classes mirrored from db
    /// </summary>
    class CustomerLibraryController
    {
        private OptikItDbContext db;

        /// <summary>
        /// Gets all users / employees from db
        /// </summary>
        /// <returns></returns>
        public List<USERS> GetUser()
        {
            using (db = new OptikItDbContext())
            {
                var users = from u in db.USERS select u;
                return users.ToList();
            }
        }

        /// <summary>
        /// creates new specified customer in db
        /// </summary>
        /// <param name="customer"></param>
        public void PostCustomer(CUSTOMERS customer)
        {
            using (db = new OptikItDbContext())
            {
                try
                {
                    db.CUSTOMERS.Add(customer);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName,
                                validationError.ErrorMessage);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the next customer from db by ID
        /// </summary>
        /// <returns></returns>
        public int GetNextCustomerId()
        {
            using (db = new OptikItDbContext())
            {
                List<CUSTOMERS> customers;
                try
                {
                    customers = GetCustomers();

                    int currentId = customers.Last().CS_STAMP;

                    return currentId + 1;
                }
                catch (DbException ex)
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// edits specified customer in db
        /// </summary>
        /// <param name="customer"></param>
        public void PutCustomer(CUSTOMERS customer)
        {
            using (db = new OptikItDbContext())
            {
                var appointmentToEditQuery = from a in db.CUSTOMERS where a.CS_CPRNO == customer.CS_CPRNO select a;
                foreach (var a in appointmentToEditQuery)
                {
                    a.CS_CPRNO = customer.CS_CPRNO;
                    a.CS_FIRSTNAME = customer.CS_FIRSTNAME;
                    a.CS_LASTNAME = customer.CS_LASTNAME;
                    a.CS_ADRESS1 = customer.CS_ADRESS1;
                    a.CS_PHONEMOBILE = customer.CS_PHONEMOBILE;
                    a.CS_EMAIL = customer.CS_EMAIL;
                }
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {

                }
            }
        }

        /// <summary>
        /// Deletes specified custoemr from db
        /// </summary>
        /// <param name="customer"></param>
        public void DeleteCustomer(CUSTOMERS customer)
        {
            using (db = new OptikItDbContext())
            {
                var removeQuery = from a in db.CUSTOMERS where a.CS_STAMP == customer.CS_STAMP select a;
                foreach (var a in removeQuery) db.CUSTOMERS.Remove(a);

                try
                {
                    db.SaveChanges();

                }
                catch (Exception)
                {

                }
            }
        }

        /// <summary>
        /// Gets all customers from db
        /// </summary>
        /// <returns></returns>
        public List<CUSTOMERS> GetCustomers()
        {
            using (db = new OptikItDbContext())
            {
                var customers = from c in db.CUSTOMERS select c;
                return customers.ToList();
            }
        }



    }
}
