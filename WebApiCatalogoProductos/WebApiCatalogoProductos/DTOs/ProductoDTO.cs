namespace WebApiCatalogoProductos.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public decimal PrecioBase { get; set; }
        public decimal? PrecioConDescuento { get; set; }
    }
}
