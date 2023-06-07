using Microsoft.EntityFrameworkCore;
using ProyectoTFG.Interfaces;

namespace ProyectoTFG.Data
{
    public class PacientesService : IPacienteService
    {
        private readonly HospitalContext _context;

        public PacientesService(HospitalContext context)
        {
            _context = context;
        }

        public async Task<bool> AgregarPacientes(Pacientes paciente)
        {
            _context.Pacientes.Add(paciente);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePacientes(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            _context.Pacientes.Remove(paciente);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Pacientes>> GetAllPacientes()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Pacientes> GetPacientes(int id)
        {
            return await _context.Pacientes.FindAsync(id);
        }
        public async Task<bool> UpdatePacientes(Pacientes paciente)
        {
            _context.Entry(paciente).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> SavePacientes(Pacientes paciente)
        {
            if (paciente.idPac > 0)
                return await UpdatePacientes(paciente);
            else
                return await AgregarPacientes(paciente);
        }

        public async Task<IEnumerable<Pacientes>> BuscarPacientesPorNombre(string nombre)
        {
            return await _context.Pacientes.Where(t => t.PacNombre.EndsWith(nombre) || t.PacApellido.EndsWith(nombre)).ToListAsync();
        }
    }
}
