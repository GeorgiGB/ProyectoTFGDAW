using Microsoft.AspNetCore.Components;
using ProyectoTFG.Data;
using ProyectoTFG.Interfaces;
using Syncfusion.Blazor;

namespace ProyectoTFG.Pages
{
	public partial class VistaEstadisticas : ComponentBase
	{
		List<DatosEstadisticos> turnoData = new ();
        List<DatosEstadisticos> citaData = new();
        List<DatosEstadisticos> gsDatas = new();

        [Inject] TrabajadorService trabajadorService { get; set; }
        [Inject] CitasService citaService { get; set; }

        [Inject] PacientesService pacientesService { get; set; }

		protected override async Task OnInitializedAsync()
		{
			var trabajadores = await trabajadorService.GetAllTrabajadores();
            var trabajadoresPorTurno = trabajadores.GroupBy(t => t.TrabHorario)
            .Select(g => new DatosEstadisticos { Turno = g.Key, Contador = g.Count() })
            .ToList();
			turnoData = trabajadoresPorTurno;

            var citas = await citaService.GetAllCitas();
            var citasPorEstado = citas.GroupBy(c => c.Estado)
            .Select(g => new DatosEstadisticos { Turno = g.Key, Contador = g.Count() })
            .ToList();
            citaData = citasPorEstado;


            var gs = await pacientesService.GetAllPacientes();
            var pacientesGS = gs.GroupBy(t => t.PacGs)
            .Select(g => new DatosEstadisticos { Turno = g.Key, Contador = g.Count() })
            .ToList();
            gsDatas = pacientesGS;
        }
	}
}
