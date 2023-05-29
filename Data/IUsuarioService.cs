namespace ProyectoTFG.Data
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAllUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task<bool> AgregarUsuario(Usuario usuario);
        Task<bool> UpdateUsuario(Usuario usuario);
        Task<bool> DeleteUsuario(int id);
        Task<bool> SaveUsuario(Usuario usuario);
    }
}
