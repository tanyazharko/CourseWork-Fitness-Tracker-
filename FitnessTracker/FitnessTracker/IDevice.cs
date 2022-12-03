using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker
{
    internal interface IDevice
    {
       void Device(string userName, Exercise exercise, Meal meal);
    }
}
