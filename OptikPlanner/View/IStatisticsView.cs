using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptikPlanner.Controller;

namespace OptikPlanner.View
{
    /// <summary>
    /// interface for StatisticsView
    /// </summary>
    public interface IStatisticsView
    {
         void SetController(StatisticsViewController controller);
    }
}
