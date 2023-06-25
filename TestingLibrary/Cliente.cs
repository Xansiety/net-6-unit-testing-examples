namespace TestingLibrary
{
    public class Cliente
    {
        public string ClienteNombre { get; set; }
        public int Descuento = 10;
        public int OrderTotal { get; set; }

        public string CrearNombreCompleto(string Nombre, string Apellido)
        {
            if (String.IsNullOrWhiteSpace(Nombre)) throw new ArgumentException("El nombre esta en blanco");

            ClienteNombre = Nombre + " " + Apellido;
            Descuento = 30;
            return ClienteNombre;
        }
         

        public TipoCliente GetClienteDetalle()
        {
            return OrderTotal < 500 ? new ClienteBasico() : new ClientePremium();
        }
    }



    public class TipoCliente { }
    public class ClienteBasico : TipoCliente { }
    public class ClientePremium : TipoCliente { }
}
