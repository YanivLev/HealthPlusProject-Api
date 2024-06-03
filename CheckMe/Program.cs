using ViewModel;
using Model;
using System.Reflection.Emit;






#region fooddata
//FoodDataDB fdDB = new FoodDataDB();
//FoodDataList fdlist = fdDB.SelectAll();
//foreach(FoodData fd in fdlist)
//{
//    Console.WriteLine(fd.Calories);
//    Console.WriteLine(fd.Carbs);
//    Console.WriteLine(fd.Protein);
//}
//FoodData fd2=new FoodData() { Calories=90, Protein=80, Carbs=400, Fibers=23, Fat=14, Sugar=400, Cholesterol=198};
//fdDB.Insert(fd2);
//fdDB.SaveChanges();
//FoodDataList fdlist2 = fdDB.SelectAll();
//foreach (FoodData fd in fdlist2)
//{
//    Console.WriteLine(fd2.Calories);
//    Console.WriteLine(fd2.Carbs);
//    Console.WriteLine(fd2.Protein);
//}
//fdDB.Delete(fdlist[2]);
//fdDB.SaveChanges();
//FoodDataList fd2list = fdDB.SelectAll();
//foreach (FoodData fd in fd2list).
//{
//    Console.WriteLine(fd.Calories);
//    Console.WriteLine(fd.Carbs);
//    Console.WriteLine(fd.Protein);
//}
//FoodData fd3 = fdlist.First();
//fd3.Calories = 200;
//fdDB.Update(fd3);
//fdDB.SaveChanges();
//foreach (FoodData fd in fdlist)
//{
//    Console.WriteLine(fd.Calories);
//    Console.WriteLine(fd.Carbs);
//    Console.WriteLine(fd.Protein);
//}
#endregion
#region user
//UserDB uDB = new UserDB();
//UserDataDB udDB = new UserDataDB();
//UserList ulist = uDB.SelectAll();
//foreach (User u in ulist)
//{
//    Console.WriteLine(u.Id);
//    Console.WriteLine(u.Username);
//    Console.WriteLine(u.Gmail);
//    Console.WriteLine(u.Phone);
//    Console.WriteLine(u.Gender.NameGender);
//    Console.WriteLine(u.IsManager);

//}
//GenderDB gdb = new GenderDB();
//GenderList db = gdb.SelectAll();

//User u2 = new User() {Id = 10, Username = "Roni Fluk", Gmail = "ronifluk2@gmail.com", Phone = "0549876547", Gender = db[1] , IsManager = true };
//UserData ud2 = new UserData() { Id = 10, Weight = 70, Height = 180, Birthdate = new DateTime(2006, 04, 21, 20, 2, 1) };
//udDB.Insert(ud2);
//uDB.Insert(u2);

//uDB.SaveChanges();
//udDB.SaveChanges();
//UserList ulist2 = uDB.SelectAll();
//UserDataList udlist2 = udDB.SelectAll();
//foreach (User u in ulist2)
//{
//    Console.WriteLine(u.Id);
//    Console.WriteLine(u.Username);
//    Console.WriteLine(u.Gmail);
//    Console.WriteLine(u.Phone);
//    Console.WriteLine(u.Gender.NameGender);
//    Console.WriteLine(u.IsManager);

//}

//User u3 = ulist2.First();
//u3.Username = "Itay Zadaka";
//uDB.Update(u3);
//uDB.SaveChanges();
//foreach (User u in ulist2)
//{
//    Console.WriteLine(u.Id);
//    Console.WriteLine(u.Username);
//    Console.WriteLine(u.Gmail);
//    Console.WriteLine(u.Phone);
//    Console.WriteLine(u.Gender.NameGender);
//    Console.WriteLine(u.IsManager);
//}
//#endregion
//uDB.Delete(ulist2[2]);
//udDB.Delete(udlist2[2]);
//uDB.SaveChanges();
//UserList u2list = uDB.SelectAll();
//foreach(User u in u2list)
//{
//    Console.WriteLine(u.Id);
//    Console.WriteLine(u.Username);
//    Console.WriteLine(u.Gmail);
//    Console.WriteLine(u.Phone);
//    Console.WriteLine(u.Gender.NameGender);
//    Console.WriteLine(u.IsManager);
//}
#endregion
#region userdata
//UserDataDB udDB = new UserDataDB();
//UserDataList udlist = udDB.SelectAll();
//foreach (UserData ud in udlist)
//{
//    Console.WriteLine(ud.Weight);
//    Console.WriteLine(ud.Height);
//    Console.WriteLine(ud.Birthdate);
//}

//udDB.Delete(udlist[0]);
//udDB.SaveChanges();
//UserDataList udlist2 = udDB.SelectAll();
//foreach (UserData u in udlist2)
//{
//    Console.WriteLine(u.Id);
//    Console.WriteLine(u.Username);
//    Console.WriteLine(u.Gmail);
//    Console.WriteLine(u.Phone);
//    Console.WriteLine(u.Gender.NameGender);
//    Console.WriteLine(u.IsManager);
//}

//UserData ud3 = udlist.First();
//ud3.Weight = 80;
//udDB.Update(ud3);
//udDB.SaveChanges();
//foreach (UserData ud in udlist)
//{
//    Console.WriteLine(ud.Weight);
//    Console.WriteLine(ud.Height);
//    Console.WriteLine(ud.Birthdate);
//}
#endregion

#region Food
//FoodDB fDB = new FoodDB();
//FoodList flist = fDB.SelectAll();
//foreach (Food f in flist)
//{
//    Console.WriteLine(f.Id);
//    Console.WriteLine(f.Foodname);
//    Console.WriteLine(f.Servingtype.Servingtype);
//}

//ServingDB sdb = new ServingDB();
//ServingList sb = sdb.SelectAll();
//Food f2 = new Food() {Id=8, Foodname="Falafel", Servingtype = sb[1]};
//fDB.Insert(f2);
//fDB.SaveChanges();
//FoodList flist2 = fDB.SelectAll();
//foreach (Food f in flist2)
//{
//    Console.WriteLine(f.Id);
//    Console.WriteLine(f.Foodname);
//    Console.WriteLine(f.Servingtype.Servingtype);
//}


//fDB.Delete(flist[2]);
//fDB.SaveChanges();
//FoodList f2list = fDB.SelectAll();
//foreach (Food f in f2list)
//{
//    Console.WriteLine(f.Id);
//    Console.WriteLine(f.Foodname);
//    Console.WriteLine(f.Servingtype.Servingtype);
//}

//Food f3 = flist.First();
//f3.Foodname = "Falafel";
//fDB.Update(f3);
//fDB.SaveChanges();
//foreach (Food f in flist)
//{
//    Console.WriteLine(f.Id);
//    Console.WriteLine(f.Foodname);
//    Console.WriteLine(f.Servingtype.Servingtype);
//}
#endregion

#region Meal
//MealDB mDB = new MealDB();
//MealList mlist = mDB.SelectAll();
//foreach (Meal m in mlist)
//{
//    Console.WriteLine(m.Id);
//    Console.WriteLine(m.User.Username);
//    Console.WriteLine(m.Mealdate);
//    Console.WriteLine(m.Mealname.Mealname);
//    Console.WriteLine(m.Food.Foodname);
//    Console.WriteLine(m.Amount);
//}

//UserDB udb = new UserDB();
//UserList u = udb.SelectAll();
//FoodDB fdb = new FoodDB();
//FoodList f = fdb.SelectAll();
//MealNameDB mndb = new MealNameDB();
//MealNameList mn = mndb.SelectAll();
//Meal m = new Meal() {Id=5, User = u[1], Mealdate=new DateTime(2023,12,19,0,0,0), Mealname = mn[1], Food = f[1],Amount=1 };
//mDB.Insert(m);
//mDB.SaveChanges();
//MealList mlist2 = mDB.SelectAll();
//foreach (Meal m2 in mlist2)
//{
//    Console.WriteLine(m.Id);
//    Console.WriteLine(m.User.Username);
//    Console.WriteLine(m.Mealdate);
//    Console.WriteLine(m.Mealname.Mealname);
//    Console.WriteLine(m.Food.Foodname);
//    Console.WriteLine(m.Amount);
//}


//mDB.Delete(mlist[2]);
//mDB.SaveChanges();
//MealList m2list = mDB.SelectAll();
//foreach (Meal m in m2list)
//{
//    Console.WriteLine(m.Id);
//    Console.WriteLine(m.User.Username);
//    Console.WriteLine(m.Mealdate);
//    Console.WriteLine(m.Mealname.Mealname);
//    Console.WriteLine(m.Food.Foodname);
//    Console.WriteLine(m.Amount);
//}

//Meal m3 = mlist.First();
//m3.Amount = 2;
//mDB.Update(m3);
//mDB.SaveChanges();
//foreach (Meal m in mlist)
//{
//    Console.WriteLine(m.Id);
//    Console.WriteLine(m.User.Username);
//    Console.WriteLine(m.Mealdate);
//    Console.WriteLine(m.Mealname.Mealname);
//    Console.WriteLine(m.Food.Foodname);
//    Console.WriteLine(m.Amount);
//}
#endregion

#region Goal
//GoalDB gDB = new GoalDB();
//GoalList glist = gDB.SelectAll();
//foreach (Goal g in glist)
//{
//    Console.WriteLine(g.Id);
//    Console.WriteLine(g.User.Username);
//    Console.WriteLine(g.Weightgoal);
//    Console.WriteLine(g.Caloriegoal);
//}

//gDB.Delete(glist[0]);
//gDB.SaveChanges();
//GoalList glist2 = gDB.SelectAll();
//foreach (Goal g in glist)
//{
//    Console.WriteLine(g.Id);
//    Console.WriteLine(g.User.Username);
//    Console.WriteLine(g.Weightgoal);
//    Console.WriteLine(g.Caloriegoal);
//}

//Goal g3 = glist.First();
//g3.Caloriegoal = 4700;
//gDB.Update(g3);
//gDB.SaveChanges();
//foreach (Goal g in glist)
//{
//    Console.WriteLine(g.Id);
//    Console.WriteLine(g.User.Username);
//    Console.WriteLine(g.Weightgoal);
//    Console.WriteLine(g.Caloriegoal);
//}
#endregion

#region ServingType
//ServingDB sDB = new ServingDB();
//ServingList slist = sDB.SelectAll();
//foreach (Serving s in slist)
//{
//    Console.WriteLine(s.Id);
//    Console.WriteLine(s.Servingtype);
//}

//sDB.Delete(slist[0]);
//sDB.SaveChanges();
//ServingList slist2 = sDB.SelectAll();
//foreach (Serving s in slist2)
//{
//    Console.WriteLine(s.Id);
//    Console.WriteLine(s.Servingtype);
//}

//Serving s = new Serving() { Id = 8, Servingtype="per 1.0 oz" };
//sDB.Insert(s);
//sDB.SaveChanges();
//ServingList slist2 = sDB.SelectAll();
//foreach (Serving s2 in slist2)
//{
//    Console.WriteLine(s2.Id);
//    Console.WriteLine(s2.Servingtype);
//}

//Serving s3 = slist.First();
//s3.Servingtype = "per 1 liter";
//sDB.Update(s3);
//sDB.SaveChanges();
//foreach (Serving s in slist)
//{
//    Console.WriteLine(s.Id);
//    Console.WriteLine(s.Servingtype);
//}

#endregion

#region Gender
//GenderDB geDB = new GenderDB();
//GenderList glist = geDB.SelectAll();
//foreach (Gender g in glist)
//{
//    Console.WriteLine(g.Id);
//    Console.WriteLine(g.NameGender);
//}

//geDB.Delete(glist[0]);
//geDB.SaveChanges();
//GenderList glist2 = geDB.SelectAll();
//foreach (Gender g in glist2)
//{
//    Console.WriteLine(g.Id);
//    Console.WriteLine(g.NameGender);
//}

//Gender g = new Gender() { Id = 3, NameGender = "Other" };
//geDB.Insert(g);
//geDB.SaveChanges();
//GenderList glist2 = geDB.SelectAll();
//foreach (Gender g3 in glist2)
//{
//    Console.WriteLine(g3.Id);
//    Console.WriteLine(g3.NameGender);
//}

//Gender g4 = glist.First();
//g4.NameGender = "Man";
//geDB.Update(g4);
//geDB.SaveChanges();
//foreach (Gender g in glist)
//{
//    Console.WriteLine(g.Id);
//    Console.WriteLine(g.NameGender);
//}
#endregion

#region MealName
//MealNameDB mnDB = new MealNameDB();
//MealNameList mnlist = mnDB.SelectAll();
//foreach (MealName mn in mnlist)
//{
//    Console.WriteLine(mn.Id);
//    Console.WriteLine(mn.Mealname);
//}

//mnDB.Delete(mnlist[0]);
//mnDB.SaveChanges();
//MealNameList mnlist2 = mnDB.SelectAll();
//foreach (MealName mn in mnlist2)
//{
//    Console.WriteLine(mn.Id);
//    Console.WriteLine(mn.Mealname);
//}

//MealName mn = new MealName() { Id = 5, Mealname = "Drink" };
//mnDB.Insert(mn);
//mnDB.SaveChanges();
//MealNameList mnlist2 = mnDB.SelectAll();
//foreach (MealName mn2 in mnlist2)
//{
//    Console.WriteLine(mn2.Id);
//    Console.WriteLine(mn2.Mealname);
//}

//MealName mn3 = mnlist.First();
//mn3.Mealname = "Breakfast";
//mnDB.Update(mn3);
//mnDB.SaveChanges();
//foreach (MealName mn in mnlist)
//{
//    Console.WriteLine(mn.Id);
//    Console.WriteLine(mn.Mealname);
//}
#endregion
