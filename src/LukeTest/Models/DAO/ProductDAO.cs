namespace LukeTest.Models.DAO
{
    using System.ComponentModel.DataAnnotations;

    public class ProductDAO
    {
        public int Id { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
    }
}