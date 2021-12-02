using MichelePesanteTest.Entities;

namespace MichelePesanteTest.Interfaces
{
    public interface IAuthorizationService
    {
        User Authenticate(string login, string secret);
        string GetUser(string encryptedToken);
    }
}
