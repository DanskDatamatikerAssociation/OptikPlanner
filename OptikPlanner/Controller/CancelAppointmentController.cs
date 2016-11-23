using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Calendar;
using OptikPlanner.Model;
using OptikPlanner.View;

namespace OptikPlanner.Controller
{
    public class CancelAppointmentController
    {
        private OptikItDbContext _db;
        private ICancelAppointmentView _view;

        public CancelAppointmentController(ICancelAppointmentView view)
        {
            _view = view;
            _view.SetController(this);
        }


        public void DeleteAppointment(APTDETAILS appointment)
        {
            using (_db = new OptikItDbContext())
            {
                var removeQuery = from a in _db.APTDETAILS where a.APD_STAMP == appointment.APD_STAMP select a;
                foreach (var a in removeQuery) _db.APTDETAILS.Remove(a);

                try
                {
                    _db.SaveChanges();

                }
                catch (Exception ex)
                {
                    
                }
            }
        }



    }
}
