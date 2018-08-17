using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using CookBook.Console.Util;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.BLL.Services;
using CookBook.BLL.DTO;
using CookBook.Console.Controllers;
using CookBook.Console.Models;

namespace CookBook.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = Binding();
            Menu(kernel);
        }

        public static void Menu(IKernel kernel)
        {
            int? input = null;
            while(input != 0)
            {
                System.Console.Clear();
                System.Console.WriteLine("Menu\n");
                System.Console.WriteLine("1 - roles");
                System.Console.WriteLine("2 - users");
                System.Console.WriteLine("3 - role admin");
                System.Console.WriteLine("0 - exit");
                input = Convert.ToInt32(System.Console.ReadLine());
                switch (input)
                {
                    case 1:
                        {
                            RolesMenu(kernel);
                            break;
                        }
                    case 2:
                        {
                            UsersMenu(kernel);
                            break;
                        }
                    case 3:
                        {
                            RoleAdminMenu(kernel);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        public static void RoleAdminMenu(IKernel kernel)
        {
            int? input = null;
            UsersRolesController usersRolesController = new UsersRolesController(kernel.Get<UserRoleService>());
            while(input != 0)
            {
                System.Console.Clear();
                System.Console.WriteLine("1 - get user roles");
                System.Console.WriteLine("2 - set role");
                System.Console.WriteLine("3 - pick up a role");
                System.Console.WriteLine("0 - back");
                input = Convert.ToInt32(System.Console.ReadLine());
                System.Console.Clear();
                switch (input)
                {
                    case 1:
                        {
                            System.Console.WriteLine("Enter email:");
                            var email = System.Console.ReadLine();
                            var roles = usersRolesController.GetUserRoles(email);
                            System.Console.WriteLine(email + " roles: ");
                            foreach (var role in roles)
                            {
                                System.Console.WriteLine(role);
                            }
                            System.Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("Enter email:");
                            var email = System.Console.ReadLine();
                            System.Console.WriteLine("Enter role:");
                            var role = System.Console.ReadLine();
                            try
                            {
                                usersRolesController.SetRole(email, role);
                            }
                            catch(Exception e)
                            {
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("Enter email:");
                            var email = System.Console.ReadLine();
                            System.Console.WriteLine("Enter role:");
                            var role = System.Console.ReadLine();
                            try
                            {
                                usersRolesController.PickUpRole(email, role);
                            }catch(Exception e)
                            {
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

            }
        }

        public static void RolesMenu(IKernel kernel)
        {
            int? input = null;
            RolesController rolesController = new RolesController(kernel.Get<RoleService>());
            while (input != 0)
            {
                System.Console.Clear();
                System.Console.WriteLine("1 - get roles");
                System.Console.WriteLine("2 - add role");
                System.Console.WriteLine("3 - remove role");
                System.Console.WriteLine("0 - back");
                input = Convert.ToInt32(System.Console.ReadLine());
                System.Console.Clear();
                switch (input)
                {
                    case 1:
                        {
                            var roles = rolesController.GetAll();
                            System.Console.WriteLine("Roles: ");
                            foreach (var role in roles)
                            {
                                System.Console.WriteLine(role.Name);
                            }
                            System.Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("Enter a name of adding role:");
                            var name = System.Console.ReadLine();
                            try
                            {
                                rolesController.Add(name);
                            }
                            catch (Exception e)
                            {
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("Enter a name of rempoing role:");
                            var name = System.Console.ReadLine();
                            try
                            {
                                rolesController.Remove(name);
                            }
                            catch (Exception e)
                            {
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        public static void UsersMenu(IKernel kernel)
        {
            int? input = null;
            UsersController usersController = new UsersController(kernel.Get<UserService>());
            while(input != 0)
            {
                System.Console.Clear();
                System.Console.WriteLine("1 - get users");
                System.Console.WriteLine("2 - add user");
                System.Console.WriteLine("3 - delete user");
                System.Console.WriteLine("4 - confirm email");
                System.Console.WriteLine("5 - get user by id");
                System.Console.WriteLine("6 - get user by email");
                System.Console.WriteLine("7 - set new information about user");
                System.Console.WriteLine("8 - restore user");
                System.Console.WriteLine("0 - back");
                input = Convert.ToInt32(System.Console.ReadLine());
                System.Console.Clear();
                switch (input)
                {
                    case 1:
                        {
                            var users = usersController.GetAll();
                            System.Console.WriteLine("Users: ");
                            foreach (var user in users)
                            {
                                System.Console.WriteLine(user.Email + "  |  " + user.UserName + "  |  " + user.AvgRating + "  |  " + user.IsDeleted.ToString() + "  |  " + user.About);
                            }
                            System.Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("Enter email:");
                            var email = System.Console.ReadLine();
                            System.Console.WriteLine("Enter password:");
                            var password = System.Console.ReadLine();
                            RegisterViewModel register = new RegisterViewModel()
                            {
                                Email = email,
                                Password = password
                            };
                            try
                            {
                                usersController.CreateUser(register);
                            }
                            catch (Exception e)
                            {
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("Enter a email of removing user:");
                            var email = System.Console.ReadLine();
                            try
                            {
                                usersController.DeleteUser(email);
                            }
                            catch (Exception e)
                            {
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("Enter email:");
                            var email = System.Console.ReadLine();
                            try
                            {
                                usersController.ConfirmEmail(email);
                            }catch(Exception e)
                            {
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 5:
                        {
                            System.Console.WriteLine("Enter id:");
                            var id = Convert.ToInt32(System.Console.ReadLine());
                            var user = usersController.Get(id);
                            if(user != null)
                                System.Console.WriteLine(user.Email + "  |  " + user.UserName + "  |  " + user.AvgRating + "  |  " + user.IsDeleted.ToString() + "  |  " + user.About);
                            System.Console.ReadKey();
                            break;
                        }
                    case 6:
                        {
                            System.Console.WriteLine("Enter email:");
                            var email = System.Console.ReadLine();
                            var user = usersController.Get(email);
                            if(user != null)
                                System.Console.WriteLine(user.Email + "  |  " + user.UserName + "  |  " + user.AvgRating + "  |  " + user.IsDeleted.ToString() + "  |  " + user.About);
                            System.Console.ReadKey();
                            break;
                        }
                    case 7:
                        {
                            System.Console.WriteLine("Enter email:");
                            var email = System.Console.ReadLine();
                            System.Console.WriteLine("About:");
                            var about = System.Console.ReadLine();
                            try
                            {
                                usersController.SetAbout(email, about);
                            }catch(Exception e)
                            {
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 8:
                        {
                            System.Console.WriteLine("Enter a email of restoring user:");
                            var email = System.Console.ReadLine();
                            try
                            {
                                usersController.RestoreUser(email);
                            }
                            catch (Exception e)
                            {
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        public static IKernel Binding()
        {
            NinjectModule roleModule = new BindModule();
            NinjectModule serviceModule = new ServiceModule();
            return new StandardKernel(roleModule, serviceModule);
        }
    }
}
