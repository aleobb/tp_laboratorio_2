using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01
{
    /// <summary>
    /// Operar matemáticamente dos objetos del tipo Numero según se le indique
    /// </summary>
    public class Calculadora
    {
        /// <summary>
        /// Realiza la operacion algebraica de 2 numeros
        /// </summary>
        /// <param name="numero1">es el objeto 1 Numero que representa un double
        /// <param name="numero2">es el objeto 2 Numero que representa un double
        /// <param name="operador">es el operador que indica la operacion (string)  
        /// <returns>devuelve el resultado de la operacion algebraica
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            operador = ValidarOperador(operador);
            double retorno = numero1.GetNumero() + numero2.GetNumero();

            switch (operador)
            {
                case "-":
                    retorno = numero1.GetNumero() - numero2.GetNumero();
                    break;
                case "*":
                    retorno = numero1.GetNumero() * numero2.GetNumero();
                    break;
                case "/":
                    if (numero2.GetNumero() == 0)
                        retorno = 0;
                    else
                        retorno = numero1.GetNumero() / numero2.GetNumero();
                    break;
            }
            return retorno;
        }

        /// <summary>
        /// Método publico de clase que validará que el operador sea un caracter válido
        /// </summary>
        /// <param name="operador">string que representa el operador
        /// <returns>retorna un string que representa un operador valido
        public static string ValidarOperador(string operador)
        {
            string retorno = "+";
            if (operador == "-" || operador == "*" || operador == "/" )
                retorno = operador;
            return retorno;
        }

    }
}
