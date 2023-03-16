using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcNetCoreZapatillas.Models
{
    [Table("V_IMAGENES_ZAPATILLAS")]
    #region Vista
    //SELECT CAST(
    //ROW_NUMBER() OVER (ORDER BY IDIMAGEN) AS INT) AS POSICION,
    //ISNULL(IDIMAGEN, 0) AS IDIMAGEN, IDPRODUCTO, IMAGEN
    //FROM IMAGENESZAPASPRACTICA
    #endregion
    public class VistaImagenesZapatilla
    {
        [Key]
        [Column("IDIMAGEN")]
        public int IdImagen { get; set; }
        [Column("IDPRODUCTO")]
        public int IdProducto { get; set; }
        [Column("IMAGEN")]
        public string Imagen { get; set; } 
        [Column("POSICION")]
        public int Posicion { get; set; }
    }
}
