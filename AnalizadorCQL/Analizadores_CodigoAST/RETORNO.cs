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
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado RETORNO");
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
    }
}