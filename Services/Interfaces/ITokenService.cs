namespace GamingCommunity.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(int userId, string username);
    }
}
