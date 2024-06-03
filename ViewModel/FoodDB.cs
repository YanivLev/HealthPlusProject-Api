using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using Model;
using System.Reflection;

namespace ViewModel
{
    public class FoodDB : BaseDB 
    {
        //הגדרת משתנה סטטי
        static private FoodList list = new FoodList();

        //מאתחל את החיבור ואת הפקודה לביצוע פעולות במסד הנתונים
        public FoodDB()
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }

        //הפעולה מגדירה יישות חדשה מסוג מאכל
        protected override Base NewEntity()
        {
            return new Food();
        }

        //הפעולה מקבלת ישות מסוג בייס ויוצרת ממנה ישות מסוג מאכל
        protected override Base CreateModel(Base entity)
        {
            Food f = entity as Food;
            f.Foodname = reader["foodname"].ToString();
            int serving = int.Parse(reader["servingtype"].ToString());
            f.Servingtype= ServingDB.SelectById(serving);
            base.CreateModel(entity);
            return f;
        }


        //הפעולה מבצעת שאילתת *בחירה לקבלת כל הרשומות מטבלת המאכלים
        //ואז משתמשת בתוצאה המתקבלת על ידי פעולת בחירה שנמצאת במחלקה הבסיסית
        public FoodList SelectAll()
        {
            command.CommandText = "SELECT * FROM FoodTbl";
            FoodList fList = new FoodList(base.Select());
            return fList;

        }

        //הפעולה מחפשת ישות מסוג מאכל ברשימת הישויות במסד הנתונים לפי זיהוי המזהה שהתקבל כפרמטר
        public static Food SelectById(int id)
        {
            if (list.Count == 0)
            {
                FoodDB db = new FoodDB();
                list = db.SelectAll();
            }
            Food food = list.Find(item => item.Id == id);
            return food;
        }


        //הפעולה מייצרת שאילתת הוספה להוספת נתוני ישות מסוג מאכל לטבלת המאכלים במסד הנתונים
        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            Food food = entity as Food;
            if (food != null)
            {
                string sqlStr = "INSERT INTO FoodTbl (foodname, servingtype) " +
                                " Values (@fName, @stype)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@fName", food.Foodname));
                command.Parameters.Add(new OleDbParameter("@stype", food.Servingtype.Id));
            }


        }

        protected void CreateInsertSQL2(Base entity, OleDbCommand command)
        {
            FoodData fooddata = entity as FoodData;
            string sqlStr = "INSERT INTO FoodDataTbl (id, calories, protein, carbs, fibers, fat, sugar, cholesterol) " +
                " VALUES (@fdId, @c, @p, @ca, @f, @fa, @s, @ch)";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@fdId", fooddata.Id));
            command.Parameters.Add(new OleDbParameter("@c", fooddata.Calories));
            command.Parameters.Add(new OleDbParameter("@p", fooddata.Protein));
            command.Parameters.Add(new OleDbParameter("@ca", fooddata.Carbs));
            command.Parameters.Add(new OleDbParameter("@f", fooddata.Fibers));
            command.Parameters.Add(new OleDbParameter("@fa", fooddata.Fat));
            command.Parameters.Add(new OleDbParameter("@s", fooddata.Sugar));
            command.Parameters.Add(new OleDbParameter("@ch", fooddata.Cholesterol));
        }

        //הפעולה מייצרת שאילתת עדכון לעדכון נתוני ישות מסוג מאכל לטבלת המאכלים במסד הנתונים
        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            Food food = entity as Food;

            string sqlStr = "UPDATE FoodDataTbl SET weightgoal=@wg, caloriegoal=@cg " +
                            " WHERE ID =@";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@fId", food.Id));


        }


        //הפעולה מייצרת שאילתת מחיקה למחיקת רשומה מטבלת המאכלים במסד הנתונים, על פי המזהה של הישות המועברת
        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            Food food = entity as Food;
            string sqlStr = "DELETE FROM FoodTbl WHERE ID = @fId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@fId", food.Id));

        }

    }
}
