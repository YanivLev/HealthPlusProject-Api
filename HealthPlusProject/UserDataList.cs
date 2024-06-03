using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserDataList : List<UserData>
    {
        public UserDataList() { }
        public UserDataList(IEnumerable<UserData> list) : base(list) { }
        public UserDataList(IEnumerable<Base> list) : base(list.Cast<UserData>().ToList()) { }
    }
}
