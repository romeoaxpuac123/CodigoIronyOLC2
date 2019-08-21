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

                }
                ValorExpresion = this.Hijos[0].Ejecutar(entorno);
            } while (ValorExpresion.ToUpper().Contains("TRUE")) ;

                return "dO-WHILE";
        }
    }
}