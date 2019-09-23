using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class ELIF : NodoAbstracto

    {
        public ELIF(String Valor) : base(Valor)
        {

        
        }

    public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado IF");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado IF");
            String ValorExpresion = this.Hijos[0].Ejecutar(entorno);
            String valor1 = "";
            Entorno NuevoEntorno = new Entorno();
            entorno.NuevasVariables(NuevoEntorno);
            //entorno.NuevasFunciones(NuevoEntorno);
            
            for (int ix = 1; ix < this.Hijos.Count; ix++)
            {
                valor1= this.Hijos[ix].Ejecutar(NuevoEntorno);
                System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if " + valor1);
                if (valor1.Contains("BREAK") == true)
                {
                    return "BREAK";
                    //return "#Error";
                }
                if (valor1.Contains("RETORNO:") == true)
                {

                    return valor1;
                }
                if (valor1.ToUpper().Contains("#ERROR") == true)
                {
                   
                        return valor1;
                   
                }
            }
            NuevoEntorno.AsignarNuevosValores(entorno);
     
            return "IF";
        }
    }
}