using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IMenuRepository
    {
        Task<IReadOnlyList<Menu>> GetMenu();
    }
}