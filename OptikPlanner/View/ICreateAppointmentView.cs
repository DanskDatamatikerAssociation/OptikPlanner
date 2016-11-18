using System.Windows.Forms.Calendar;
using OptikPlanner.Controller;
using OptikPlanner.Model;

namespace OptikPlanner.View

{
    public interface ICreateAppointmentView
    {
        //APTDETAILS ClickedAppointment { get; set; }
        void SetController(CreateAppointmentController controller);
    }
}