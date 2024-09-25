
using LukeTest.Interfaces.Repositories;
using LukeTest.Interfaces.Services;
using LukeTest.Models.DAO;

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

        public async Task<bool> RegisterMemberAsync(MemberDAO member)
        {
            MemberDAO memberInDB = await _memberRepository.GetMemberByUsernameAsync(member.Username);
            if(memberInDB != null)
                return false;

            await _memberRepository.AddMemberAsync(member);
            return true;
        }

        public async Task<MemberDAO> GetMemberByUsernameAndPasswordAsync(string username, string password)
        {
            MemberDAO member = await _memberRepository.GetMemberByUsernameAsync(username);
            if (member == null || member.Password != password)
                return null;

            return member;
        }
    }
}