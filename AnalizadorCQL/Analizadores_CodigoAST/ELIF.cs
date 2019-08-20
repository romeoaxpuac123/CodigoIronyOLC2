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
            if (ValorExpresion.ToUpper().Contains("TRUE"))
            {
                System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                foreach (NodoAbstracto sentencia in this.Hijos[1].Hijos)
                {
                    System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                    valor1 = sentencia.Ejecutar(entorno);
                    if (valor1.Contains("#Error") == true)
                    {
                        System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                        break;
                        //return "#Error";
                    }

                }
                //ValorExpresion = this.Hijos[0].Ejecutar(entorno);
            }

            return "IF";
        }
    }
}