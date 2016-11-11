using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptikPlanner.Model
{
    class Customer
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string CprNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public int ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Group { get; set; }
        public int CommercialsSms { get; set; }
        public int CommercialsEmail { get; set; }
        public int CommercialsLetter { get; set; }
        public int DebtorType { get; set; }
        public int ForcedRefNumber { get; set; }
        public int Active { get; set; }
        public int CanEdit { get; set; }

        public Customer()
        {
            Group = 1;
            CommercialsSms = 0;
            CommercialsEmail = 0;
            CommercialsLetter = 0;
            DebtorType = 0;
            ForcedRefNumber = 0;
            Active = 1;
            CanEdit = 1;
        }


    }
}


