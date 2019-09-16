using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class Aritmetica : NodoAbstracto
    {

        public Aritmetica(String Nombre) : base(Nombre)
        {

        }
        public override void Ejecutar()
        {
            throw new NotImplementedException();
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion Aritmetica");


            
            int total = 0;
            float totald = 0;
            double totaldouble = 0;
            Boolean totalb = true;
            String totalC = "";
            String val1 = this.Hijos[0].Ejecutar(entorno);
            String val2 = this.Hijos[2].Ejecutar(entorno);

            String Tipo1 = this.Hijos[0].TipoDato;
            String Tipo2 = this.Hijos[2].TipoDato;

           

            System.Diagnostics.Debug.WriteLine("Ejecucion Aritmetica el tipo1->"+Tipo1);
            //System.Diagnostics.Debug.WriteLine("TIPO asjdflkads->" + this.Hijos[1].NombreVariable);
            System.Diagnostics.Debug.WriteLine("Ejecucion Aritmetica el tipo1->" + Tipo2);
            //System.Diagnostics.Debug.WriteLine("TIPO asjdflkads->" + this.Hijos[2].NombreVariable);

            if (this.Hijos[1].Nombre == "]"){
                System.Diagnostics.Debug.WriteLine("ES CASTEOOOOOOOOOOOOOOOO");
                System.Diagnostics.Debug.WriteLine("vamos con los casteos");

                String TipoACastear = this.Hijos[0].Nombre;
                System.Diagnostics.Debug.WriteLine("Tipo a Castear:" + TipoACastear);

                String VariableACastear = this.Hijos[2].NombreVariable;
                System.Diagnostics.Debug.WriteLine("Variable A Castear:" + VariableACastear);

                String TipoVariableACastear = "x";
                String ValorNuevo = "";// entorno.ObtenerTipo(this.Hijos[2].NombreVariable);
                if (VariableACastear != null
                //String TipoVariableACastear = entorno.ObtenerTipo(this.Hijos[2].NombreVariable);
                )
                {
                    TipoVariableACastear = entorno.ObtenerTipo(this.Hijos[2].NombreVariable);
                    ValorNuevo = entorno.ObtenerValor(this.Hijos[2].NombreVariable);
                }
                else
                {
                    TipoVariableACastear = this.Hijos[2].TipoDato;
                    ValorNuevo = this.Hijos[2].Ejecutar(entorno);
                }
                ///String TipoVariableACastear = entorno.ObtenerTipo(this.Hijos[2].NombreVariable);
                System.Diagnostics.Debug.WriteLine("Tipo Variable A Castear:" + TipoVariableACastear);
                System.Diagnostics.Debug.WriteLine("valor:" + ValorNuevo);


                if ((TipoACastear.ToUpper().Contains("STRING") == true) &&
                    (TipoVariableACastear.ToUpper().Contains("FECHAS") || TipoVariableACastear.ToUpper().Contains("DATE"))
                )
                {
                    System.Diagnostics.Debug.WriteLine("CASTEO STRING - FECHA");
                    this.TipoDato = "cadena";
                    return ValorNuevo.Replace(" (fechas)", "");

                }
                else if ((TipoACastear.ToUpper().Contains("DATE") == true) &&
                     (TipoVariableACastear.ToUpper().Contains("CADENA") || TipoVariableACastear.ToUpper().Contains("STRING"))
                 )
                {
                    System.Diagnostics.Debug.WriteLine("CASTEO FECHA- STRING");
                    ValorNuevo = ValorNuevo.Replace(" (fechas)", "");
                    if (ValorNuevo.ToUpper().Contains("A") || ValorNuevo.ToUpper().Contains("B") || ValorNuevo.ToUpper().Contains("C") || ValorNuevo.ToUpper().Contains("D")
                       || ValorNuevo.ToUpper().Contains("D") || ValorNuevo.ToUpper().Contains("E") || ValorNuevo.ToUpper().Contains("F") || ValorNuevo.ToUpper().Contains("G")
                       || ValorNuevo.ToUpper().Contains("H") || ValorNuevo.ToUpper().Contains("I") || ValorNuevo.ToUpper().Contains("J") || ValorNuevo.ToUpper().Contains("K")
                       || ValorNuevo.ToUpper().Contains("L") || ValorNuevo.ToUpper().Contains("M") || ValorNuevo.ToUpper().Contains("Ñ") || ValorNuevo.ToUpper().Contains("O")
                       || ValorNuevo.ToUpper().Contains("P") || ValorNuevo.ToUpper().Contains("Q") || ValorNuevo.ToUpper().Contains("R") || ValorNuevo.ToUpper().Contains("S")
                       || ValorNuevo.ToUpper().Contains("T") || ValorNuevo.ToUpper().Contains("U") || ValorNuevo.ToUpper().Contains("V") || ValorNuevo.ToUpper().Contains("W")
                       || ValorNuevo.ToUpper().Contains("X") || ValorNuevo.ToUpper().Contains("Y") || ValorNuevo.ToUpper().Contains("Z")
                       )
                    {
                        System.Diagnostics.Debug.WriteLine("#ERROR5 TIPO DE CASTEO INCORRECTO");
                        return "#ERROR5 TIPO DE CASTEO INCORRECTO";
                    }
                    else
                    {
                        if (ValorNuevo.Contains("-") == false)
                        {
                            System.Diagnostics.Debug.WriteLine("#ERROR5 TIPO DE CASTEO INCORRECTO");
                            return "#ERROR5 TIPO DE CASTEO INCORRECTO";
                        }
                        else
                        {
                            this.TipoDato = "Fechas";
                            return "'" + ValorNuevo.Replace(" (fechas)", "") + "'";
                        }

                    }

                }
                else if ((TipoACastear.ToUpper().Contains("STRING") == true) &&
                        (TipoVariableACastear.ToUpper().Contains("HORA") || TipoVariableACastear.ToUpper().Contains("TIME"))
                )
                {
                    System.Diagnostics.Debug.WriteLine("CASTEO STRING - TIME");
                    this.TipoDato = "cadena";
                    return ValorNuevo.Replace(" (hora)", "");

                }
                else if ((TipoACastear.ToUpper().Contains("TIME") == true) &&
                    (TipoVariableACastear.ToUpper().Contains("CADENA") || TipoVariableACastear.ToUpper().Contains("STRING"))
                )
                {
                    System.Diagnostics.Debug.WriteLine("CASTEO hora- STRING");
                    ValorNuevo = ValorNuevo.Replace(" (hora)", "");
                    if (ValorNuevo.ToUpper().Contains("A") || ValorNuevo.ToUpper().Contains("B") || ValorNuevo.ToUpper().Contains("C") || ValorNuevo.ToUpper().Contains("D")
                       || ValorNuevo.ToUpper().Contains("D") || ValorNuevo.ToUpper().Contains("E") || ValorNuevo.ToUpper().Contains("F") || ValorNuevo.ToUpper().Contains("G")
                       || ValorNuevo.ToUpper().Contains("H") || ValorNuevo.ToUpper().Contains("I") || ValorNuevo.ToUpper().Contains("J") || ValorNuevo.ToUpper().Contains("K")
                       || ValorNuevo.ToUpper().Contains("L") || ValorNuevo.ToUpper().Contains("M") || ValorNuevo.ToUpper().Contains("Ñ") || ValorNuevo.ToUpper().Contains("O")
                       || ValorNuevo.ToUpper().Contains("P") || ValorNuevo.ToUpper().Contains("Q") || ValorNuevo.ToUpper().Contains("R") || ValorNuevo.ToUpper().Contains("S")
                       || ValorNuevo.ToUpper().Contains("T") || ValorNuevo.ToUpper().Contains("U") || ValorNuevo.ToUpper().Contains("V") || ValorNuevo.ToUpper().Contains("W")
                       || ValorNuevo.ToUpper().Contains("X") || ValorNuevo.ToUpper().Contains("Y") || ValorNuevo.ToUpper().Contains("Z")
                       )
                    {
                        System.Diagnostics.Debug.WriteLine("#ERROR5 TIPO DE CASTEO INCORRECTO");
                        return "#ERROR5 TIPO DE CASTEO INCORRECTO";
                    }
                    else
                    {
                        this.TipoDato = "hora";
                        this.Nombre = "hora";
                        return "'" + ValorNuevo + "'";
                    }



                }
                else if ((TipoACastear.ToUpper().Contains("STRING") == true) &&
                       (TipoVariableACastear.ToUpper().Contains("ENTERO") || TipoVariableACastear.ToUpper().Contains("INT"))
               )
                {
                    System.Diagnostics.Debug.WriteLine("CASTEO STRING - INT");
                    this.TipoDato = "cadena";
                    return ValorNuevo;

                }
                else if ((TipoACastear.ToUpper().Contains("INT") == true) &&
                      (TipoVariableACastear.ToUpper().Contains("CADENA") || TipoVariableACastear.ToUpper().Contains("STRING"))
              )
                {
                    System.Diagnostics.Debug.WriteLine("CASTEO STRING - INT");
                    if (ValorNuevo.ToUpper().Contains("A") || ValorNuevo.ToUpper().Contains("B") || ValorNuevo.ToUpper().Contains("C") || ValorNuevo.ToUpper().Contains("D")
                      || ValorNuevo.ToUpper().Contains("D") || ValorNuevo.ToUpper().Contains("E") || ValorNuevo.ToUpper().Contains("F") || ValorNuevo.ToUpper().Contains("G")
                      || ValorNuevo.ToUpper().Contains("H") || ValorNuevo.ToUpper().Contains("I") || ValorNuevo.ToUpper().Contains("J") || ValorNuevo.ToUpper().Contains("K")
                      || ValorNuevo.ToUpper().Contains("L") || ValorNuevo.ToUpper().Contains("M") || ValorNuevo.ToUpper().Contains("Ñ") || ValorNuevo.ToUpper().Contains("O")
                      || ValorNuevo.ToUpper().Contains("P") || ValorNuevo.ToUpper().Contains("Q") || ValorNuevo.ToUpper().Contains("R") || ValorNuevo.ToUpper().Contains("S")
                      || ValorNuevo.ToUpper().Contains("T") || ValorNuevo.ToUpper().Contains("U") || ValorNuevo.ToUpper().Contains("V") || ValorNuevo.ToUpper().Contains("W")
                      || ValorNuevo.ToUpper().Contains("X") || ValorNuevo.ToUpper().Contains("Y") || ValorNuevo.ToUpper().Contains("Z") || ValorNuevo.ToUpper().Contains(".")
                      )
                    {
                        System.Diagnostics.Debug.WriteLine("#ERROR5 TIPO DE CASTEO INCORRECTO");
                        return "#ERROR5 TIPO DE CASTEO INCORRECTO";
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("CASTEO STRING - INT");
                        this.TipoDato = "entero";
                        return ValorNuevo;
                    }


                }
                else if ((TipoACastear.ToUpper().Contains("STRING") == true) &&
                   (TipoVariableACastear.ToUpper().Contains("DECIMAL") || TipoVariableACastear.ToUpper().Contains("DOUBLE"))
                    )
                {
                    System.Diagnostics.Debug.WriteLine("CASTEO STRING - double");
                    this.TipoDato = "cadena";
                    return ValorNuevo;

                }
                else if ((TipoACastear.ToUpper().Contains("DOUBLE") == true) &&
                     (TipoVariableACastear.ToUpper().Contains("CADENA") || TipoVariableACastear.ToUpper().Contains("STRING"))
               )
                {

                    System.Diagnostics.Debug.WriteLine("CASTEO double- STRING");
                    if (ValorNuevo.ToUpper().Contains("A") || ValorNuevo.ToUpper().Contains("B") || ValorNuevo.ToUpper().Contains("C") || ValorNuevo.ToUpper().Contains("D")
                      || ValorNuevo.ToUpper().Contains("D") || ValorNuevo.ToUpper().Contains("E") || ValorNuevo.ToUpper().Contains("F") || ValorNuevo.ToUpper().Contains("G")
                      || ValorNuevo.ToUpper().Contains("H") || ValorNuevo.ToUpper().Contains("I") || ValorNuevo.ToUpper().Contains("J") || ValorNuevo.ToUpper().Contains("K")
                      || ValorNuevo.ToUpper().Contains("L") || ValorNuevo.ToUpper().Contains("M") || ValorNuevo.ToUpper().Contains("Ñ") || ValorNuevo.ToUpper().Contains("O")
                      || ValorNuevo.ToUpper().Contains("P") || ValorNuevo.ToUpper().Contains("Q") || ValorNuevo.ToUpper().Contains("R") || ValorNuevo.ToUpper().Contains("S")
                      || ValorNuevo.ToUpper().Contains("T") || ValorNuevo.ToUpper().Contains("U") || ValorNuevo.ToUpper().Contains("V") || ValorNuevo.ToUpper().Contains("W")
                      || ValorNuevo.ToUpper().Contains("X") || ValorNuevo.ToUpper().Contains("Y") || ValorNuevo.ToUpper().Contains("Z") 
                      )
                    {
                        System.Diagnostics.Debug.WriteLine("#ERROR5 TIPO DE CASTEO INCORRECTO");
                        return "#ERROR5 TIPO DE CASTEO INCORRECTO";
                    }
                    else
                    {
                        this.TipoDato = "decimal";
                        return ValorNuevo;
                    }


                }



                    System.Diagnostics.Debug.WriteLine("CASTEO incorrecto");
                return "#ERROR5";
            }
          
            if(Tipo1 == "id")
            {
                val1 = entorno.ObtenerValor(this.Hijos[0].NombreVariable);
            }
            if (Tipo2 == "id")
            {
                val2 = entorno.ObtenerValor(this.Hijos[2].NombreVariable);
            }
            String Var = "";
            if (Tipo1 == "id2" || Tipo1 == "id" )
            {
                Var = this.Hijos[0].NombreVariable;
                System.Diagnostics.Debug.WriteLine("TIPO 1 ID" + this.Hijos[0].NombreVariable);
                System.Diagnostics.Debug.WriteLine(entorno.ObtenerTipo(this.Hijos[0].NombreVariable).ToUpper());
                if ((entorno.ObtenerTipo(this.Hijos[0].NombreVariable).ToUpper().Contains("INT") == true)
                    || (entorno.ObtenerTipo(this.Hijos[0].NombreVariable).ToUpper().Contains("COUNT") == true))
                {
                   

                   Tipo1 = "entero";
                }
                else if (entorno.ObtenerTipo(this.Hijos[0].NombreVariable).ToUpper().Contains("DOUBLE") == true)
                {
                    //System.Diagnostics.Debug.WriteLine("TIPO 1 IDx");

                    Tipo1 = "decimal";
                }
                else if (entorno.ObtenerTipo(this.Hijos[0].NombreVariable).ToUpper().Contains("STRING") == true)
                {
                    //System.Diagnostics.Debug.WriteLine("TIPO 1 IDx");
                    
                    Tipo1 = "cadena";
                }
                else if (entorno.ObtenerTipo(this.Hijos[0].NombreVariable).ToUpper().Contains("BOOLEAN") == true)
                {
                    //System.Diagnostics.Debug.WriteLine("TIPO 1 IDx");
                    
                    Tipo1 = "Booleano";
                }
                else if (entorno.ObtenerTipo(this.Hijos[0].NombreVariable).ToUpper().Contains("DATE") == true)
                {
                    //System.Diagnostics.Debug.WriteLine("TIPO 1 IDx");

                    Tipo1 = "Fechas";
                }
                else if (entorno.ObtenerTipo(this.Hijos[0].NombreVariable).ToUpper().Contains("TIME") == true)
                {
                    //System.Diagnostics.Debug.WriteLine("TIPO 1 IDx");

                    Tipo1 = "hora";
                }

            }
            
            if (Tipo2 == "id2" || Tipo2 == "id" )
            {
                System.Diagnostics.Debug.WriteLine("TIPO 2 ID" + this.Hijos[2].NombreVariable);
                if (entorno.ObtenerTipo(this.Hijos[2].NombreVariable).ToUpper().Contains("INT") == true)
                {
                    //System.Diagnostics.Debug.WriteLine("TIPO 1 IDx");

                    Tipo2 = "entero";
                }
                else if (entorno.ObtenerTipo(this.Hijos[2].NombreVariable).ToUpper().Contains("DOUBLE") == true)
                {
                    //System.Diagnostics.Debug.WriteLine("TIPO 1 IDx");

                    Tipo2 = "decimal";
                }
                else if (entorno.ObtenerTipo(this.Hijos[2].NombreVariable).ToUpper().Contains("STRING") == true)
                {
                    //System.Diagnostics.Debug.WriteLine("TIPO 1 IDx");

                    Tipo2 = "cadena";
                }
                else if (entorno.ObtenerTipo(this.Hijos[2].NombreVariable).ToUpper().Contains("BOOLEAN") == true)
                {
                    //System.Diagnostics.Debug.WriteLine("TIPO 1 IDx");

                    Tipo2 = "Booleano";
                }
                else if (entorno.ObtenerTipo(this.Hijos[2].NombreVariable).ToUpper().Contains("DATE") == true)
                {
                    //System.Diagnostics.Debug.WriteLine("TIPO 1 IDx");

                    Tipo2 = "Fechas";
                }
                else if (entorno.ObtenerTipo(this.Hijos[2].NombreVariable).ToUpper().Contains("TIME") == true)
                {
                    //System.Diagnostics.Debug.WriteLine("TIPO 1 IDx");

                    Tipo2 = "hora";
                }
            }

            if (val2.Contains("+"))
            {
                int valor1 = Int32.Parse(val1.Replace(" (numero)", ""));
                if (Tipo1 == "entero"|| (Tipo1 == "decimal"))
                {
                    entorno.AsignarValor(Var, (valor1 + 1).ToString());
                    
                }
                return (valor1).ToString();
            }
            if (val2.Contains("-"))
            {
                int valor1 = Int32.Parse(val1.Replace(" (numero)", ""));
                if (Tipo1 == "entero" || (Tipo1 == "decimal"))
                {
                    entorno.AsignarValor(Var, (valor1 - 1).ToString());
                    //return (valor1).ToString();
                }
                return (valor1).ToString();
            }

            //System.Diagnostics.Debug.WriteLine("TIPO 2 IDRx" + Tipo2 + "->" + val2);
            val1 = val1.Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "");
            val2 = val2.Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "");
            System.Diagnostics.Debug.WriteLine("TIPO 1 IDRx" + Tipo1 + "->" + val1);
            System.Diagnostics.Debug.WriteLine("TIPO 2 IDRx" + Tipo2 + "->" + val2);

            if (val1.ToUpper().Contains("#ERROR") || val2.ToUpper().Contains("#ERROR"))
            {
                return "#Error";
            }
            //*************************

            //PARTE DONDE SOLO TRABAJAREMOS enteros

            ///************
            if (Tipo1 == "entero" && Tipo2 == "entero")
            {
                int valor1 = Int32.Parse(val1.Replace(" (numero)", ""));
                int valor2 = Int32.Parse(val2.Replace(" (numero)", ""));
               //System.Diagnostics.Debug.WriteLine("Entro num num" + Tipo1+".>"+Tipo2);
                switch (this.Hijos[1].Nombre)
                {
                    case "+":
                        total = valor1 + valor2;
                        Console.WriteLine("Paso por una suma" + total);
                         break;
                    case "-":
                        total = valor1 - valor2;
                        Console.WriteLine("Paso por una resta" + total);
                        break;
                    case "/":
                        if (valor2 == 0)
                        {
                            //salida.Text = "#Error: Se está intentando dividir por 0 \n";
                            System.Diagnostics.Debug.WriteLine("#Error: Se está intentando dividir por 0 \n");
                            return "#Error";
                        }
                        total = valor1 / valor2;
                        Console.WriteLine("Paso por una division" + total);
                        break;
                    case "*":
                        total = valor1 * valor2;
                        Console.WriteLine("Paso por una multiplicacion" + total);
                        break;
                    case "%":
                        if (valor2 == 0)
                        {
                            //salida.Text = "#Error: Se está intentando dividir por 0 \n";
                            System.Diagnostics.Debug.WriteLine("#Error: Se está intentando dividir por 0 \n");
                            return "#Error";
                        }
                        total = valor1 % valor2;
                        Console.WriteLine("Paso por una modulo" + total);
                        break;
                    case "**":
                        totaldouble = Math.Pow(valor1, valor2);
                        return totaldouble.ToString();
                    case ">":
                        totalb = valor1 > valor2;
                        return totalb.ToString();
                    case "<":
                        totalb = valor1 < valor2;
                        return totalb.ToString();
                    case ">=":
                        totalb = valor1 >= valor2;
                        return totalb.ToString();
                    case "<=":
                        totalb = valor1 <= valor2;
                        return totalb.ToString();
                    case "==":
                        totalb = valor1 == valor2;
                        System.Diagnostics.Debug.WriteLine("#Bayron:" + totalb);
                        return totalb.ToString();
                    case "!=":
                        totalb = valor1 != valor2;
                        return totalb.ToString();

                }
                if (this.Hijos[0].AutoIncrmentable == 1)
                {
                    /*System.Diagnostics.Debug.WriteLine("**********************");
                    float a = float.Parse(entorno.ObtenerValor(this.Hijos[0].Hijos[0].NombreVariable.ToString()));
                    a = a + 1;
                    System.Diagnostics.Debug.WriteLine("si entro: " + this.Hijos[0].Hijos[0].NombreVariable.ToString() + "-" + a.ToString());
                    entorno.AsignarValor(this.Hijos[0].Hijos[0].NombreVariable.ToString(), a.ToString());
                    total = total - 1;
                    this.Hijos[0].AutoIncrmentable = 0;
                    //val1 = (float.Parse(val1) - 1).ToString(); */
                    total = total - 1;
                }
               
                return total.ToString();
            }
            //*************************

            //PARTE DONDE SOLO TRABAJAREMOS decimales

            ///************

            else if (Tipo1 == "decimal" && Tipo2 == "decimal")
            {
                float valor1 = float.Parse(val1.Replace(" (numdecimal)", "").Replace(" ", "").Replace(".", ","));
                float valor2 = float.Parse(val2.Replace(" (numdecimal)", "").Replace(" ", "").Replace(".", ","));
                //float uno = 3.1f ;
                //Console.WriteLine(val1 + "AA"+uno);
                //Console.WriteLine(val2 + "bb"+uno);
                switch (this.Hijos[1].Nombre)
                {
                    case "+":
                        totald = valor1 + valor2;
                        Console.WriteLine("Paso por una suma" + totald);
                        break;
                    case "-":
                        totald = valor1 - valor2;
                        Console.WriteLine("Paso por una resta" + totald);
                        break;
                    case "/":
                        if (valor2 == 0)
                        {
                            //salida.Text = "#Error: Se está intentando dividir por 0 \n";
                            System.Diagnostics.Debug.WriteLine("#Error: Se está intentando dividir por 0 \n");
                            return "#Error";
                        }
                        totald = valor1 / valor2;
                        Console.WriteLine("Paso por una division" + totald);
                        break;
                    case "*":
                        totald = valor1 * valor2;
                        Console.WriteLine("Paso por una multiplicacion" + totald);
                        break;
                    case "%":
                        if (valor2 == 0)
                        {
                            //salida.Text = "#Error: Se está intentando dividir por 0 \n";
                            System.Diagnostics.Debug.WriteLine("#Error: Se está intentando dividir por 0 \n");
                            return "#Error";
                        }
                        totald = valor1 % valor2;
                        Console.WriteLine("Paso por una modulo" + totald);
                        break;
                    case "**":
                        totaldouble = Math.Pow(valor1, valor2);
                        return totaldouble.ToString();
                    case ">":
                        totalb = valor1 > valor2;
                        return totalb.ToString();

                    case "<":
                        totalb = valor1 < valor2;
                        return totalb.ToString();
                    case ">=":
                        totalb = valor1 >= valor2;
                        return totalb.ToString();
                    case "<=":
                        totalb = valor1 <= valor2;
                        return totalb.ToString();
                    case "==":
                        totalb = valor1 == valor2;
                        return totalb.ToString();
                    case "!=":
                        totalb = valor1 != valor2;
                        return totalb.ToString();

                }
                return totald.ToString();
            }
            //*************************

            //PARTE DONDE SOLO EL LADO IZQUIERDO ES DECIMAL Y EL DERECHO entero

            ///************
            else if (Tipo1 == "decimal" && Tipo2 == "entero")
            {
                float valor1 = float.Parse(val1.Replace(" (numdecimal)", "").Replace(" ", "").Replace(".", ","));
                int valor2 = Int32.Parse(val2.Replace(" (numero)", ""));
                //float uno = 3.1f ;
                //Console.WriteLine(val1 + "AA"+uno);
                //Console.WriteLine(val2 + "bb"+uno);
                switch (this.Hijos[1].Nombre)
                {
                    case "+":
                        totald = valor1 + valor2;
                        Console.WriteLine("Paso por una suma" + totald);
                        break;
                    case "-":
                        totald = valor1 - valor2;
                        Console.WriteLine("Paso por una resta" + totald);
                        break;
                    case "/":
                        if (valor2 == 0)
                        {
                            //salida.Text = "#Error: Se está intentando dividir por 0 \n";
                            System.Diagnostics.Debug.WriteLine("#Error: Se está intentando dividir por 0 \n");
                            return "#Error";
                        }
                        totald = valor1 / valor2;
                        Console.WriteLine("Paso por una division" + totald);
                        break;
                    case "*":
                        totald = valor1 * valor2;
                        Console.WriteLine("Paso por una multiplicacion" + totald);
                        break;
                    case "%":
                        if (valor2 == 0)
                        {
                            //salida.Text = "#Error: Se está intentando dividir por 0 \n";
                            System.Diagnostics.Debug.WriteLine("#Error: Se está intentando dividir por 0 \n");
                            return "#Error";
                        }
                        totald = valor1 % valor2;
                        Console.WriteLine("Paso por una modulo" + totald);
                        break;
                    case "**":
                        totaldouble = Math.Pow(valor1, valor2);
                        return totaldouble.ToString();
                    case ">":
                        totalb = valor1 > valor2;
                        return totalb.ToString();

                    case "<":
                        totalb = valor1 < valor2;
                        return totalb.ToString();
                    case ">=":
                        totalb = valor1 >= valor2;
                        return totalb.ToString();
                    case "<=":
                        totalb = valor1 <= valor2;
                        return totalb.ToString();
                    case "==":
                        totalb = valor1 == valor2;
                        return totalb.ToString();
                    case "!=":
                        totalb = valor1 != valor2;
                        return totalb.ToString();


                }
                return totald.ToString();
            }
            //*************************

            //PARTE DONDE SOLO EL LADO IZQUIERDO ES entero y EL DERECHO DECIMAL

            ///*****

            else if (Tipo1 == "entero" && Tipo2 == "decimal")
            {
                int valor1 = Int32.Parse(val1.Replace(" (numero)", ""));
                float valor2 = float.Parse(val2.Replace(" (numdecimal)", "").Replace(" ", "").Replace(".", ","));

                //float uno = 3.1f ;

                switch (this.Hijos[1].Nombre)
                {
                    case "+":
                        totald = valor1 + valor2;
                        Console.WriteLine("Paso por una suma" + totald);
                        break;
                    case "-":
                        totald = valor1 - valor2;
                        Console.WriteLine("Paso por una resta" + totald);
                        break;
                    case "/":
                        if (valor2 == 0)
                        {
                            // salida.Text = "#Error: Se está intentando dividir por 0 \n";
                            System.Diagnostics.Debug.WriteLine("#Error: Se está intentando dividir por 0 \n");
                            return "#Error";
                        }
                        totald = valor1 / valor2;
                        Console.WriteLine("Paso por una division" + totald);
                        break;
                    case "*":
                        totald = valor1 * valor2;
                        Console.WriteLine("Paso por una multiplicacion" + totald);
                        break;
                    case "%":
                        if (valor2 == 0)
                        {
                            //salida.Text = "#Error: Se está intentando dividir por 0 \n";
                            System.Diagnostics.Debug.WriteLine("#Error: Se está intentando dividir por 0 \n");
                            return "#Error";
                        }
                        totald = valor1 % valor2;
                        Console.WriteLine("Paso por una modulo" + totald);
                        break;
                    case "**":
                        totaldouble = Math.Pow(valor1, valor2);
                        return totaldouble.ToString();

                    case ">":
                        totalb = valor1 > valor2;
                        return totalb.ToString();

                    case "<":
                        totalb = valor1 < valor2;
                        return totalb.ToString();
                    case ">=":
                        totalb = valor1 >= valor2;
                        return totalb.ToString();
                    case "<=":
                        totalb = valor1 <= valor2;
                        return totalb.ToString();
                    case "==":
                        totalb = valor1 == valor2;
                        return totalb.ToString();
                    case "!=":
                        totalb = valor1 != valor2;
                        return totalb.ToString();

                }
                return totald.ToString();
            }

            //VAMOS A TRATAR LAS CADENAS ENTONCES "cadena"
            else if (Tipo1 == "cadena" && Tipo2 == "cadena")
            {
                String valor1 = (val1.Replace(" (cadena)", ""));
                String valor2 = (val2.Replace(" (cadena)", ""));
                // System.Diagnostics.Debug.WriteLine("hola1" + valor1);
                // System.Diagnostics.Debug.WriteLine("hola2" + valor2);
                //float uno = 3.1f ;
                //Console.WriteLine(val1 + "AA"+uno);
                //Console.WriteLine(val2 + "bb"+uno);
                switch (this.Hijos[1].Nombre)
                {
                    case "+":
                        totalC = valor1 + valor2;
                        System.Diagnostics.Debug.WriteLine("concatenacion");
                        break;
                    case "-":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");

                        return "#Error";

                    case "/":

                        // salida.Text = "#Error: Se está intentando dividir por 0 \n";
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");

                        return "#Error";

                    case "*":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case "%":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                    case "**":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case ">":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                    case "<":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case ">=":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case "<=":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case "==":
                        totalb = valor1 == valor2;
                        System.Diagnostics.Debug.WriteLine("#Bayron:" + totalb);
                        return totalb.ToString();
                    case "!=":
                        totalb = valor1 != valor2;
                        return totalb.ToString();

                }
                return totalC.ToString();
            }

            else if (Tipo1 == "cadena" && Tipo2 == "entero")
            {
                String valor1 = (val1.Replace(" (cadena)", ""));
                String valor2 = (val2.Replace(" (numero)", ""));
                // System.Diagnostics.Debug.WriteLine("hola1" + valor1);
                // System.Diagnostics.Debug.WriteLine("hola2" + valor2);
                //float uno = 3.1f ;
                //Console.WriteLine(val1 + "AA"+uno);
                //Console.WriteLine(val2 + "bb"+uno);
                switch (this.Hijos[1].Nombre)
                {
                    case "+":
                        totalC = valor1 + valor2;
                        System.Diagnostics.Debug.WriteLine("concatenacion");
                        break;
                    case "-":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");

                        return "#Error";

                    case "/":

                        // salida.Text = "#Error: Se está intentando dividir por 0 \n";
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");

                        return "#Error";

                    case "*":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                    case "%":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case "**":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        break;
                    case ">":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                    case "<":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case ">=":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case "<=":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                }
                return totalC.ToString();
            }

            else if (Tipo1 == "entero" && Tipo2 == "cadena")
            {
                String valor2 = (val2.Replace(" (cadena)", ""));
                String valor1 = (val1.Replace(" (numero)", ""));
                // System.Diagnostics.Debug.WriteLine("hola1" + valor1);
                // System.Diagnostics.Debug.WriteLine("hola2" + valor2);
                //float uno = 3.1f ;
                //Console.WriteLine(val1 + "AA"+uno);
                //Console.WriteLine(val2 + "bb"+uno);
                switch (this.Hijos[1].Nombre)
                {
                    case "+":
                        totalC = valor1 + valor2;
                        System.Diagnostics.Debug.WriteLine("concatenacion");
                        break;
                    case "-":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings xd");
                        totalC = "#Error";
                        return "#Error";

                    case "/":

                        // salida.Text = "#Error: Se está intentando dividir por 0 \n";
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");

                        return "#Error";

                    case "*":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        totalC = "#Error";
                        return "#Error";
                    case "%":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case "**":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        break;
                    case ">":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                    case "<":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case ">=":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case "<=":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                }
                return totalC.ToString();
            }

            else if (Tipo1 == "cadena" && Tipo2 == "decimal")
            {
                String valor1 = (val1.Replace(" (cadena)", ""));
                float valor2 = float.Parse(val2.Replace(" (numdecimal)", "").Replace(" ", "").Replace(".", ","));
                // System.Diagnostics.Debug.WriteLine("hola1" + valor1);
                // System.Diagnostics.Debug.WriteLine("hola2" + valor2);
                //float uno = 3.1f ;
                //Console.WriteLine(val1 + "AA"+uno);
                System.Diagnostics.Debug.WriteLine("concatenacionxd");
                //Console.WriteLine(val2 + "bb"+uno);
                switch (this.Hijos[1].Nombre)
                {
                    case "+":
                        totalC = valor1 + valor2;
                        System.Diagnostics.Debug.WriteLine("concatenacion");
                        break;
                    case "-":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");

                        return "#Error";

                    case "/":

                        // salida.Text = "#Error: Se está intentando dividir por 0 \n";
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");

                        return "#Error";

                    case "*":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                    case "%":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case "**":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        break;
                    case ">":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                    case "<":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case ">=":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case "<=":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                }
                return totalC.ToString();
            }

            else if (Tipo1 == "Booleano" && Tipo2 == "Booleano")
            {
                String valor1 = (val1.Replace(" (cadena)", ""));
                String valor2 = (val2.Replace(" (cadena)", ""));

                Boolean var3 = Convert.ToBoolean(valor1);
                Boolean var4 = Convert.ToBoolean(valor2);
                // System.Diagnostics.Debug.WriteLine("hola1" + valor1);
                // System.Diagnostics.Debug.WriteLine("hola2" + valor2);
                //float uno = 3.1f ;
                //Console.WriteLine(val1 + "AA"+uno);
                //Console.WriteLine(val2 + "bb"+uno);
                switch (this.Hijos[1].Nombre)
                {
                    case "==":
                        totalb = valor1 == valor2;
                        return totalb.ToString();
                    case "!=":
                        totalb = valor1 != valor2;
                        return totalb.ToString();
                    case "||":
                        totalb = var3 || var4;
                        return totalb.ToString();
                    case "&&":
                        totalb = var3 && var4;
                        return totalb.ToString();
                    case "^":
                        totalb = var3 ^ var4;
                        return totalb.ToString();
                    case "!":
                        totalb = !(var4);
                        return totalb.ToString();

                }
                System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                return "#Error";
            }
            
            else if (Tipo1 == "decimal" && Tipo2 == "cadena")
            {
                String valor2 = (val2.Replace(" (cadena)", ""));
                float valor1 = float.Parse(val1.Replace(" (numdecimal)", "").Replace(" ", "").Replace(".", ","));
                // System.Diagnostics.Debug.WriteLine("hola1" + valor1);
                // System.Diagnostics.Debug.WriteLine("hola2" + valor2);
                //float uno = 3.1f ;
                //Console.WriteLine(val1 + "AA"+uno);
                System.Diagnostics.Debug.WriteLine("concatenacionxd");
                //Console.WriteLine(val2 + "bb"+uno);
                switch (this.Hijos[1].Nombre)
                {
                    case "+":
                        totalC = valor1 + valor2;
                        System.Diagnostics.Debug.WriteLine("concatenacion");
                        break;
                    case "-":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");

                        return "#Error";

                    case "/":

                        // salida.Text = "#Error: Se está intentando dividir por 0 \n";
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");

                        return "#Error";

                    case "*":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                    case "%":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case "**":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        break;
                    case ">":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                    case "<":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case ">=":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case "<=":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                }
                return totalC.ToString();
            }

            else if (Tipo1 == "cadena" && Tipo2 == "Booleano")
            {
                String valor1 = (val1.Replace(" (cadena)", ""));
                String valor2 = (val2.Replace(" (cadena)", ""));
                // System.Diagnostics.Debug.WriteLine("hola1" + valor1);
                // System.Diagnostics.Debug.WriteLine("hola2" + valor2);
                //float uno = 3.1f ;
                //Console.WriteLine(val1 + "AA"+uno);
                //Console.WriteLine(val2 + "bb"+uno);
                switch (this.Hijos[1].Nombre)
                {
                    case "+":
                        totalC = valor1 + valor2;
                        System.Diagnostics.Debug.WriteLine("concatenacion");
                        break;
                    case "-":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");

                        return "#Error";

                    case "/":

                        // salida.Text = "#Error: Se está intentando dividir por 0 \n";
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");

                        return "#Error";

                    case "*":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case "%":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                    case "**":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                }
                return totalC.ToString();
            }

            else if (Tipo1 == "Booleano" && Tipo2 == "cadena")
            {
                String valor1 = (val1.Replace(" (cadena)", ""));
                String valor2 = (val2.Replace(" (cadena)", ""));
                // System.Diagnostics.Debug.WriteLine("hola1" + valor1);
                // System.Diagnostics.Debug.WriteLine("hola2" + valor2);
                //float uno = 3.1f ;
                //Console.WriteLine(val1 + "AA"+uno);
                //Console.WriteLine(val2 + "bb"+uno);
                switch (this.Hijos[1].Nombre)
                {
                    case "+":
                        totalC = valor1 + valor2;
                        System.Diagnostics.Debug.WriteLine("concatenacion");
                        break;
                    case "-":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");

                        return "#Error";

                    case "/":

                        // salida.Text = "#Error: Se está intentando dividir por 0 \n";
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");

                        return "#Error";

                    case "*":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case "%":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                    case "**":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                }
                return totalC.ToString();
            }

            else if(Tipo1 == "Fechas" && Tipo2 == "Fechas")
            {
                String valor1 = (val1.Replace(" (fechas)", "").Replace("'", ""));
                String valor2 = (val2.Replace(" (fechas)", "").Replace("'", ""));
                DateTime fecha1 = Convert.ToDateTime(valor1).Date;
                DateTime fecha2 = Convert.ToDateTime(valor2).Date;
                System.Diagnostics.Debug.WriteLine("fecha1" + fecha1);
                System.Diagnostics.Debug.WriteLine("fecha2" + fecha2);
                switch (this.Hijos[1].Nombre)
                {
                    
                    case ">":
                        totalb = fecha1 > fecha2;
                        return totalb.ToString();
                    case "<":
                        totalb = fecha1 < fecha2;
                        return totalb.ToString();
                    case ">=":
                        totalb = fecha1 >= fecha2;
                        return totalb.ToString();
                    case "<=":
                        totalb = fecha1 <= fecha2;
                        return totalb.ToString();
                    case "==":
                        totalb = valor1 == valor2;
                        return totalb.ToString();
                    case "!=":
                        totalb = valor1 != valor2;
                        return totalb.ToString();

                }


                System.Diagnostics.Debug.WriteLine("#Error semanticoxd \n");
                return "#Error";
            }

            else if (Tipo1 == "hora" && Tipo2 == "hora")
            {
                String valor1 = (val1.Replace(" (hora)", "").Replace("'", ""));
                String valor2 = (val2.Replace(" (hora)", "").Replace("'", ""));
                DateTime fecha1 = Convert.ToDateTime(valor1).Date;
                DateTime fecha2 = Convert.ToDateTime(valor2).Date;
                System.Diagnostics.Debug.WriteLine("fecha1" + fecha1);
                System.Diagnostics.Debug.WriteLine("fecha2" + fecha2);
                switch (this.Hijos[1].Nombre)
                {

                    case ">":
                        totalb = fecha1 > fecha2;
                        return totalb.ToString();
                    case "<":
                        totalb = fecha1 < fecha2;
                        return totalb.ToString();
                    case ">=":
                        totalb = fecha1 >= fecha2;
                        return totalb.ToString();
                    case "<=":
                        totalb = fecha1 <= fecha2;
                        return totalb.ToString();
                    case "==":
                        totalb = valor1 == valor2;
                        return totalb.ToString();
                    case "!=":
                        totalb = valor1 != valor2;
                        return totalb.ToString();

                }


                System.Diagnostics.Debug.WriteLine("#Error semanticoxd \n");
                return "#Error";
            }

            else if (Tipo1 == "cadena" && (Tipo2 == "Fechas" || Tipo2 == "hora"))
            {
                String valor1 = (val1.Replace(" (cadena)", ""));
                String valor2 = (val2.Replace(" (Fechas)", "").Replace(" (hora)",""));
                // System.Diagnostics.Debug.WriteLine("hola1" + valor1);
                // System.Diagnostics.Debug.WriteLine("hola2" + valor2);
                //float uno = 3.1f ;
                //Console.WriteLine(val1 + "AA"+uno);
                //Console.WriteLine(val2 + "bb"+uno);
                switch (this.Hijos[1].Nombre)
                {
                    case "+":
                        totalC = valor1 + valor2;
                        System.Diagnostics.Debug.WriteLine("concatenacion");
                        break;
                    case "-":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");

                        return "#Error";

                    case "/":

                        // salida.Text = "#Error: Se está intentando dividir por 0 \n";
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");

                        return "#Error";

                    case "*":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case "%":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                    case "**":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case ">":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                    case "<":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case ">=":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case "<=":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case "==":
                        totalb = valor1 == valor2;
                        return totalb.ToString();
                    case "!=":
                        totalb = valor1 != valor2;
                        return totalb.ToString();

                }
                return totalC.ToString();
            }

            else if (Tipo2 == "cadena" && (Tipo1 == "Fechas" || Tipo1 == "hora"))
            {
                String valor2 = (val1.Replace(" (cadena)", ""));
                String valor1 = (val2.Replace(" (Fechas)", "").Replace(" (hora)", ""));
                // System.Diagnostics.Debug.WriteLine("hola1" + valor1);
                // System.Diagnostics.Debug.WriteLine("hola2" + valor2);
                //float uno = 3.1f ;
                //Console.WriteLine(val1 + "AA"+uno);
                //Console.WriteLine(val2 + "bb"+uno);
                switch (this.Hijos[1].Nombre)
                {
                    case "+":
                        totalC = valor2 + valor1;
                        System.Diagnostics.Debug.WriteLine("concatenacion");
                        break;
                    case "-":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");

                        return "#Error";

                    case "/":

                        // salida.Text = "#Error: Se está intentando dividir por 0 \n";
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");

                        return "#Error";

                    case "*":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case "%":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                    case "**":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case ">":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                    case "<":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case ">=":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case "<=":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";
                    case "==":
                        totalb = valor1 == valor2;
                        return totalb.ToString();
                    case "!=":
                        totalb = valor1 != valor2;
                        return totalb.ToString();

                }
                return totalC.ToString();
            }
            System.Diagnostics.Debug.WriteLine("#Error semantico \n");
            return "#Error";
        }
    }
}