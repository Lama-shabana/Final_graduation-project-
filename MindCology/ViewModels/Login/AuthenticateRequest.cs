using System.ComponentModel.DataAnnotations;

namespace MindCology.ViewModels.Login
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}