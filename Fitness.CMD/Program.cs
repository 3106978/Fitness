using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL.Controller;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Fitness app!");
            Console.WriteLine("Enter user name");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter your gender");
                var gender = Console.ReadLine();
                DateTime birthDate=ParseDateTime(); 
                double weight = ParseDouble("weight");
                double height = ParseDouble("height");
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();

            
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Enter your birth date (dd.MM.yyyy)");
               birthDate= DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);
                if (birthDate!=null)
                    break;
                else
                    Console.WriteLine("Wrong format of the date");
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine("Enter your " + name);
                if (double .TryParse(Console.ReadLine(), out double value))
                    return value;                    
                else
                    Console.WriteLine("Wrong format of the " + name);
            }
        }
    }
}
