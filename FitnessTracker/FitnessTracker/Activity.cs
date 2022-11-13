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
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can not to be empty or null", nameof(name));
            }

            if (caloriesPerMinute <= 0)
            {
                throw new ArgumentException("Сalories can not to be <= 0.", nameof(caloriesPerMinute));
            }

            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }
    }
}
