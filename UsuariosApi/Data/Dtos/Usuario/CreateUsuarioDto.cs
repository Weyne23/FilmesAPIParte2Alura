using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos.Usuario
{
    public class CreateUsuarioDto 
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }//Senha no Identidy segue essa restricao 'Senha123!' (Uma letra maiuscula, numeros e um caractere especial)
        [Required]
        [Compare(nameof(Password))]
        public string RePassword { get; set; }
    }
}
