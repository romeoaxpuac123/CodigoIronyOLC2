using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
            
            string text = System.IO.File.ReadAllText(@"C:\Users\Bayyron\Desktop\entrada.txt");

            Boolean resultado = Analizadores.Sintactico.Analizar(text);
            ParseTreeNode resul2 = Analizadores.Sintactico.Analizar2(text);
            if (resultado == true)
            {
                TextBox1.Text = "Cadena Valida";
                //Recorrido.Recorrido1(resul2);
                Recorrido Re = new Recorrido();
                //Re.RecorrerArbol(resultado);
                Re.Recorrido1(resul2);
                Console.WriteLine("**********************");
                Re.Analizar(Re.Raiz);
                System.Diagnostics.Debug.WriteLine("FIIIIIIIIIIIIIIIIIN");
            }
            else
            {
                TextBox1.Text = "Cadena NO Valida";
            }
            
        }
    }
}