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

        public string StringToDNI
        {
            set
            {
                this.DNI = ValidarDNI(this.nacionalidad, value);
            }
        }

        public Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre);
            sb.AppendFormat("\nNACIONALIDAD: {0}", this.Nacionalidad);
            return sb.ToString();
        }

        int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
           if (dato<1 || dato > 99999999)
               throw new DniInvalidoException();
           else if( !( nacionalidad==ENacionalidad.Argentino && dato < 90000000 || nacionalidad==ENacionalidad.Extranjero && dato > 89999999 ) )
               throw new NacionalidadInvalidaException();
           return dato;
        }

        int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            int aux;
            if (!int.TryParse(dato, out aux))
                throw new DniInvalidoException();
            
            return this.ValidarDNI(nacionalidad,aux);
        }

        string ValidarNombreApellido(string dato)
        {
            Regex r = new Regex("^[A-Za-z ]+$");
            if(!r.IsMatch(dato))
                return "";
            return dato;
        }

    }
}
