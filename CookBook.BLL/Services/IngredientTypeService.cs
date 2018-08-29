using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Interfaces;
using CookBook.Domain.Entities;
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

        public OperationDetails SetIngredientType(string name)
        {
            var ingr = database.IngridientTypeManager.FirstOrDefault(c => c.Name == name);
            if (ingr != null)
                return new OperationDetails(false, "Ingredient type is already exist", "");
            ingr = new IngredientType()
            {
                Name = name
            };
            database.IngridientTypeManager.Create(ingr);
            database.Save();
            return new OperationDetails(true, "Ingredient type created successfully", "");
        }
    }
}
