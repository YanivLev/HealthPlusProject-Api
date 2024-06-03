using ViewModel;
using Model;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HealthPlusApiService
{
    public class ApiService : IApiService
    {

        //כתובת דינמית
        string adress = "https://0b80-84-228-30-175.ngrok-free.app";
        #region User

        public async Task<UserList> GetUserList()
        {
            HttpClient client = new HttpClient();
            UserList userList = null;
            try
            {
                string URI = adress + "/api/HealthPlus/UserSelector";
                userList = await client.GetFromJsonAsync<UserList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return userList;
        }

        public async Task<int> InsertUser(User user)
        {
            HttpClient httpClient = new HttpClient();
            String URI = adress + "/api/HealthPlus/InsertUser";
            var x = await httpClient.PostAsJsonAsync<User>(URI, user);
            if (x.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> UpdateUser(User user)
        {
            HttpClient client = new HttpClient();
            string URI = adress + "/api/HealthPlus/UpdateUser";
            HttpResponseMessage response = await client.PutAsJsonAsync<User>(URI, user);
            if (response.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> DeleteUser(User user)
        {
            HttpClient client = new HttpClient();
            int num = 0;
            try
            {
                return (await client.DeleteAsync(adress + "/api/HealthPlus/DeleteUser/" + user.Id)).IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return num;
        }
        #endregion

        #region UserData
        public async Task<UserDataList> GetUserDataList()
        {
            HttpClient client = new HttpClient();
            UserDataList userdataList = null;
            try
            {
                string URI = adress + "/api/HealthPlus/UserDataSelector";
                userdataList = await client.GetFromJsonAsync<UserDataList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return userdataList;
        }

        public async Task<int> InsertUserData(UserData userdata)
        {
            HttpClient httpClient = new HttpClient();
            String URI = adress + "/api/HealthPlus/InsertUserData";
            var x = await httpClient.PostAsJsonAsync<UserData>(URI, userdata);
            if (x.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> UpdateUserData(UserData userdata)
        {
            HttpClient client = new HttpClient();
            string URI = adress + "/api/HealthPlus/UpdateUserData";
            HttpResponseMessage response = await client.PutAsJsonAsync<UserData>(URI, userdata);
            if (response.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> DeleteUserData(UserData userdata)
        {
            HttpClient client = new HttpClient();
            int num = 0;
            try
            {
                return (await client.DeleteAsync(adress + "/api/HealthPlus/DeleteUserData/" + userdata.Id)).IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return num;
        }
        #endregion

        #region FoodData
        public async Task<FoodDataList> GetFoodDataList()
        {
            HttpClient client = new HttpClient();
            FoodDataList fooddataList = null;
            try
            {
                string URI = adress + "/api/HealthPlus/FoodDataSelector";
                fooddataList = await client.GetFromJsonAsync<FoodDataList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return fooddataList;
        }

        public async Task<int> InsertFoodData(FoodData fooddata)
        {
            HttpClient httpClient = new HttpClient();
            String URI = adress + "/api/HealthPlus/InsertFoodData";
            var x = await httpClient.PostAsJsonAsync<FoodData>(URI, fooddata);
            if (x.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> UpdateFoodData(FoodData fooddata)
        {
            HttpClient client = new HttpClient();
            string URI = adress + "/api/HealthPlus/UpdateFoodData";
            HttpResponseMessage response = await client.PutAsJsonAsync<FoodData>(URI, fooddata);
            if (response.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> DeleteFoodData(FoodData fooddata)
        {
            HttpClient client = new HttpClient();
            int num = 0;
            try
            {
                return (await client.DeleteAsync(adress + "/api/HealthPlus/DeleteFoodData/" + fooddata.Id)).IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return num;
        }
        #endregion

        #region Food
        public async Task<FoodList> GetFoodList()
        {
            HttpClient client = new HttpClient();
            FoodList foodList = null;
            try
            {
                string URI = adress + "/api/HealthPlus/FoodSelector";
                foodList = await client.GetFromJsonAsync<FoodList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return foodList;
        }

        public async Task<int> InsertFood(Food food)
        {
            HttpClient httpClient = new HttpClient();
            String URI = adress + "/api/HealthPlus/InsertFood";
            var x = await httpClient.PostAsJsonAsync<Food>(URI, food);
            if (x.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> UpdateFood(Food food)
        {
            HttpClient client = new HttpClient();
            string URI = adress + "/api/HealthPlus/UpdateFood";
            HttpResponseMessage response = await client.PutAsJsonAsync<Food>(URI, food);
            if (response.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> DeleteFood(Food food)
        {
            HttpClient client = new HttpClient();
            int num = 0;
            try
            {
                return (await client.DeleteAsync(adress + "/api/HealthPlus/DeleteFood/" + food.Id)).IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return num;
        }
        #endregion

        #region MealName
        public async Task<MealNameList> GetMealNameList()
        {
            HttpClient client = new HttpClient();
            MealNameList mealnameList = null;
            try
            {
                string URI = adress + "/api/HealthPlus/MealNameSelector";
                mealnameList = await client.GetFromJsonAsync<MealNameList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return mealnameList;
        }

        public async Task<int> InsertMealName(MealName mealname)
        {
            HttpClient httpClient = new HttpClient();
            String URI = adress + "/api/HealthPlus/InsertMealName";
            var x = await httpClient.PostAsJsonAsync<MealName>(URI, mealname);
            if (x.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> UpdateMealName(MealName mealname)
        {
            HttpClient client = new HttpClient();
            string URI = adress + "/api/HealthPlus/UpdateMealName";
            HttpResponseMessage response = await client.PutAsJsonAsync<MealName>(URI, mealname);
            if (response.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> DeleteMealName(MealName mealname)
        {
            HttpClient client = new HttpClient();
            int num = 0;
            try
            {
                return (await client.DeleteAsync(adress + "/api/HealthPlus/DeleteMealName/" + mealname.Id)).IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return num;
        }
        #endregion

        #region Meal
        public async Task<MealList> GetMealList()
        {
            HttpClient client = new HttpClient();
            MealList mealList = null;
            try
            {
                string URI = adress + "/api/HealthPlus/MealSelector";
                mealList = await client.GetFromJsonAsync<MealList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return mealList;
        }

        public async Task<int> InsertMeal(Meal meal)
        {
            HttpClient httpClient = new HttpClient();
            String URI = adress + "/api/HealthPlus/InsertMeal";
            var x = await httpClient.PostAsJsonAsync<Meal>(URI, meal);
            if (x.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> UpdateMeal(Meal meal)
        {
            HttpClient client = new HttpClient();
            string URI = adress + "/api/HealthPlus/UpdateMeal";
            HttpResponseMessage response = await client.PutAsJsonAsync<Meal>(URI, meal);
            if (response.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> DeleteMeal(Meal meal)
        {
            HttpClient client = new HttpClient();
            int num = 0;
            try
            {
                return (await client.DeleteAsync(adress + "/api/HealthPlus/DeleteMeal/" + meal.Id)).IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return num;
        }
        #endregion

        #region Gender
        public async Task<GenderList> GetGenderList()
        {
            HttpClient client = new HttpClient();
            GenderList genderList = null;
            try
            {
                string URI = adress + "/api/HealthPlus/GenderSelector";
                genderList = await client.GetFromJsonAsync<GenderList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return genderList;
        }

        public async Task<int> InsertGender(Gender gender)
        {
            HttpClient httpClient = new HttpClient();
            String URI = adress + "/api/HealthPlus/InsertGender";
            var x = await httpClient.PostAsJsonAsync<Gender>(URI, gender);
            if (x.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> UpdateGender(Gender gender)
        {
            HttpClient client = new HttpClient();
            string URI = adress + "/api/HealthPlus/UpdateGender";
            HttpResponseMessage response = await client.PutAsJsonAsync<Gender>(URI, gender);
            if (response.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> DeleteGender(Gender gender)
        {
            HttpClient client = new HttpClient();
            int num = 0;
            try
            {
                return (await client.DeleteAsync(adress + "/api/HealthPlus/DeleteGender/" + gender.Id)).IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return num;
        }
        #endregion

        #region Serving
        public async Task<ServingList> GetServingList()
        {
            HttpClient client = new HttpClient();
            ServingList servingList = null;
            try
            {
                string URI = adress + "/api/HealthPlus/ServingSelector";
                servingList = await client.GetFromJsonAsync<ServingList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return servingList;
        }

        public async Task<int> InsertServing(Serving serving)
        {
            HttpClient httpClient = new HttpClient();
            String URI = adress + "/api/HealthPlus/InsertServing";
            var x = await httpClient.PostAsJsonAsync<Serving>(URI, serving);
            if (x.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> UpdateServing(Serving serving)
        {
            HttpClient client = new HttpClient();
            string URI = adress + "/api/HealthPlus/UpdateServing";
            HttpResponseMessage response = await client.PutAsJsonAsync<Serving>(URI, serving);
            if (response.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> DeleteServing(Serving serving)
        {
            HttpClient client = new HttpClient();
            int num = 0;
            try
            {
                return (await client.DeleteAsync(adress + "/api/HealthPlus/DeleteServing/" + serving.Id)).IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return num;
        }
        #endregion

        #region Login+Register
        public async Task<User> Login(string username, string gmail)
        {
            HttpClient client = new HttpClient();
            try
            {
                var x = await client.PostAsJsonAsync<object>(adress + "/api/HealthPlus/Login", new { username, gmail });
                return x.IsSuccessStatusCode ? await x.Content.ReadFromJsonAsync<User>() : null;
            }
            catch
            {
                return null;
            }
        }
        public async Task<User> Register(string username, string phone, string gmail, int gender)
        {
            HttpClient client = new HttpClient();
            try
            {
                var x = await client.PostAsJsonAsync<object>(adress + "/api/HealthPlus/Register", new { username, phone, gmail, gender });
                return x.IsSuccessStatusCode ? await x.Content.ReadFromJsonAsync<User>() : null;
            }
            catch
            {
                return null;
            }
        }


    }
}
#endregion