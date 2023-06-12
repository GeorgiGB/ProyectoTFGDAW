using System.ComponentModel.DataAnnotations;

namespace ProyectoTFG.Data.Autentificacion
{
    public class EstandarModel
    {
        [Required(ErrorMessage ="Falta campo")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Falta campo")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
