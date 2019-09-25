using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class SINO:NodoAbstracto
    {
        public SINO(String Valor) : base(Valor)
        {


        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado SINO");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado SINO");

            if(this.AutoIncrmentable2 == 1)
            {
                String valor1 = "";
                Entorno NuevoEntorno = new Entorno();
                entorno.NuevasVariables(NuevoEntorno);
                //entorno.NuevasFunciones(NuevoEntorno);
                String ValorExpresion = this.Hijos[0].Ejecutar(NuevoEntorno);
                if (ValorExpresion.ToUpper().Contains("TRUE") == true)
                {
                    for (int ix = 0; ix < this.Hijos[1].Hijos.Count; ix++)
                    {
                        valor1 = this.Hijos[1].Hijos[ix].Ejecutar(NuevoEntorno);
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
                    return "TRUE";
                }
            }

            else if(this.AutoIncrmentable2 == 2)
            {
                String valor1 = "";
                Entorno NuevoEntorno = new Entorno();
                entorno.NuevasVariables(NuevoEntorno);
                //entorno.NuevasFunciones(NuevoEntorno);
                String ValorExpresion = this.Hijos[0].Ejecutar(NuevoEntorno);
                if (ValorExpresion.ToUpper().Contains("TRUE") == true)
                {
                    for (int ix = 0; ix < this.Hijos[1].Hijos.Count; ix++)
                    {
                        valor1 = this.Hijos[1].Hijos[ix].Ejecutar(NuevoEntorno);
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
                    return "TRUE";
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("fallamos perro2");
                    valor1 = this.Hijos[2].Ejecutar(entorno);
                }
            }

            else if(this.AutoIncrmentable2 == 3)
            {
                String valor1 = "";
                Entorno NuevoEntorno = new Entorno();
                entorno.NuevasVariables(NuevoEntorno);
                entorno.NuevasFunciones(NuevoEntorno);
                //entorno.NuevasFunciones(NuevoEntorno);
                String ValorExpresion = this.Hijos[0].Ejecutar(NuevoEntorno);
                if (ValorExpresion.ToUpper().Contains("TRUE") == true)
                {
                    for (int ix = 0; ix < this.Hijos[1].Hijos.Count; ix++)
                    {
                        valor1 = this.Hijos[1].Hijos[ix].Ejecutar(NuevoEntorno);
                        System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if " + valor1 + "romeo");
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
                
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("fallamos perro2");
                    for (int ix = 0; ix < this.Hijos[2].Hijos.Count; ix++)
                    {
                        valor1 = this.Hijos[2].Hijos[ix].Ejecutar(NuevoEntorno);
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
                }
            }
            return "SINO";
        }
    }
}