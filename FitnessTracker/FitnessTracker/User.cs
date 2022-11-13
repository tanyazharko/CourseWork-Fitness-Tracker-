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
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("User name can not to be empty or null", nameof(userName));
            }

            UserName = userName;
        }

        public User(string userName, string name, string gender, DateTime birthDate, double weight, double height)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("User name can not to be empty or null", nameof(userName));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can not to be empty or null", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Gender can not to be null.", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Impossible birth Date", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Weight can not to be <= 0.", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Height can not to be <= 0", nameof(height));
            }

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
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
