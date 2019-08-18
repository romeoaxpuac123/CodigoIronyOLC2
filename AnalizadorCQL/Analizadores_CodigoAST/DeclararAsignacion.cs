﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class DeclararAsignacion : NodoAbstracto
    {
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado declararasiganar");
        }
        public DeclararAsignacion(String Valor) : base(Valor)
        {

        }
        public override string Ejecutar(Entorno entorno)
        {
            String tipo = this.Hijos[0].Nombre;
            String id = this.Hijos[1].Nombre;
            String sali = entorno.ObtenerValor(this.Hijos[1].Nombre);
            System.Diagnostics.Debug.WriteLine("tipo de variable" + this.Hijos[0].Nombre);
            System.Diagnostics.Debug.WriteLine("VAR" + this.Hijos[1].Nombre);
            System.Diagnostics.Debug.WriteLine("tipo de la expresion" + this.Hijos[2].Nombre);
            System.Diagnostics.Debug.WriteLine("valor" + this.Hijos[2].Ejecutar(entorno).Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", ""));
            String Variable1 = this.Hijos[2].Ejecutar(entorno).Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(".", ",");
            Boolean DecimalEntero = true;
            Boolean ElBool = true;
            if (this.Hijos[2].TipoDato == "entero" || this.Hijos[2].TipoDato == "decimal")
            {
                DecimalEntero = false;
            }
            if (Variable1.ToUpper() == "TRUE" || Variable1.ToUpper() == "FALSE")
            {
                ElBool = false;
            }
            if ("#Error2".Equals(sali) == true)
            {
                if (this.Hijos[0].Nombre.ToUpper().Contains("INT") == true
                    && (this.Hijos[2].Nombre == "Entero" || this.Hijos[2].Nombre == "Decimal" || this.Hijos[2].Nombre == "EXP")
                    && DecimalEntero == false
                    ) 
                {
                    //System.Diagnostics.Debug.WriteLine("la variable es entera");
                    entorno.Agregar(id, tipo, Variable1);
                }
                else if (this.Hijos[0].Nombre.ToUpper().Contains("DOUBLE") == true && (this.Hijos[2].Nombre == "Entero" || this.Hijos[2].Nombre == "Decimal" || this.Hijos[2].Nombre == "EXP")
                    && DecimalEntero == false
                    )
                {
                    //System.Diagnostics.Debug.WriteLine("la variable es DOUBLE");
                    entorno.Agregar(id, tipo, Variable1);
                }
                else if (this.Hijos[0].Nombre.ToUpper().Contains("BOOLEAN") == true
                     && (this.Hijos[2].Nombre.ToString().Contains("Booleano") || this.Hijos[2].Nombre == "EXP")
                    && ElBool == false
                    )
                {
                    //System.Diagnostics.Debug.WriteLine("la variable es BOOLEAN");
                    entorno.Agregar(id, tipo, Variable1);
                }
                else if (this.Hijos[0].Nombre.ToUpper().Contains("STRING") == true
                    && (this.Hijos[2].Nombre.ToString().Contains("Cadena") || this.Hijos[2].Nombre == "EXP"))
                {
                  //  System.Diagnostics.Debug.WriteLine("la variable es STRING");
                    entorno.Agregar(id, tipo, Variable1);
                }
                else if (this.Hijos[0].Nombre.ToUpper().Contains("DATE") == true
                    && (this.Hijos[2].Nombre.ToString().Contains("Fecha") || this.Hijos[2].Nombre == "EXP")
                    )
                {
                    //System.Diagnostics.Debug.WriteLine("la variable es DATE");
                    entorno.Agregar(id, tipo, Variable1);
                }
                else if (this.Hijos[0].Nombre.ToUpper().Contains("TIME") == true
                    && (this.Hijos[2].Nombre.ToString().Contains("hora") || this.Hijos[1].Nombre == "EXP")
                    )
                {
                    //System.Diagnostics.Debug.WriteLine("la variable es TIME");
                    entorno.Agregar(id, tipo, Variable1);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("#Error3 asiganacion incorrecta");
                    return "#Error3";
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("#Error4 la variable YA EXISTE");
                return "#Error4";
            }

                //entorno.Agregar(id, tipo, valor);
            return "";
        }
    }
}