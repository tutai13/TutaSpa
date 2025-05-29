using Microsoft.AspNetCore.Identity;

namespace TutaSpa_API.Models
{
    public class User : IdentityUser
    {
        public bool FisrtLogin { get; set;  } = true ; 
    }
}
