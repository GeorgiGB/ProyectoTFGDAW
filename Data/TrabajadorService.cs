﻿using Microsoft.EntityFrameworkCore;
using ProyectoTFG.Interfaces;

namespace ProyectoTFG.Data
{
    public class TrabajadorService : ITrabajadorService
    {
        private readonly HospitalContext _context;

        public TrabajadorService(HospitalContext context)
        {
            _context = context;
        }
        public async Task<bool> AgregarTrabajador(Trabajadores trabajador)
        {
            _context.Trabajadores.Add(trabajador);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteTrabajador(int id)
        {
            var trabajador = await _context.Trabajadores.FindAsync(id);

            _context.Trabajadores.Remove(trabajador);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Trabajadores> GetTrabajador(int id)
        {
            return await _context.Trabajadores.FindAsync(id);
        }

        public async Task<IEnumerable<Trabajadores>> GetAllTrabajadores()
        {
            return await _context.Trabajadores.ToListAsync();
        }

        public async Task<bool> UpdateTrabajador(Trabajadores trabajador)
        {
            _context.Entry(trabajador).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }
        /*
         * Determina si el objeto Usuario ya existe en la base de datos
         * Si existe el Usuario usara el metodo UpdateUsuario
         * sino el metodo AgregarUsuario
         */
        public async Task<bool> SaveTrabajador(Trabajadores trabajador)
        {
            if (trabajador.idTrab > 0)
                return await UpdateTrabajador(trabajador);
            else
                return await AgregarTrabajador(trabajador);
        }
        public async Task<IEnumerable<Trabajadores>> BuscarTrabajadoresPorNombre(string nombre)
        {
            return await _context.Trabajadores.Where(t => t.TrabNombre.EndsWith(nombre) || t.TrabApellido.EndsWith(nombre)).ToListAsync();
        }

    }
}
