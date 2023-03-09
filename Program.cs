using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace calculadora_2._0
{//problema com numeros negativos
    internal class Program
    {
        static List<string> array_expresion;
        static string loop = "";
        static void Main(string[] args)
        {
            while (loop != "f")
            {
                string expresion = "";
                Console.WriteLine("Welcome to your calculator developed by Leo Technologies\n\n\n\nType your expresion\n");
                expresion = Console.ReadLine();
                expresion = expresion.Trim();
                expresion = expresion.Replace(",", ".");//in case of decimal numbers, protect the user from using , as decimal sign
                Replacing();
                array_expresion = expresion.Split('@').ToList();


               

                bool processing = true;
                while (processing)
                {
                    var div = array_expresion.Contains("/");
                    var mul = array_expresion.Contains("*");
                    var som = array_expresion.Contains("+");
                    var sub = array_expresion.Contains("-");
                    if (!div && !mul && !som && !sub)
                    {
                        processing = false;
                        break;
                    }

                    if (div == true || mul == true)
                    {
                        var idxDiv = array_expresion.IndexOf("");
                        var idxMul = array_expresion.IndexOf("*");
                        if (idxDiv < idxMul)
                        {
                            var num1 = Convert.ToDouble(array_expresion[idxDiv - 1]);
                            var num2 = Convert.ToDouble(array_expresion[idxDiv + 1]);
                            Double result = Division(num1, num2);

                            array_expresion.RemoveRange(Convert.ToInt32(array_expresion[idxDiv - 1]), 3);
                            array_expresion.Insert(Convert.ToInt32(array_expresion[idxDiv - 1]), result.ToString());
                        }
                        else
                        {

                        }

                    }

                }






                Console.WriteLine("The result is: " + expresion + "\n\nPress any key to repeat or f to exit");
                loop = Console.ReadLine().ToLower().Trim();
                Console.Clear();
            }
        }
        static void Replacing()
        {
            //replacing negative numbers
            // negative numbers
            for (int i = 0; i < expresion.Length; i++)
            {
                if (i > 0 && expresion.Substring(i, 1) == "-" && expresion.Substring(i - 1, 1) == "/")
                {
                    expresion = expresion.Replace("/-", "@/@-");
                    i = 0;
                    continue;
                }
                if (i > 0 && expresion.Substring(i, 1) == "-" && expresion.Substring(i - 1, 1) == "*")
                {
                    expresion = expresion.Replace("*-", "@*@-");
                    i = 0;
                    continue;
                }
                if (i > 0 && expresion.Substring(i, 1) == "-" && expresion.Substring(i - 1, 1) == "+")
                {
                    expresion = expresion.Replace("+-", "@+@-");
                    i = 0;
                    continue;
                }
                if (i > 0 && expresion.Substring(i, 1) == "-" && expresion.Substring(i - 1, 1) == "-")
                {
                    expresion = expresion.Replace("--", "@-@-");
                    i = 0;
                    continue;
                }
            }
            for (int i = 0; i < expresion.Length; i++)
            {

                // replacing operators
                // +++++++++
                if (i > 0 && expresion.Substring(i, 1) == "+" && expresion.Substring(i - 1, 1) != "@" && expresion.Substring(i + 1, 1) != "@")
                {
                    expresion = expresion.Replace("+", "@+@");
                    i = 0;
                    continue;
                }
                // ---------
                if (i > 0 && expresion.Substring(i, 1) == "-" && expresion.Substring(i - 1, 1) != "@" && expresion.Substring(i + 1, 1) != "@"/*talvez tenha um problema com numeros negativos no final */)
                {
                    expresion = expresion.Replace("-", "@-@");
                    i = 0;
                    continue;
                }
                // ////////
                if (i > 0 && expresion.Substring(i, 1) == "/" && expresion.Substring(i - 1, 1) != "@" && expresion.Substring(i + 1, 1) != "@")
                {
                    expresion = expresion.Replace("/", "@/@");
                    i = 0;
                    continue;
                }
                // *************
                if (i > 0 && expresion.Substring(i, 1) == "*" && expresion.Substring(i - 1, 1) != "@" && expresion.Substring(i + 1, 1) != "@")
                {
                    expresion = expresion.Replace("*", "@*@");
                    i = 0;
                    continue;
                }
            }
            if (expresion.Substring(0, 1) == "@")//excecao do replace de -
            {
                expresion = expresion.Substring(3);
                expresion = "-" + expresion;
            }
        }
        static double Multiplication(double num1, double num2)
        {
            return num1 * num2;
        }
        static double Division(double num1, double num2)
        {
            return num1 / num2;
        }
        static double Addition(double num1, double num2)
        {
            return num1 + num2;
        }
        static double Subtraction(double num1, double num2)
        {
            return num1 - num2;
        }
    }
}
