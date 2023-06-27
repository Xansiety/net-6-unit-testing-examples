using Moq;
using NUnit.Framework;

namespace TestingLibrary
{
    [TestFixture]
    public class CuentaBancariaNUnitTest
    {
        //private CuentaBancaria cuentaBancaria;
        private CuentaBancaria cuenta;

        [SetUp]
        public void Setup()
        {
            // Así pasamos clases al constructor pero no se debe realizar esto
            //cuentaBancaria = new CuentaBancaria(new LoggerGeneral());
            // lo que se debe de hacer es crear una clase falsa
            //cuentaBancaria = new CuentaBancaria(new LoggerGeneralFake());
        }

        [Test]
        public void CuentaBancaria_Deposito_DebeRetornarTrue()
        {
            CuentaBancaria cuentaBancaria = new CuentaBancaria(new LoggerGeneralFake());
            var resultado = cuentaBancaria.Deposito(100);
            Assert.IsTrue(resultado);
        }

        [Test]
        public void BalanceCuenta_ElBalanceDebeSerIgualAlDeposito()
        {
            CuentaBancaria cuentaBancaria = new CuentaBancaria(new LoggerGeneralFake());
            var deposito = 100;
            cuentaBancaria.Deposito(deposito);
            var resultado = cuentaBancaria.GetBalance();
            Assert.AreEqual(deposito, resultado);
            Assert.That(resultado, Is.EqualTo(deposito));
        }


        // MOQ - Implementation 
        [Test]
        public void CuentaBancariaMocking_Deposito_DebeRetornarTrue()
        {
            var mocking = new Mock<ILoggerGeneral>();
            // .Object es para obtener el objeto y su instancia
            CuentaBancaria cuentaBancaria = new CuentaBancaria(mocking.Object); // Se pasa el objeto

            var resultado = cuentaBancaria.Deposito(100);
            Assert.IsTrue(resultado);
        }

        [Test]
        public void Retiro_DebeRetornarTrue()
        {
            var mocking = new Mock<ILoggerGeneral>();
            CuentaBancaria cuentaBancaria = new CuentaBancaria(mocking.Object); // Se pasa el objeto
        }

        [Test]
        [TestCase(200, 100)]
        [TestCase(200, 150)]
        public void Retiro_RetirarCorrecto_DebeRetornarTrue(
                int balance, int retiro
            )
        {
            var loggerMocking = new Mock<ILoggerGeneral>();

            //llamar los métodos -> simular la operación -> NO EJECUTARLOS
            loggerMocking.Setup(u => u.LogDatabase(It.IsAny<string>())).Returns(true); // Se le pasa cualquier string

            // así indicamos que el valor de entrada(param) que recibe es mayor  a 0 It.Is<int>(x => x > 0))
            loggerMocking.Setup(Setup => Setup.LogBalanceDespuesRetiro(It.Is<int>(x => x > 0))).Returns(true); // Se le pasa cualquier int


            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMocking.Object);

            cuentaBancaria.Deposito(balance);

            var resultado = cuentaBancaria.Retiro(retiro);

            Assert.IsTrue(resultado);
            Assert.That(resultado, Is.True);
        }


        [Test]
        [TestCase(200, 300)]
        [TestCase(200, 400)]
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

            Assert.IsFalse(resultado);
            Assert.That(resultado, Is.False);
        }

        

    }
}
