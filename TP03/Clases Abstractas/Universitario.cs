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

        public Universitario():base()
        {}

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }


        public override bool Equals(object obj)
        {
            if( obj is Universitario) 
                return this == (Universitario)obj;
            return false;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append("\nLEGAJO NÚMERO: " + this.legajo);
            return sb.ToString();
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if( !object.ReferenceEquals(pg1, null) && !object.ReferenceEquals(pg2, null) && pg1 is Universitario && pg2 is Universitario)
                return ( pg1.GetType() == pg2.GetType() && ( pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI) ); 
            return false;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1==pg2);
        }

        protected abstract string ParticiparEnClase();

    }
}
