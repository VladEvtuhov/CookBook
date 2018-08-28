using AutoMapper;
using CookBook.BLL.Interfaces;
using CookBook.Console.Models;
using System.Collections.Generic;
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
