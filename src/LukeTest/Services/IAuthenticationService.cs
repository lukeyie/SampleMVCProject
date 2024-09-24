namespace LukeTest.Services
{
    public interface IAuthenticationService
    {
        Task SignInAsync(string userId);
        Task SignOutAsync();
    }
}