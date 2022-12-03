using System.Reflection;

namespace FitnessTracker
{
    public class Food
    {
        private readonly User user;
        public List<Food> Foods { get; }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydates { get; set; }
        public double Weight { get; set; }
        public double _calories;
        public Food() { }
        public Food(string name) : this(name, 0, 0, 0, 0,0) { }

        public Food(string name, double calories, double proteins, double fats, double carbohydates, double weight)
        {
            Name = !string.IsNullOrWhiteSpace(name)
               ? name
               : throw new ArgumentNullException(nameof(name));

            Calories = !(calories < 0)
            ? calories
            : throw new ArgumentException(nameof(calories));

            proteins = !(proteins < 0)
            ? proteins
            : throw new ArgumentException(nameof(proteins));

            Fats = !(fats < 0)
            ? fats
            : throw new ArgumentException(nameof(fats));

            Carbohydates = !(carbohydates < 0)
           ? carbohydates
           : throw new ArgumentException(nameof(carbohydates));

            Weight = !(weight < 0)
           ? weight
           : throw new ArgumentException(nameof(weight));

            _calories = weight * calories;
        }
    }
}
