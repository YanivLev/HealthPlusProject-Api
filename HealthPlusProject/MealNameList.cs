using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MealNameList:List<MealName>
    {
        public MealNameList() { }
        public MealNameList(IEnumerable<MealName> list) : base(list) { }
        public MealNameList(IEnumerable<Base> list) : base(list.Cast<MealName>().ToList()) { }
    }
}
