using Moq;
using NUnit.Framework;

namespace TestingLibrary
{
    [TestFixture]
    public class LoggerGeneralNUnitTest
    {

        [Test]
        public void MessageConReturnString_DebeRetornarElMismoStringEnMinusculas()
        {

            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola mundo";

            loggerGeneralMock.Setup(Setup => Setup.MessageConReturnString(It.IsAny<string>())).Returns<string>(str => str.ToLower());// Se pasa el objeto

            var resultado = loggerGeneralMock.Object.MessageConReturnString("HoLa mUNdo");

            Assert.That(resultado, Is.EqualTo(textoPrueba));
            Assert.True(resultado == textoPrueba);
        }

        [Test]
        public void MessageConOutParameterReturnBool_DebeRetornarTrue()
        {

            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola";


            loggerGeneralMock.Setup(Setup => Setup.MessageConOutParameterReturnBool(It.IsAny<string>(), out textoPrueba)).Returns(true);

            string parametroOut = "";
            var resultado = loggerGeneralMock.Object.MessageConOutParameterReturnBool("Xan", out parametroOut);

            Assert.That(resultado, Is.True);

        }


        [Test]
        public void MessageConRefParameterReturnBool_DebeRetornarTrue()
        {

            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            Cliente cliente = new Cliente();
            Cliente clienteNoUsado = new Cliente();

            loggerGeneralMock.Setup(x => x.MessageConRefParameterReturnBool(ref cliente)).Returns(true);

            Assert.IsTrue(loggerGeneralMock.Object.MessageConRefParameterReturnBool(ref cliente));

            Assert.IsFalse(loggerGeneralMock.Object.MessageConRefParameterReturnBool(ref clienteNoUsado));
        }


        [Test]
        public void LogMockingPropiedadPrioridadTipo_DebeRetornarTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();

            loggerGeneralMock.Setup(x => x.TipoLogger).Returns("warning");
            loggerGeneralMock.Setup(x => x.PrioridadLogger).Returns(10);

            Assert.That(loggerGeneralMock.Object.TipoLogger, Is.EqualTo("warning"));
            Assert.That(loggerGeneralMock.Object.PrioridadLogger, Is.EqualTo(10));
        }
    }
}
