using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MealList:List<Meal>
    {
        public MealList() { }
        public MealList(IEnumerable<Meal> list) : base(list) { }
        public MealList(IEnumerable<Base> list) : base(list.Cast<Meal>().ToList()) { }
    }
}
