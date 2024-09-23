using LukeTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LukeTest.Data.Repositories
{
    public interface IMemberRepository
    {
        Task<IEnumerable<MemberDAO>> GetAllMembersAsync();
        Task<MemberDAO> GetMemberByUsernameAsync(string username);
        Task<MemberDAO> GetMemberByUsernameAndPasswordAsync(string username, string password);
        Task AddMemberAsync(MemberDAO newMember);
    }
}