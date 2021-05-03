using System.Linq;
using Core.Entities;

namespace Core.Specifications
{
    public class MenuAndMenuItems : BaseSpecification<Menu>
    {
         public MenuAndMenuItems()
         {
            
             
         }

         public MenuAndMenuItems(string name) : base(x => x.Name == name && x.MenuItems.Any(x => x.ParentId == null))
         {
            AddInclude(x => x.MenuItems);
            
             
         }
    }
}