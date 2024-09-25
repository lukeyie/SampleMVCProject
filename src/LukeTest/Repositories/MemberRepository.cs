using Newtonsoft.Json;
using LukeTest.Interfaces.Repositories;
using LukeTest.Models.DAO;

namespace LukeTest.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly string _filePath;

        public MemberRepository(IWebHostEnvironment webHostEnvironment)
        {
            _filePath = Path.Combine(webHostEnvironment.WebRootPath, "data", "table_Member.json");
        }

        public async Task<IEnumerable<MemberDAO>> GetAllMembersAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_filePath);
            var members = JsonConvert.DeserializeObject<IEnumerable<MemberDAO>>(jsonData);
            return members;
        }

        public async Task<MemberDAO> GetMemberByUsernameAsync(string username)
        {
            var members = await GetAllMembersAsync();
            return members.FirstOrDefault(m => m.Username == username);
        }

        public async Task AddMemberAsync(MemberDAO newMember)
        {
            var members = (await GetAllMembersAsync()).ToList();
            members.Add(newMember);
            var jsonData = JsonConvert.SerializeObject(members, Formatting.Indented);
            await File.WriteAllTextAsync(_filePath, jsonData);
        }
    }
}