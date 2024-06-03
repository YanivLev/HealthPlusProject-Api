using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Model;
using System.Drawing;

namespace HealthPlusApiService
{
    public interface IApiService
    {
        #region User
        Task<UserList> GetUserList();
        Task<int> InsertUser(User user);
        Task<int> UpdateUser(User user);
        Task<int> DeleteUser(User user);
        #endregion

        #region UserData
        Task<UserDataList> GetUserDataList();
        Task<int> InsertUserData(UserData userdata);
        Task<int> UpdateUserData(UserData userdata);
        Task<int> DeleteUserData(UserData userdata);
        #endregion

        #region MealName
        Task<MealNameList> GetMealNameList();
        Task<int> InsertMealName(MealName mealname);
        Task<int> UpdateMealName(MealName mealname);
        Task<int> DeleteMealName(MealName mealname);
        #endregion

        #region Meal
        Task<MealList> GetMealList();
        Task<int> InsertMeal(Meal meal);
        Task<int> UpdateMeal(Meal meal);
        Task<int> DeleteMeal(Meal meal);
        #endregion

        #region Serving
        Task<ServingList> GetServingList();
        Task<int> InsertServing(Serving serving);
        Task<int> UpdateServing(Serving serving);
        Task<int> DeleteServing(Serving serving);
        #endregion

        #region Goal
        Task<GoalList> GetGoalList();
        Task<int> InsertGoal(Goal goal);
        Task<int> UpdateGoal(Goal goa);
        Task<int> DeleteGoal(Goal goa);
        #endregion

        #region Gender
        Task<GenderList> GetGenderList();
        Task<int> InsertGender(Gender gender);
        Task<int> UpdateGender(Gender gender);
        Task<int> DeleteGender(Gender gender);
        #endregion

        #region FoodData
        Task<FoodDataList> GetFoodDataList();
        Task<int> InsertFoodData(FoodData fooddata);
        Task<int> UpdateFoodData(FoodData fooddata);
        Task<int> DeleteFoodData(FoodData fooddata);
        #endregion

        #region Food
        Task<FoodList> GetFoodList();
        Task<int> InsertFood(Food food);
        Task<int> UpdateFood(Food food);
        Task<int> DeleteFood(Food food);
        #endregion

    }
}
