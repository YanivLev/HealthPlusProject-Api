using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.OleDb;
namespace ViewModel
{
    public class ChangeEntity
    {
        private Base entity;
        private CreateSql createSql;

        //הגדרת בנאי שמקבל שני פרמטרים: פונקציה ליצירת שאילתות אס-קיו-אל ואבייקט מסוג בייס
        public ChangeEntity(CreateSql createSql, Base entity)
        {
            this.createSql = createSql;
            this.entity = entity;
        }

        //יצירת גישה והגדרה של ישות מסוימת בתוך המחלקה.
        public Base Entity { get => entity; set => entity = value; }

        //מספק גישה לתיעוד של הפעולה של יצירת שאילתות אס-קיו-אל עבור אובייקט מסוים
        public CreateSql CreateSql { get => createSql; set => createSql = value; }
    }

    //הגדרת סוג נתונים מקומי, המייצג דלגייט שמקבל פרמטרים של בייס ואולדיביקומנד ואינו מחזיר ערך
    public delegate void CreateSql(Base entity, OleDbCommand command);
}
