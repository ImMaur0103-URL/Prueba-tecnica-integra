namespace Prueba_Tecnica_Integra.Models
{
    public class T_GRUPO_PROV
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public List<T_PROVEEDOR> Proveedores { get; set; }
    }

    public class T_PROVEEDOR
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string NIT { get; set; }
        public string Direccion { get; set; }
        public int IDGrupoProv { get; set; }
        public T_GRUPO_PROV GrupoProveedor { get; set; }
        public List<T_ARTÍCULO> Articulos { get; set; }
    }

    public class T_ARTÍCULO
    {
        public int ID { get; set; }
        public string CodigoVenta { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
        public int IDProveedor { get; set; }
        public T_PROVEEDOR Proveedor { get; set; }
    }
}
