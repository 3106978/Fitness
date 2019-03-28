using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL.Model;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var exersiceController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(10, 50));

            //act

            exersiceController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));

            //Assert
            Assert.AreEqual(activity.Name, exersiceController.Activities.First().Name);
        }
    }
}