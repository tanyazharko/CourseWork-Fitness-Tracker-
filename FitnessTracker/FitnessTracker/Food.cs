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
        public Food() { }

        public Food(string name) : this(name, 0, 0, 0, 0,0) { }

        public Food(string name, double calories, double proteins, double fats, double carbohydates, double weight)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can not to be empty or null", nameof(name));
            }

            if (calories < 0)
            {
                throw new ArgumentException("Сalories can not to be < 0.", nameof(calories));
            }

            if (proteins < 0)
            {
                throw new ArgumentException("Proteins can not to be < 0", nameof(proteins));
            }

            if (fats < 0)
            {
                throw new ArgumentException("Fats can not to be < 0", nameof(fats));
            }

            if (carbohydates < 0)
            {
                throw new ArgumentException("Carbohydates can not to be < 0", nameof(carbohydates));
            }

            if (weight < 0)
            {
                throw new ArgumentException("Carbohydates can not to be < 0", nameof(weight));
            }

            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydates = carbohydates / 100.0;
            Weight = weight;    
        }
    }
}
