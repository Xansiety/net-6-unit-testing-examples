using Moq;
using NUnit.Framework;

namespace TestingLibrary
{
    [TestFixture]
    public class ProductoNUnitTest
    {
        [Test]
        public void GetPrecio_ClientePremium_DebeAplicarDescuento()
        {
            // Arrange
            Producto producto = new Producto { Id = 1, Nombre = "Laptop", Precio = 50 };
            Cliente cliente = new Cliente { ClienteNombre = "Juan", isPremium = true };
            int resultadoEsperado = 40;
            // Act
            var resultado = producto.GetPrecio(cliente);
            // Assert
            Assert.That(resultado, Is.EqualTo(resultadoEsperado));
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [Test]
        public void GetPrecio_ClienteNoPremium_NoDebeAplicarDescuento()
        {
            // Arrange
            Producto producto = new Producto { Id = 1, Nombre = "Laptop", Precio = 50 };
            Cliente cliente = new Cliente { ClienteNombre = "Juan", isPremium = false };

            // Act
            var resultado = producto.GetPrecio(cliente);

            // Assert
            Assert.AreEqual(50, resultado);
        }


        [Test]
        public void GetPrecioMocking_ClientePremium_DebeAplicarDescuento()
        {
            // Arrange
            Producto producto = new Producto { Id = 1, Nombre = "Laptop", Precio = 50 };

            var cliente = new Mock<ICliente>();
            cliente.Setup(c => c.isPremium).Returns(true); // Se configura el objeto y se asigna el valor que se desea

            int resultadoEsperado = 40;
            // Act
            var resultado = producto.GetPrecio(cliente.Object);
            // Assert
            Assert.That(resultado, Is.EqualTo(resultadoEsperado));
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [Test]
        public void GetPrecioMocking_ClienteNoPremium_NoDebeAplicarDescuento()
        {
            // Arrange
            Producto producto = new Producto { Id = 1, Nombre = "Laptop", Precio = 50 };
            
            var cliente = new Mock<ICliente>();
            cliente.Setup(c => c.isPremium).Returns(false); // Se configura el objeto y se asigna el valor que se desea

            // Act
            var resultado = producto.GetPrecio(cliente.Object);

            // Assert
            Assert.AreEqual(50, resultado);
        }
    }
}
