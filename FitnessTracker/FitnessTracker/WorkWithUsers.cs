using System.Reflection;
using System.Xml.Linq;

namespace FitnessTracker
{
    public class WorkWithUsers : BaseSave
    {
        public List<User> Users { get; }
        public User User { get; set; }
        public bool IsNewUser { get; set; } = false;
        public WorkWithUsers() { }

        public WorkWithUsers(string userName)
        {
            Users = !string.IsNullOrWhiteSpace(userName)
              ? GetUsersData()
              : throw new ArgumentNullException(nameof(userName));

            User = Users.SingleOrDefault(u => u.UserName == userName);

            if (User == null)
            {
                User = new User(userName);
                Users.Add(User);
                IsNewUser = true;
            }
        }

        public static WorkWithUsers CreateANewUser(WorkWithUsers newUser)
        {
            Console.Write("Enter your name: ");
            string? name = Console.ReadLine();
            FitnessTracker.IsValidName(name);
           
            Console.Write("Enter your gener: ");
            string? gender = Console.ReadLine();
            FitnessTracker.IsValidName(gender);
            
            DateTime birthDate = FitnessTracker.CorrectDateTime("Birth Date"); ;
            double weight = FitnessTracker.CorrectDouble("Weight");
            double height = FitnessTracker.CorrectDouble("Height");

            newUser.SetNewUserData(name, gender, birthDate, weight, height);

            return newUser;
        }

        public void SetNewUserData(string name, string gender, DateTime birthDate, double weight, double height)
        {
            User.Name = !string.IsNullOrWhiteSpace(name)
               ? name
               : throw new ArgumentNullException(nameof(name));

            User.Gender = !string.IsNullOrWhiteSpace(gender)
            ? gender
            : throw new ArgumentNullException(nameof(gender));

            User.BirthDate = !(birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            ? birthDate
            : throw new ArgumentException(nameof(birthDate));

            User.Weight = !(weight <= 0)
            ? weight
            : throw new ArgumentException(nameof(weight));

            User.Height = !(height <= 0)
            ? height
            : throw new ArgumentException(nameof(height));
           
            Save();
        }

        private void Save()
        {
            Save(Users);
        }

        private List<User> GetUsersData()
        {
            return GetInfo<User>() ?? new List<User>();
        }
    }
}
