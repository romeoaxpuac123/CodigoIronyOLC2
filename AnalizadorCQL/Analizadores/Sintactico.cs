using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Irony.Ast;
using Irony.Parsing;
using AnalizadorCQL.Analizadores_Grafica;

namespace AnalizadorCQL.Analizadores
{
    public class Sintactico : Grammar
    {
        /*
        public static ParseTreeNode Analizar(String Cadena)
        {
            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(Cadena);
            ParseTreeNode raiz = arbol.Root;
            /*
            if(raiz == null)
            {
                return false;
            }
            GenerarImagen(raiz);
            return true;
            
            GenerarImagen(raiz);
            return raiz;
        }
    */
        public static Boolean Analizar(String Cadena)
        {
            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(Cadena);
            ParseTreeNode raiz = arbol.Root;
            
            if(raiz == null)
            {
                return false;
            }
            GenerarImagen(raiz);
            return true;
        }
        public static ParseTreeNode Analizar2(String Cadena)
        {
            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(Cadena);
            ParseTreeNode raiz = arbol.Root;

            if (raiz == null)
            {
                return raiz;
            }
            GenerarImagen(raiz);
            return raiz;
        }

        private static void GenerarImagen(ParseTreeNode raiz)
        {
            String grafoDOT = ControlDOT.GetDot(raiz);
            Archivo(grafoDOT);
            Imagen();
        }

        private static void Archivo(String cadena)
        {
            System.IO.File.WriteAllText(@"C:\Users\Bayyron\Desktop\AST.dot", cadena);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Bayyron\Desktop\AST.dot"))
            {
                file.WriteLine(cadena);
            }

        }

        private static void Imagen()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("dot.exe");
            startInfo.Arguments = "C:\\Program Files (x86)\\Graphviz2.38\bin\\dot.exe -Tpng C:\\Users\\Bayyron\\Desktop\\AST.dot -o C:\\Users\\Bayyron\\Desktop\\AST.png";

            Process.Start(startInfo);
        }
    }
}