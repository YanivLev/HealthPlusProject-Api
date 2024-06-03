using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FoodDataList:List<FoodData>
    {
        public FoodDataList() { }
        public FoodDataList(IEnumerable<FoodData> list) : base(list) { }
        public FoodDataList(IEnumerable<Base> list) : base(list.Cast<FoodData>().ToList()) { }
    }
}
