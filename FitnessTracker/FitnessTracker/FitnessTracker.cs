namespace FitnessTracker
{
    internal class FitnessTracker
    {
        public static string IsValidName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return name;
            }
            else
            {
                throw new ArgumentNullException("Incorrect data");
            }
        }

        public static double CorrectDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter your {name}: ");
                string? s = Console.ReadLine();

                if (double.TryParse(s, out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Wrong formate {name}");
                }
            }
        }

        public static DateTime CorrectDateTime(string value)
        {
            while (true)
            {
                Console.Write($"Enter {value} (dd.MM.yyyy): ");
                string? s = Console.ReadLine();

                if (DateTime.TryParse(s, out DateTime birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine($"Wrong formate {value}");
                }
            }
        }

        public static DateTime CorrectTime(string value)
        {
            while (true)
            {
                Console.Write($"Enter {value} (hh:mm:ss): ");
                string? s = Console.ReadLine();

                if (DateTime.TryParse(s, out DateTime birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine($"Wrong formate {value}");
                }
            }
        }

        public static Food EnterEating()
        {
            Console.Write("Enter name of food: ");
            string? food = Console.ReadLine();
            IsValidName(food);

            var calories = CorrectDouble("calories");
            var prots = CorrectDouble("proteins");
            var fats = CorrectDouble("fats");
            var carbs = CorrectDouble("carbohydates");

            var weight = CorrectDouble("portion weight");
            var product = new Food(food, calories, prots, fats, carbs, weight);

            return product;
        }

        public static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("Enter name of activity:");
            string? name = Console.ReadLine();
            IsValidName(name);

            var energy = CorrectDouble("energy consumption per minute");

            var begin = CorrectTime("time of begin");
            var end = CorrectTime("time of end");

            var activity = new Activity(name, energy);
            return (begin, end, activity);
        }

        public static void StartProgram()
        {
            Console.Write("Enter your username:  ");
            string? userName = Console.ReadLine();
            IsValidName(userName);  

            WorkWithUsers user = new WorkWithUsers(userName);
            Exercise exercise = new Exercise(user.User);
            Meal meal = new Meal(user.User);

            if (user.IsNewUser)
            {
                WorkWithUsers.CreateANewUser(user);
            }

            ConsoleDevice consoleDevice = new ConsoleDevice();
            consoleDevice.Device(userName, exercise, meal);
        }
    }
}
