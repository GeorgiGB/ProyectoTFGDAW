using Microsoft.EntityFrameworkCore;
using ProyectoTFG.Interfaces;

namespace ProyectoTFG.Data
{
    public class CitasService : ICitaService
    {
        private readonly HospitalContext _context;

        public CitasService(HospitalContext context) 
        {
        _context = context;
        }
        public async Task<bool> AgregarCitas(Cita cita)
        {
            _context.Citas.Add(cita);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCitas(int id)
        {
            var cita = await _context.Citas.FindAsync(id);

            _context.Citas.Remove(cita);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Cita>> GetAllCitas()
        {
            return await _context.Citas.ToListAsync();
        }

        public async Task<Cita> GetCitas(int id)
        {
            return await _context.Citas.FindAsync(id);
        }

        public async Task<bool> UpdateCitas(Cita cita)
        {
            _context.Entry(cita).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }
        
        public async Task<bool> SaveCitas(Cita citas)
        {
            if (citas.IdCita > 0)
                return await UpdateCitas(citas);
            else
                return await AgregarCitas(citas);
        }
        public async Task<Cita> GetCitaDetalles(int id)
        {
            return await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Trabajador)
                .FirstOrDefaultAsync(c => c.IdCita == id);
        }

    }
}
