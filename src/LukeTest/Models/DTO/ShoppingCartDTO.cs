namespace LukeTest.Models.DTO
{
    using System.ComponentModel.DataAnnotations;

    public class ShoppingCartDTO
    {
        [Display(Name = "產品編號")]
        public string? ProductCode { get; set; }

        [Display(Name = "品名")]
        public string? ProductName { get; set; }

        [Display(Name = "單價")]
        public decimal Price { get; set; }

        [Display(Name = "訂購數量")]
        public int Quantity { get; set; }
    }
}