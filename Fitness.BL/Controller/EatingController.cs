﻿using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public class EatingController : BaseController
    {
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }


        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User can't be empty", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }
        
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }

        }
        private Eating GetEating()
        {
            var eatings = Load<Eating>();

            if (eatings.Count() > 0)
                return eatings.First();
            return new Eating();
        }

        private List<Food> GetAllFoods()
        {
            return Load<Food>();

        }
        private void Save()
        {
            Save();
           
        }


    }
}
