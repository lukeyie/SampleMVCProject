using LukeTest.Models.DTO;

namespace LukeTest.Interfaces.Services
{
    public interface IAccountService
    {
        Task<bool> RegisterMemberAsync(MemberDTO member);
        Task<MemberDTO> GetMemberByUsernameAndPasswordAsync(string username, string password);
    }
}