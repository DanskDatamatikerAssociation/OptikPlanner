using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptikPlanner.Model
{
    /// <summary>
    /// Appointment class to represent appointments from the db
    /// </summary>
    class Appointment
    {

        public int Id { get; set; }
        public int Calendar { get; set; }
        public int User { get; set; }
        public Room Room { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public Customer Customer { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public string Description { get; set; }



    }
    
}
