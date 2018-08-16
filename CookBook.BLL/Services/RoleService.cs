﻿using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.Services
{
    public class RoleService : IRoleService
    {
        IUnitOfWork database;
        public RoleService(IUnitOfWork _database)
        {
            database = _database;
        }
        public void CreateRole(RoleDTO roleDTO)
        {
            if (database.Roles.Find(s => s.Name == roleDTO.Name).Count() != 0)
                throw new ValidationException("Role is already exist", "");
            var role = new Role()
            {
                Id = database.Roles.GetAll().Count() == 0? 1: database.Roles.GetAll().Last().Id + 1,
                Name = roleDTO.Name
            };
            database.Roles.Create(role);
            database.Save();
        }

        public IEnumerable<RoleDTO> GetRoles()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Role>, List<RoleDTO>>(database.Roles.GetAll());
        }

        public void RemoveRole(RoleDTO roleDTO)
        {
            if (database.Roles.Find(s => s.Name == roleDTO.Name).Count() == 0)
                throw new ValidationException("Role not found", "");
            var role = new Role()
            {
                Name = roleDTO.Name
            };
            database.Roles.Remove(role);
            database.Save();
        }
    }
}