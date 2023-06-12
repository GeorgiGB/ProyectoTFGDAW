namespace ProyectoTFG.Componentes
{
    public static class RutasDefinidas
    {
        public const string VistaTrabajadores = "/api/trabajadores";
        public const string CrearTrabajador = "/api/trabajadores/creartrabajador";
        public const string DetalleTrabajador = "/api/trabajadores/{TrabId}";


        public const string VistaPacientes = "/api/pacientes";
        public const string CrearPaciente = "/api/pacientes/crearpaciente";
        public const string DetallePaciente = "/api/pacientes/{TrabId}";

        public const string VistaCitas = "/api/citas";
        public const string CrearCitas = "/api/crearcitas";
        public const string AdministrarCitas = "/api/citaspendientes";

        public const string VistaEstadisticas = "/api/estadisticas";

        public const string CerrarSesion = "/logout";


        public const string PaginaPrincipal = "/";
    }
}
