using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Food:Base
    {
        private string foodname;
        private Serving servingtype;

        public string Foodname { get => foodname; set => foodname = value; }
        public Serving Servingtype { get => servingtype; set => servingtype = value; }
    }
}
