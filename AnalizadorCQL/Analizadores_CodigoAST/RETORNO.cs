using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class RETORNO : NodoAbstracto
    {
        public RETORNO(String Valor) : base(Valor)
        {


        }
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado RETORNO");
        }

        public override string Ejecutar(Entorno entorno)
        {
            String Todos = "";
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado RETORNO");
            if(this.AutoIncrmentable2 == 100) { 

            String ValorRetorno = this.Hijos[0].Ejecutar(entorno);
            String TipoRetorno = this.Hijos[0].Nombre;

            if (TipoRetorno.ToUpper().Contains("ID2") == true)
            {
                TipoRetorno = entorno.ObtenerTipo(this.Hijos[0].NombreVariable);
            }
            else
            {
                TipoRetorno = this.Hijos[0].TipoDato;
                if (TipoRetorno.ToUpper().Contains("ENTERO"))
                {
                    TipoRetorno = "int";
                }
                else if (TipoRetorno.ToUpper().Contains("DECIMAL"))
                {
                    TipoRetorno = "double";
                }
                else if (TipoRetorno.ToUpper().Contains("CADENA"))
                {
                    TipoRetorno = "String";
                }
                else if (TipoRetorno.ToUpper().Contains("BOOLEANO"))
                {
                    TipoRetorno = "Booleano";
                }
                else if (TipoRetorno.ToUpper().Contains("FECHAS"))
                {
                    TipoRetorno = "Date";
                }
                else if (TipoRetorno.ToUpper().Contains("HORA"))
                {
                    TipoRetorno = "Time";
                }



                System.Diagnostics.Debug.WriteLine("Valor: " + ValorRetorno);
                System.Diagnostics.Debug.WriteLine("Tipo: " + TipoRetorno);
                ValorRetorno = ValorRetorno.Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "");


            }
            return "RETORNO:" + ValorRetorno + ",TIPO:" + TipoRetorno;
            }

            if (this.AutoIncrmentable2 == 200)
            {
                System.Diagnostics.Debug.WriteLine("LISTA DE RETORNOS----");
                
                for (int i = 0; i < this.ListaR1.Count; i++)
                {
                    System.Diagnostics.Debug.WriteLine("----------------------------------------"+this.ListaR1[i]);
                    String ValorRetorno = this.ListaR1[i];
                    String TipoRetorno = this.ListaR1[i];
                    String TipoRetornoX = "";// this.ListaR1[i];

                    if (TipoRetorno.ToUpper().Contains("ID2") == true)
                    {
                        TipoRetornoX = entorno.ObtenerTipo(TipoRetorno.Replace(" (id2)",""));
                        ValorRetorno = entorno.ObtenerValor(TipoRetorno.Replace(" (id2)", ""));
                        Todos = Todos + ValorRetorno + "," + TipoRetornoX + "?";
                    }
                    else
                    {
                       
                        if (TipoRetorno.ToUpper().Contains("NUMERO"))
                        {
                            TipoRetornoX = "int";
                        }
                        else if (TipoRetorno.ToUpper().Contains("NUMDECIMAL"))
                        {
                            TipoRetornoX = "double";
                        }
                        else if (TipoRetorno.ToUpper().Contains("CADENA"))
                        {
                            TipoRetornoX = "String";
                        }
                        else if (TipoRetorno.ToUpper().Contains("BOOLEANO"))
                        {
                            TipoRetornoX = "Booleano";
                        }
                        else if (TipoRetorno.ToUpper().Contains("FECHAS"))
                        {
                            TipoRetornoX = "Date";
                        }
                        else if (TipoRetorno.ToUpper().Contains("HORA"))
                        {
                            TipoRetornoX= "Time";
                        }



                        System.Diagnostics.Debug.WriteLine("Valor: " + ValorRetorno);
                        System.Diagnostics.Debug.WriteLine("Tipo: " + TipoRetornoX);
                        ValorRetorno = ValorRetorno.Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "");

                        Todos = Todos + ValorRetorno + "," + TipoRetornoX + "?";


                    }
                    //System.Diagnostics.Debug.WriteLine("LISTA DE RETORNOS----");
                }
                return "RETORNO:" + Todos;
            }


            return "";
        }
    }
}