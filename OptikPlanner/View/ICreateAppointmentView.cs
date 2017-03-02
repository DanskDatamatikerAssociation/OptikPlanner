using System.Windows.Forms.Calendar;
using OptikPlanner.Controller;
using OptikPlanner.Model;

namespace OptikPlanner.View

{
    /// <summary>
    /// interface for CreateAppointmentView
    /// </summary>
    public interface ICreateAppointmentView
    {
        //APTDETAILS ClickedAppointment { get; set; }
        void SetController(CreateAppointmentController controller);
    }
}