using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class While : NodoAbstracto
    {
        public While(String Valor) : base(Valor)
        {

        }

    public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado while");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado while");
            //String ValorExpresion = this.Hijos[0].Ejecutar(entorno);
            String valor1 = "";
            Entorno NuevoEntorno = new Entorno();
            entorno.NuevasVariables(NuevoEntorno);
            entorno.NuevasFunciones(NuevoEntorno);
            String ValorExpresion = this.Hijos[0].Ejecutar(NuevoEntorno);
            System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL WHILEXD" + ValorExpresion);
            Boolean elbrak = false;
            while (ValorExpresion.ToUpper().Contains("TRUE"))
            {   
                System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL WHILEXD");

                for (int ix = 1; ix < this.Hijos.Count; ix++)
                {
                    valor1 = this.Hijos[ix].Ejecutar(NuevoEntorno);
                    System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if " + valor1);
                    if (valor1.Contains("BREAK") == true)
                    {
                        elbrak = true;
                        break;
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
                ValorExpresion = this.Hijos[0].Ejecutar(NuevoEntorno);
                if (elbrak == true)
                {
                    break;
                }
            }
            NuevoEntorno.AsignarNuevosValores(entorno);
 
             return "WHILE";
        }
    }
}