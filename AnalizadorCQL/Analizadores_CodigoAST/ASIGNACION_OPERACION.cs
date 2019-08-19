using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class ASIGNACION_OPERACION : NodoAbstracto
    {
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion asignacion operaciones");
        }
        public ASIGNACION_OPERACION(String Nombre) : base(Nombre)
        {

        }
        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion asignacion operaciones");
            String TipoVariable = entorno.ObtenerTipo(this.Hijos[0].Nombre.ToString());
            String NombreVariable = this.Hijos[0].Nombre.ToString();
            String ValorVaribale = entorno.ObtenerValor(this.Hijos[0].Nombre.ToString());

            System.Diagnostics.Debug.WriteLine("TIPO VARIABLE:" + TipoVariable);
            System.Diagnostics.Debug.WriteLine("NOMBRE VARIABLE:" + NombreVariable);
            System.Diagnostics.Debug.WriteLine("VALOR VARIABLE:" + ValorVaribale);

            String TipoExpresion = this.Hijos[2].TipoDato;
            String ValorExpresion = this.Hijos[2].Ejecutar(entorno).Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(".", ","); ;
            String Signo = this.Hijos[1].Nombre;
            System.Diagnostics.Debug.WriteLine("TIPO EXPRESION:" + TipoExpresion);
            System.Diagnostics.Debug.WriteLine("Valor EXPRESION:" + ValorExpresion);
            System.Diagnostics.Debug.WriteLine("signo:" + Signo);

            if ((TipoVariable.ToUpper().Contains("INT")|| TipoVariable.ToUpper().Contains("DOUBLE"))
                && TipoExpresion.ToUpper().Contains("ENTERO")
                )
            {
                //System.Diagnostics.Debug.WriteLine("ENTRO");
                float resultado = 0;
                if (Signo.Contains("*"))
                {
                    resultado = float.Parse(ValorExpresion) * float.Parse(ValorVaribale);
                }else if (Signo.Contains("+"))
                {
                    resultado = float.Parse(ValorExpresion) + float.Parse(ValorVaribale);
                }else if (Signo.Contains("-"))
                {
                    resultado = float.Parse(ValorVaribale) - float.Parse(ValorExpresion);
                }else if (Signo.Contains("/"))
                {
                    if(int.Parse(ValorExpresion) == 0)
                    {
                        System.Diagnostics.Debug.WriteLine("EXISTE ERROR EN ASIOPE");
                        return "#Error2 de asignacion_operacon";
                    }
                    resultado = float.Parse(ValorVaribale) / float.Parse(ValorExpresion);
                }
                System.Diagnostics.Debug.WriteLine("ENTRO" + resultado);
                entorno.AsignarValor(NombreVariable, resultado.ToString());
            }
            else if ((TipoVariable.ToUpper().Contains("INT") || TipoVariable.ToUpper().Contains("DOUBLE"))
              && TipoExpresion.ToUpper().Contains("DECIMAL")
              )
            {
                //System.Diagnostics.Debug.WriteLine("ENTRO");
                float resultado = 0;
                if (Signo.Contains("*"))
                {
                    resultado = float.Parse(ValorExpresion) * float.Parse(ValorVaribale);
                }
                else if (Signo.Contains("+"))
                {
                    resultado = float.Parse(ValorExpresion) + float.Parse(ValorVaribale);
                }
                else if (Signo.Contains("-"))
                {
                    resultado = float.Parse(ValorVaribale) - float.Parse(ValorExpresion);
                }
                else if (Signo.Contains("/"))
                {
                    if (float.Parse(ValorExpresion) == 0)
                    {
                        System.Diagnostics.Debug.WriteLine("EXISTE ERROR EN ASIOPE");
                        return "#Error2 de asignacion_operacon";
                    }


                    resultado = float.Parse(ValorVaribale) / float.Parse(ValorExpresion);
                }
                System.Diagnostics.Debug.WriteLine("ENTRO" + resultado);
                entorno.AsignarValor(NombreVariable, resultado.ToString());
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("EXISTE ERROR EN ASIOPE");
                return "#Error2 de asignacion_operacon";
            }

            return "";
        }
    }
}