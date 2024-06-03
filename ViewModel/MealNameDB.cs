using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.OleDb;
namespace ViewModel
{
    public class MealNameDB : BaseDB
    {

        //הגדרת משתנה סטטי
        static private MealNameList list = new MealNameList();

        //מאתחל את החיבור ואת הפקודה לביצוע פעולות במסד הנתונים
        public MealNameDB()
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }

        //הפעולה מגדירה יישות חדשה מסוג שם-ארוחה
        protected override Base NewEntity()
        {
            return new MealName();
        }

        //הפעולה מקבלת ישות מסוג בייס ויוצרת ממנה ישות מסוג שם-ארוחה
        protected override Base CreateModel(Base entity)
        {
            MealName mn = entity as MealName;
            mn.Mealname = reader["mealname"].ToString();
            base.CreateModel(entity);
            return mn;
        }


        //הפעולה מבצעת שאילתת *בחירה לקבלת כל הרשומות מטבלת שם-הארוחה
        //ואז משתמשת בתוצאה המתקבלת על ידי פעולת בחירה שנמצאת במחלקה הבסיסית
        public MealNameList SelectAll()
        {
            command.CommandText = "SELECT * FROM MealNameTbl";
            MealNameList mnList = new MealNameList(base.Select());
            return mnList;

        }

        //הפעולה מחפשת ישות מסוג שם-ארוחה ברשימת הישויות במסד הנתונים לפי זיהוי המזהה שהתקבל כפרמטר
        public static MealName SelectById(int id)
        {
            if (list.Count == 0)
            {
                MealNameDB db = new MealNameDB();
                list = db.SelectAll();
            }
            MealName mealname = list.Find(item => item.Id == id);
            return mealname;
        }

        //הפעולה מייצרת שאילתת הוספה להוספת נתוני ישות מסוג שם-הארוחה לטבלת שמות-הארוחות במסד הנתונים
        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            MealName mealname = entity as MealName;
            if (mealname != null)
            {
                string sqlStr = "INSERT INTO MealNameTbl (id, mealname) " +
                                " Values (@i,@mName)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@i", mealname.Id));
                command.Parameters.Add(new OleDbParameter("@mName", mealname.Mealname));
            }


        }

        //הפעולה מייצרת שאילתת עדכון לעדכון נתוני ישות מסוג שם-הארוחה לטבלת שמות-הארוחות במסד הנתונים
        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            MealName mealname = entity as MealName;

            string sqlStr = "UPDATE MealNameTbl SET mealname=@mn " +
                "WHERE ID =@mnId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@mn", mealname.Mealname));

            command.Parameters.Add(new OleDbParameter("@mnId", mealname.Id));


        }

        //הפעולה מייצרת שאילתת מחיקה למחיקת רשומה מטבלת שמות-הארוחות במסד הנתונים, על פי המזהה של הישות המועברת
        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            MealName mealname = entity as MealName;
            string sqlStr = "DELETE FROM MealNameTbl WHERE ID = @mnId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@mnId", mealname.Id));

        }
    }
}

