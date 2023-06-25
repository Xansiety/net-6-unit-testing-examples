using NUnit.Framework;

namespace TestingLibrary
{
    [TestFixture]
    public class ClienteNUnitTest
    {
        [Test]
        public void CrearNombreCompletoNUnit_DebeConcatenarElNombre()
        {
            // Arrange
            Cliente cliente = new Cliente();
            // Act
            string nombreCompleto = cliente.CrearNombreCompleto("Xan", "siety");
            // Assert
            Assert.That(nombreCompleto, Is.EqualTo("Xan siety"));
            Assert.AreEqual(nombreCompleto, "Xan siety");
            Assert.That(nombreCompleto, Does.Contain("siety"));
            Assert.That(nombreCompleto, Does.Contain("Siety").IgnoreCase);
            Assert.That(nombreCompleto, Does.StartWith("Xan"));
        }

        [Test]
        public void ClienteNombre_DebeRetornarNull()
        {
            Cliente cliente = new Cliente();

            // evaluamos una propiedad
            Assert.IsNull(cliente.ClienteNombre);
        }
    }
}
