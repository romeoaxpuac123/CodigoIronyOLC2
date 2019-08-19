using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class Incremento : NodoAbstracto
    {
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion Incremento");
        }
        public Incremento(String Nombre) : base(Nombre)
        {

        }
        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion Incremento" + this.AutoIncrmentable);
            int a = 11;
            String val1 = entorno.ObtenerValor(this.Hijos[0].Nombre);
            String Tipo1 = entorno.ObtenerTipo(this.Hijos[0].Nombre);
            float total = 0;
            System.Diagnostics.Debug.WriteLine("TIPO 1 ID" + val1);
            System.Diagnostics.Debug.WriteLine("TIPO 1 ID" + Tipo1);
            if (Tipo1.ToUpper().Contains("INT") ==true || Tipo1.ToUpper().Contains("DOUBLE")==true)
            {
                System.Diagnostics.Debug.WriteLine("TIPO 1 ID" + this.Hijos[1].Nombre);
                System.Diagnostics.Debug.WriteLine("TIPO 1 ID" + this.Hijos[1].Nombre);
                if(this.Hijos[1].Nombre.Contains("+")== true && this.AutoIncrmentable==0)
                {
                    total = float.Parse(val1) + 1;
                    entorno.AsignarValor(this.Hijos[0].Nombre, total.ToString());
                    this.AutoIncrmentable = 0;
                }
                else if (this.Hijos[1].Nombre.Contains("-") == true && this.AutoMinision == 0)
                {
                    total = float.Parse(val1) - 1;
                    entorno.AsignarValor(this.Hijos[0].Nombre, total.ToString());
                    this.AutoMinision = 0;
                    this.AutoIncrmentable = 0;
                }
            }
            else
            {
                
                return "#Error3";
            }
            this.AutoIncrmentable = 0;
            this.AutoMinision = 0;
            this.TipoDato = "decimal";

            //System.Diagnostics.Debug.WriteLine("TIPO 1 ID" + val1);
            //System.Diagnostics.Debug.WriteLine("TIPO 1 ID" + Tipo1);
            //System.Diagnostics.Debug.WriteLine(entorno.ObtenerTipo(this.Hijos[0].NombreVariable).ToUpper());


            return total.ToString();
        }
    }
}