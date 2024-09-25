using LukeTest.Models.DAO;

namespace LukeTest.Interfaces.Services
{
    public interface IAccountService
    {
        Task<bool> RegisterMemberAsync(MemberDAO member);
        Task<MemberDAO> GetMemberByUsernameAndPasswordAsync(string username, string password);
    }
}