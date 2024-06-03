using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ServingList:List<Serving>
    {
        public ServingList() { }
        public ServingList(IEnumerable<Serving> list) : base(list) { }
        public ServingList(IEnumerable<Base> list) : base(list.Cast<Serving>().ToList()) { }
    }
}
