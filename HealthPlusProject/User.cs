using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User:Base
    {
        private string username;
        private string gmail;
        private string phone;
        private Gender gender;
        private bool isManager;

        public string Username { get => username; set => username = value; }
        public string Gmail { get => gmail; set => gmail = value; }
        public string Phone { get => phone; set => phone = value; }
        public Gender Gender { get => gender; set => gender = value; }
        public bool IsManager { get => isManager; set => isManager = value; }
    }
}
