// Ignore Spelling: Operacion Numeros


using Xunit;

namespace TestingLibrary
{
    public class OperacionXUnitTest
    {

        [Fact]
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
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void IsPairValueNUnit_DebeDevolverFalso()
        {
            // Arrange
            Operacion op = new Operacion();
            var numero = 3;
            // Act
            bool resultado = op.IsPairValue(numero);
            // Assert
            Assert.False(resultado);
            //Assert.That(resultado, Is.EqualTo(false)); // NO ES SOPORTADO POR XUNIT
        }


        [Theory]
        [InlineData(3, false)]
        [InlineData(5, false)]
        [InlineData(7, false)]
        public void IsPairValueNUnit_DebeDevolverFalsoParam(int numero, bool expectedResult)
        {
            Operacion op = new Operacion();
            var resultado = op.IsPairValue(numero);
            Assert.Equal(expectedResult, resultado);
        }


        [Theory]
        // se ejecutara 3 veces y se le pasaran los siguientes valores
        [InlineData(2)]
        [InlineData(6)]
        [InlineData(20)]
        public void IsPairValueNUnit_DebeDevolverVerdadero(int numeroPar)
        {
            // Arrange
            Operacion op = new Operacion();
            //var numero = 2;
            // Act
            bool resultado = op.IsPairValue(numeroPar);
            // Assert
            Assert.True(resultado);
        }




        [Theory]
        [InlineData(2.2, 1.2)] // 3.4
        [InlineData(2.23, 1.24)] // 3.47
        public void SumarDecimalNUnit_DebeRealizarLaSumaDeDosNumerosDecimales(double numero1, double numero2)
        {
            // Arrange
            Operacion op = new Operacion();

            // Act
            double resultado = op.SumarDecimal(numero1, numero2);

            // Assert - valor en un intervalo 3.3 hasta 3.5 -> 0.1 es lo que se le sumara o restara a 3.4
            Assert.Equal(3.4, resultado, 0); // si se coloca cero redondea el valor
        }


        [Fact]
        public void getListaNumerosImpares_DebeDevolverUnaListaDeNumerosImpares()
        {
            Operacion op = new Operacion();
            List<int> numerosImparesEsperados = new List<int>() { 5, 7, 9 };

            List<int> resultados = op.getListaNumerosImpares(5, 10);

            Assert.Equal(numerosImparesEsperados, resultados);

            // otros métodos de aserción
            Assert.Contains(5, resultados); // validar que el elemento 5 este en la lista
            Assert.NotEmpty(resultados); // validar que la lista no este vacía 
            Assert.Equal(3, resultados.Count); // validar que la lista tenga 3 elementos
            Assert.DoesNotContain(100, resultados); // validar que el elemento 100 no este en la lista
            Assert.Equal(resultados.OrderBy(x => x), resultados); // validar que estén ordenados: DEFAULT ASCENDING
            Assert.Equal(resultados.Distinct(), resultados); // Validar si el resultado se esta duplicando en la colección 
        }



    }
}
