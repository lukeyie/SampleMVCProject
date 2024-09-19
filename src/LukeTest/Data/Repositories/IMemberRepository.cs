using LukeTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LukeTest.Data.Repositories
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllMembersAsync();
        Task<Member> GetMemberByIdAsync(int id);
    }
}