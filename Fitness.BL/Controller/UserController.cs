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
        public User User { get;}
        /// <summary>
        /// Create new User's controller
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName, DateTime birdthDay, double weight, double height)
        {
            //TODO: Check

            var gender = new Gender(genderName);
            User = new User(userName, gender, birdthDay, weight, height);
           
        }

       
        /// <summary>
        /// Save data of User
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs=new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
            
        }
        /// <summary>
        /// Get data of user
        /// </summary>
        /// <returns>User app</returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user) {
                    User = user;
                }

                // TODO: What to do when the user is not readeble?
            }
        }
    }
}
