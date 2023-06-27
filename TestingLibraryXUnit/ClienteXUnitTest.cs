using Xunit;

namespace TestingLibrary
{
    public class ClienteXUnitTest
    {
        private Cliente cliente;
         
        // SETUP NO ES SOPORTADO POR XUNIT POR LO QUE SE USA EL CONSTRUCTOR
        public ClienteXUnitTest()
        {
            cliente = new Cliente();
        }


        [Fact]
        public void CrearNombreCompletoNUnit_DebeConcatenarElNombre()
        {
            // Arrange
            //Cliente cliente = new Cliente();

            // Act
            //string nombreCompleto = cliente.CrearNombreCompleto("Xan", "siety");
            cliente.CrearNombreCompleto("Xan", "siety");

            // Assert
            //Assert.Multiple(() =>{}); no es soportado por XUNIT por lo que se usa el siguiente
            // Assert using XUnit
            Assert.Equal("Xan siety", cliente.ClienteNombre);
            Assert.Contains("siety", cliente.ClienteNombre);
            Assert.StartsWith("Xan", cliente.ClienteNombre);
            Assert.EndsWith("siety", cliente.ClienteNombre);
        }



        [Fact]
        public void ClienteNombre_DebeRetornarNull()
        {
            //Cliente cliente = new Cliente();

            // evaluamos una propiedad  
            Assert.Null(cliente.ClienteNombre);
        }


        [Fact]
        public void DescuentoEvaluacion_DebeRetornarUnIntervalo()
        {
            int descuento = cliente.Descuento;
            Assert.InRange(descuento, 5, 24);
        }


        [Fact]
        public void CrearNombreCompletoNUnit_NoDebeMostrarUnaExcepcion()
        {
            cliente.CrearNombreCompleto("Xan", "");

            Assert.NotNull(cliente.ClienteNombre);
            Assert.False(String.IsNullOrEmpty(cliente.ClienteNombre));
        }


        [Fact]
        public void ClienteNombreCompletoNUnit_DebeMostrarUnThrowExcepcion()
        {
            var exceptionDetalle = Assert.Throws<ArgumentException>(() => cliente.CrearNombreCompleto(null, "siety"));


            Assert.Equal("El nombre esta en blanco", exceptionDetalle.Message);

            // Throws.ArgumentException.With.Message.EqualTo NO ES SOPORTADO POR XUNIT 

            Assert.Throws<ArgumentException>(() => cliente.CrearNombreCompleto(null, "siety"));
        }

        [Fact]
        public void GetClienteDetalleNUnit_DebeDevolverUnClienteBasico()
        {
            cliente.OrderTotal = 499;
            var resultado = cliente.GetClienteDetalle();
            Assert.IsType<ClienteBasico>(resultado);
        }

        [Fact]
        public void GetClienteDetalleNUnit_DebeDevolverUnClientePremium()
        {
            cliente.OrderTotal = 501;
            var resultado = cliente.GetClienteDetalle();

            Assert.IsType<ClientePremium>(resultado);
        }
    }
}
