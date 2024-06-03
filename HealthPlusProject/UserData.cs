using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserData:User
    {
        private int weight;
        private int height;
        private DateTime birthdate;
        private int caloriegoal;
        private int weightgoal;

        public int Weight { get => weight; set => weight = value; }
        public int Height { get => height; set => height = value; }
        public DateTime Birthdate { get => birthdate; set => birthdate = value; }

        public int Caloriegoal { get => caloriegoal; set => caloriegoal = value; }
        public int Weightgoal { get => weightgoal; set => weightgoal = value; }
    }
}
