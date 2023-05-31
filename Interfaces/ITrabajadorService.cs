using ProyectoTFG.Data;

namespace ProyectoTFG.Interfaces
{
    public interface ITrabajadorService
    {
        Task<IEnumerable<Trabajadores>> GetAllTrabajadores();
        Task<Trabajadores> GetTrabajador(int id);
        Task<bool> AgregarTrabajador(Trabajadores trabajadores);
        Task<bool> UpdateTrabajador(Trabajadores trabajadores);
        Task<bool> DeleteTrabajador(int id);
        Task<bool> SaveTrabajador(Trabajadores trabajadores);
    }
}
