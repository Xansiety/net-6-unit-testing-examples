using Moq;
using Xunit;

namespace TestingLibrary
{

    public class LoggerGeneralXUnitTest
    {

        [Fact]
        public void MessageConReturnString_DebeRetornarElMismoStringEnMinusculas()
        {

            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola mundo";

            loggerGeneralMock.Setup(Setup => Setup.MessageConReturnString(It.IsAny<string>())).Returns<string>(str => str.ToLower());// Se pasa el objeto

            var resultado = loggerGeneralMock.Object.MessageConReturnString("HoLa mUNdo");

            Assert.Equal(textoPrueba, resultado);
            Assert.True(resultado == textoPrueba);
        }

        [Fact]
        public void MessageConOutParameterReturnBool_DebeRetornarTrue()
        {

            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola";


            loggerGeneralMock.Setup(Setup => Setup.MessageConOutParameterReturnBool(It.IsAny<string>(), out textoPrueba)).Returns(true);

            string parametroOut = "";
            var resultado = loggerGeneralMock.Object.MessageConOutParameterReturnBool("Xan", out parametroOut);

            Assert.True(resultado);

        }


        [Fact]
        public void MessageConRefParameterReturnBool_DebeRetornarTrue()
        {

            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            Cliente cliente = new Cliente();
            Cliente clienteNoUsado = new Cliente();

            loggerGeneralMock.Setup(x => x.MessageConRefParameterReturnBool(ref cliente)).Returns(true);

            Assert.True(loggerGeneralMock.Object.MessageConRefParameterReturnBool(ref cliente));

            Assert.False(loggerGeneralMock.Object.MessageConRefParameterReturnBool(ref clienteNoUsado));
        }


        [Fact]
        public void LogMockingPropiedadPrioridadTipo_DebeRetornarTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();

            loggerGeneralMock.Setup(x => x.TipoLogger).Returns("warning");
            loggerGeneralMock.Setup(x => x.PrioridadLogger).Returns(10);

            // para generar un error
            //loggerGeneralMock.SetupAllProperties(); // es necesario añadir esta linea antes de sobre escribir las propiedades
            //loggerGeneralMock.Object.PrioridadLogger = 100;

            Assert.Equal("warning", loggerGeneralMock.Object.TipoLogger);
            Assert.Equal(10, loggerGeneralMock.Object.PrioridadLogger);

            // Callback 
            string textoTemporal = "xan";
            int contador = 5;
            loggerGeneralMock.Setup(x => x.LogDatabase(It.IsAny<string>()))
                .Returns(true)
                .Callback((string str) => str += textoTemporal); //caputrar el valor de retorno y reprocesarlos

            loggerGeneralMock.Setup(x => x.LogDatabase(It.IsAny<string>()))
                .Returns(true)
                .Callback((string str) => contador++); //caputrar el valor de retorno y reprocesarlos


            loggerGeneralMock.Object.LogDatabase("hola");

            Assert.Equal("xan", textoTemporal);
            Assert.Equal(6, contador);
        }

    }
}
