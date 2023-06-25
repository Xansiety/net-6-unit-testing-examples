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

    }
}
