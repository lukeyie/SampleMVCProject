using LukeTest.Models.DAO;

namespace LukeTest.Interfaces.Repositories
{
    public interface IMemberRepository
    {
        Task<IEnumerable<MemberDAO>> GetAllMembersAsync();
        Task<MemberDAO> GetMemberByUsernameAsync(string username);
        Task AddMemberAsync(MemberDAO newMember);
    }
}