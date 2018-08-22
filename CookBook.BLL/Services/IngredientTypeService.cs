using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;
using System.Collections.Generic;

namespace CookBook.BLL.Services
{
    public class IngredientTypeService: IIngredientTypeService
    {
        IUnitOfWork database;
        public IngredientTypeService(IUnitOfWork _database)
        {
            database = _database;
        }

        public IEnumerable<IngredientTypeDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IngredientType, IngredientTypeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<IngredientType>, List<IngredientTypeDTO>>(database.IngridientTypeManager.GetAll());
        }

        public void SetIngredientType(string name)
        {
            var ingr = database.IngridientTypeManager.FirstOrDefault(c => c.Name == name);
            if (ingr != null)
                throw new ValidationException("IngredientType is already exist", "");
            ingr = new IngredientType()
            {
                Name = name
            };
            database.IngridientTypeManager.Create(ingr);
            database.Save();
        }
    }
}
