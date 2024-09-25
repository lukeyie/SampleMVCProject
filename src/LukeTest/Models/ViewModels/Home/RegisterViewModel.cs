using LukeTest.Models.DAO;

namespace LukeTest.Models.ViewModels.Home
{
    public class RegisterViewModel
    {
        public MemberDAO? member { get; set; }

        public string TitleText = "會員註冊";
    }
}