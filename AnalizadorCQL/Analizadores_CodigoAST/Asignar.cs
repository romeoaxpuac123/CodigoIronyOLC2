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
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado asignar");
            String sali = entorno.ObtenerValor(this.Hijos[0].Nombre);
            System.Diagnostics.Debug.WriteLine("VAR" + this.Hijos[0].Nombre);
            System.Diagnostics.Debug.WriteLine("tipo de la expresion" + this.Hijos[1].TipoDato);
            System.Diagnostics.Debug.WriteLine("tipo de la expresion" + this.Hijos[1].Hijos[0].Nombre);
            System.Diagnostics.Debug.WriteLine("valor" + this.Hijos[1].Ejecutar(entorno).Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", ""));
            String Variable1 = this.Hijos[1].Ejecutar(entorno).Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(".",",");
            String TipoDato1 = "";
            String var = this.Hijos[0].Nombre;
            int a = 0;
            System.Diagnostics.Debug.WriteLine(a++ + 29);
            System.Diagnostics.Debug.WriteLine(a++);
            if (this.Hijos[1].Hijos[0].Nombre.Contains("@"))
            {
                Variable1 = entorno.ObtenerValor(this.Hijos[1].Hijos[0].Nombre);
                TipoDato1 = entorno.ObtenerTipo(this.Hijos[1].Hijos[0].Nombre);
            }
            System.Diagnostics.Debug.WriteLine("variable1:" + Variable1 + "-");
            System.Diagnostics.Debug.WriteLine("variable1:" + TipoDato1 + "-");
            System.Diagnostics.Debug.WriteLine("variable1:" + var + "-");

            if ((entorno.ObtenerTipo(var).ToString().ToUpper().Contains("INT")) &&
                ( TipoDato1.ToUpper().Contains("INT") || TipoDato1.ToUpper().Contains("DOUBLE"))
                )
            {
                System.Diagnostics.Debug.WriteLine("asignacion decremento");
                entorno.AsignarValor(var, (Int64.Parse(Variable1)-1).ToString());
                return sali;
            }

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
                    //ASIGANACION DE UNA VARIABLE DE TIPO voolena
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

                }else if (this.Hijos[1].TipoDato == "id2")
                {
                    String TIPO1 = entorno.ObtenerTipo(this.Hijos[1].NombreVariable);
                    String TIPO2 = entorno.ObtenerTipo(this.Hijos[0].Nombre);
                    //System.Diagnostics.Debug.WriteLine("AAAAAH PERRO ERES UN ID DE TIPO2" + entorno.ObtenerTipo(this.Hijos[1].NombreVariable));
                   // System.Diagnostics.Debug.WriteLine("AAAAAH PERRO ERES UN ID DE TIPO1" + entorno.ObtenerTipo(this.Hijos[0].Nombre));
                    if (TIPO1.ToUpper().Contains(TIPO2.ToUpper()))
                    {
                        System.Diagnostics.Debug.WriteLine("SON DEL MISMO TIPO");
                        entorno.AsignarValor(this.Hijos[0].Nombre, entorno.ObtenerValor(this.Hijos[1].NombreVariable));
                    }
                    else
                    {
                        if (TIPO1.ToUpper().Contains("INT") && TIPO2.ToUpper().Contains("DOUBLE"))
                        {
                            entorno.AsignarValor(this.Hijos[0].Nombre, entorno.ObtenerValor(this.Hijos[1].NombreVariable));

                        }
                        else if (TIPO1.ToUpper().Contains("DOUBLE") && TIPO2.ToUpper().Contains("INT"))
                        {
                            entorno.AsignarValor(this.Hijos[0].Nombre, entorno.ObtenerValor(this.Hijos[1].NombreVariable));

                        }
                        else {

                            System.Diagnostics.Debug.WriteLine("DIFERENTE TIPO");
                            return "#Error3";
                        }
                        
                    }

                   
                }
               

                else
                {
                    System.Diagnostics.Debug.WriteLine("#Error3 asiganacion incorrecta");
                    return "#Error3";
                }


                

            }
            //System.Diagnostics.Debug.WriteLine("**********************" + this.Hijos[0].AutoIncrmentable);
            
            sali = entorno.ObtenerValor(this.Hijos[1].Nombre);
            return sali;
        }
    }
}