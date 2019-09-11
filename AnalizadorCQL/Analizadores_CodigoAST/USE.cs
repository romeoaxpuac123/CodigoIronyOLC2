using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class USE : NodoAbstracto
    {
        public USE(String Nombre) : base(Nombre)
        {

        }
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion USE");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion USE");
            String NombreBD = this.Hijos[0].Nombre;
            
            if (entorno.ExisteBD(NombreBD) == true)
            {
                entorno.LaBD(NombreBD);
                System.Diagnostics.Debug.WriteLine("Ejecucion USE->" + entorno.Tabla());
            }
            else
            {
                return "#ERROR BDDontExists:usar o eliminar una base de datos inexistente";
            }

            


            return "USE";
        }
    }
}