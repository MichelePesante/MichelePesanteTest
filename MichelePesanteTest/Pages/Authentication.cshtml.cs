using MichelePesanteTest.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MichelePesanteTest.Pages
{
    [BindProperties]
    public class AuthenticationModel : PageModel
    {
        private readonly IAuthorizationService auth;
        public string ID { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; }
        public string Result { get; set; }

        public AuthenticationModel(IAuthorizationService _auth)
        {
            auth = _auth;
        }

        public void OnPost()
        {
            var user = auth.Authenticate(Name + "_" + ID, Secret);
            if (user != null)
            {
                Result = $"Welcome {user.Name}! Let's try some APIs!";
                HttpContext.Session.SetString("Token", user?.Token);
            }
            else
            {
                Result = "Name, ID or Secret not valid!";
            }
        }
    }
}
