using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcNetCoreZapatillas.Data;
using MvcNetCoreZapatillas.Models;

#region SQL SERVER
//VUESTRO PROCEDIMIENTO DE PAGINACION DE IMAGENES DE ZAPATILLAS
#endregion

namespace MvcNetCoreZapatillas.Repositories
{
    public class RepositoryZapatillas
    {
        private ZapatillasContext context;

        public RepositoryZapatillas(ZapatillasContext context)
        {
            this.context = context;
        }

        public async Task <List<Zapatilla>> GetZapatillas()
        {
            return await this.context.Zapatillas.ToListAsync();
        }

        public async Task<Zapatilla> FindZapatilla(int idzapatilla)
        {
            return await this.context.Zapatillas.FirstOrDefaultAsync(x => x.IdProducto == idzapatilla);
        }

        public async Task<VistaImagenesZapatilla> GetImagensAsync(int posicion, int idzapatilla)
        {
            return await this.context.VistaImagenZapatilla.FirstOrDefaultAsync(x => x.IdProducto == idzapatilla && x.Posicion == posicion);
        }

        public int GetNumeroTotalImagenesGaleria(int idzapatilla)
        {
            return this.context.VistaImagenZapatilla.Count(x => x.IdProducto == idzapatilla);
        }

    }
}
