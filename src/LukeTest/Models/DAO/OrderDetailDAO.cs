namespace LukeTest.Models.DAO
{
    using System.ComponentModel.DataAnnotations;

    public class OrderDetailDAO
    {
        public int Id { get; set; }

        [Display(Name = "訂單編號")]
        public string? Guid { get; set; }

        [Display(Name = "會員帳號")]
        public string? Username { get; set; }

        [Display(Name = "產品編號")]
        public string? ProductCode { get; set; }

        [Display(Name = "品名")]
        public string? ProductName { get; set; }

        [Display(Name = "單價")]
        public decimal Price { get; set; }

        [Display(Name = "訂購數量")]
        public int Quantity { get; set; }

        [Display(Name = "是否形成訂單")]
        public string IsApproved { get; set; }
    }
}