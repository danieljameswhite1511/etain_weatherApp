using System.Collections.Generic;

namespace API.Dtos
{
    public class MenuDto
    {
        public string Name { get; set; }

        public virtual List<MenuItemDto> MenuItems { get; set; }
    }
}