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
    public class Universidad
    {
        public enum EClases
        { Programacion, Laboratorio, Legislacion, SPD }

        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;

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

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.Jornadas[i];
            }

            set
            {
                this.Jornadas[i] = value;
            }
        }

        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            if ( !object.ReferenceEquals(g, null) && !object.ReferenceEquals(a, null) )
            {
                foreach (Alumno alumno in g.Alumnos)
                {
                    if (!object.ReferenceEquals(alumno, null) && a == alumno)
                        return true;
                }
            }
            return false;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g == a)
                throw new AlumnoRepetidoException();
            else if ( !object.ReferenceEquals(g, null) && !object.ReferenceEquals(a, null) ) // necesito repetir esta evaluacion porque que g y a sean no iguales(==) no me indica que no lo sean por objetos nulos
                g.Alumnos.Add(a);
            return g;
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            if ( !object.ReferenceEquals(g, null) && !object.ReferenceEquals(i, null) )
            {
                foreach (Profesor profesor in g.Instructores)
                {
                    if (!object.ReferenceEquals(profesor, null) && i == profesor)
                        return true;
                }
            }
            return false;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g == i)
                throw new ProfesorRepetidoException();
            else if ( !object.ReferenceEquals(g, null) && !object.ReferenceEquals(i, null) ) // necesito repetir esta evaluacion porque que g e i sean no iguales(==) no me indica que no lo sean por objetos nulos
                g.Instructores.Add(i);
            return g;
        }

        public static Profesor operator ==(Universidad g, EClases clase)
        {
            if (!object.ReferenceEquals(g, null))
            {
                foreach (Profesor p in g.Instructores)
                {
                    if (!object.ReferenceEquals(p, null) && p == clase)
                        return p; // Si p == clase (el profesor da esa clase) lo retorna (primero que encuentra)
                }
            }
            throw new SinProfesorException(); // Si no lo encuntra se lanza la excepcion SinProfesorException
        }


        public static Profesor operator !=(Universidad g, EClases clase)
        {
            if (!object.ReferenceEquals(g, null))
            {
                foreach (Profesor p in g.Instructores)
                {
                    if (!object.ReferenceEquals(p, null) && p != clase)
                        return p; // Si p != clase (el profesor NO da esa clase) lo retorna (primero que encuentra)
                }
            }
            throw new SinProfesorException(); // Si no lo encuntra se lanza la excepcion SinProfesorException
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            if (!object.ReferenceEquals(g, null))
            {
                Jornada j = new Jornada(clase, g == clase);
                foreach (Alumno alumno in g.Alumnos)
                {
                    if ( !object.ReferenceEquals(alumno, null) )
                        j+=alumno;
                }
                g.Jornadas.Add(j);
            }
            return g;
        }

        public static bool Guardar(Universidad gim)
        {
            return new Xml<Universidad>().Guardar("Universitad.xml", gim); 
        }


        public static string Leer()
        {
            Universidad u = new Universidad();
            new Xml<Universidad>().Leer("Universitad.xml", out u); 
            return u.ToString();
        }

        static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada jornada in gim.Jornadas)
            {
                if (!object.ReferenceEquals(jornada, null))
                {
                    sb.AppendLine("JORNADA:");
                    sb.AppendLine(jornada.ToString());
                    sb.AppendLine("< ---------------------------------------------------------------->");
                }
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
    }
}
