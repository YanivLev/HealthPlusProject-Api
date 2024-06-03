using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Meal:Base
    {
        private User user;
        private DateTime mealdate;
        private MealName mealname;
        private Food food;
        private int amount;

        public User User { get => user; set => user = value; }
        public DateTime Mealdate { get => mealdate; set => mealdate = value; }
        public MealName Mealname { get => mealname; set => mealname = value; }
        public Food Food { get => food; set => food = value; }
        public int Amount { get => amount; set => amount = value; }
    }
}
