using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculadora_2._0
{//problema com numeros negativos
    internal class Program
    {
        static string expresion = "";
        static string[] array_expresion;
        static string loop = "";
        static void Main(string[] args)
        {
            while (loop != "f")
            {
                Console.WriteLine("Welcome to your calculator developed by Leo Technologies\n\n\n\nType your expresion\n");
                expresion = Console.ReadLine();
                expresion = expresion.Trim();
                expresion = expresion.Replace(",", ".");//in case of decimal numbers, protect the user from using , as decimal sign
                replacing();
                array_expresion = expresion.Split('@');
                multiplication();
                division();
                subtraction();
                addition();
                Console.WriteLine("The result is: " + expresion + "\n\nPress any key to repeat or f to exit");
                loop = Console.ReadLine().ToLower().Trim();
                Console.Clear();
            }
        }
        static void replacing()
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
            for (int i=0;i<expresion.Length;i++)
            {
                
                // replacing operators
                // +++++++++
                if (i>0&&expresion.Substring(i, 1) == "+" && expresion.Substring(i - 1, 1) != "@" && expresion.Substring(i + 1, 1) != "@")
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
            if(expresion.Substring(0, 1) == "@")//excecao do replace de -
            {
                expresion = expresion.Substring(3);
                expresion = "-" + expresion;
            }
        }
        static void multiplication()
        {
            /*put the * first*/
            for (int i = 0; i < array_expresion.Length; i++)
            {
                expresion = expresion.Trim();
                array_expresion = expresion.Split('@');
                if (array_expresion.Length > 1 && array_expresion[i] == "*")
                {
                    expresion = "";
                    array_expresion[i - 1] = Convert.ToString(Convert.ToDecimal(array_expresion[i - 1]) * Convert.ToDecimal(array_expresion[i + 1]));
                    array_expresion[i] = "#";
                    array_expresion[i + 1] = "#";
                    for (int k = 0; k < array_expresion.Length; k++)
                    {
                        if (array_expresion[k] != "#")
                        {
                            expresion += array_expresion[k];
                        }
                    }
                    replacing();
                    i = 0;
                    continue;
                }
            }
        }
        static void division()
        {
            for (int i = 0; i < array_expresion.Length; i++)
            {
                expresion = expresion.Trim();
                array_expresion = expresion.Split('@');
                if (array_expresion.Length > 1 && array_expresion[i] == "/")
                {
                    expresion = "";
                    array_expresion[i - 1] = Convert.ToString(Convert.ToDecimal(array_expresion[i - 1]) / Convert.ToDecimal(array_expresion[i + 1]));
                    array_expresion[i] = "#";
                    array_expresion[i + 1] = "#";
                    for (int k = 0; k < array_expresion.Length; k++)
                    {
                        if (array_expresion[k] != "#")
                        {
                            expresion += array_expresion[k];
                        }
                    }
                    replacing();
                    i = 0;
                    continue;
                }
            }
        }
        static void addition()
        {
            for (int i = 0; i < array_expresion.Length; i++)
            {
                expresion = expresion.Trim();
                array_expresion = expresion.Split('@');
                if (array_expresion.Length > 1 && array_expresion[i] == "+")
                {
                    expresion = "";
                    array_expresion[i - 1] = Convert.ToString(Convert.ToDecimal(array_expresion[i - 1]) + Convert.ToDecimal(array_expresion[i + 1]));
                    array_expresion[i] = "#";
                    array_expresion[i + 1] = "#";
                    for (int k = 0; k < array_expresion.Length; k++)
                    {
                        if (array_expresion[k] != "#")
                        {
                            expresion += array_expresion[k];
                        }
                    }
                    replacing();
                    i = 0;
                    continue;
                }
            }
        }
        static void subtraction()
        {
            for (int i = 0; i < array_expresion.Length; i++)
            {
                expresion = expresion.Trim();
                array_expresion = expresion.Split('@');
                if (array_expresion.Length > 1 && array_expresion[i] == "-")
                {
                    expresion = "";
                    array_expresion[i - 1] = Convert.ToString(Convert.ToDecimal(array_expresion[i - 1]) - Convert.ToDecimal(array_expresion[i + 1]));
                    array_expresion[i] = "#";
                    array_expresion[i + 1] = "#";
                    for (int k = 0; k < array_expresion.Length; k++)
                    {
                        if (array_expresion[k] != "#")
                        {
                            expresion += array_expresion[k];
                        }
                    }
                    replacing();
                    i = 0;
                    continue;
                }
            }
        }
    }
}
