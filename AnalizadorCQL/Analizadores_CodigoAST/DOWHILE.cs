using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class DOWHILE : NodoAbstracto
    {
        public DOWHILE(String Valor) : base(Valor)
        {

        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado DO-while");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado DO-while");
            String valor1 = "";
            Entorno NuevoEntorno = new Entorno();
            entorno.NuevasVariables(NuevoEntorno);
            String ValorExpresion = this.Hijos[0].Ejecutar(NuevoEntorno); Boolean elbrak = false;
            System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL WHILEXD" + ValorExpresion);
            do
            {
                System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL WHILEXD");

                for (int ix = 1; ix < this.Hijos.Count; ix++)
                {
                    valor1 = this.Hijos[ix].Ejecutar(NuevoEntorno);
                    System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if " + valor1);
                    if (valor1.Contains("BREAK") == true)
                    {
                        //return "BREAK";
                        elbrak = true;
                        break;
                        //break;
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
            } while (ValorExpresion.ToUpper().Contains("TRUE"));
            NuevoEntorno.AsignarNuevosValores(entorno);




            /*
            String ValorExpresion = this.Hijos[0].Ejecutar(entorno);
            String valor1 = "";
            Entorno entorno1 = new Entorno();
            do
            {
                System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL WHILEXD");
                foreach (NodoAbstracto sentencia in this.Hijos[1].Hijos)
                {
                    System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL WHILE");
                    valor1 = sentencia.Ejecutar(entorno);
                    if (valor1.Contains("#Error") == true)
                    {
                        System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL WHILE");
                        break;
                        //return "#Error";
                    }
                    if (valor1.Contains("BREAK") == true)
                    {
                        return "dO-WHILE";
                        //return "#Error";
                        //elbreak = true;
                        //break;
                    }
                    if (valor1.Contains("RETORNO:") == true)
                    {

                        return valor1;
                    }

                }
                ValorExpresion = this.Hijos[0].Ejecutar(entorno);
            } while (ValorExpresion.ToUpper().Contains("TRUE")) ;
            */
            return "dO-WHILE";
        }
    }
}