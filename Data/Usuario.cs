using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoTFG.Data;

public partial class Usuario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idUsu { get; set; }

    public string UsuNombre { get; set; } = null!;

    public string UsuPwd { get; set; } = null!;

    public string UsuRol { get; set; } = null!;

    public int UsuTrabId { get; set; }
}
