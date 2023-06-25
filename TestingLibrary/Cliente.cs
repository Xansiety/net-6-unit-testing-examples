namespace TestingLibrary
{
    public class Cliente
    {
        public string ClienteNombre { get; set; }
        public int Descuento = 10;

        public string CrearNombreCompleto(string Nombre, string Apellido)
        {
            ClienteNombre = Nombre + " " + Apellido;
            Descuento = 30;
            return ClienteNombre;
        }
    }
}
