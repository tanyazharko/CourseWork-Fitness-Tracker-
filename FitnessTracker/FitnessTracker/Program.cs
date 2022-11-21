
using System;
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

        private static double CorrectDouble(string name)
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

        private static DateTime CorrectDateTime(string value)
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

        private static DateTime CorrectTime(string value)
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

            var calories = CorrectDouble("calories");
            var prots = CorrectDouble("proteins");
            var fats = CorrectDouble("fats");
            var carbs = CorrectDouble("carbohydates");

            var weight = CorrectDouble("portion weight");
            var product = new Food(food, calories, prots, fats, carbs, weight);

            return product;
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("Enter name of activity:");
            var name = CorrectDate();

            var energy = CorrectDouble("energy consumption per minute");

            var begin = CorrectTime("time of begin");
            var end = CorrectTime("time of end");

            var activity = new Activity(name, energy);
            return (begin, end, activity);
        }

        private static string GetChoose()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("F - enter a meal");
            Console.WriteLine("A - enter exercise");
            Console.WriteLine("E - view a list of your workouts");
            Console.WriteLine("M - view a list of your meal");
            Console.WriteLine("Z - exit");
            string answer = CorrectDate();

            return answer;
        }

        static void Main()
        {
            Console.Write("Enter your username:  ");
            string userName = CorrectDate();

            WorkWithUsers user = new WorkWithUsers(userName);
            Exercise exercise = new Exercise(user.User);
            Meal meal = new Meal(user.User);

            if (user.IsNewUser)
            {
                Console.Write("Enter your name: ");
                string name = CorrectDate();
                Console.Write("Enter your gener: ");
                string gender = CorrectDate();
                DateTime birthDate = CorrectDateTime("Birth Date"); ;
                double weight = CorrectDouble("Weight");
                double height = CorrectDouble("Height");

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
                    case "E":
                        foreach (var selectExercise in exercise.Exercises.Where(e => e.User.UserName == userName))
                        {
                            Console.WriteLine($"Workout: {selectExercise.Activity.Name} -  training time in minutes {selectExercise._timeOfTranning}");
                        }
                        break;
                    case "M":
                        foreach (var selectMeal in meal.Meals.Where(e => e.User.UserName == userName))
                        {
                            Console.WriteLine($"The product's name: {selectMeal.Food.Name} - count of calories {selectMeal.Food._calories}");
                        }
                        break;
                    case "Z":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
