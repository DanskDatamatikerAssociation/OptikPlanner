using System.Windows.Forms.Calendar;
using OptikPlanner.Controller;

namespace OptikPlanner.View

{
    public interface IAppointmentView
    {
        Calendar Calendar { get; }

        void SetController(CreateAppointmentController controller);
    }
}