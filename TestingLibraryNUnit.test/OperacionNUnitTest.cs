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
        [TestCase(3, ExpectedResult = false)]
        [TestCase(5, ExpectedResult = false)]
        [TestCase(7, ExpectedResult = false)]
        public bool IsPairValueNUnit_DebeDevolverFalsoParam(int numero)
        {
            Operacion op = new Operacion();
            return op.IsPairValue(numero);
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




        [Test]
        [TestCase(2.2, 1.2)] // 3.4
        [TestCase(2.23, 1.24)] // 3.47
        public void SumarDecimalNUnit_DebeRealizarLaSumaDeDosNumerosDecimales(double numero1, double numero2)
        {
            // Arrange
            Operacion op = new Operacion();

            // Act
            double resultado = op.SumarDecimal(numero1, numero2);

            // Assert - valor en un intervalo 3.3 hasta 3.5 -> 0.1 es lo que se le sumara o restara a 3.4
            Assert.AreEqual(3.4, resultado, 0.1);
        }


        [Test]
        public void getListaNumerosImpares_DebeDevolverUnaListaDeNumerosImpares()
        {
            Operacion op = new Operacion();
            List<int> numerosImparesEsperados = new List<int>() { 5, 7, 9 };

            List<int> resultados = op.getListaNumerosImpares(5, 10);

            Assert.That(resultados, Is.EquivalentTo(numerosImparesEsperados));

            // otros métodos
            Assert.AreEqual(numerosImparesEsperados, resultados);
            Assert.That(resultados, Does.Contain(5));
            Assert.Contains(5, resultados);
            Assert.That(resultados, Is.Not.Empty); // validar que la lista no este vacía
            Assert.That(resultados.Count, Is.EqualTo(3));
            Assert.That(resultados, Has.No.Member(100));  //Buscar un elemento que no este en la lista
            Assert.That(resultados, Is.Ordered.Ascending); // validar que estén ordenados: DEFAULT ASCENDING
            Assert.That(resultados, Is.Unique); // Validar si el resultado se esta duplicando en la colección

        }



    }
}
