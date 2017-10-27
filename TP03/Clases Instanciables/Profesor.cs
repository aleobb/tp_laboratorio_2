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
    public sealed class Profesor:Universitario
    {
        Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor():base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        private void _randomClases()
        {
            for(int i = 0; i<2 ;i++)
                this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0,3));
        }


        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            if( !object.ReferenceEquals(i,null) )
            { 
                foreach(Universidad.EClases c in i.clasesDelDia)
                {
                    if (!object.ReferenceEquals(c, null) && c == clase)
                        return true;
                }
            }
            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }


        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder("CLASES DEL DÍA:\n");
            if (!object.ReferenceEquals(this.clasesDelDia, null))
            {
                foreach (Universidad.EClases c in this.clasesDelDia)
                    sb.AppendFormat("{0}\n", c);
            }
            return sb.ToString();
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
