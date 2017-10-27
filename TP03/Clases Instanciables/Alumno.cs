using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesAbstractas;
using Excepciones;
using Archivos;


namespace Clases_Instanciables
{
    public sealed class Alumno:Universitario
    {

        public enum EEstadoCuenta
        { AlDia, Deudor, Becado }

        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;

        public Alumno()
            : base()
        { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id,nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        protected override string ParticiparEnClase()
        {
            /*
            StringBuilder sb = new StringBuilder("TOMA CLASE DE ");
            switch (this.claseQueToma)
            {
                case EClases.Laboratorio:
                    sb.Append("Laboratorio");
                    break;
            }
            return sb.ToString();
            */
            return string.Format("TOMA CLASE DE " + this.claseQueToma);
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            if (this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                sb.AppendLine("ESTADO DE CUENTA: Cuota al día");
            }
            else
            {
                sb.AppendFormat("ESTADO DE CUENTA: {0}\n", this.estadoCuenta);
            }
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        public override string ToString()
        {  
            return this.MostrarDatos();
        }

        public static bool operator ==(Alumno a,Universidad.EClases clase)
        {
            return !(a!=clase) && a.estadoCuenta!=EEstadoCuenta.Deudor;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a is Alumno && !object.ReferenceEquals(a, null))
                return a.claseQueToma != clase;
            return false;
        }

    }
}
