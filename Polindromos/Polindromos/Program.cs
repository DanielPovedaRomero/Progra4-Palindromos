using System.Text;

namespace Polindromos
{
    static internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Palindromos Fuerza bruta =>");
            Console.WriteLine($"Es palindromo: {ValidarPalabraPolindrome("Ana")}");
            Console.WriteLine($"Es palindromo: {ValidarPalabraPolindrome("11 11")}");
            Console.WriteLine($"Es palindromo: {ValidarPalabraPolindrome("Hola")}");
            Console.WriteLine($"Es palindromo: {ValidarPalabraPolindrome("11 11 1111 11 1")}");
            Console.WriteLine($"Es palindromo: {ValidarPalabraPolindrome("Na")}");


            Console.WriteLine($"Palindromos Performance =>");
            Console.WriteLine($"Es palindromo: {ValidarPalabraPolindromeOptimizada("Ana")}");
            Console.WriteLine($"Es palindromo: {ValidarPalabraPolindromeOptimizada("11 11")}");
            Console.WriteLine($"Es palindromo: {ValidarPalabraPolindromeOptimizada("Hola")}");
            Console.WriteLine($"Es palindromo: {ValidarPalabraPolindromeOptimizada("11 11 1111 11 1")}");
            Console.WriteLine($"Es palindromo: {ValidarPalabraPolindromeOptimizada("Na")}");

            Console.ReadLine();
        }

        public static bool ValidarPalabraPolindrome(string cadena) 
        {
            bool sonLetrasIguales = true;

            cadena = FormatearCadena(cadena);
            string cadenaInversa = ReversarCadena(cadena);

            for (int i = 0; i < cadena.Length; i++) 
            {
                sonLetrasIguales = cadena[i].Equals(cadenaInversa[i]) ? true : false;
                if (!sonLetrasIguales) break;
            }

            return sonLetrasIguales;
        }

        public static bool ValidarPalabraPolindromeOptimizada(string cadena) 
        {
            cadena = FormatearCadena(cadena);
            string cadenaInversa = ReversarCadena(cadena);

            return ValidarCadenaPar(cadena) ? ValidarPalabraPolindromePar(cadena, cadenaInversa)
                                            : ValidarPalabraPolindromeImpar(cadena, cadenaInversa);

        }

        public static bool ValidarPalabraPolindromeImpar(string cadena, string cadenaInversa)
        {
            bool sonLetrasIguales = true;        
            int posicionDelMedio = ((cadena.Length) / 2 + 1) ;

            for (int i = 0; i < posicionDelMedio; i++)
            {
                sonLetrasIguales = cadena[i].Equals(cadenaInversa[i]) ? true : false;
                if (!sonLetrasIguales) break;
            }

            return sonLetrasIguales;
        }

        public static bool ValidarPalabraPolindromePar(string cadena, string cadenaInversa)
        {
            bool sonLetrasIguales = true;
            int posicionDelMedio = ((cadena.Length) / 2);

            for (int i = 0; i < posicionDelMedio; i++)
            {
                sonLetrasIguales = cadena[i].Equals(cadenaInversa[i]) ? true : false;
                if (!sonLetrasIguales) break;
            }

            return sonLetrasIguales;
        }

        public static string ReversarCadena(string cadena)
        {
            StringBuilder cadenaInversa = new StringBuilder();

            for (int i = cadena.Length - 1; i >= 0; i--)
            {
                cadenaInversa.Append(cadena[i]);
            }

            return cadenaInversa.ToString();
        }

        public static string FormatearCadena(string cadena) 
        {
            return cadena.ToUpper().Replace(" ", string.Empty);
        }

        public static bool ValidarCadenaPar(string cadena) 
        {
            int longitudDeCadena = cadena.Length;
            return longitudDeCadena % 2 == 0;
        }
    }
}
