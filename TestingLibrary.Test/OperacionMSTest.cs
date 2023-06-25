// Ignore Spelling: Numeros Operacion
using TestingLibrary;

namespace TestingLibraryMS.Test
{
    [TestClass]
    public class OperacionMSTest
    {
        [TestMethod]
        public void SumarNumeros_DebeRealizarLaSumaDeDosNumeros()
        {
            // Arrange -> Inicializar variables o componentes que ejecutaran el test
            Operacion op = new Operacion();
            int numero1 = 2;
            int numero2 = 2;
            var resultadoEsperado = numero1 + numero2;

            // Act
            int resultado = op.SumarNumeros(numero1: numero1, numero2: numero2);

            // Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }
    }
}
