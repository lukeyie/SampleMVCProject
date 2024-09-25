using System.ComponentModel.DataAnnotations;

namespace LukeTest.Models.DAO
{
    public class OrderDAO
    {
        public int Id { get; set; }

        [Display(Name = "訂單編號")]
        public string? Guid { get; set; }

        [Display(Name = "會員帳號")]
        public string? Username { get; set; }

        [Display(Name = "收件人姓名")]
        public string? FullName { get; set; }

        [Display(Name = "收件人信箱")]
        public string? Email { get; set; }

        [Display(Name = "收件人地址")]
        public string? Address { get; set; }

        [Display(Name = "訂單日期")]
        public string? Timestamp { get; set; }
    }
}