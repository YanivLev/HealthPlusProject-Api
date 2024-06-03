using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Model;
namespace ViewModel
{
    public class UserDataDB : UserDB
    {
        //הבנאי קורא לבנאי הבסיס של המחלקה
        public UserDataDB() : base() { }

        //הגדרת משתנה סטטי
        static private UserDataList list = new UserDataList();

        //פעולה המייצרת מודל חדש לפי הנתונים המתקבלים מהקורא, ומגדירה את הערכים של משתני המודל
        protected override Base CreateModel(Base entity)
        {
            UserData userData = entity as UserData;
            userData.Weight = int.Parse(reader["weight"].ToString());
            userData.Height = int.Parse(reader["height"].ToString());
            //userData.Birthdate = DateOnly.Parse(reader["birthdate"].ToString());
            userData.Birthdate = DateTime.Parse(reader["birthdate"].ToString());
            userData.Caloriegoal = int.Parse(reader["caloriegoal"].ToString());
            userData.Weightgoal = int.Parse(reader["weightgoal"].ToString());
            base.CreateModel(entity);
            return userData;
        }

        //פעולה המבצעת שאילתת בחירה על כל השדות של טבלת המשתמשים וגם על השדות הנוספים
        //של טבלת הנתונים המשתמש במסד הנתונים, ומחזירה רשימת משתמשי נתונים
        public UserDataList SelectAll()
        {
            command.CommandText = "SELECT UserTbl.id, UserTbl.username, UserTbl.gmail, UserTbl.phone, UserTbl.gender, UserTbl.IsManager, UserDataTbl.weight, UserDataTbl.height, UserDataTbl.birthdate, UserDataTbl.caloriegoal, UserDataTbl.weightgoal "+
                                  " FROM  (UserTbl Inner JOIN  UserDataTbl ON UserTbl.id = UserDataTbl.id)";
            UserDataList udList = new UserDataList(base.Select());
            return udList;
        }

        //הפעולה מחפשת משתמש לפי המזהה הייחודי שלו ומחזירה את המשתמש המתאים
        //אם אין משתמשים נתונים ברשימה, היא מבצעת פניה לבסיס הנתונים
        //כדי לקבל את רשימת כל המשתמשים נתונים ומחזירה משתמש נתונים מתאים
        public static UserData SelectById(int id)
        {
            if (list.Count == 0)
            {
                UserDataDB db = new UserDataDB();
                list = db.SelectAll();
            }
            UserData userdata = list.Find(item => item.Id == id);
            return userdata;
        }

        //הפעולה מוסיפה ישות חדשה לרשימת הישויות שנוצרו
        public override void Insert(Base entity)
        {
            Base reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(base.CreateInsertSQL, entity)); ;
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity)); ;
            }
        }

        //הפעולה מוסיפה את הישות הנתונה לרשימת הישויות שנמחקו
        public override void Delete(Base entity)
        {
            UserData userdata = entity as UserData;
            if (userdata != null)
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
                deleted.Add(new ChangeEntity(base.CreateDeletedSQL, entity));
            }

        }

        //הפעולה מוסיפה את הישות המעודכנת לרשימת הישויות שעודכנו
        public override void Update(Base entity)
        {
            UserData userdata = entity as UserData;
            if (userdata != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
                updated.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
            }

        }

        //הפעולה יוצרת שאילתת אס-קיו-אל להוספת רשומה חדשה לטבלת המשתמשים במסד הנתונים
        //ומגדירה את הפרמטרים הנדרשים לשאילתה
        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            UserData userdata = entity as UserData;
            string sqlStr = "INSERT INTO UserDataTbl (id, weight, height, birthdate, caloriegoal, weightgoal) " +
                " VALUES (@udId, @w, @h, @bd, @cg, @wg)";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@udId", userdata.Id));
            command.Parameters.Add(new OleDbParameter("@w", userdata.Weight));
            command.Parameters.Add(new OleDbParameter("@h", userdata.Height));
            
            command.Parameters.Add(new OleDbParameter("@bd", DateTime.Parse(userdata.Birthdate.ToString()).Date));
            command.Parameters.Add(new OleDbParameter("@cg", userdata.Caloriegoal));
            command.Parameters.Add(new OleDbParameter("@wg", userdata.Weightgoal));

        }


        //הפעולה מייצרת שאילתת אס-קיו-אל לעדכון רשומה קיימת בטבלת נתוני-המשתמשים במסד הנתונים
        //ומגדירה את הפרמטרים הנדרשים לשאילתה
        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            UserData userdata = entity as UserData;

            string sqlStr = "UPDATE UserDataTbl SET weight=@w, height=@h, birthdate=@bd, caloriegoal=@cg, weightgoal=@wg " +
                            " WHERE ID =@udId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@w", userdata.Weight));
            command.Parameters.Add(new OleDbParameter("@h", userdata.Height));
            command.Parameters.Add(new OleDbParameter("@bd",userdata.Birthdate.Date));
            command.Parameters.Add(new OleDbParameter("@cg", userdata.Caloriegoal));
            command.Parameters.Add(new OleDbParameter("@cg", userdata.Weightgoal));
            command.Parameters.Add(new OleDbParameter("@udId", userdata.Id));
        }


        //הפעולה מייצרת שאילתת אס-קיו-אל למחיקת רשומה קיימת מטבלת נתוני המשתמשים במסד הנתונים
        //ומגדירה את הפרמטר הנדרש לשאילתה
        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            UserData userdata = entity as UserData;
            string sqlStr = "DELETE FROM UserDataTbl WHERE ID = @udId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@sId", userdata.Id));

        }

        //הפעולה מחזירה ישות חדשה
        //הפעולה מחזירה ישות חדשה
        protected override Base NewEntity()
        {
            return new UserData();
        }
    }
}
