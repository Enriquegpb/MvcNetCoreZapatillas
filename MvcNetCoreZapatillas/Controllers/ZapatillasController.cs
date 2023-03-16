using Microsoft.AspNetCore.Mvc;
using MvcNetCoreZapatillas.Models;
using MvcNetCoreZapatillas.Repositories;

namespace MvcNetCoreZapatillas.Controllers
{
    public class ZapatillasController : Controller
    {
        private RepositoryZapatillas repo;
        public ZapatillasController(RepositoryZapatillas repo)
        {
            this.repo = repo;
        }
        public async Task <IActionResult> Index()
        {
            List<Zapatilla> zapatillas = await this.repo.GetZapatillas();
            return View(zapatillas);
        }

        public async Task<IActionResult> DetailsPartial(int idzapatilla)
        {
            Zapatilla zapatilla = await this.repo.FindZapatilla(idzapatilla);
            return PartialView("DetailsPartial",zapatilla);
        } 
        public async Task<IActionResult> Details(int idzapatilla)
        {
            Zapatilla zapatilla = await this.repo.FindZapatilla(idzapatilla);
            return View(zapatilla);
            
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
            VistaImagenesZapatilla verzapatilas = await this.repo.GetImagensAsync(idzapatilla, posicion.Value);
            ViewData["ULTIMO"] = numregistros;
            ViewData["SIGUIENTE"] = siguiente;
            ViewData["ANTERIOR"] = anterior;
            return View(verzapatilas);
        }
    }
}
