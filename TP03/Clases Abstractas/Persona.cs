using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        { Argentino, Extranjero }

        string apellido;
        int dni;
        ENacionalidad nacionalidad;
        string nombre;

        /// <summary>
        /// Propiedad publica lectura/escritura Apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad publica lectura/escritura DNI
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDNI(this.nacionalidad,value);
            }
        }

        /// <summary>
        /// Propiedad publica lectura/escritura Nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad publica lectura/escritura Nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        
        /// <summary>
        /// Propiedad publica escritura string_DNI
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.DNI = ValidarDNI(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        { }

        /// <summary>
        /// Constructor que recibe los 3 atributos como parametros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor que ademas recibe int dni como parametro
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor que ademas recibe string dni como parametro
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// sobrecarga ToString que publica los atributos de la clase
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0}", this.Nacionalidad);
            return sb.ToString();
        }

        /// <summary>
        /// valida DNI
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
           if (dato<1 || dato > 99999999)
               throw new DniInvalidoException();
           else if( !( nacionalidad==ENacionalidad.Argentino && dato < 90000000 || nacionalidad==ENacionalidad.Extranjero && dato > 89999999 ) )
               throw new NacionalidadInvalidaException();
           return dato;
        }

        /// <summary>
        /// valida dni string
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            int aux;
            if (!int.TryParse(dato, out aux))
                throw new DniInvalidoException();
            
            return this.ValidarDNI(nacionalidad,aux);
        }

        /// <summary>
        /// valida string nombre/apellido
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        string ValidarNombreApellido(string dato)
        {
            Regex r = new Regex("^[áéíóúa-zA-Z ]+$");
            if(!r.IsMatch(dato))
                return "";
            return dato;
        }

    }
}
