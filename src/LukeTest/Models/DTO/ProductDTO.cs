namespace LukeTest.Models.DTO
{
    using System.ComponentModel.DataAnnotations;

    public class ProductDTO
    {
        public int Id { get; set; }

        [Display(Name = "品名")]
        public string? ProductName { get; set; }

        [Display(Name = "單價")]
        public decimal Price { get; set; }

        [Display(Name = "圖示")]
        public string? Image { get; set; }
    }
}