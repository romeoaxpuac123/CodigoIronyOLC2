using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class LOG : NodoAbstracto
    {
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado imprimir\n");
        }

        public LOG (String Valor):base(Valor)
        {
          
        }

    public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("entro a imrpirmi");
            String val = this.Hijos[0].Ejecutar(entorno);
            if (val.Equals("#Error") == false)
            {

                //salida.Text = val + "\n";
                System.Diagnostics.Debug.WriteLine(val.Replace(" (numero)","").Replace(" (hora)","").Replace(" (numdecimal)","").Replace(" (fechas)","") + "\n");
            }
           else{
               // System.Diagnostics.Debug.WriteLine("Existe un error" + "\n");
                return "#Error";
            }
            return "imprimir";
        }
    }
}