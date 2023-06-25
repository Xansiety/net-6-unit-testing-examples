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
        }
    }
}
