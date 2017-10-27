using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using Clases_Instanciables;
using Excepciones;
using EntidadesAbstractas;

namespace Test_Unitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidarDNI()
        {
            bool condicion = false;

            Alumno a = new Alumno(1, "Juan", "Lopez", "122",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);

            if (a.DNI>=1 && a.DNI <= 99999999)
                condicion = true;

            Assert.IsTrue(condicion);
        }
    }
}
