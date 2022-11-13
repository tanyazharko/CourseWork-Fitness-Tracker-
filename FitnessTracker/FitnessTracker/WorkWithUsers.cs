namespace FitnessTracker
{
    public class WorkWithUsers
    {
        public List<User> Users { get; }
        public User User { get; }
        public bool IsNewUser { get; set; } = false;
        public WorkWithUsers() { }

        public WorkWithUsers(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("User name can not to be empty or null", nameof(userName));
            }

            Users = GetUsersData();

            User = Users.SingleOrDefault(u => u.UserName == userName);

            if (User == null)
            {
                User = new User(userName);
                Users.Add(User);
                IsNewUser = true;
            }
        }

        public void SetNewUserData(string name, string gender, DateTime birthDate, double weight, double height)
        {
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

            User.Name = name;
            User.Gender = gender;
            User.BirthDate = birthDate;
            User.Weight = weight;
            User.Height = height;
            Save();
        }

        private void Save()
        {
            Program.Save(Users);
        }

        private List<User> GetUsersData()
        {
            return Program.GetInfo<User>() ?? new List<User>();
        }
    }
}
