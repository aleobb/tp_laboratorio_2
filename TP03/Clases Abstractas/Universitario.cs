using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Universitario:Persona
    {
        int legajo;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universitario():base()
        {}

        /// <summary>
        /// Constructor publico de instancia
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// sobrecarga equals. reutilizo ==
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if( obj is Universitario) 
                return this == (Universitario)obj; //con esta reutilizacion de codigo evito evaluar aca que los objetos sean nulos (ya lo hago en el ==)
            return false;
        }

        /// <summary>
        /// compara si 2 universitarios son iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if( !object.ReferenceEquals(pg1, null) && !object.ReferenceEquals(pg2, null) )
                return ( pg1.GetType() == pg2.GetType() && ( pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI) ); 
            return false;
        }

        /// <summary>
        /// compara si 2 universitarios son distintos
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1==pg2);
        }

        /// <summary>
        /// hace publicos todos los datos de universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append("\nLEGAJO NÚMERO: " + this.legajo);
            return sb.ToString();
        }

        /// <summary>
        /// metodo abstracto a implementar por las derivadas
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

    }
}
