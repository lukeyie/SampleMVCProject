
using LukeTest.Interfaces.Repositories;
using LukeTest.Interfaces.Services;
using LukeTest.Models.DAO;
using LukeTest.Models.DTO;

namespace LukeTest.Services
{
    public class AccountService : IAccountService
    {
        private readonly ILogger<AccountService> _logger;
        private readonly IMemberRepository _memberRepository;

        public AccountService(ILogger<AccountService> logger, IMemberRepository memberRepository)
        {
            _logger = logger;
            _memberRepository = memberRepository;
        }

        public async Task<bool> RegisterMemberAsync(MemberDTO member)
        {
            MemberDAO memberInDB = await _memberRepository.GetMemberByUsernameAsync(member.Username);
            if(memberInDB != null)
                return false;

            MemberDAO memberDAO = new()
            {
                Username = member.Username,
                Password = member.Password,
                Email = member.Email,
                FullName = member.FullName,
                Age = member.Age
            };
            await _memberRepository.AddMemberAsync(memberDAO);
            return true;
        }

        public async Task<MemberDTO> GetMemberByUsernameAndPasswordAsync(string username, string password)
        {
            MemberDAO member = await _memberRepository.GetMemberByUsernameAsync(username);
            if (member == null || member.Password != password)
                return null;
            
            MemberDTO memberDTO = new()
            {
                Username = member.Username,
                Password = member.Password,
                Email = member.Email,
                FullName = member.FullName,
                Age = member.Age
            };

            return memberDTO;
        }
    }
}