﻿namespace TestingLibrary
{
    public class CuentaBancaria
    {
        public int balance { get; set; }

        private readonly ILoggerGeneral _loggerGeneral;

        public CuentaBancaria(ILoggerGeneral loggerGeneral)
        {
            _loggerGeneral = loggerGeneral;
            balance = 0;
        }


        public bool Deposito(int monto)
        {
            _loggerGeneral.Message($"Esta depositando la cantidad de: {monto}");
            balance += monto; ;
            return true;
        }

        public bool Retiro(int monto)
        {
            if (monto <= balance)
            {
                balance -= monto;
                return true;
            }
            return false;
        }

        public int GetBalance()
        {
            return balance;
        }
    }
}
