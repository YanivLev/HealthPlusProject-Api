using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FoodList: List<Food>
    {
        public FoodList() { }
        public FoodList(IEnumerable<Food> list) : base(list) { }
        public FoodList(IEnumerable<Base> list) : base(list.Cast<Food>().ToList()) { }

    }
}
