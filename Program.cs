using System;

namespace ValidadoRut
{

    class Program
    {
        private static String MENSAJE_ERROR = "Formato del rut no valido ";
        static void Main(string[] args)
        {
            int rut;
            char dv;

            Console.WriteLine("Ingresta tu rut: ");

            var rutFromConsole = Console.ReadLine().Trim();
            var rutResult = rutFromConsole.Split("-");
            try
            {
                if (ValidarEstructuraRut(rutResult))
                {
                    rut = int.Parse(rutResult[0]);
                    dv = char.Parse(rutResult[1]);
                    Console.WriteLine("Rut valido: " + (ValidarRut(rut, dv)?"VALIDO !!!":"NO VALIDO :V"));
                }
                else
                {
                    Console.WriteLine(MENSAJE_ERROR);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(MENSAJE_ERROR, ex);
            }
            catch (Exception ex2)
            {
                Console.WriteLine("ERROR CRITICO", ex2);
            }

             Console.WriteLine("Gracias!!!!");
        }
        /*
            Metodo encargado de validar si el rut es valido en 
            base a la formula matematica de rut chileno
        */
        private static bool ValidarRut(int rut, char dv)
        {
            int m = 0, s = 1;
            for (; rut != 0; rut /= 10)
            {
                s = (s + rut % 10 * (9 - m++ % 6)) % 11;

            }
            return Char.ToUpper(dv) == (char)(s != 0 ? s + 47 : 75);
        }
        /*
            Metodo encargado de validar la estrucura minima de la cual se compone un rut
        */
        private static bool ValidarEstructuraRut(string[] rut)
        {
            if (rut.Length != 2)
            {
                return false;
            }
            return true;

        }
    }
}
