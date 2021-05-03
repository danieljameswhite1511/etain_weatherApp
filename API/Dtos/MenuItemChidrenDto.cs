namespace API.Dtos
{
    public class MenuItemChidrenDto
    {
          public int Id { get; set; }
        
        public int ParentId { get; set; }
        public string  LinkText { get; set; }
    }
}