namespace TestingLibrary
{

    public interface ICliente
    {
        string ClienteNombre { get; set; }
        int Descuento { get; set; }
        int OrderTotal { get; set; }
        bool isPremium { get; set; }

        string CrearNombreCompleto(string Nombre, string Apellido);
        TipoCliente GetClienteDetalle();
    }


    public class Cliente : ICliente
    {
        public string ClienteNombre { get; set; }
        public int Descuento { get; set; }
        public int OrderTotal { get; set; }
        public bool isPremium { get; set; }

        public Cliente()
        {
            isPremium = false;
            Descuento = 10;
        }

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
