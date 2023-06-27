using Moq;
using Xunit;

namespace TestingLibrary
{
    public class CuentaBancariaXUnitTest
    {
        //private CuentaBancaria cuentaBancaria;
        private CuentaBancaria cuenta;

        [Fact]
        public void CuentaBancaria_Deposito_DebeRetornarTrue()
        {
            CuentaBancaria cuentaBancaria = new CuentaBancaria(new LoggerGeneralFake());
            var resultado = cuentaBancaria.Deposito(100);
            Assert.True(resultado);
        }

        [Fact]
        public void BalanceCuenta_ElBalanceDebeSerIgualAlDeposito()
        {
            CuentaBancaria cuentaBancaria = new CuentaBancaria(new LoggerGeneralFake());
            var deposito = 100;
            var resultado = cuentaBancaria.Deposito(deposito);

            Assert.True(resultado);
            Assert.Equal(deposito, cuentaBancaria.GetBalance());
        }


        // MOQ - Implementation 
        [Fact]
        public void CuentaBancariaMocking_Deposito_DebeRetornarTrue()
        {
            var mocking = new Mock<ILoggerGeneral>();
            // .Object es para obtener el objeto y su instancia
            CuentaBancaria cuentaBancaria = new CuentaBancaria(mocking.Object); // Se pasa el objeto

            var resultado = cuentaBancaria.Deposito(100);
            Assert.True(resultado);
        }

        [Fact]
        public void Retiro_DebeRetornarTrue()
        {
            var mocking = new Mock<ILoggerGeneral>();
            CuentaBancaria cuentaBancaria = new CuentaBancaria(mocking.Object); // Se pasa el objeto
        }

        [Theory]
        [InlineData(200, 100)]
        [InlineData(200, 150)]
        public void Retiro_RetirarCorrecto_DebeRetornarTrue(int balance, int retiro)
        {
            var loggerMocking = new Mock<ILoggerGeneral>();

            //llamar los métodos -> simular la operación -> NO EJECUTARLOS
            loggerMocking.Setup(u => u.LogDatabase(It.IsAny<string>())).Returns(true); // Se le pasa cualquier string

            // así indicamos que el valor de entrada(param) que recibe es mayor  a 0 It.Is<int>(x => x > 0))
            loggerMocking.Setup(Setup => Setup.LogBalanceDespuesRetiro(It.Is<int>(x => x > 0))).Returns(true); // Se le pasa cualquier int


            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMocking.Object);

            cuentaBancaria.Deposito(balance);

            var resultado = cuentaBancaria.Retiro(retiro);

            Assert.True(resultado);
        }


        [Theory]
        [InlineData(200, 300)]
        [InlineData(200, 400)]
        public void Retiro_RetirarInvalido_DebeRetornarFalse(
                int balance, int retiro
            )
        {
            var loggerMocking = new Mock<ILoggerGeneral>();

            // así indicamos que el valor de entrada(param) que recibe es mayor  a 0 It.Is<int>(x => x > 0))
            //loggerMocking.Setup(Setup => Setup.LogBalanceDespuesRetiro(It.Is<int>(x => x < 0))).Returns(false);

            // validamos que el parámetro este dentro del min value hasta el -1
            loggerMocking.Setup(Setup => Setup.LogBalanceDespuesRetiro(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMocking.Object);

            cuentaBancaria.Deposito(balance);

            var resultado = cuentaBancaria.Retiro(retiro);

            Assert.False(resultado);
        }


        [Fact]
        public void CuentaBancariaVerifyLogger_VerCuantasVecesSeEjecuta()
        {
            var loggerMocking = new Mock<ILoggerGeneral>();
            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMocking.Object);

            cuentaBancaria.Deposito(100);

            Assert.Equal(100, cuentaBancaria.GetBalance());

            // Verificar que se llame al método _loggerGeneral.Message 3 veces
            loggerMocking.Verify(x => x.Message(It.IsAny<string>()), Times.Exactly(3));

            // Verificar que al menos se ejecuto una vez un método 
            loggerMocking.Verify(x => x.Message("Visita mi portfolio"), Times.AtLeastOnce);

            // Verificar que una propiedad se setee al menos una vez
            loggerMocking.VerifySet(x => x.PrioridadLogger = 100, Times.Once);

            // Verificar que el get cuantas veces se aplica el get dentro del método
            loggerMocking.VerifyGet(x => x.PrioridadLogger, Times.Once);
        }
    }
}
