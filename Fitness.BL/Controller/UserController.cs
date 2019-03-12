using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{/// <summary>
/// Controller of User
/// </summary>
    public class UserController
    {
        /// <summary>
        /// User app
        /// </summary>
        public List<User> Users { get;}
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;
        /// <summary>
        /// Create new User's controller
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException("Name of user can't be empty", nameof(userName));
            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);
            if (CurrentUser==null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

       
        /// <summary>
        /// Save data of User
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs=new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
            
        }
        /// <summary>
        /// Get List of user's data
        /// </summary>
        /// <returns>User app</returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                    return users;

                else
                    return new List<User>();
            }
            
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight=1, double height=1)
        {
            //check
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
    }
}
