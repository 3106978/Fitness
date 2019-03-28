using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public class ExerciseController : BaseController
    {
        
        private readonly User user;
        public List<Exercise> Exercises;
        public List<Activity> Activities;

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if (act == null)
            {
                Activities.Add(activity);
                var exercises = new Exercise(begin, end, activity, user);
                Exercises.Add(exercises);
            }
            else
            {
                var exercises = new Exercise(begin, end, act, user);
                Exercises.Add(exercises);
            }
            Save();
        }
        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(Exercises);
            Save(Activities);
        }
    }
}
