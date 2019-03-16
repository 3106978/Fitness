using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL.Controller;
using Fitness.BL.Model;

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
            var eatingController = new EatingController(userController.CurrentUser);
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
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("E- enter eating of food");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key==ConsoleKey.E)
            {
               var foods= EnterEating();
                eatingController.Add(foods.Food, foods.Weight);
                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();

            
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Enter name of product:");
            var food = Console.ReadLine();
           // Console.Write("Enter calories of product in 100g:");
            var calories = ParseDouble("calories");
            //Console.Write("Enter proteins of product in 100g:");
            var prots = ParseDouble("proteines");
            //Console.Write("Enter fats of product in 100g:");
            var fats = ParseDouble("fats");
           // Console.Write("Enter carbs of product in 100g:");
            var carbs = ParseDouble("carbonates");
            

           // Console.Write("Enter weight of food:");
            var weight = ParseDouble("weight of food");
            var product = new Food(food, calories, prots, fats, carbs);
            return (Food: product, Weight: weight);
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
