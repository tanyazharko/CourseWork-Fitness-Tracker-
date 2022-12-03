namespace FitnessTracker
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get { return GetAge(BirthDate); } }
        public double Weight { get; set; }
        public double Height { get; set; }
        public User() { }

        public User(string userName)
        {
            UserName = !string.IsNullOrWhiteSpace(userName)
                ? userName
                : throw new ArgumentNullException(nameof(userName));
        }

        public User(string userName, string name, string gender, DateTime birthDate, double weight, double height)
        {
            UserName = !string.IsNullOrWhiteSpace(userName)
               ? userName
               : throw new ArgumentNullException(nameof(userName));

            Name = !string.IsNullOrWhiteSpace(name)
               ? name
               : throw new ArgumentNullException(nameof(name));

            Gender = !string.IsNullOrWhiteSpace(gender)
            ? gender
            : throw new ArgumentNullException(nameof(gender));

            BirthDate = !(birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            ? birthDate
            : throw new ArgumentException(nameof(birthDate));

            Weight = !(weight <= 0)
            ? weight
            : throw new ArgumentException(nameof(weight));

            Height = !(height <= 0)
            ? height
            : throw new ArgumentException(nameof(height));
        }

        private static int GetAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;

            if (birthDate.AddYears(age) > today)
            {
                age--;
            }

            return age;
        }
    }
}
