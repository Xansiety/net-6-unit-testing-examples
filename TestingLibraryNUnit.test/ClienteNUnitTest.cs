using NUnit.Framework;

namespace TestingLibrary
{
    [TestFixture]
    public class ClienteNUnitTest
    {
        private Cliente cliente;

        [SetUp] // este método se ejecutara por cada uno de los test
        public void Setup()
        {
            // reutilizamos
            cliente = new Cliente();
        }


        [Test]
        public void CrearNombreCompletoNUnit_DebeConcatenarElNombre()
        {
            // Arrange
            //Cliente cliente = new Cliente();

            // Act
            //string nombreCompleto = cliente.CrearNombreCompleto("Xan", "siety");
            cliente.CrearNombreCompleto("Xan", "siety");

            // Assert
            Assert.That(cliente.ClienteNombre, Is.EqualTo("Xan siety"));
            Assert.AreEqual(cliente.ClienteNombre, "Xan siety");
            Assert.That(cliente.ClienteNombre, Does.Contain("siety"));
            Assert.That(cliente.ClienteNombre, Does.Contain("Siety").IgnoreCase);
            Assert.That(cliente.ClienteNombre, Does.StartWith("Xan"));
        }


        [Test]
        public void CrearNombreCompletoNUnit_DebeConcatenarElNombreRunAllAssert()
        {
            // Arrange
            //Cliente cliente = new Cliente();

            // Act
            //string nombreCompleto = cliente.CrearNombreCompleto("Xan", "siety");
            cliente.CrearNombreCompleto("Xan", "siety");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(cliente.ClienteNombre, Is.EqualTo("Xan siety"));
                Assert.AreEqual(cliente.ClienteNombre, "Xan siety");
                Assert.That(cliente.ClienteNombre, Does.Contain("siety"));
                Assert.That(cliente.ClienteNombre, Does.Contain("Siety").IgnoreCase);
                Assert.That(cliente.ClienteNombre, Does.StartWith("Xan"));
            });

        }

        [Test]
        public void ClienteNombre_DebeRetornarNull()
        {
            //Cliente cliente = new Cliente();

            // evaluamos una propiedad
            Assert.IsNull(cliente.ClienteNombre);
        }


        [Test]
        public void DescuentoEvaluacion_DebeRetornarUnIntervalo()
        {
            int descuento = cliente.Descuento;
            Assert.That(descuento, Is.InRange(5, 24));
        }


        [Test]
        public void CrearNombreCompletoNUnit_NoDebeMostrarUnaExcepcion()
        {
            cliente.CrearNombreCompleto("Xan", "");
            Assert.IsNotNull(cliente.ClienteNombre);
            Assert.IsFalse(String.IsNullOrEmpty(cliente.ClienteNombre));
        }


        [Test]
        public void ClienteNombreCompletoNUnit_DebeMostrarUnThrowExcepcion()
        {
            var exceptionDetalle = Assert.Throws<ArgumentException>(() => cliente.CrearNombreCompleto(null, "siety"));

            Assert.AreEqual("El nombre esta en blanco", exceptionDetalle.Message);

            Assert.That(() => cliente.CrearNombreCompleto(null, "siety"), Throws.ArgumentException.With.Message.EqualTo("El nombre esta en blanco"));


            Assert.Throws<ArgumentException>(() => cliente.CrearNombreCompleto(null, "siety"));
            Assert.That(() => cliente.CrearNombreCompleto(null, "siety"), Throws.ArgumentException);
        }

        [Test]
        public void GetClienteDetalleNUnit_DebeDevolverUnClienteBasico()
        {
            cliente.OrderTotal = 499;
            var resultado = cliente.GetClienteDetalle();

            Assert.That(resultado, Is.TypeOf<ClienteBasico>());
        }

        [Test]
        public void GetClienteDetalleNUnit_DebeDevolverUnClientePremium()
        {
            cliente.OrderTotal = 501;
            var resultado = cliente.GetClienteDetalle();

            Assert.That(resultado, Is.TypeOf<ClientePremium>());
        }




    }
}
