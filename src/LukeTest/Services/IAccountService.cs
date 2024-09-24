using LukeTest.Models;

namespace LukeTest.Services
{
    public interface IAccountService
    {
        Task<bool> RegisterMemberAsync(MemberDAO member);
        Task<MemberDAO> GetMemberByUsernameAndPasswordAsync(string username, string password);
    }
}