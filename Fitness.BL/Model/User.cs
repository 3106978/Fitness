using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    
    [Serializable]
    /// <summary>
/// User
/// </summary>
    public class User
    {/// <summary>
    /// Name
    /// </summary>
        public string Name { get; }// set name just one time
        /// <summary>
        /// Gender
        /// </summary>

        public Gender Gender { get; }
        /// <summary>
        /// Date of birth of User
        /// </summary>
        public DateTime BirthDate { get; }
        /// <summary>
        /// weight of User
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Height of User
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="gender">Gender.</param>
        /// <param name="birthDate">Birthday date.</param>
        /// <param name="weight">Weight</param>
        /// <param name="height">Height</param>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Check of entry values
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name of user can't be empty or null", nameof(name));
            }
            if (gender==null)
            {
                throw new ArgumentNullException("The gender of user can't be null", nameof(gender));
            }
            if (birthDate<DateTime.Parse("01.01.1900") || birthDate>=DateTime.Now)
            {
                throw new ArgumentException("Date of birth is not passible", nameof(birthDate));
            }
            if (weight<=0)
            {
                throw new ArgumentException("weight is not passible", nameof(weight));
            }
            if (height<=0)
            {
                throw new ArgumentException("height is not passible", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
