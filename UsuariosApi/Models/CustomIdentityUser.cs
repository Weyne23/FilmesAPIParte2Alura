using Microsoft.AspNetCore.Identity;
using System;

namespace UsuariosApi.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime DataNascimento { get; set; }
    }
}
