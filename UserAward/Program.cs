using Entity;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAward.BLL.Interface;
using UserAward.Container;

namespace UserAward
{
    class Program
    {
        private static IUserLogic userLogic;
        private static IAwardLogic awardLogic;

        static void Main(string[] args)
        {
            string temp = "45 rewr";

            if (!int.TryParse(temp, out int result))
            {
                Console.WriteLine(result);
            }

            Console.WriteLine("ALL");

            //Console.WriteLine("Куда сохранять информацию? Push button: 1 - Database, 2 - File, 3 or another button - Memory (default)");
            //var command = Console.ReadKey();
            //switch (command.Key)
            //{
            //    case ConsoleKey.D1:
            //        //Регистрация зависимостей. Параметр отвечает за DAL
            //        NinjectCommon.Registration(1);
            //        break;
            //    case ConsoleKey.D2:
            //        //Регистрация зависимостей. Параметр отвечает за DAL
            //        NinjectCommon.Registration(2);
            //        break;
            //    default:
            //        //Регистрация зависимостей. Параметр отвечает за DAL
            //        NinjectCommon.Registration();
            //        break;
            //}

            //userLogic = NinjectCommon.Kernel.Get<IUserLogic>();
            //awardLogic = NinjectCommon.Kernel.Get<IAwardLogic>();

            //StartMethod();

            Console.Read();

        }


        private static void StartMethod()
        {

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"1: Add data in base");
                Console.WriteLine($"2: Show data in base");
                Console.WriteLine($"3: Another actions");
                Console.WriteLine($"4: EXIT");

                Console.Write($"Choose action: ");

                var userAction = Console.ReadLine();

                switch (userAction)
                {
                    case "1":
                        Adding();
                        break;
                    case "2":
                        Showing();
                        break;
                    case "3":
                        Actions();
                        break;
                    case "4":
                        return;
                    default:
                        break;
                }
            }
        }

        //добавление информации
        private static void Adding()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"1: Add user");
                Console.WriteLine($"2: Add award");
                Console.WriteLine($"3: HELP");
                Console.WriteLine($"4: EXIT");

                Console.Write($"Choose action: ");

                var userAction = Console.ReadLine();

                switch (userAction)
                {
                    case "1":
                        Console.Write($"User's Name: ");
                        var name = Console.ReadLine();
                        Console.Write($"User's Birthday: ");
                        var birthday = Console.ReadLine();
                        Console.Write($"User's Email: ");
                        var email = Console.ReadLine();
                        Console.Write($"User's Password: ");
                        var password = Console.ReadLine();
                        Console.Write($"User's Role: ");
                        var role = Console.ReadLine();
                        if (userLogic.AddUser(name, birthday, email, password, role, null))
                        {
                            Console.WriteLine($"User is created!{Environment.NewLine}");
                        }
                        else
                        {
                            Console.WriteLine($"User isn't created!{Environment.NewLine}");
                        }
                        break;
                    case "2":
                        Console.Write($"Award's Title: ");
                        var title = Console.ReadLine();
                        Console.Write($"Award's Description: ");
                        var description = Console.ReadLine();
                        awardLogic.AddAward(title, description, null);
                        Console.WriteLine($"Award is created!{Environment.NewLine}");
                        break;
                    case "3":
                        Console.WriteLine($"HELP YOURSELF");
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("I don't know this comuserd");
                        break;
                }
            }
        }

        //показывает информацию
        private static void Showing()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"1: Show all men");
                Console.WriteLine($"2: Show all awards");
                Console.WriteLine($"3: Show all User's award by id");
                Console.WriteLine($"4: EXIT");

                Console.Write($"Choose action: ");

                var userAction = Console.ReadLine();

                switch (userAction)
                {
                    case "1":
                        foreach (var item in userLogic.GetUsers())
                        {
                            Console.WriteLine($"{item.IdUser} : {item.Name} : {item.Birthday.Year}-{item.Birthday.Month}-{item.Birthday.Day} : {item.Age}{Environment.NewLine}");
                        }
                        break;
                    case "2":
                        foreach (var item in awardLogic.GetAwards())
                        {
                            Console.WriteLine($"{item.IdAward} : {item.Title} : {item.Description}{Environment.NewLine}");
                        }
                        break;
                    case "3":
                        Console.Write($"User's id: ");
                        var id_3 = Console.ReadLine();
                        var awardsByUser = userLogic.GetAwardFromUserAward(id_3);
                        foreach (var item in awardsByUser)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "4":
                        return;
                    default:
                        break;
                }
            }
        }


        //выбор действия
        private static void Actions()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"1: Action with user");
                Console.WriteLine($"2: Action with award");
                Console.WriteLine($"3: EXIT");

                Console.Write($"Choose action: ");

                var userAction = Console.ReadLine();

                switch (userAction)
                {
                    case "1":
                        UsersAction();
                        break;
                    case "2":
                        AwardsAction();
                        break;
                    case "3":
                        return;
                    default:
                        break;
                }
            }
        }

        //дейтсвия для Users
        private static void UsersAction()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"1: Find user by ID");
                Console.WriteLine($"2: Find user by Name");
                Console.WriteLine($"3: Find men by the first letter");
                Console.WriteLine($"4: Find men whose name starts or ends with the entered word");
                Console.WriteLine($"5: Rewarding");
                Console.WriteLine($"6: Delete user");
                Console.WriteLine($"7: Edit user");
                Console.WriteLine($"8: EXIT");

                Console.Write("Choose action: ");

                var userEnter = Console.ReadLine();

                switch (userEnter)
                {
                    case "1":
                        Console.Write($"User's ID: ");
                        var id_1 = Console.ReadLine();
                        try
                        {
                            var userById = userLogic.GetUserById(id_1);
                            Console.WriteLine($"{userById.IdUser} : {userById.Name} : {userById.Birthday.Year}-{userById.Birthday.Month}-{userById.Birthday.Day} : {userById.Age}{Environment.NewLine}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "2":
                        Console.Write($"User's name: ");
                        var name_2 = Console.ReadLine();
                        foreach (var item in userLogic.GetUserByName(name_2))
                        {
                            Console.WriteLine($"{item.IdUser} : {item.Name} : {item.Birthday.Year}-{item.Birthday.Month}-{item.Birthday.Day} : {item.Age}{Environment.NewLine}");
                        }
                        break;
                    case "3":
                        Console.Write($"Write letter: ");
                        var letter = Console.ReadLine();
                        foreach (var item in userLogic.GetUserByLetter(letter))
                        {
                            Console.WriteLine($"{item.IdUser} : {item.Name} : {item.Birthday.Year}-{item.Birthday.Month}-{item.Birthday.Day} : {item.Age}{Environment.NewLine}");
                        }
                        break;
                    case "4":
                        Console.Write($"Write word: ");
                        var word = Console.ReadLine();
                        foreach (var item in userLogic.GetUserByWord(word))
                        {
                            Console.WriteLine($"{item.IdUser} : {item.Name} : {item.Birthday.Year}-{item.Birthday.Month}-{item.Birthday.Day} : {item.Age}{Environment.NewLine}");
                        }
                        break;
                    case "5":
                        Console.Write($"User ID: ");
                        var userId = Console.ReadLine();
                        Console.Write($"Award ID: ");
                        var awardId = Console.ReadLine();
                        try
                        {
                            userLogic.Rewarding(userId, awardId);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "6":
                        Console.Write($"User's ID: ");
                        var id_5 = Console.ReadLine();
                        try
                        {
                            try
                            {
                                userLogic.DeleteUser(id_5);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"В методе {ex.TargetSite} произошла ошибка: не найден user с ID = {id_5}.");
                            UsersAction();
                        }
                        break;
                    case "7":
                        Console.Write($"User's ID: ");
                        var id_6 = Console.ReadLine();
                        Console.Write($"User's Name: ");
                        var name_6 = Console.ReadLine();
                        Console.Write($"User's Birthday: ");
                        var birthday = Console.ReadLine();
                        Console.Write($"User's Email: ");
                        var email = Console.ReadLine();
                        Console.Write($"User's Password: ");
                        var password = Console.ReadLine();
                        Console.Write($"User's Role: ");
                        var role = Console.ReadLine();
                        try
                        {
                            userLogic.UpdateUser(id_6, name_6, birthday, email, password, role, null);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "8":
                        return;
                    default:
                        break;
                }
            }
        }

        //дейтсвия для Awards
        private static void AwardsAction()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"1: Find award by ID");
                Console.WriteLine($"2: Find award by Name");
                Console.WriteLine($"3: Find award by the first letter");
                Console.WriteLine($"4: Find award whose name includes the entered word");
                Console.WriteLine($"5: Delete award");
                Console.WriteLine($"6: Edit award");
                Console.WriteLine($"7: EXIT");

                Console.Write("Choose action: ");

                var userEnter = Console.ReadLine();

                switch (userEnter)
                {
                    case "1":
                        Console.Write($"Award's ID: ");
                        var id_1 = Console.ReadLine();
                        var result_1 = awardLogic.GetAwardById(id_1);
                        Console.WriteLine($"{result_1.IdAward} : {result_1.Title} : {result_1.Description}{Environment.NewLine}");
                        break;
                    case "2":
                        Console.Write($"Award's Title: ");
                        var name_2 = Console.ReadLine();
                        foreach (var item in awardLogic.GetAwardByTitle(name_2))
                        {
                            Console.WriteLine($"{item.IdAward} : {item.Title} : {item.Description}{Environment.NewLine}");
                        }
                        break;
                    case "3":
                        Console.Write($"Write letter: ");
                        var letter_3 = Console.ReadLine();
                        foreach (var item in awardLogic.GetAwardByLetter(letter_3))
                        {
                            Console.WriteLine($"{item.IdAward} : {item.Title} : {item.Description}{Environment.NewLine}");
                        }
                        break;
                    case "4":
                        Console.Write($"Write word: ");
                        var word = Console.ReadLine();
                        foreach (var item in awardLogic.GetAwardByWord(word))
                        {
                            Console.WriteLine($"{item.IdAward} : {item.Title} : {item.Description}{Environment.NewLine}");
                        }
                        break;
                    case "5":
                        Console.Write($"Award's ID: ");
                        var id_5 = Console.ReadLine();
                        awardLogic.DeleteAward(id_5);
                        break;
                    case "6":
                        Console.Write($"award's ID: ");
                        var id_6 = Console.ReadLine();
                        var result_6 = awardLogic.GetAwardById(id_6);
                        Console.Write($"award's Titile: ");
                        var title = Console.ReadLine();
                        Console.Write($"award's Description: ");
                        var description = Console.ReadLine();
                        awardLogic.UpdateAward(id_6, title, description, null);
                        break;
                    case "7":
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
