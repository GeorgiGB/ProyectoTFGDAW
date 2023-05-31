using ProyectoTFG.Data;

namespace ProyectoTFG.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<Pacientes>> GetAllPacientes();
        Task<Pacientes> GetPacientes(int id);
        Task<bool> AgregarPacientes(Pacientes paciente);
        Task<bool> UpdatePacientes(Pacientes paciente);
        Task<bool> DeletePacientes(int id);
        Task<bool> SavePacientes(Pacientes paciente);
    }
}
