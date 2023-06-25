namespace TestingLibrary
{
    public class Cliente
    {
        public string ClienteNombre { get; set; }

        public string CrearNombreCompleto(string Nombre, string Apellido)
        {
            ClienteNombre = Nombre + " " + Apellido;
            return ClienteNombre;
        }
    }
}
