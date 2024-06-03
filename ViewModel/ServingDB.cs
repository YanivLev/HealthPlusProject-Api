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
    public class ServingDB:BaseDB
    {
        //הגדרת משתנה סטטי
        static private ServingList list = new ServingList();

        //מאתחל את החיבור ואת הפקודה לביצוע פעולות במסד הנתונים
        public ServingDB()
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }

        //הפעולה מגדירה יישות חדשה מסוג סוג-ארוחה
        protected override Base NewEntity()
        {
            return new Serving();
        }

        //הפעולה מקבלת ישות מסוג בייס ויוצרת ממנה ישות מסוג סוג-ארוחה
        protected override Base CreateModel(Base entity)
        {
            Serving st = entity as Serving;
            st.Servingtype = reader["servingtype"].ToString();
            base.CreateModel(entity);
            return st;
        }

        //הפעולה מבצעת שאילתת *בחירה לקבלת כל הרשומות מטבלת סוג-הארוחה
        //ואז משתמשת בתוצאה המתקבלת על ידי פעולת בחירה שנמצאת במחלקה הבסיסית
        public ServingList SelectAll()
        {
            command.CommandText = "SELECT * FROM ServingTbl";
            ServingList stList = new ServingList(base.Select());
            return stList;

        }

        //הפעולה מחפשת ישות מסוג סוג-ארוחה ברשימת הישויות במסד הנתונים לפי זיהוי המזהה שהתקבל כפרמטר
        public static Serving SelectById(int id)
        {
            if (list.Count == 0)
            {
                ServingDB db = new ServingDB();
                list = db.SelectAll();
            }
            Serving servingtype = list.Find(item => item.Id == id);
            return servingtype;
        }

        //הפעולה מייצרת שאילתת הוספה להוספת נתוני ישות מסוג סוג-ארוחה לטבלת סוגי-הארוחות במסד הנתונים
        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            Serving servingtype = entity as Serving;
            if (servingtype != null)
            {
                string sqlStr = "INSERT INTO ServingTbl (id, servingtype) " +
                                " Values (@i, @sType)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@i", servingtype.Id));
                command.Parameters.Add(new OleDbParameter("@sType", servingtype.Servingtype));
            }


        }

        //הפעולה מייצרת שאילתת עדכון לעדכון נתוני ישות מסוג סוג-ארוחה לטבלת סוגי-הארוחות במסד הנתונים
        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            Serving servingtype = entity as Serving;

            string sqlStr = "UPDATE ServingTbl SET servingtype=@st " +
                "WHERE ID =@stId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@st", servingtype.Servingtype));
            command.Parameters.Add(new OleDbParameter("@stId", servingtype.Id));


        }

        //הפעולה מייצרת שאילתת מחיקה למחיקת רשומה מטבלת סוגי-הארוחות במסד הנתונים, על פי המזהה של הישות המועברת
        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
           Serving servingtype = entity as Serving;
            string sqlStr = "DELETE FROM ServingTbl WHERE ID = @stId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@stId", servingtype.Id));

        }
    }
}
