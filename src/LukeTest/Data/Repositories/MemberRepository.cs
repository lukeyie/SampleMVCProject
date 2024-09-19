using LukeTest.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace LukeTest.Data.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly string _filePath;

        public MemberRepository(IWebHostEnvironment webHostEnvironment)
        {
            _filePath = Path.Combine(webHostEnvironment.WebRootPath, "data", "table_Member.json");
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_filePath);
            var members = JsonConvert.DeserializeObject<IEnumerable<Member>>(jsonData);
            return members;
        }

        public async Task<Member> GetMemberByIdAsync(int id)
        {
            var members = await GetAllMembersAsync();
            return members.FirstOrDefault(m => m.Id == id);
        }
    }
}