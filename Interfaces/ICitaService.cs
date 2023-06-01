using ProyectoTFG.Data;

namespace ProyectoTFG.Interfaces
{
    public interface ICitaService
    {
        Task<IEnumerable<Cita>> GetAllCitas();
        Task<Cita> GetCitas(int id);
        Task<bool> AgregarCitas(Cita cita);
        Task<bool> UpdateCitas(Cita cita);
        Task<bool> DeleteCitas(int id);
        Task<bool> SaveCitas(Cita citas);
    }
}
