using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Calendar;
using OptikPlanner.Controller;

namespace OptikPlanner.View
{
    public interface ICalendarView
    {
        Calendar Calendar { get; }
        void SetController(CalendarViewController controller);
    }
}
