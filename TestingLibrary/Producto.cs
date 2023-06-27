namespace TestingLibrary
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public double Precio { get; set; }

        public double GetPrecio(Cliente cliente)
        {
            return cliente.isPremium ? Precio * 0.8 : Precio;
        }

        public double GetPrecio(ICliente cliente)
        {
            return cliente.isPremium ? Precio * 0.8 : Precio;
        }
    }
}
