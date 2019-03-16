using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }
        public double Proteins  { get; }
        public double Fats  { get; }
        public double Carbohydrates  { get;}
        /// <summary>
        /// Calories by 100 g of product
        /// </summary>
        public double Calories  { get;}
       

        public Food(string name) : this(name, 0, 0, 0, 0) { }
        

        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            Name = name;
            Calories = calories/100.0;
            Proteins = proteins/100.0;
            Fats = fats/100.0;
            Carbohydrates = carbohydrates/100.0;
            //todo: Check
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
