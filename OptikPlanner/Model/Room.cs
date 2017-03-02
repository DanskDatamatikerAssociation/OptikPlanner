using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptikPlanner.Model
{
    /// <summary>
    /// Room class to represent the rooms from the db
    /// </summary>
    class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; } 
        public string OpenFrom { get; set; }
        public string OpenTo { get; set; }
        public int UseForWeb { get; set; }


        public Room()
        {
            UseForWeb = 0;
        }

    }
}
