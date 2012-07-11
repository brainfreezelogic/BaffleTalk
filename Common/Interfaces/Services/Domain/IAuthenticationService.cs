namespace BaffleTalk.Common.Interfaces.Services.Domain
{
    public interface IAuthenticationService
    {
        bool AuthenticateUser(string uniqueName, string password);
    }
}