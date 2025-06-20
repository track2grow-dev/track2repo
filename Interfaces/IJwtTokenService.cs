using Track2GrowProject.API.Models.Entities;

namespace Track2GrowProject.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }

}
