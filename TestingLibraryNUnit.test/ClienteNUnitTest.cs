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

    }
}
