using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01
{
    /// <summary>
    /// Valida y contiene los operandos
    /// </summary>
    public class Numero
    {
        double numero; /// Atributo privado de clase

        /// <summary>
        /// Constructor publico, inicializa el operando en cero
        /// No recibe parametros
        /// </summary>
        public Numero()
        { }

        /// <summary>
        /// Constructor publico, inicializa el operando con el valor recibido por parámetro
        /// </summary>
        /// <param name="numero">valor del operando (en este caso un double)
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor publico, inicializa el operando con el valor recibido por parámetro
        /// </summary>
        /// <param name="numero">valor del operando (en este caso un string que se validara usando el metodo privado setNumero)
        public Numero(string numero)
        {
            SetNumero(numero);
        }

        /// <summary>
        /// Carga el valor del operando en el atributo del objeto. Valida el string recibido
        /// </summary>
        /// <param name="numero">Recibe un string y lo valida
        private void SetNumero(string numero)
        {
            this.numero = ValidarNumero(numero);
        }

        /// <summary>
        /// Valida que un string se pueda parsear a un double valido
        /// </summary>
        /// <param name="numeroString">recibe un string que representa un double
        /// <returns>retorna el string parseado a un double
        private double ValidarNumero(string numeroString)
        { 
            double retorno = 0;
            double.TryParse(numeroString, out retorno);
            return retorno;
        }

        /// <summary>
        /// Devueleve el valor del operando cargado en el atributo del objeto.
        /// </summary>
        /// <returns>retorna el double que representa el operando del objeto
        public double GetNumero()
        {
            return this.numero;
        }
    }
}
