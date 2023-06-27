namespace TestingLibrary
{
    public interface ILoggerGeneral
    {
        void Message(string message);
        bool LogDatabase(string message);
        bool LogBalanceDespuesRetiro(int balanceDespuesRetiro);

        string MessageConReturnString(string message);

        // con parámetros de salida
        bool MessageConOutParameterReturnBool(string str, out string outputStr);

        // con referencias
        bool MessageConRefParameterReturnBool(ref Cliente cliente);


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

        public bool MessageConOutParameterReturnBool(string str, out string outputStr)
        {
            outputStr = "Hola" + str;
            return true;
        }

        public bool MessageConRefParameterReturnBool(ref Cliente cliente)
        {
            return true;
        }

        public string MessageConReturnString(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
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

        public bool MessageConOutParameterReturnBool(string str, out string outputStr)
        {
            throw new NotImplementedException();
        }

        public bool MessageConRefParameterReturnBool(ref Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public string MessageConReturnString(string message)
        {
            return message;
        }
    }
}
