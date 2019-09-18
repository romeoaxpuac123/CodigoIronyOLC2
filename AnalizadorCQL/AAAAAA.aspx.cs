using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnalizadorCQL.Analizadores;
using Irony.Parsing;


namespace AnalizadorCQL
{
    public partial class AAAAAA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            String rutaCompleta = @"C:\Users\Bayyron\Desktop\Salida.txt";
            //System.Diagnostics.Debug.WriteLine(texto);
            //System.Diagnostics.Debug.WriteLine(rutaCompleta);
            if (File.Exists(rutaCompleta))
            {
                File.Delete(rutaCompleta);

            }
            using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
            {
               // mylogs.WriteLine("SALIDA>>" + val.Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "") + "\n");
                mylogs.Close();
            }
            string text = System.IO.File.ReadAllText(@"C:\Users\Bayyron\Desktop\entrada.txt");

         
            
            text = text.Replace("(String)", "¿String?");
            text = text.Replace("(Double)", "¿Double?");
            text = text.Replace("(Int)", "¿Int?");
            text = text.Replace("(Time)", "¿Time?");
            text = text.Replace("(Date)", "¿Date?");
            text = text.Replace("(string)", "¿String?");
            text = text.Replace("(double)", "¿Double?");
            text = text.Replace("(int)", "¿Int?");
            text = text.Replace("(time)", "¿[Time?");
            text = text.Replace("(date)", "¿Date?");
            text = text.Replace("(STRING)", "¿String?");
            text = text.Replace("(DOUBLE)", "¿Double?");
            text = text.Replace("(INT)", "¿Int?");
            text = text.Replace("(TIME)", "¿Time?");
            text = text.Replace("(DATE)", "¿Date?");
            //  text = text.ToUpper();

           

            Boolean resultado = Analizadores.Sintactico.Analizar(text);
            ParseTreeNode resul2 = Analizadores.Sintactico.Analizar2(text);
            ParseTree resul2x = Analizadores.Sintactico.Analizar2x(text);
            if (resultado == true)
            {
                TextBox1.Text = "Cadena Valida";

                //Recorrido.Recorrido1(resul2);
                Recorrido Re = new Recorrido();
                //Re.RecorrerArbol(resultado);
                Re.Recorrido12(resul2);
                Console.WriteLine("**********************");
                Re.Analizar(Re.Raiz);

                System.Diagnostics.Debug.WriteLine("FIIIIIIIIIIIIIIIIIN");
            }
            else
            {
                for (int i = 0; i < resul2x.ParserMessages.Count(); i++)
                {
                    System.Diagnostics.Debug.WriteLine("ERROR-BRAY->" +
                        " Tipo de error: " + "Sintactico" +
                        " Linea: " + resul2x.ParserMessages.ElementAt(i).Location.Line +
                        " Columna: " + resul2x.ParserMessages.ElementAt(i).Location.Column);

                }

                TextBox1.Text = "Cadena NO Valida";
            }
        }
    }
}