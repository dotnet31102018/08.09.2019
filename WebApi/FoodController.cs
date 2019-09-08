using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebRestApiFood.Models;

namespace WebRestApiFood.Controllers
{
    public class FoodController : ApiController
    {
        private static List<Food> foods = new List<Food>();
        static FoodController()
        {
            foods.Add(new Food { Id = 1, Name = "Pie", Calories = 1800 });
            foods.Add(new Food { Id = 2, Name = "Pizza", Calories = 3600 });
            foods.Add(new Food { Id = 3, Name = "Apple", Calories = 80 });
            foods.Add(new Food { Id = 4, Name = "Burger (double) with onion rings", Calories = 5400 });
        }

        // GET api/values
        public List<Food> Get()
        {
            return foods;
        }

        // GET api/values/5
        public Food Get(int id)
        {
            foreach (var food in foods)
            {
                if (food.Id == id)
                    return food;
            }
            return new Food { Id = -1, Name = "Food excdeption" };
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Food f = null;
            foreach (var food in foods)
            {
                if (food.Id == id)
                {
                    f = food;
                    break;
                }
            }
            if (f != null)
            {
                foods.Remove(f);
            }

        }
    }
}
