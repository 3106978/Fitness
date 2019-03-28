using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
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
            //var culture = CultureInfo.CreateSpecificCulture("he");
            var culture = CultureInfo.CurrentCulture;
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello", culture));
            Console.WriteLine(resourceManager.GetString("Name", culture));

            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter your gender");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime("date of birth");
                double weight = ParseDouble("weight");
                double height = ParseDouble("height");
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            while (true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("E- enter eating of food");
                Console.WriteLine("A- enter exercise");
                Console.WriteLine("Q- exit");
                var key = Console.ReadKey();
                Console.WriteLine();


                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);
                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.activity, exe.start, exe.end);
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.Write($"\t{item.Activity} from {item.Start.ToShortTimeString()} to {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
            }
            


        }

        private static (DateTime start, DateTime end, Activity activity) EnterExercise()
        {
            Console.WriteLine("Enter name of exercise");
            var exercName = Console.ReadLine();
            var energy = ParseDouble("power consumption per minute");
            var start = ParseDateTime("start time");
            var end = ParseDateTime("end time");
            var activity = new Activity(exercName, energy);
            return (start, end, activity);

        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Enter name of product:");
            string food = Console.ReadLine();
            var calories = ParseDouble("calories");
            var prots = ParseDouble("proteines");
            var fats = ParseDouble("fats");
            var carbs = ParseDouble("carbonates");
            var weight = ParseDouble("weight of food");
            Food product = new Food(food, calories, prots, fats, carbs);
            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime enteredDate;
            while (true)
            {
                if (value == "date of birth")
                {
                    Console.WriteLine($"Enter your {value} (dd.MM.yyyy)");
                    enteredDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);
                }
                   
                else
                {
                    Console.WriteLine($"Enter your {value} (hh:mm)");
                    enteredDate = DateTime.ParseExact(Console.ReadLine(), "hh:mm", null);
                }
                if (enteredDate != null)
                    break;
                else
                    Console.WriteLine("Wrong format of the date");
            }

            return enteredDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine("Enter " + name);
                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;
                else
                    Console.WriteLine("Wrong format of the " + name);
            }
        }
    }
}
