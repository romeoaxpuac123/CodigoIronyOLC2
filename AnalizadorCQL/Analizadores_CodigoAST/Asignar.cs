using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class Asignar : NodoAbstracto
    {
        public override void Ejecutar()
        {
            throw new NotImplementedException();
        }
        public Asignar(String Valor) : base(Valor)
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado declarar");
        }
        public override string Ejecutar(Entorno entorno)
        {
            String sali = entorno.ObtenerValor(this.Hijos[0].Nombre);
            System.Diagnostics.Debug.WriteLine("VAR" + this.Hijos[0].Nombre);
            System.Diagnostics.Debug.WriteLine("tipo de la expresion" + this.Hijos[1].TipoDato);
            System.Diagnostics.Debug.WriteLine("valor" + this.Hijos[1].Ejecutar(entorno).Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", ""));
            String Variable1 = this.Hijos[1].Ejecutar(entorno).Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(".",",");
            Boolean DecimalEntero = true;
            Boolean ElBool = true;
            
                if (this.Hijos[1].TipoDato =="entero" || this.Hijos[1].TipoDato == "decimal" )
                {
                    DecimalEntero = false;
                }
                if (Variable1.ToUpper() == "TRUE" || Variable1.ToUpper() == "FALSE")
                {
                    ElBool = false;
                }

            

            if ("#Error2".Equals(sali)== false)
            {
                if (entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("INT")
                    &&(this.Hijos[1].Nombre.ToString() == "Entero" || this.Hijos[1].Nombre.ToString() == "Decimal"|| this.Hijos[1].Nombre == "EXP") 
                    && DecimalEntero == false                   
                    ) 
                {
                    //ASIGANACION DE UNA VARIABLE DE TIPO ENTERO
                    entorno.AsignarValor(this.Hijos[0].Nombre, Variable1);
                }
                else if (entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("DOUBLE")
                    && (this.Hijos[1].Nombre.ToString() == "Entero" || this.Hijos[1].Nombre.ToString() == "Decimal" || this.Hijos[1].Nombre == "EXP")
                    && DecimalEntero == false
                 )
                {
                    //ASIGANACION DE UNA VARIABLE DE TIPO DOUBLE
                    System.Diagnostics.Debug.WriteLine("la variable es decimal");
                    entorno.AsignarValor(this.Hijos[0].Nombre, Variable1);
                }
                else if (entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("BOOLEAN")
                    && (this.Hijos[1].Nombre.ToString().Contains("Booleano") || this.Hijos[1].Nombre == "EXP")
                    && ElBool == false

                    )
                {
                    //ASIGANACION DE UNA VARIABLE DE TIPO DOUBLE
                    //System.Diagnostics.Debug.WriteLine("la variable es boleano");
                    entorno.AsignarValor(this.Hijos[0].Nombre, Variable1);
                    
                }
                else if (entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("STRING")
                    && (this.Hijos[1].Nombre.ToString().Contains("Cadena") || this.Hijos[1].Nombre == "EXP")
                    //&& ElBool == false

                    )
                {
                    //ASIGANACION DE UNA VARIABLE DE TIPO string
                    System.Diagnostics.Debug.WriteLine("la variable es String");
                    entorno.AsignarValor(this.Hijos[0].Nombre, Variable1);

                }
                else if (entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("DATE")
                   && (this.Hijos[1].Nombre.ToString().Contains("Fecha") || this.Hijos[1].Nombre == "EXP")
                   //&& ElBool == false

                   )
                {
                    //ASIGANACION DE UNA VARIABLE DE TIPO fechas
                    entorno.AsignarValor(this.Hijos[0].Nombre, Variable1);

                }
                else if (entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("TIME")
                   && (this.Hijos[1].Nombre.ToString().Contains("hora") || this.Hijos[1].Nombre == "EXP")
                   //&& ElBool == false

                   )
                {
                    //ASIGANACION DE UNA VARIABLE DE TIPO fechas
                    entorno.AsignarValor(this.Hijos[0].Nombre, Variable1);

                }


                else
                {
                    System.Diagnostics.Debug.WriteLine("#Error3 asiganacion incorrecta");
                    return "#Error3";
                }


                

            }
            sali = entorno.ObtenerValor(this.Hijos[1].Nombre);
            return sali;
        }
    }
}