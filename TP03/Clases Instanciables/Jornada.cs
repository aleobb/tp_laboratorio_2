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
    [Serializable]
    public class Jornada
    {
        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        public static bool Guardar(Jornada jornada)
        {
            return new Texto().Guardar("Jornada.txt",jornada.ToString());
        }

        public static string Leer()
        {
            string retorno="\nEl archivo no pudo ser leido!\n";
            new Texto().Leer("Jornada.txt",out retorno);
            return retorno;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            if (!object.ReferenceEquals(j, null) && !object.ReferenceEquals(a, null))
            {
                foreach (Alumno alumno in j.Alumnos)
                {
                    if ( !object.ReferenceEquals(alumno,null) && a == alumno )
                        return true;
                }
            }
            return false;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
                throw new AlumnoRepetidoException();
            else if ( !object.ReferenceEquals(j, null) && !object.ReferenceEquals(a, null) ) // necesito repetir esta evaluacion porque que j y a sean no iguales(==) no me indica que no lo sean por objetos nulos
                j.Alumnos.Add(a);
            return j;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR {1}", this.Clase, this.Instructor.ToString());
            sb.AppendLine("\nALUMNOS:");
            foreach (Alumno alumno in this.Alumnos)
            {
                 if ( !object.ReferenceEquals(alumno,null) )
                    sb.AppendLine(alumno.ToString());
            }
            return sb.ToString();
        }
    }
}
