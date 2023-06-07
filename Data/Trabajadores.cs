using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTFG.Data;

public partial class Trabajadores
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idTrab { get; set; }
    [Required]
    public string TrabNombre { get; set; } = null!;
    [Required]

    public string TrabApellido { get; set; } = null!;
    [Required]

    public string? TrabDireccion { get; set; }
    [Required]

    public string? TrabPuesto { get; set; }
    [Required]

    public string? TrabHorario { get; set; }
    [Required]

    public string? TrabCorreo { get; set; }
    [Required]

    public string? TrabSexo { get; set; }
    [Required]

    public string? TrabTel { get; set; }

    public DateTime TrabFechaContrato { get; set; }
}
