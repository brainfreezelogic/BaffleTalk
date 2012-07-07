namespace BaffleTalk.Common.Interfaces.Services.Domain
{
    public interface IMembershipService
    {
        bool GetUserEmailAlreadyExists(string email);
        bool GetUserUniqueNameAlreadyExists(string email);
    }
}
