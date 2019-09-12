using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class DROP_TABLE : NodoAbstracto
    {
        public DROP_TABLE(String Nombre) : base(Nombre)
        {
        }
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion ELIMINAR TABLA");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion ELIMINAR TABLA");

            return "ELIMINAR TABLA";
        }
    }
}