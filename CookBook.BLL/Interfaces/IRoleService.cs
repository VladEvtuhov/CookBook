using CookBook.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface IRoleService
    {
        void CreateRole(RoleDTO roleDTO);
        IEnumerable<RoleDTO> GetRoles();
        void RemoveRole(RoleDTO roleDTO);
    }
}
