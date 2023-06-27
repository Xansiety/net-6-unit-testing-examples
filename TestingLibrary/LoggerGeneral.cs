namespace TestingLibrary
{
    public interface ILoggerGeneral
    {
        void Message(string message);
        bool LogDatabase(string message);
        bool LogBalanceDespuesRetiro(int balanceDespuesRetiro);
    }

    public class LoggerGeneral : ILoggerGeneral
    {
        public bool LogBalanceDespuesRetiro(int balanceDespuesRetiro)
        {
            if (balanceDespuesRetiro >= 0)
            {
                Console.WriteLine("Éxito de la operación");
                return true;
            }

            Console.WriteLine("Error en la operación");
            return false;

        }

        public bool LogDatabase(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }




    public class LoggerGeneralFake : ILoggerGeneral
    {
        public bool LogBalanceDespuesRetiro(int balanceDespuesRetiro)
        {
            //throw new NotImplementedException();
            return true;
        }

        public bool LogDatabase(string message)
        {
            //throw new NotImplementedException();
            return true;
        }

        public void Message(string message)
        {
            // throw new NotImplementedException();

        }
    }
}
