namespace BaffleTalk.Common.Interfaces.Services.Utilities
{
    public interface IValidationDictionary
    {
        bool IsValid { get; }
        void AddError(string key, string errorMessage);
    }
}