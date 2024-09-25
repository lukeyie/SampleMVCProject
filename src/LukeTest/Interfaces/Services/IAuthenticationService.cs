namespace LukeTest.Interfaces.Services
{
    public interface ICustomAuthenticationService
    {
        Task SignInAsync(string userId);
        Task SignOutAsync();
    }
}