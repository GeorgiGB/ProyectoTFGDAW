using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTFG.Data;

public partial class Pacientes
{
    [Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int idPac { get; set; }
    [Required]
    public string PacNombre { get; set; } = null!;
	[Required]
	public string PacApellido { get; set; } = null!;
	[Required]
	public string? PacDireccion { get; set; }
	[Required]
	public string? PacSexo { get; set; }
	[Required]
	public string? PacGs { get; set; } //Grupo sanguineo

    public DateTime PacFechRegistro { get; set; }
}
