using MichelePesanteTest.Entities;

namespace MichelePesanteTest.Interfaces
{
    public interface IAuthorizationService
    {
        User Authenticate(string name, string secret);
        string GetUser(string encryptedToken);
    }
}
