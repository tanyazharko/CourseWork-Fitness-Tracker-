using Newtonsoft.Json;

namespace FitnessTracker
{
    public class Exercise: BaseSave
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public Activity Activity { get; set; }
        public int ActivityId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int _timeOfTranning;
        private readonly User user;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }
        public Exercise() { }

        public Exercise(User user, Activity activity, DateTime start, DateTime finish)
        { 
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
            _timeOfTranning = (finish - start).Minutes;
        }

        public Exercise(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));

            Exercises = GetExercises();
            Activities = GetActivities();
        }

        public void AddExercise(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);

            if (act == null)
            {
                Activities.Add(activity);

                var exercise = new Exercise(user, activity, begin, end);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(user, activity, begin, end);
                Exercises.Add(exercise);
            }
            Save();
        }

        private List<Exercise> GetExercises()
        {
            return GetInfo<Exercise>() ?? new List<Exercise>();
        }

        private List<Activity> GetActivities()
        {
            return GetInfo<Activity>() ?? new List<Activity>();
        }

        private void Save()
        {
            Save(Exercises);
            Save(Activities);
        }
    }
}
