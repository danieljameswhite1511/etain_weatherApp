using System.Collections.Generic;
using System.Linq;

namespace API.Dtos
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        
        public int? ParentId { get; set; }
        public string  LinkText { get; set; }

        public string Url { get; set; }

        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public bool IsParent => ParentId == null;
        public List<MenuItemDto> Children { get; set; }
        
    }
}