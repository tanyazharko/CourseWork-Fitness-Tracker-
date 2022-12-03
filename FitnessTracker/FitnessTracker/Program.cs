
using System;
using System.Text.Json;
using System.Xml.Linq;

namespace FitnessTracker
{
    class Program
    {
        static void Main()
        {
            try
            {
                FitnessTracker.StartProgram();
            }
            catch (Exception)
            {
                    Console.WriteLine("Invalid data,try again");
                    FitnessTracker.StartProgram(); 
            }
        }
    }
}
