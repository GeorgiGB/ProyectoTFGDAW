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
            try
            {
                _context.Citas.Add(cita);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
                Console.WriteLine(innerException.Message);
                throw;  // esto re-lanza la excepción para que pueda ser manejada en otro lugar, o puedes optar por manejarla aquí.
            }
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

        public async Task<Cita> UpdateCitas(Cita cita)
        {
            try
            {
                _context.Entry(cita).State = EntityState.Modified;
                var numChanges = await _context.SaveChangesAsync();
                if (numChanges > 0)
                {
                    return cita;
                }
                else
                {
                    // No se realizaron cambios, manejar según sea necesario
                    // ...
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is Cita)
                    {
                        // Una operación de actualización de la base de datos afectó inesperadamente
                        // a más o menos filas de las esperadas. Esto puede ser el resultado de un
                        // conflicto de concurrencia. En este caso, recargamos la entidad.
                        await entry.ReloadAsync();
                        await _context.SaveChangesAsync();
                        return cita;
                    }
                    else
                    {
                        // Algo más ocurrió que causó la excepción. Lanzamos la excepción.
                        throw;
                    }
                }
            }
            return null;
        }


        /*public async Task<bool> SaveCitas(Cita citas)
        {
            if (citas.idCita > 0)
                return await UpdateCitas(citas);
            else
                return await AgregarCitas(citas);
        }*/
        public async Task<Cita> GetCitaDetalles(int id)
        {
            return await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Trabajador)
                .FirstOrDefaultAsync(c => c.idCita == id);
        }

        public async Task<bool> AprobarCita(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
            {
                return false;
            }

            cita.Estado = Cita.EstadoCita.Aprobada.ToString();
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DenegarCita(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
            {
                return false;
            }

            cita.Estado = Cita.EstadoCita.Denegada.ToString();
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
