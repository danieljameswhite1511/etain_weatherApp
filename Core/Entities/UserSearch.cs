using System;

namespace Core.Entities
{
    public class UserSearch
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Query { get; set; }
    }
}