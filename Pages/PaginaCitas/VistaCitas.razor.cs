﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTFG.Data;
using ProyectoTFG.Interfaces;

namespace ProyectoTFG.Pages.PaginaCitas
{
    [Authorize]
    public partial class VistaCitas : ComponentBase
    {
        private List<Cita> CitasMostradas = new();
        [Inject] HospitalContext? context { get; set; }
        [Inject] public CitasService? citasService { get; set; }
        [Inject] NavigationManager? Navigator { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await ShowCitas();
        }

        private void VerDetalle(int id)
        {
            Navigator?.NavigateTo($"/api/citas/gestionarcita/{id}");
        }

        public async Task ShowCitas()
        {
            if (context is not null)
            {
                CitasMostradas = await context.Citas.ToListAsync();
            }
        }
    }
}
