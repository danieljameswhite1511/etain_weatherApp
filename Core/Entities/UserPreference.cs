using System;

namespace Core.Entities
{
    public class UserPreference
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        
    }
}