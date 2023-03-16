using Microsoft.AspNetCore.Mvc;
using MvcNetCoreZapatillas.Models;
using MvcNetCoreZapatillas.Repositories;

namespace MvcNetCoreZapatillas.Controllers
{
    public class PaginacionController : Controller
    {
        private RepositoryZapatillas repo;
        public PaginacionController(RepositoryZapatillas repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> PaginarImages(int idzapatilla, int? posicion)
        {
            if (posicion == null)
            {
                posicion = 1;
            }

            int numregistros = this.repo.GetNumeroTotalImagenesGaleria(idzapatilla);
            //ESTAMOS EN LA POSICION 1, QUE TENEMOS QUE DEVOLVER A LA VISTA?
            int siguiente = posicion.Value + 1;
            if (siguiente > numregistros)
            {
                //EFECTO OPTICO
                siguiente = numregistros;
            }
            int anterior = posicion.Value - 1;
            if (anterior < 1)
            {
                anterior = 1;
            }
            VistaImagenesZapatilla verzapatillas =
                await this.repo.GetImagensAsync(posicion.Value, idzapatilla);
            ViewData["ULTIMO"] = numregistros;
            ViewData["SIGUIENTE"] = siguiente;
            ViewData["ANTERIOR"] = anterior;
            return View(verzapatillas);


        }
    }
}
