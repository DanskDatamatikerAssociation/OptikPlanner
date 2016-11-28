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
    //Skal kun håndtere logik der indebærer models. 
    public class CalendarViewController
    {
        OptikItDbContext db = new OptikItDbContext();
        private ICalendarView _view;

        public CalendarViewController(ICalendarView view)
        {
            _view = view;
            view.SetController(this);
        }
        public void PostAppointment()
        {
            
        }
        }
    }

