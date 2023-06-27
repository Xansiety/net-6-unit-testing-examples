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
    }
}
