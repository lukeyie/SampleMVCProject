using System.Text.Json;
using LukeTest.Interfaces.Repositories;
using LukeTest.Models.DAO;

namespace LukeTest.Tests.Mocks.Repositories
{
    public class MockMemberRepository : IMemberRepository
    {
        private readonly string _jsonPath = "TestData/member.json";

        public Task AddMemberAsync(MemberDAO newMember)
        {
            return Task.CompletedTask;
        }

        public async Task<MemberDAO> GetMemberByUsernameAsync(string username)
        {
            var jsonData = await File.ReadAllTextAsync(_jsonPath);
            var members = JsonSerializer.Deserialize<IEnumerable<MemberDAO>>(jsonData);
            return members.FirstOrDefault(m => m.Username == username);
        }

        public async Task<IEnumerable<MemberDAO>> GetAllMembersAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_jsonPath);
            var members = JsonSerializer.Deserialize<IEnumerable<MemberDAO>>(jsonData);
            return members ?? new List<MemberDAO>();
        }
    }
}