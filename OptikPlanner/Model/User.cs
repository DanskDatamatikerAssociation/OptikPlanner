using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptikPlanner.Model
{
    /// <summary>
    /// User class to represent the users from the db
    /// </summary>
    class User
    {
        public int Id { get; set; }
        public string Initials { get; set; }
        public string Username { get; set; }
        public string CprNumber { get; set; }
        public string Adress { get; set; }
        public int ZipCode { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Color Color { get; set; }
        
        
    }
}