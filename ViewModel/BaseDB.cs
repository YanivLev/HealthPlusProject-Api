using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.OleDb;


namespace ViewModel
{
    public abstract class BaseDB
    {
        //כתובת לחיבור מסד נתונים
        protected static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Yaniv\Downloads\HealthPlusProject-master\HealthPlusProject-master\ViewModel\HealthPlus.accdb";
        // עצם בנאגט שהוספנו שמאפשר חיבור למסד נתונים עם הפרוייקט
        protected OleDbConnection connection;
        //עצם בנאגט שהוספנו שמשמש לביצוע פקודות ושאילתות אס-קיו-אל במסד הנתונים
        protected OleDbCommand command;
        //עצם בנאגט שהוספנו שמאפשר לקרוא את התוצאות בתוך שאילתת האס-קיו-אל
        protected OleDbDataReader reader;

        //הגדרת משתנים סטטיים , כאשר כל רשימה מייצגת סוג של שינויים בישויות
        public static List<ChangeEntity> inserted = new List<ChangeEntity>();
        public static List<ChangeEntity> deleted = new List<ChangeEntity>();
        public static List<ChangeEntity> updated = new List<ChangeEntity>();

        //הגדרת פעולות ליצרת שאילתות אס-קיו-אל עבור הוספה, עדכון ומחיקה של ישויות במסד הנתונים
        protected abstract void CreateInsertSQL(Base entity, OleDbCommand cmd);
        protected abstract void CreateUpdateSQL(Base entity, OleDbCommand cmd);
        protected abstract void CreateDeletedSQL(Base entity, OleDbCommand cmd);

        // פעולה המגדירה ישות חדשה
        protected abstract Base NewEntity();

        //פעולה המבצעת הוספה של ישות לרשימת הישויות המוכנות להוספה, כאשר תנאים מתאימים נענים
        public virtual void Insert(Base entity)
        {
            Base reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity)); ;
            }        }

        //פעולה המבצעת עדכון לרשימת הישויות המוכנות לעדכון, כאשר תנאים מתאימים נענים
        public virtual void Update(Base entity)
        {
            Base reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
            }
        }

        //פעולה המבצעת מחיקה מרשימת הישויות המוכנות למחיקה, כאשר תנאים מתאימים נענים
        public virtual void Delete(Base entity)
        {
            Base reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
            }
        }

        //פעולה המבצעת קריאה ממסד הנתונים ומחזירה רשימת ישויות מסוג בייס
        protected List<Base> Select()
        {
            List<Base> list = new List<Base>();

            try
            {
                command.Connection = connection;
                // command.CommandTGext = sqlStr;
                connection.Open();
                reader = command.ExecuteReader();


                while (reader.Read())
                {
                    Base entity = NewEntity();
                    list.Add(CreateModel(entity));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(
                    e.Message + "\nSQL:" + command.CommandText);
            }
            finally
            {
                if (reader != null) reader.Close();
                if (connection.State == ConnectionState.Open) connection.Close();
            }

            return list;
        }

        //פעולה המבצעת קריאה א-סינכרונית ממסד הנתונים ומחזירה רשימת ישויות מסוג בייס
        protected async Task<List<Base>> SelectAsync(string sqlStr)
        {
            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command = new OleDbCommand();
            List<Base> list = new List<Base>();

            try
            {
                command.Connection = connection;
                command.CommandText = sqlStr;
                connection.Open();
                this.reader = (OleDbDataReader)await command.ExecuteReaderAsync();


                while (reader.Read())
                {
                    Base entity = NewEntity();
                    list.Add(CreateModel(entity));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL:" + command.CommandText);
            }
            finally
            {
                if (reader != null) reader.Close();
                if (connection.State == ConnectionState.Open) connection.Close();
            }

            return list;
        }

       //בנאי המאתחל את אובייקט החיבור ואת אובייקט הפקודה עם חיבור המוגדר מראש בעזרת מחרוזת החיבור
        public BaseDB()
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }

        //פעולה המבצעת שמירת שינויים במסד הנתונים על ידי ביצוע פעולות הוספה
        //מחיקה לפי הישויות שנאספו ברשימות המתאימות, הפעולה משתמשת בטרנזקציה כדי להבטיח
        //עקיפת כל הפעולות במקרה של כשלון, ומחזירה את מספר השורות שהושפעו ע"י השינויים
        public int SaveChanges()
        {
            OleDbTransaction trans = null;

            int records_affected = 0;

            try
            {
                connection.Open();
                trans = connection.BeginTransaction();
                command.Transaction = trans;

                foreach (var entity in inserted)
                {
                    command.Parameters.Clear();
                    entity.CreateSql(entity.Entity, command); //cmd.CommandText = CreateInsertSQL(entity.Entity);
                    records_affected += command.ExecuteNonQuery();

                    command.CommandText = "Select @@Identity";
                    entity.Entity.Id = (int)command.ExecuteScalar();
                }

                foreach (var entity in updated)
                {
                    command.Parameters.Clear();
                    entity.CreateSql(entity.Entity, command); //cmd.CommandText = CreateUpdateSQL(entity.Entity);
                    records_affected += command.ExecuteNonQuery();
                }

                foreach (var entity in deleted)
                {
                    command.Parameters.Clear();
                    entity.CreateSql(entity.Entity, command);

                    records_affected += command.ExecuteNonQuery();
                }

                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                System.Diagnostics.Debug.WriteLine(ex.Message + "\n SQL:" + command.CommandText);
            }
            finally
            {
                inserted.Clear();
                updated.Clear();
                deleted.Clear();

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

            return records_affected;
        }

        //פעולה המבצעת שמירת שינויים במסד הנתונים באופן א-סינכרוני, בעזרת ביצוע פעולות
        //הוספה, עדכון, ומחיקה עבור הישויות המצויות ברשימות המתאימות
        //הפעולה משתמש בפעולות א-סינכרוניות כדי לבצע פעולות עם המסד ומחזירה את מספר השורות שהושפעו ע"י השינויים
        public async Task<int> SaveChangesAsync()
        {
            int records_affected = 0;
            OleDbCommand command = new OleDbCommand();
            try
            {
                command.Connection = this.connection;
                this.connection.Open();

                foreach (var item in inserted)
                {
                    command.Parameters.Clear();
                    item.CreateSql(item.Entity, command);
                    records_affected += await command.ExecuteNonQueryAsync();

                    command.CommandText = "Select @@Identity";
                    item.Entity.Id = (int)command.ExecuteScalarAsync().Result;
                }

                foreach (var item in updated)
                {
                    command.Parameters.Clear();
                    item.CreateSql(item.Entity, command);
                    records_affected += await command.ExecuteNonQueryAsync();
                }

                foreach (var item in deleted)
                {
                    command.Parameters.Clear();
                    item.CreateSql(item.Entity, command);
                    records_affected += await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL:" + command.CommandText);
            }
            finally
            {
                inserted.Clear();
                updated.Clear();
                deleted.Clear();

                if (connection.State == ConnectionState.Open) connection.Close();
            }

            return records_affected;
        }

        //הפעולה יוצרת מודל עבור הישות הנתונה על ידי קריאת ערך מזהה(איי-דיי) מהקורא ומקציאה אותו למאפיין של הישות
        protected virtual Base CreateModel(Base entity)
        {
            entity.Id = (int)reader["ID"];
            return entity;
        }
    }
}
