using System;
using System.Collections.Generic;

namespace ProyectoTFG.Data;

public partial class Usuario
{
    public long Idusu { get; set; }

    public string UsuNombre { get; set; } = null!;

    public string UsuPwd { get; set; } = null!;

    public string UsuRol { get; set; } = null!;

    public long UsuTrabId { get; set; }
}
