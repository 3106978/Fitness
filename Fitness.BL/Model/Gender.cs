using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Gender 
    /// </summary>
    public class Gender
    {/// <summary>
     /// Name
     /// </summary>
        public int ID { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Create new Gender
        /// </summary>
        /// <param name="name"> Name of gender</param>
        public Gender()
        {

        }
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name of Gender can't be empty or null", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name; 
        }
    }
}
