namespace LukeTest.Models.DAO
{
    using System.ComponentModel.DataAnnotations;

    public class OrderDetailDAO
    {
        public int Id { get; set; }
        public string? Guid { get; set; }
        public string? Username { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string IsApproved { get; set; }
    }
}