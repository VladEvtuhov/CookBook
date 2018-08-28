using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Interfaces;
using CookBook.Domain.Entities;
using System.Collections.Generic;

namespace CookBook.BLL.Services
{
    public class CookingMethodService: ICookingMethodService
    {
        IUnitOfWork database;
        public CookingMethodService(IUnitOfWork _database)
        {
            database = _database;
        }

        public IEnumerable<CookingMethodDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CookingMethod, CookingMethodDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CookingMethod>, List<CookingMethodDTO>>(database.CookingMethodManager.GetAll());
        }

        public void SetCookingMethod(string name)
        {
            var cook = database.CookingMethodManager.FirstOrDefault(c => c.Name == name);
            if (cook != null)
                throw new ValidationException("Category is already exist", "");
            cook = new CookingMethod()
            {
                Name = name
            };
            database.CookingMethodManager.Create(cook);
            database.Save();
        }
    }
}
