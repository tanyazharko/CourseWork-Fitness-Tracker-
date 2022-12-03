namespace FitnessTracker
{
    internal class ConsoleDevice : IDevice
    {
        public void Device(string userName, Exercise exercise, Meal meal)
        {
            while (true)
            {
                switch (GetChoose())
                {
                    case Choice.AddFood:
                        var foods = FitnessTracker.EnterEating();
                        meal.AddFood(foods);
                        break;
                    case Choice.AddExercise:
                        var exe = FitnessTracker.EnterExercise();
                        exercise.AddExercise(exe.Activity, exe.Begin, exe.End);
                        break;
                    case Choice.InfoWorkout:
                        foreach (var selectExercise in exercise.Exercises.Where(e => e.User.UserName == userName))
                        {
                            Console.WriteLine($"Workout: {selectExercise.Activity.Name} -  training time in minutes {selectExercise._timeOfTranning}");
                        }
                        break;
                    case Choice.InfoMeal:
                        foreach (var selectMeal in meal.Meals.Where(e => e.User.UserName == userName))
                        {
                            Console.WriteLine($"The product's name: {selectMeal.Food.Name} - count of calories {selectMeal.Food._calories}");
                        }
                        break;
                    case Choice.Enter:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public static Choice GetChoose()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - enter a meal");
            Console.WriteLine("2 - enter exercise");
            Console.WriteLine("3 - view a list of your workouts");
            Console.WriteLine("4 - view a list of your meal");
            Console.WriteLine("9 - exit");

            var a = Input();

            Choice choice = new Choice();

            if (a == 1)
            {
                choice = Choice.AddFood;
            }
            else if (a == 2)
            {
                choice = Choice.AddExercise;
            }
            else if (a == 3)
            {
                choice = Choice.InfoWorkout;
            }
            else if (a == 4)
            {
                choice = Choice.InfoMeal;
            }
            else if (a == 9)
            {
                choice = Choice.Enter;
            }

            return choice;
        }

        public static int Input()
        {
            string temp = Console.ReadLine();
            int i = 0;

            while (!int.TryParse(temp, out i))
            {
                Console.WriteLine("It is not number! Please,enter a number!");
                temp = Console.ReadLine();
            }

            return i;
        }
    }
}
