using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GenderList : List<Gender>
    {
        public GenderList() { }
        public GenderList(IEnumerable<Gender> list) : base(list) { }
        public GenderList(IEnumerable<Base> list) : base(list.Cast<Gender>().ToList()) { }
    }
}
