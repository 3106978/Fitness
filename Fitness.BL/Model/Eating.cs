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
        public int ID { get; set; }
        public DateTime Moment  { get; set; }//moment
        public Dictionary<Food, double> Foods { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public Eating() { }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("User can't be empty", nameof(user));
            Moment = DateTime.UtcNow;
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
