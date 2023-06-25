// Ignore Spelling: Operacion Numeros

using NUnit.Framework;

namespace TestingLibrary
{
    [TestFixture]
    public class OperacionNUnitTest
    {

        [Test]
        public void SumarNumerosNUnit_DebeRealizarLaSumaDeDosNumeros()
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

        [Test]
        public void IsPairValueNUnit_DebeDevolverFalso()
        {
            // Arrange
            Operacion op = new Operacion();
            var numero = 3;
            // Act
            bool resultado = op.IsPairValue(numero);
            // Assert
            Assert.IsFalse(resultado);
            Assert.That(resultado, Is.EqualTo(false));
        }

        [Test]
        // se ejecutara 3 veces y se le pasaran los siguientes valores
        [TestCase(2, 100, "Hola")]
        [TestCase(6, 120, "Hola")]
        [TestCase(20, 160, "Hola")]
        public void IsPairValueNUnit_DebeDevolverVerdadero(int numeroPar, int numeroX, string TercerParam)
        {
            // Arrange
            Operacion op = new Operacion();
            //var numero = 2;
            // Act
            bool resultado = op.IsPairValue(numeroPar);
            // Assert
            Assert.IsTrue(resultado);
            Assert.That(resultado, Is.EqualTo(true));
        }

    }
}
