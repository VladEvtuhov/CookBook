using AutoMapper;
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
            return mapper.Map<IEnumerable<IngredientType>, List<IngredientTypeDTO>>(database.IngridientTypes.GetAll());
        }

        public void SetIngredientType(string name)
        {
            var ingr = database.IngridientTypes.FirstOrDefault(c => c.Name == name);
            if (ingr != null)
                throw new ValidationException("IngredientType is already exist", "");
            ingr = new IngredientType()
            {
                Id = database.IngridientTypes.Count() == 0 ? 1 : database.IngridientTypes.GetAll().OrderBy(o => o.Id).Last().Id + 1,
                Name = name
            };
            database.IngridientTypes.Create(ingr);
            database.Save();
        }
    }
}
