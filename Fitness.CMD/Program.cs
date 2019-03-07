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

            Console.WriteLine("Enter your gender");
            var gender=Console.ReadLine();
            Console.WriteLine("Enter your birth date");
            var birthDate= DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);// TODO try parse
            Console.WriteLine("Enter your weight");
            var weight=double.Parse(Console.ReadLine());
            Console.WriteLine("Enter your height");
            var height= double.Parse(Console.ReadLine());
            var userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();
        }
    }
}
