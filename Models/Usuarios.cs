using System.ComponentModel.DataAnnotations;

namespace soothlyAPI.Models
{
    public class Usuarios
    {
        public int id{get; set;}
        [Required]
        public string? nome{get; set;}
        [Required]
        public string? emaill{get; set;}
        [Required]
        public string? senha{get; set;}
        [Required]
        public string? sexo{get; set;}
        [Required]
        public int idade{get; set;}
    }
}