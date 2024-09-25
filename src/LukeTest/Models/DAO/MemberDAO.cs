using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LukeTest.Models.DAO
{
    public class MemberDAO
    {
        [Required]
        [DisplayName("帳號")]
        public required string Username { get; set; }

        [Required]
        [DisplayName("密碼")]
        public required string Password { get; set; }

        [Required]
        [DisplayName("姓名")]
        public required string FullName { get; set; }

        [Required]
        [DisplayName("電子信箱")]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [DisplayName("年紀")]
        public required int Age { get; set; }
    }
}
