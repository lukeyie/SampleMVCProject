namespace LukeTest.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProductDAO
    {
        public int Id { get; set; }

        [Display(Name = "產品編號")]
        public string? ProductCode { get; set; }

        [Display(Name = "品名")]
        public string? ProductName { get; set; }

        [Display(Name = "單價")]
        public decimal Price { get; set; }

        [Display(Name = "圖示")]
        public string? Image { get; set; }
    }
}