using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class FUN_RETORNO : NodoAbstracto
    {
        public FUN_RETORNO(String Nombre) : base(Nombre)
        {

        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion funCIONES URUAIOAR");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion funCIONES URUAIOAR");
            
            if (this.AutoIncrmentable2 == 54)
            {
                String NombreFuncion = this.Hijos[0].Nombre;
                System.Diagnostics.Debug.WriteLine("NOMBRE FUNCION: " + NombreFuncion);
                NodoAbstracto Acciones = entorno.NodoSinParametros(NombreFuncion);
                String Retorno = "";
                if (Acciones == null)
                {
                    return "#ERROR FUNCION NO EXISTENTE";
                }
                else
                {
                   
                    String valor1 = "";
                    Entorno x = new Entorno();
                    foreach (NodoAbstracto sentencia in Acciones.Hijos)

                    {
                        System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                        valor1 = sentencia.Ejecutar(x);
                        if (valor1.Contains("#Error") == true)
                        {
                            System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                            return "#ERROR EN FUNCION";
                            //return "#Error";
                        }
                        if (valor1.Contains("RETORNO:") == true)
                        {
                            
                            Retorno = valor1;
                            break;
                        }

                    }
                }

                System.Diagnostics.Debug.WriteLine("valor retorno: "+ Retorno);

                string[] separadas;
                separadas = Retorno .Split(',');

                string[] separadas2;
                separadas2 = separadas[0].Split(':');

                string[] separadas3;
                separadas3 = separadas[1].Split(':');
                String TipoRetorno = separadas3[1];

                if (TipoRetorno.ToUpper().Contains("INT"))
                {
                    TipoRetorno = "entero";
                }
                else if (TipoRetorno.ToUpper().Contains("DOUBLE"))
                {
                    TipoRetorno = "decimal";
                }
                else if (TipoRetorno.ToUpper().Contains("STRING"))
                {
                    TipoRetorno = "cadena";
                }
                else if (TipoRetorno.ToUpper().Contains("BOOLEANO"))
                {
                    TipoRetorno = "Booleano";
                }
                else if (TipoRetorno.ToUpper().Contains("DATE"))
                {
                    TipoRetorno = "Fechas";
                }
                else if (TipoRetorno.ToUpper().Contains("TIME"))
                {
                    TipoRetorno = "hora";
                }



                this.TipoDato = TipoRetorno;
                return separadas2[1];
            }


            return "FuncionesPropias";
        }
    }
}