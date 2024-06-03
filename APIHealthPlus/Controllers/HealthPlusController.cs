using Microsoft.AspNetCore.Mvc;
using ViewModel;
using Model;
using System.Text.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIHealthPlus.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HealthPlusController : ControllerBase
    {
        #region SelectAll
        [HttpGet]
        [ActionName("FoodSelector")]
        public FoodList SelectAllFood()
        {
            FoodDB foodDB = new FoodDB();
            FoodList food = foodDB.SelectAll();
            return food;
        }

        [HttpGet]
        [ActionName("FoodDataSelector")]
        public FoodDataList SelectAllFoodData()
        {
            FoodDataDB fooddataDB = new FoodDataDB();
            FoodDataList fooddata = fooddataDB.SelectAll();
            return fooddata;
        }

        [HttpGet]
        [ActionName("GenderSelector")]
        public GenderList SelectAllGender()
        {
            GenderDB genderDB = new GenderDB();
            GenderList gender = genderDB.SelectAll();
            return gender;
        }

        [HttpGet]
        [ActionName("MealSelector")]
        public MealList SelectAllMeal()
        {
            MealDB mealDB = new MealDB();
            MealList meal = mealDB.SelectAll();
            return meal;
        }

        [HttpGet]
        [ActionName("MealNameSelector")]
        public MealNameList SelectAllMealName()
        {
            MealNameDB mealnameDB = new MealNameDB();
            MealNameList mealname = mealnameDB.SelectAll();
            return mealname;
        }

        [HttpGet]
        [ActionName("ServingSelector")]
        public ServingList SelectAllServing()
        {
            ServingDB servingDB = new ServingDB();
            ServingList serving = servingDB.SelectAll();
            return serving;
        }

        [HttpGet]
        [ActionName("UserDataSelector")]
        public UserDataList SelectAllUserData()
        {
            UserDataDB userdataDB = new UserDataDB();
            UserDataList userdata = userdataDB.SelectAll();
            return userdata;
        }

        [HttpGet]
        [ActionName("UserSelector")]
        public UserList SelectAllUser()
        {
            UserDB userDB = new UserDB();
            UserList user = userDB.SelectAll();
            return user;
        }
        #endregion

        #region Insert
        [HttpPost]
        [ActionName("InsertFoodData")]
        public int InsertFoodData([FromBody] FoodData fd)
        {
            FoodDataDB fooddataDB = new FoodDataDB();
            fooddataDB.Insert(fd);
            int x = fooddataDB.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("InsertFood")]
        public int InsertFood([FromBody] Food f)
        {
            FoodDB foodDB = new FoodDB();
            foodDB.Insert(f);
            int x = foodDB.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("InsertGender")]
        public int InsertGender([FromBody] Gender g)
        {
            GenderDB genderDB = new GenderDB();
            genderDB.Insert(g);
            int x = genderDB.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("InsertMeal")]
        public int InsertMeal([FromBody] Meal m)
        {
            MealDB mealDB = new MealDB();
            mealDB.Insert(m);
            int x = mealDB.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("InsertMealName")]
        public int InsertMealName([FromBody] MealName mn)
        {
            MealNameDB mealnameDB = new MealNameDB();
            mealnameDB.Insert(mn);
            int x = mealnameDB.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("InsertServing")]
        public int InsertServing([FromBody] Serving s)
        {
            ServingDB servingDB = new ServingDB();
            servingDB.Insert(s);
            int x = servingDB.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("InsertUserData")]
        public int InsertUserData([FromBody] UserData ud)
        {
            UserDataDB userdataDB = new UserDataDB();
            userdataDB.Insert(ud);
            int x = userdataDB.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("InsertUser")]
        public int InsertUser([FromBody] User u)
        {
            UserDB userDB = new UserDB();
            userDB.Insert(u);
            int x = userDB.SaveChanges();
            return x;
        }
        #endregion

        #region Update
        [HttpPut]
        [ActionName("UpdateUser")]
        public int UpdateUser([FromBody] User u)
        {
            UserDB userDB = new UserDB();
            userDB.Update(u);
            int x = userDB.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("UpdateUserData")]
        public int UpdateUserData([FromBody] UserData ud)
        {
            UserDataDB userdataDB = new UserDataDB();
            userdataDB.Update(ud);
            int x = userdataDB.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("UpdateServing")]
        public int UpdateServing([FromBody] Serving s)
        {
            ServingDB servingDB = new ServingDB();
            servingDB.Update(s);
            int x = servingDB.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("UpdateMealName")]
        public int UpdateMealName([FromBody] MealName mn)
        {
            MealNameDB mealnameDB = new MealNameDB();
            mealnameDB.Update(mn);
            int x = mealnameDB.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("UpdateMeal")]
        public int UpdateMeal([FromBody] Meal m)
        {
            MealDB mealDB = new MealDB();
            mealDB.Update(m);
            int x = mealDB.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("UpdateGender")]
        public int UpdateGender([FromBody] Gender g)
        {
            GenderDB genderDB = new GenderDB();
            genderDB.Update(g);
            int x = genderDB.SaveChanges();
            return x;
        }


        [HttpPut]
        [ActionName("UpdateFood")]
        public int UpdateFood([FromBody] Food f)
        {
            FoodDB foodDB = new FoodDB();
            foodDB.Update(f);
            int x = foodDB.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("UpdateFoodData")]
        public int UpdateFoodData([FromBody] FoodData fd)
        {
            FoodDataDB fooddataDB = new FoodDataDB();
            fooddataDB.Update(fd);
            int x = fooddataDB.SaveChanges();
            return x;
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        [ActionName("DeleteFoodData")]
        public int DeleteFoodData(int id)
        {
            FoodData fooddata = FoodDataDB.SelectById(id);
            FoodDataDB fooddataDB = new FoodDataDB();
            fooddataDB.Delete(fooddata);
            int x = fooddataDB.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteFood")]
        public int DeleteFood(int id)
        {
            Food food = FoodDB.SelectById(id);
            FoodDB foodDB = new FoodDB();
            foodDB.Delete(food);
            int x = foodDB.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteGender")]
        public int DeleteGender(int id)
        {
            Gender gender = GenderDB.SelectById(id);
            GenderDB genderDB = new GenderDB();
            genderDB.Delete(gender);
            int x = genderDB.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteMeal")]
        public int DeleteMeal(int id)
        {
            Meal meal = MealDB.SelectById(id);
            MealDB mealDB = new MealDB();
            mealDB.Delete(meal);
            int x = mealDB.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteMealName")]
        public int DeleteMealName(int id)
        {
            MealName mealname = MealNameDB.SelectById(id);
            MealNameDB mealnameDB = new MealNameDB();
            mealnameDB.Delete(mealname);
            int x = mealnameDB.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteServing")]
        public int DeleteServing(int id)
        {
            Serving serving = ServingDB.SelectById(id);
            ServingDB servingDB = new ServingDB();
            servingDB.Delete(serving);
            int x = servingDB.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteUser")]
        public int DeleteUser(int id)
        {
            User user = UserDB.SelectById(id);
            UserDB userDB = new UserDB();
            userDB.Delete(user);
            int x = userDB.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteUserData")]
        public int DeleteUserData(int id)
        {
            UserData userdata = UserDataDB.SelectById(id);
            UserDataDB userdataDB = new UserDataDB();
            userdataDB.Delete(userdata);
            int x = userdataDB.SaveChanges();
            return x;
        }

        #endregion

        #region Login+Register
        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login([FromBody] JsonElement j)
        {
            UserDB uDB = new UserDB();
            string username = j.GetProperty("username").GetString();
            string gmail = j.GetProperty("gmail").GetString();

            User u1 = uDB.SelectAll().Find(x => x.Username == username && x.Gmail == gmail);
            if (u1 == null)
                return BadRequest();
            return Ok(u1);
        }

        [HttpPost]
        [ActionName("Register")]
        public ActionResult Register([FromBody] JsonElement j)
        {
            UserDB uDB = new UserDB();
            string username = j.GetProperty("username").GetString();
            string phone = j.GetProperty("phone").GetString();
            string gmail = j.GetProperty("gmail").GetString();
            int gender = j.GetProperty("gender").GetInt32();

            User u1 = uDB.SelectAll().Find(x => x.Username == username && x.Phone == phone && x.Gmail == gmail && x.Gender.Id == gender);
            if (u1 != null)
                return BadRequest();
            User u2 = new User { Username = username, Phone = phone, Gmail = gmail, Gender = GenderDB.SelectById(gender)};
            uDB.Insert(u2);
            uDB.SaveChanges();
            return Ok(u1);
        }
        #endregion
    }
}
