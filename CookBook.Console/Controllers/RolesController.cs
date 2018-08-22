using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Interfaces;
using CookBook.BLL.Services;
using CookBook.Console.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Console.Controllers
{
    public class RolesController
    {
        private readonly IRoleService roleService;
        public RolesController(IRoleService _roleService)
        { 
            roleService = _roleService;
        }

        public async Task AddAsync(string name)
        {
            await roleService.CreateRoleAsync(name);
        }

        public void Remove(string name)
        {
            roleService.RemoveRoleAsync(name);
        }
        //Todo: here maybe fatal error
        public IEnumerable<RoleViewModel> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<string, RoleViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<string>, List<RoleViewModel>>(roleService.GetRoles());
        }
    }
}
