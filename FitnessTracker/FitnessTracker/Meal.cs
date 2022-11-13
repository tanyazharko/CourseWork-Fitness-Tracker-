using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker
{
    public class Meal
    {
        public int Id { get; set; }
        public DateTime MealTime { get; set; } = DateTime.Now;
        public User User { get; set; }
        public int UserId { get; set; }
        public Food Food { get; set; }
        public int FoodId { get; set; }

        private readonly User user;
        public List<Meal> Meals { get; }
        public List<Food> Foods { get; }
        public Meal() { }

        public Meal(User user, Food food, DateTime mealTime)
        {
            Food = food;
            MealTime = mealTime;
            User = user;
        }

        public Meal(User user, Food food)
        {
            Food = food;
            User = user;
        }

        public Meal(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User can not be null", nameof(user));

            Meals = GetMeals();
            Foods = GetFoods();
        }

        public void AddFood(Food food)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);

            if (product == null)
            {
                Foods.Add(food);
                var meal = new Meal(user, food);
                Meals.Add(meal);
            }
            else
            {
                var meal = new Meal(user, food);
                Meals.Add(meal);
            }

            Save();
        }

        public void DeleteFood(Food food)
        {
            Foods.Remove(food);
            Save();
        }

        private List<Meal> GetMeals()
        {
            return Program.GetInfo<Meal>() ?? new List<Meal>();
        }

        private List<Food> GetFoods()
        {
            return Program.GetInfo<Food>() ?? new List<Food>();
        }

        private void Save()
        {
            Program.Save(Meals);
            Program.Save(Foods);
        }
    }
}
