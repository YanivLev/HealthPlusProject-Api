using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Model;
using System.Data;

namespace ViewModel
{
    public class MealDB:BaseDB
    {

        //יצירת משתנה סטטי
        static private MealList list = new MealList();

        //מאתחל את החיבור למסד הנתונים ואת הפקודה לביצוע פעולות במסד הנתונים
        public MealDB()
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }

        //הפעולה מקבלת את ההגדרה של יישות חדשה
        protected override Base NewEntity()
        {
            return new Meal();
        }

        //הפעולה מקבלת יישות מסוג בייס ויוצר ממנה יישות מסוג ארוחות
        protected override Base CreateModel(Base entity)
        {

            Meal m = entity as Meal;
            int user = int.Parse(reader["mealuser"].ToString());
            m.User = UserDB.SelectById(user);
            m.Mealdate = DateTime.Parse(reader["mealdate"].ToString());
            int mealname = int.Parse(reader["mealname"].ToString());
            m.Mealname = MealNameDB.SelectById(mealname);
            int food = int.Parse(reader["food"].ToString());
            m.Food = FoodDB.SelectById(food);
            int amount = int.Parse(reader["amount"].ToString());
            m.Amount = amount;
            base.CreateModel(entity);
            return m;
        }

        //הפעולה מבצעת שאילתת *בחירה לקבלת כל הרשומות מטבלת הארוחות
        //ואז משתמשת בתוצאה המתקבלת על ידי הפעולת בחירה שנמצאת במחלקה הבסיסית ליצרת רשימת ישויות
        public MealList SelectAll()
        {
            command.CommandText = "SELECT * FROM MealTbl";
            MealList mList = new MealList(base.Select());
            return mList;

        }

        //הפעולה מחפשת יישות מסוג ארוחות ברשימת הישויות במסד הנתונים לפי זיהוי המזהה שהתקבל כפרמטר
        public static Meal SelectById(int id)
        {
            if (list.Count == 0)
            {
                MealDB db = new MealDB();
                list = db.SelectAll();
            }
            Meal meal = list.Find(item => item.Id == id);
            return meal;
        }

        //הפעולה מייצרת שאילתת הוספה להוספת נתוני ישות מסוג ארוחה לטבלת הארוחות במסד הנתונים
        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            Meal meal = entity as Meal;
            string sqlStr = "INSERT INTO MealTbl (mealuser, mealdate, mealname, food, amount) " +
                           " VALUES (@u, @md, @mn, @f, @a)";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@u", meal.User.Id));
            command.Parameters.Add(new OleDbParameter("@md", DateTime.Parse(meal.Mealdate.ToString()).Date));
            command.Parameters.Add(new OleDbParameter("@mn", meal.Mealname.Id));
            command.Parameters.Add(new OleDbParameter("@f", meal.Food.Id));
            command.Parameters.Add(new OleDbParameter("@a", meal.Amount));
        }

        //הפעולה מייצרת שאילתת עדכון לעדכון נתוני ישות מסוג ארוחה בטבלת הארוחות במסד הנתונים
        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            Meal meal = entity as Meal;

            string sqlStr = "UPDATE MealTbl SET user=@u" +
                " mealdate=@md" +
                " mealname=@mn" +
                " food=@f" +
                " amount=@a" +
                " WHERE ID =@mId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@u", meal.User));
            command.Parameters.Add(new OleDbParameter("@md", meal.Mealdate));
            command.Parameters.Add(new OleDbParameter("@mn", meal.Mealname));
            command.Parameters.Add(new OleDbParameter("@f", meal.Food));
            command.Parameters.Add(new OleDbParameter("@a", meal.Amount));


        }

        //הפעולה יוצרת שאילתת מחיקה למחיקת רשומה מטבלת המגדרים במסד הנתונים על פי המזהה של הישות המועברת
        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            Meal meal = entity as Meal;
            string sqlStr = "DELETE FROM MealTbl WHERE ID = @mId ";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@mId", meal.Id));

        }


    }

}
