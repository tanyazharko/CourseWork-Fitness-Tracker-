using System.Text.Json;

namespace FitnessTracker
{
    class Program
    {
        public static void Save<T>(List<T> values) where T : class
        {
            var fileName = typeof(T).Name;
            fileName += ".json";

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, values, options);
            }
        }

        public static List<T> GetInfo<T>() where T : class
        {
            var fileName = typeof(T).Name;
            fileName += ".json";

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && JsonSerializer.Deserialize<List<T>>(fs) is List<T> items)
                {
                    return items;
                }
                else
                {
                    return new List<T>();
                }
            }
        }

        private static string CorrectDate()
        {
            string? name = Console.ReadLine();

            if (!string.IsNullOrEmpty(name))
            {
                return name;
            }
            else
            {
                throw new ArgumentNullException("Incorrect data");
            }
        }

        private static double ParseDouble(string name)
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

        private static DateTime ParseDateTime(string value)
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

        private static DateTime ParseTime(string value)
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

        private static Food EnterEating()
        {
            Console.Write("Enter name of food: ");
            var food = CorrectDate();

            var calories = ParseDouble("calories");
            var prots = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbs = ParseDouble("carbohydates");

            var weight = ParseDouble("portion weight");
            var product = new Food(food, calories, prots, fats, carbs, weight);

            return product;
        }
       
        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("Enter name of activity:");
            var name = CorrectDate();

            var energy = ParseDouble("energy consumption per minute");

            var begin = ParseTime("time of begin");
            var end = ParseTime("time of end");

            var activity = new Activity(name, energy);
            return (begin, end, activity);
        }

        private static string GetChoose()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("F - enter a meal");
            Console.WriteLine("A - enter exercise");
            Console.WriteLine("Z - exit");
            string answer = CorrectDate();

            return answer;
        }

        static void Main()
        {
            Console.WriteLine("Enter your user name:  ");
            string userName = CorrectDate();

            WorkWithUsers user = new WorkWithUsers(userName);
            Exercise exercise = new Exercise(user.User);
            Meal meal = new Meal(user.User);

            if (user.IsNewUser)
            {
                Console.Write("Enter your name :");
                string name = CorrectDate();
                Console.Write("Enter your gener:");
                string gender = CorrectDate();
                DateTime birthDate = ParseDateTime("Birth Date"); ;
                double weight = ParseDouble("weight");
                double height = ParseDouble("height");

                user.SetNewUserData(name, gender, birthDate, weight, height);
            }

            while (true)
            {
                switch (GetChoose())
                {
                    case "F":
                        var foods = EnterEating();
                        meal.AddFood(foods);
                        break;
                    case "A":
                        var exe = EnterExercise();
                        exercise.AddExercise(exe.Activity, exe.Begin, exe.End);
                        break;
                    case "Z":
                        Environment.Exit(0);
                        break;
                }
            }     
        }
    }
}
