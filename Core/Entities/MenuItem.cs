using System.Collections.Generic;

namespace Core.Entities
{
    public class MenuItem : BaseEntity
    {
        public string LinkText { get; set; }
        public string Url { get; set; }
        public int SortOrder { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public int? ParentId { get; set; }
        public MenuItem Parent { get; set; }
        public virtual ICollection<MenuItem> Children { get; set; }

    }
}