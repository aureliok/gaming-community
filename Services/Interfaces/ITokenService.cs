namespace GamingCommunity.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(string userId);
    }
}
