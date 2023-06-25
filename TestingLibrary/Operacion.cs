// Ignore Spelling: Numeros Operacion

namespace TestingLibrary
{
    public class Operacion
    {
        public List<int> NumeroImpares = new List<int>();

        public int SumarNumeros(int numero1, int numero2) => numero1 + numero2;

        public bool IsPairValue(int number) => number % 2 == 0;

        public double SumarDecimal(double decimal1, double decimal2) => decimal1 + decimal2;


        public List<int> getListaNumerosImpares(int intervaloMinimo, int intervaloMaximo)
        {
            NumeroImpares.Clear();

            for (int i = intervaloMinimo; i <= intervaloMaximo; i++)
            {
                if (i % 2 != 0)
                {
                    NumeroImpares.Add(i);
                }
            }
            return NumeroImpares;
        }

    }
}