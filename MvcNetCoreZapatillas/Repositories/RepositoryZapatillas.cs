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
    }
}
