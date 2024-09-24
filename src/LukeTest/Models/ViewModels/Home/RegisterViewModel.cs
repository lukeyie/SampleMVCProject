using LukeTest.Models;

namespace LukeTest.ViewModels
{
    public class HomeRegisterViewModel
    {
        public MemberDAO? member { get; set; }

        public string TitleText = "會員註冊";
    }
}