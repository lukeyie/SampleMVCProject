using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LukeTest.Models.DAO
{
    public class MemberDAO
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required int Age { get; set; }
    }
}
