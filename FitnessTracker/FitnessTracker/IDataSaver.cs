using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FitnessTracker
{
    internal interface IDataSaver
    {
        void Save<T>(List<T> item) where T : class;
        List<T> GetInfo<T>() where T : class;
    }
}
