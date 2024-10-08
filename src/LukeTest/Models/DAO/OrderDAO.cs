using System.ComponentModel.DataAnnotations;

namespace LukeTest.Models.DAO
{
    public class OrderDAO
    {
        public int Id { get; set; }
        public string? Guid { get; set; }
        public string? Username { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Timestamp { get; set; }
    }
}