using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FoodData:Food
    {
        private double calories;
        private double protein;
        private double carbs;
        private double fibers;
        private double fat;
        private double sugar;
        private double cholesterol;

        public double Calories { get => calories; set => calories = value; }
        public double Protein { get => protein; set => protein = value; }
        public double Carbs { get => carbs; set => carbs = value; }
        public double Fibers { get => fibers; set => fibers = value; }
        public double Fat { get => fat; set => fat = value; }
        public double Sugar { get => sugar; set => sugar = value; }
        public double Cholesterol { get => cholesterol; set => cholesterol = value; }
    }
}
