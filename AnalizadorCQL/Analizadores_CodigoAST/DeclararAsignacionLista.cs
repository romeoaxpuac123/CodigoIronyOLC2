using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class DeclararAsignacionLista : NodoAbstracto
    {
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado declarar y asginar lista");
        }
        public DeclararAsignacionLista(String Valor) : base(Valor)
        {

        }
        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado declarar y asginar lista");
            String retorno = "";
            List<String> ListaID1x = new List<String>();
            ListaID1x = this.ListaID1;
            String total = "";
            
            if (this.Hijos[2].Nombre.Contains("INCREMENTO")==true)
            {
                total = (float.Parse(entorno.ObtenerValor(this.Hijos[2].Hijos[0].Nombre))).ToString();
            }
            if (this.Hijos[2].Nombre.Contains("DECREMENTO") == true)
            {
                total = (float.Parse(entorno.ObtenerValor(this.Hijos[2].Hijos[0].Nombre))).ToString();
            }


            for (int i = 0; i < ListaID1x.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("la variable esxd:" + ListaID1x[i]);
                String tipo = this.Hijos[0].Nombre;
                String id = ListaID1x[i];
                String sali = entorno.ObtenerValor(this.Hijos[1].Nombre);
                System.Diagnostics.Debug.WriteLine("tipo de variable" + this.Hijos[0].Nombre);
                System.Diagnostics.Debug.WriteLine("VAR" + ListaID1x[i]);
                System.Diagnostics.Debug.WriteLine("tipo de la expresion" + this.Hijos[2].Nombre);
                System.Diagnostics.Debug.WriteLine("valor" + this.Hijos[2].Ejecutar(entorno).Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", ""));
                String Variable1 = this.Hijos[2].Ejecutar(entorno).Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(".", ",");
                Boolean DecimalEntero = true;
                Boolean ElBool = true;


                if (this.Hijos[2].Nombre == "id2")
                {
                    Variable1 = entorno.ObtenerValor(this.Hijos[2].NombreVariable);
                    String Tipaso = entorno.ObtenerTipo(this.Hijos[2].NombreVariable);
                    System.Diagnostics.Debug.WriteLine("valorxe" + Tipaso);
                    if (Tipaso.ToUpper().Contains("INT") == true)
                    {
                        this.Hijos[2].Nombre = "Entero";
                        this.Hijos[2].TipoDato = "entero";

                    }
                    else if (Tipaso.ToUpper().Contains("DOUBLE") == true)
                    {
                        this.Hijos[2].Nombre = "Decimal";
                        this.Hijos[2].TipoDato = "decimal";
                    }
                    else if (Tipaso.ToUpper().Contains("BOOL") == true)
                    {
                        this.Hijos[2].Nombre = "Booleano";
                        
                    }
                    else if (Tipaso.ToUpper().Contains("STRING") == true)
                    {
                        this.Hijos[2].Nombre = "Cadena";
                      
                    }
                    else if (Tipaso.ToUpper().Contains("TIME") == true)
                    {
                        this.Hijos[2].Nombre = "hora";
                       
                    }
                    else if (Tipaso.ToUpper().Contains("DATE") == true)
                    {
                        this.Hijos[2].Nombre = "Fechas";
                        Variable1 = entorno.ObtenerValor(this.Hijos[2].NombreVariable);
                    }
                    
                }
                if (Variable1.Contains("@") == true)
                {
                    Variable1 = entorno.ObtenerValor(Variable1);
                }
                
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
                        System.Diagnostics.Debug.WriteLine("la variable es entera" + Variable1);
                        if (Variable1.Contains(","))
                        {
                            entorno.Agregar(id, tipo, Variable1.Remove(Variable1.IndexOf(",")));
                        }
                        else
                        {
                            entorno.Agregar(id, tipo, Variable1);
                        }
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
                    else if ((this.Hijos[0].Nombre.ToUpper().Contains("INT") || this.Hijos[0].Nombre.ToUpper().Contains("DOUBLE"))
                         && this.Hijos[2].Nombre.Contains("INCREMENTO")
                    )
                    {
                        System.Diagnostics.Debug.WriteLine("INCREMENTOOOOOOOOOOO" + this.Hijos[2].Hijos[0].Nombre);


                        entorno.Agregar(id, tipo, total) ;

                    }
                    else if ((this.Hijos[0].Nombre.ToUpper().Contains("INT") || this.Hijos[0].Nombre.ToUpper().Contains("DOUBLE"))
                        && this.Hijos[2].Nombre.Contains("DECREMENTO")
                   )
                    {
                        System.Diagnostics.Debug.WriteLine("DECREMENTOOOOOOOOOOO" + this.Hijos[2].Hijos[0].Nombre);


                        entorno.Agregar(id, tipo, total);

                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("#Error3 asiganacion incorrecta");
                        retorno = "#Error3";
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("#Error4 la variable YA EXISTE");
                    retorno = "#Error4";
                }
            }
            if (this.Hijos[2].Nombre.Contains("INCREMENTO"))
            {
                entorno.AsignarValor(this.Hijos[2].Hijos[0].Nombre, (float.Parse(total) + 1).ToString());
            }
            if (this.Hijos[2].Nombre.Contains("DECREMENTO"))
            {
                entorno.AsignarValor(this.Hijos[2].Hijos[0].Nombre, (float.Parse(total) - 1).ToString());
            }

            return retorno;
        }
    }
}