using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptikPlanner.Model;

namespace OptikPlanner.Misc
{
    public enum Reason
    {
        IkkeMødtOp,
        AflystTelefonisk,
        Aflyst
    }

   public class Cancellation
    {

        public Reason Reason { get; set; }
        public USERS Users { get; set; }


        public Cancellation(Reason reason, USERS users)
        {
            Reason = reason;
            Users = users;
        }
    }
}
