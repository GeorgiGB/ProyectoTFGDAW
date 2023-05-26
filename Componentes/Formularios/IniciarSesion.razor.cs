﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ProyectoTFG.Componentes.Widgets;
using ProyectoTFG.Data.Toast;
using ProyectoTFG.Data;

namespace ProyectoTFG.Componentes.Formularios
{
    public partial class IniciarSesion
    {
        public Usuario UsuarioIniciado = new();

        [Inject] public ToastService Toast { get; set; }

        private async Task iniciarSesion()
        {
            string nombreUsuario = UsuarioIniciado.UsuNombre;
            string nombrePwd = UsuarioIniciado.UsuPwd;

            await Toast.ShowToast(new ToastOption() { Title = "Exito!", Content = "Se ha enviado la notificacion" });
        }
/*
        private DatosDataContext? _context;
        protected override async Task OnInitializedAsync()
        {
            await ShowDatos();
        }

        public async Task ShowDatos()
        {
            _context ??= await DatosDataContextFatory.CreateDbContextAsync();

            if (_context is not null)
            {
                DatosMostrados = await _context.Datos.ToListAsync();
            }

            //if (true) await _context.DisposeAsync();
        }*/
    }
}