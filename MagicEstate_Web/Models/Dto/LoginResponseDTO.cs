using MagicEstate_Web.Models;

namespace MagicEsatate_Web.Models.Dto
{
    public class LoginResponseDTO
    {
        public UserDTO User { get; set; }
        public string Token { get; set; }
    }
}
