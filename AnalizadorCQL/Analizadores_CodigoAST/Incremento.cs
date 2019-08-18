using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class Incremento : NodoAbstracto
    {
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion Incremento");
        }
        public Incremento(String Nombre) : base(Nombre)
        {

        }
        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion Incremento");
            String val1 = entorno.ObtenerValor(this.Hijos[0].Nombre);
            String Tipo1 = entorno.ObtenerTipo(this.Hijos[0].Nombre);
            float total = 0;
            
            

            
                System.Diagnostics.Debug.WriteLine("TIPO 1 ID" + val1);
                System.Diagnostics.Debug.WriteLine("TIPO 1 ID" + Tipo1);
            //System.Diagnostics.Debug.WriteLine(entorno.ObtenerTipo(this.Hijos[0].NombreVariable).ToUpper());


            return total.ToString();
        }
    }
}