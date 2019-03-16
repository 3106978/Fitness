using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{/// <summary>
 /// Eating
 /// </summary>
    [Serializable]
    public  class Eating
    {
       
        public DateTime TimeofEating  { get; set; }//moment
        public Dictionary<Food, double> Foods { get; set; }
        public User User { get;}

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("User can't be empty", nameof(user));
            TimeofEating = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {  
            var product=Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (product==null)
                Foods.Add(food, weight);
            
            else
                Foods[product] += weight;
            
        }
    }
}
