using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.OleDb;
using System.Data;
namespace ViewModel
{
    public class GenderDB : BaseDB
    {

        //הגדרת משתנה מסוג סטטי
        static private GenderList list = new GenderList();

        //מאתחל את החיבור ואת הפקודה לביצוע פעולות במסד הנתונים
        public GenderDB()
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }

        //הפעולה מקבלת את ההגדרה של יישות חדשה
        protected override Base NewEntity()
        {
            return new Gender();
        }

        //הפעולה מקבלת יישות מסוג בייס ויוצרת ממנה יישות מסוג מין
        //מקצה לה ערך לשדה של השם מתוך התוצאה שמתקבלת מהקורא
        protected override Base CreateModel(Base entity)
        {
            Gender g = entity as Gender;
            g.NameGender= reader["gender"].ToString();
            base.CreateModel(entity);
            return g;
        }

        //הפעולה מבצעת שאילתת בחירה של הכל לקבלת כל הרשומות מטבלת המין
        //ואז משתמשת בתוצאה המתקבלת על ידי פעולת הבחירה שנמצאת במחלקה של הבייס ליצירת רשימת ישויות מסוג מין
        public GenderList SelectAll()
        {
            command.CommandText = "SELECT * FROM GenderTbl";
            GenderList gList = new GenderList(base.Select());
            return gList;

        }

        //הפעולה מחפשת יישות מסוג מין ברשימת הישויות במסד הנתונים לפי זיהוי המזהה שהתקבל כפרמטר
        public static Gender SelectById(int id)
        {
            if (list.Count == 0)
            {
                GenderDB db = new GenderDB();
                list = db.SelectAll();
            }
            Gender gender = list.Find(item => item.Id == id);
            return gender;
        }

        //הפעולה מייצרת שאילתת הוספה להוספת נתוני ישות מסוג מין לטבלת המגדרים במסד הנתונים
        //ומוסיפה פרמטרים לפי הנתונים שנמסרו מהישות המועברת
        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            Gender gender  = entity as Gender;
            if (gender != null)
            {
                string sqlStr = "INSERT INTO GenderTbl (id, gender) " +
                                " Values (@i,@g)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@i", gender.Id));
                command.Parameters.Add(new OleDbParameter("@g", gender.NameGender));
            }


        }

        //הפעולה מייצרת שאילתת עדכון בשביל לעדכן את נתוני ישות מסוג מגדר בטלבת המגדרים במסד הנתונים
        //ומוסיפה פרמטרים לפי הנתונים שנמסרו מהישות המועברת
        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            Gender gender = entity as Gender;

            string sqlStr = "UPDATE GenderTbl SET gender=@g " +
                "WHERE ID =@gId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@g", gender.NameGender));
            command.Parameters.Add(new OleDbParameter("@gId", gender.Id));


        }


        //הפעולה יוצרת שאילתת מחיקה למחיקת רשומה מטבלת המגדרים במסד הנתונים על פי המזהה של הישות המועברת
        //ומוסיפה פרמטר לפי המזהה של המגדר שנמצא בישות המועברת
        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            Gender gender = entity as Gender;
            string sqlStr = "DELETE FROM GenderTbl WHERE ID = @gId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@gId", gender));

        }
    }
}
