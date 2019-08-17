using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class Declarar : NodoAbstracto

    {
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado declarar");
        }
        public Declarar(String Valor) : base(Valor)
        {

        }
        public override string Ejecutar(Entorno entorno)
        {
            String sali = entorno.ObtenerValor(this.Hijos[1].Nombre);
            if ("#Error2".Equals(sali))
            {
               //System.Diagnostics.Debug.WriteLine("VAMOS A VER EL TIPO: " + Hijos[0].Nombre.ToUpper());
               //salida.Text = "#Error: No se ha encontrado la variables -> " + this.Hijos[0].Nombre + "\n";
               if(Hijos[0].Nombre.ToUpper().Contains("INT"))
                {
                    entorno.Agregar(this.Hijos[1].Nombre, Hijos[0].Nombre.ToUpper(), "0");
                }
                else if (Hijos[0].Nombre.ToUpper().Contains("DOUBLE"))
                {
                    entorno.Agregar(this.Hijos[1].Nombre, Hijos[0].Nombre.ToUpper(), "0,0");
                }
                else if (Hijos[0].Nombre.ToUpper().Contains("BOOLEAN"))
                {
                    entorno.Agregar(this.Hijos[1].Nombre, Hijos[0].Nombre.ToUpper(), "false");
                }
                else if(Hijos[0].Nombre.ToUpper().Contains("STRING") || Hijos[0].Nombre.ToUpper().Contains("DATE")|| Hijos[0].Nombre.ToUpper().Contains("TIME"))
                {
                    entorno.Agregar(this.Hijos[1].Nombre, Hijos[0].Nombre.ToUpper(), "null");
                }

            }
            sali = entorno.ObtenerValor(this.Hijos[1].Nombre);
            return sali;
        }
    }
}