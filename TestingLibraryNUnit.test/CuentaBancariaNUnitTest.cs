using NUnit.Framework;

namespace TestingLibrary
{
    [TestFixture]
    public class CuentaBancariaNUnitTest
    {
        private CuentaBancaria cuentaBancaria;

        [SetUp]
        public void Setup()
        {
            // Así pasamos clases al constructor pero no se debe realizar esto
            //cuentaBancaria = new CuentaBancaria(new LoggerGeneral());
            // lo que se debe de hacer es crear una clase falsa
            cuentaBancaria = new CuentaBancaria(new LoggerGeneralFake());
        }

        [Test]
        public void CuentaBancaria_Deposito_DebeRetornarTrue()
        {
            var resultado = cuentaBancaria.Deposito(100);
            Assert.IsTrue(resultado);
        }

        [Test]
        public void BalanceCuenta_ElBalanceDebeSerIgualAlDeposito()
        {
            var deposito = 100;
            cuentaBancaria.Deposito(deposito);
            var resultado = cuentaBancaria.GetBalance();
            Assert.AreEqual(deposito, resultado);
            Assert.That(resultado, Is.EqualTo(deposito));
        }
    }
}
