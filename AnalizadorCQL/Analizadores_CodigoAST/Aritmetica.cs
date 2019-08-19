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

            if(this.Hijos[4] != null){
                System.Diagnostics.Debug.WriteLine("ES CASTEOOOOOOOOOOOOOOOO");
            }
          

            if (Tipo1 == "id2")
            {
                
                System.Diagnostics.Debug.WriteLine("TIPO 1 ID" + this.Hijos[0].NombreVariable);
                System.Diagnostics.Debug.WriteLine(entorno.ObtenerTipo(this.Hijos[0].NombreVariable).ToUpper());
                if (entorno.ObtenerTipo(this.Hijos[0].NombreVariable).ToUpper().Contains("INT") == true)
                {
                    //System.Diagnostics.Debug.WriteLine("TIPO 1 IDx");

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
            if (Tipo2 == "id2")
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

            //Console.WriteLine(val1 + "AA");
            //Console.WriteLine(val2 + "bb");
            //Console.WriteLine(this.Hijos[1].Nombre + "CC");

            // System.Diagnostics.Debug.WriteLine("va a entrar");
            /*
             if (this.Hijos[0].AutoIncrmentable == 1 )
             {

                 System.Diagnostics.Debug.WriteLine("**********************");
                 float a = float.Parse(entorno.ObtenerValor(this.Hijos[0].Hijos[0].NombreVariable.ToString()));
                 a = a + 1;
                 System.Diagnostics.Debug.WriteLine("si entro: " + this.Hijos[0].Hijos[0].NombreVariable.ToString() + "-" + a.ToString());
                 entorno.AsignarValor(this.Hijos[0].Hijos[0].NombreVariable.ToString(), a.ToString());
                 //this.Hijos[0].AutoIncrmentable = 0;
                 val1 = (float.Parse(val1) - 1).ToString();
             }
             /*
             if (this.Hijos[1].AutoIncrmentable == 1)
             {

                 System.Diagnostics.Debug.WriteLine("**********************");
                 float a = float.Parse(entorno.ObtenerValor(this.Hijos[1].Hijos[0].NombreVariable.ToString()));
                 a = a + 1;
                 System.Diagnostics.Debug.WriteLine("si entro: " + this.Hijos[1].Hijos[0].NombreVariable.ToString() + "-" + a.ToString());
                 entorno.AsignarValor(this.Hijos[1].Hijos[0].NombreVariable.ToString(), a.ToString());
                 this.Hijos[1].AutoIncrmentable = 0;
                 val1 = (float.Parse(val1) - 1).ToString();
             }
             */
            if (val1.Equals("#Error") || val2.Equals("#Error"))
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
            
            System.Diagnostics.Debug.WriteLine("#Error semantico \n");
            return "#Error";
        }
    }
}