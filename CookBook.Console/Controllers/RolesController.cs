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

        public void Add(string name)
        {
            RoleDTO roleDTO = new RoleDTO()
            {
                Name = name
            };
            roleService.CreateRole(roleDTO);
        }

        public void Remove(string name)
        {
            RoleDTO roleDTO = new RoleDTO()
            {
                Name = name
            };
            roleService.RemoveRole(roleDTO);
        }

        public IEnumerable<RoleViewModel> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RoleDTO, RoleViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<RoleDTO>, List<RoleViewModel>>(roleService.GetRoles());
        }
    }
}
