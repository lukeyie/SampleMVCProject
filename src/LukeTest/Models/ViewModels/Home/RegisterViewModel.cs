using LukeTest.Models.DTO;

namespace LukeTest.Models.ViewModels.Home
{
    public class RegisterViewModel
    {
        public MemberDTO? member { get; set; }

        public string TitleText = "會員註冊";
    }
}