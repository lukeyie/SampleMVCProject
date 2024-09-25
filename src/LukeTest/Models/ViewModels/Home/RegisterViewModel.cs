using LukeTest.Models.DAO;

namespace LukeTest.Models.ViewModels
{
    public class HomeRegisterViewModel
    {
        public MemberDAO? member { get; set; }

        public string TitleText = "會員註冊";
    }
}