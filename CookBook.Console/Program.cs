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

namespace CookBook.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            NinjectModule roleModule = new RoleModule();
            NinjectModule serviceModule = new ServiceModule();
            var kernel = new StandardKernel(roleModule, serviceModule);

        }
    }
}
