namespace DistripackAPI.Models
{
    public class ProductoCategoria
    {
        public byte CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int ProductoId { get; set; }
        public int ProductoSku { get; set; }
        public Producto Producto { get; set; }


    }
}