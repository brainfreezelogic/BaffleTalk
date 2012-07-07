namespace BaffleTalk.Data.Entities.Membership
{
    public class UserOathData
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int OauthProviderId { get; set; }
        public virtual OauthProvider OauthProvider { get; set; }
        public virtual OauthProviderValue OauthProviderValue
        {
            get { return (OauthProviderValue) OauthProviderId; }
            set { OauthProviderId = (int)value; }
        }
        public string OathData { get; set; }
    }
}