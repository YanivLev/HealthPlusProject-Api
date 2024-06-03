using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;
using System.Data.OleDb;
namespace ViewModel
{
    public class FoodDataDB:FoodDB
    {
        //הפעלת הבנאי במחלקה הבסיסית
        public FoodDataDB() : base() { }

        //הגדרת משתנה סטטי
        static private FoodDataList list = new FoodDataList();

        //הפעולה מקבלת ישות מסוג בייס ויוצרת ממנה ישות מסוג נתוני-מאכל
        protected override Base CreateModel(Base entity)
        {
            FoodData fooddata = entity as FoodData;
            fooddata.Calories = double.Parse(reader["calories"].ToString());
            fooddata.Protein = double.Parse(reader["protein"].ToString());
            fooddata.Carbs = double.Parse(reader["carbs"].ToString());
            fooddata.Fibers = double.Parse(reader["fibers"].ToString());
            fooddata.Fat = double.Parse(reader["fat"].ToString());
            fooddata.Sugar = double.Parse(reader["sugar"].ToString());
            fooddata.Cholesterol = double.Parse(reader["cholesterol"].ToString());
            base.CreateModel(entity);
            return fooddata;
        }

        //הפעולה מבצעת שאילתת *בחירה לקבלת כל הרשומות מטבלת נתוני-המאכל
        //ואז משתמשת בתוצאה המתקבלת על ידי פעולת בחירה שנמצאת במחלקה הבסיסית
        public FoodDataList SelectAll()
        {
            command.CommandText = "SELECT FoodTbl.id, FoodTbl.foodname, FoodTbl.servingtype, FoodDataTbl.calories, FoodDataTbl.protein, FoodDataTbl.carbs, FoodDataTbl.fibers, FoodDataTbl.fat, FoodDataTbl.sugar, FoodDataTbl.cholesterol" +
                                  " FROM  (FoodTbl INNER JOIN  FoodDataTbl ON FoodTbl.id = FoodDataTbl.id)";
            FoodDataList fdList = new FoodDataList(base.Select());
            return fdList;
        }

        //הפעולה מחפשת ישות מסוג נתוני-מאכל ברשימת הישויות במסד הנתונים לפי זיהוי המזהה שהתקבל כפרמטר
        public static FoodData SelectById(int id)
        {
            if (list.Count == 0)
            {
                FoodDataDB db = new FoodDataDB();
                list = db.SelectAll();
            }
            FoodData fooddata = list.Find(item => item.Id == id);
            return fooddata;
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
            FoodData userdata = entity as FoodData;
            if (userdata != null)
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
                deleted.Add(new ChangeEntity(base.CreateDeletedSQL, entity));
            }

        }

        //הפעולה מוסיפה את הישות המעודכנת לרשימת הישויות שעודכנו
        public override void Update(Base entity)
        {
            FoodData userdata = entity as FoodData;
            if (userdata != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
                updated.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
            }

        }

        //הפעולה מייצרת שאילתת הוספה להוספת נתוני ישות מסוג נתוני-מאכל לטבלת נתוני-המאכלים במסד הנתונים
        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            FoodData fooddata= entity as FoodData;
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

        //הפעולה מייצרת שאילתת עדכון לעדכון נתוני ישות מסוג נתוני-מאכל לטבלת נתוני-המאכלים במסד הנתונים
        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            FoodData fooddata = entity as FoodData;

            string sqlStr = "UPDATE FoodDataTbl SET calories=@c, protein=@p, carbs=@ca, fibers=@f, fat=@fa, sugar=@s, cholesterol=@ch " +
                            " WHERE ID =@fdId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@c", fooddata.Calories));
            command.Parameters.Add(new OleDbParameter("@p", fooddata.Protein));
            command.Parameters.Add(new OleDbParameter("@ca", fooddata.Carbs));
            command.Parameters.Add(new OleDbParameter("@f", fooddata.Fibers));
            command.Parameters.Add(new OleDbParameter("@fa", fooddata.Fat));
            command.Parameters.Add(new OleDbParameter("@s", fooddata.Sugar));
            command.Parameters.Add(new OleDbParameter("@ch", fooddata.Cholesterol));
        }

        //הפעולה מייצרת שאילתת מחיקה למחיקת רשומה מטבלת נתוני-המאכלים במסד הנתונים, על פי המזהה של הישות המועברת
        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            FoodData fooddata = entity as FoodData;
            string sqlStr = "DELETE FROM FoodDataTbl WHERE ID = @fdId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@fId", fooddata.Id));

        }

        //הפעולה מגדירה יישות חדשה מסוג נתוני-מאכל
        protected override Base NewEntity()
        {
            return new FoodData();
        }
    }
}
