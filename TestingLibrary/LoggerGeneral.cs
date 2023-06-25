namespace TestingLibrary
{
    public interface ILoggerGeneral
    {
        void Message(string message);
    }

    public class LoggerGeneral : ILoggerGeneral
    {
        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }


    public class LoggerGeneralFake : ILoggerGeneral
    {
        public void Message(string message)
        {
            // throw new NotImplementedException();
        }
    }
}
