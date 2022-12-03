using System.Reflection;

namespace FitnessTracker
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CaloriesPerMinute { get; set; }
        public Activity() { }

        public Activity(string name, double caloriesPerMinute)
        {           
            Name = !string.IsNullOrWhiteSpace(name)
               ? name
               : throw new ArgumentNullException(nameof(name));

            CaloriesPerMinute = !(caloriesPerMinute <= 0)
            ? caloriesPerMinute
            : throw new ArgumentException(nameof(caloriesPerMinute));
        }
    }
}
