using System.Collections.Generic;

namespace Core.Entities
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}