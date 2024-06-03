using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        //הגדרת משתנה סטטי המשמש לאחסון רשימת משתמשים
        static private UserList list = new UserList();

        //הבנאי מקבל את כל הפרמטרים הדרושים לבנאי הבסיס שלו
        public UserDB() : base(){ }
        
        //פעולה המקבל ישות מסוג בייס ומייצרת ממנה ישות מסוג משתמש
        //ע"פ ערכי השדות שנקראים מהקורא
        protected override Base CreateModel(Base entity)
        {
            User userData = entity as User;
            userData.Username = reader["username"].ToString();
            userData.Gmail= reader["gmail"].ToString();
            userData.Phone = reader["phone"].ToString();
            int gender = int.Parse(reader["gender"].ToString());
            userData.Gender = GenderDB.SelectById(gender);
            userData.IsManager = bool.Parse(reader["IsManager"].ToString());
            base.CreateModel(entity);
            return userData;
        }

        //הפעולה מבצעת שאילתת בחירה על כל השדות של טבלת המשתמשים ומחזירה רשימת משתמשים
        public UserList SelectAll()
        {
            command.CommandText = "SELECT UserTbl.id, UserTbl.username, UserTbl.gmail, UserTbl.phone, UserTbl.gender, UserTbl.IsManager" +
                                  " FROM  UserTbl";
            UserList uList = new UserList(base.Select());
            return uList;
        }

        //הפעולה מחפשת משתמש ע"פ המזהה הייחודי שלו ומחזירה את המשתמש המתאים
        //ואם אין משתמשים ברשימה, היא מבצעת פניה לבסיס הנתונים כדי לקבל את רשימת כל המשתמשים ומחזירה משתמש מתאים
        public static User SelectById(int id)
        {
            if (list.Count == 0)
            {
                UserDB db = new UserDB();
                list = db.SelectAll();
            }
            User userdata = list.Find(item => item.Id == id);
            return userdata;
        }

        //הפעולה מוסיפה ישות חדשה לרשימת הישויות שנוצרו
        //public override void Insert(Base entity)
        //{
        //    Base reqEntity = this.NewEntity();
        //    if (entity != null & entity.GetType() == reqEntity.GetType())
        //    {
        //        inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity));
        //        //inserted.Add(new ChangeEntity(this.CreateInsertSQLTwo, entity));
        //    }
        //}

        //הפעולה מוסיפה את הישות הנתונה לרשימת הישויות שנמחקו
        //public override void Delete(Base entity)
        //{
        //    User userData = entity as User;
        //    if (userData != null)
        //        deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));

        //}

        ////הפעולה מוסיפה את הישות המעודכנת לרשימת הישויות שעודכנו
        //public override void Update(Base entity)
        //{
        //    User user = entity as User;
        //    if (user != null)
        //        updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
        //}

        //הפעולה יוצרת שאילתת אס-קיו-אל להוספת רשומה חדשה לטבלת המשתמשים במסד הנתונים
        //ומגדירה את הפרמטרים הנדרשים לשאילתה
        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            User user = entity as User;
            string sqlStr = "INSERT INTO UserTbl (username, gmail, phone, gender, IsManager) " +
                           "VALUES (@u, @g, @p, @gId, @i)";

            command.CommandText = sqlStr;
            
            command.Parameters.Add(new OleDbParameter("@u", user.Username));
            command.Parameters.Add(new OleDbParameter("@g", user.Gmail));
            command.Parameters.Add(new OleDbParameter("@p", user.Phone));
            command.Parameters.Add(new OleDbParameter("@gId", user.Gender.Id));
            command.Parameters.Add(new OleDbParameter("@i", user.IsManager)) ;
        }

        //protected void CreateInsertSQL2(Base entity, OleDbCommand command)
        //{
        //    UserData userdata = entity as UserData;
        //    string sqlStr = "INSERT INTO UserDataTbl (id, weight, height, birthdate) " +
        //        " VALUES (@udId, @w, @h, @bd)";

        //    command.CommandText = sqlStr;
        //    command.Parameters.Add(new OleDbParameter("@udId", userdata.Id));
        //    command.Parameters.Add(new OleDbParameter("@w", userdata.Weight));
        //    command.Parameters.Add(new OleDbParameter("@h", userdata.Height));
        //    command.Parameters.Add(new OleDbParameter("@bd", DateTime.Parse(userdata.Birthdate.ToString()).Date));

        //}

        //הפעולה מייצרת שאילתת אס-קיו-אל לעדכון רשומה קיימת בטבלת המשתמשים במסד הנתונים
        //ומגדירה את הפרמטרים הנדרשים לשאילתה
        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            User user = entity as User;
            string sqlStr = "UPDATE UserTbl SET username=@un, gmail=@g, phone=@p, gender=@gen, IsManager=@im WHERE ID = @id";
            //string sqlStr = "UPDATE UserTbl SET username=@u," +
            //    " gmail=@g," +
            //    " phone=@p," +
            //    " gender=@gId," +
            //    " IsManager=@i," +
            //    " WHERE ID =@uId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@un", user.Username));
            command.Parameters.Add(new OleDbParameter("@g", user.Gmail));
            command.Parameters.Add(new OleDbParameter("@p", user.Phone));
            command.Parameters.Add(new OleDbParameter("@gen",user.Gender.Id));
            command.Parameters.Add(new OleDbParameter("@im", user.IsManager));
            command.Parameters.Add(new OleDbParameter("@id", user.Id));

        }

        //הפעולה מייצרת שאילתת אס-קיו-אל למחיקת רשומה קיימת מטבלת המשתמשים במסד הנתונים
        //ומגדירה את הפרמטר הנדרש לשאילתה
        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            User user = entity as User;
            string sqlStr = "DELETE FROM UserTbl WHERE ID = @uId ";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@uId", user.Id));

        }

        //הפעולה מחזירה ישות חדשה מסוג משתמש
        protected override Base NewEntity()
        {
            return new User();
        }

    }
}
