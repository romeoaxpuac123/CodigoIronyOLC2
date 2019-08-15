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
            String totalC = "";
            String val1 = this.Hijos[0].Ejecutar(entorno);
            String val2 = this.Hijos[2].Ejecutar(entorno);

            String Tipo1 = this.Hijos[0].TipoDato;
            String Tipo2 = this.Hijos[2].TipoDato;

            //Console.WriteLine(val1 + "AA");
            //Console.WriteLine(val2 + "bb");
            //Console.WriteLine(this.Hijos[1].Nombre + "CC");

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
                    case "^":

                        break;

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
                    case "^":

                        break;

                }
                return totald.ToString();
            }
            //*************************

            //PARTE DONDE SOLO EL LADO IZQUIERDO ES DECIMAL Y EL DERECHO entero

            ///************
            else if(Tipo1 == "decimal" && Tipo2 == "entero")
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
                    case "^":

                        break;

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
                    case "^":

                        break;

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
                       
                    case "^":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        break;

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

                    case "^":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        break;

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
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");

                        return "#Error";

                    case "/":

                        // salida.Text = "#Error: Se está intentando dividir por 0 \n";
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");

                        return "#Error";

                    case "*":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        return "#Error";

                    case "^":
                        System.Diagnostics.Debug.WriteLine("#Error: Se está realizando operaciones raras con strings \n");
                        break;

                }
                return totalC.ToString();
            }


            return total.ToString();
        }
    }
}