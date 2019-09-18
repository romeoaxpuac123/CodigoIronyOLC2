using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class LOG : NodoAbstracto
    {
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado imprimir\n");
        }

        public LOG (String Valor):base(Valor)
        {
          
        }

    public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("entro a imrpirmi");
            String rutaCompleta = @"C:\Users\Bayyron\Desktop\Salida.txt";
            String val = this.Hijos[0].Ejecutar(entorno);
            if (val.ToUpper().Contains("#ERROR") == false)
            {

                //salida.Text = val + "\n";
                System.Diagnostics.Debug.WriteLine("SALIDA>>" +val.Replace(" (numero)","").Replace(" (hora)","").Replace(" (numdecimal)","").Replace(" (fechas)","") + "\n");
                using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
                {
                    mylogs.WriteLine("SALIDA>>" + val.Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "") + "\n");
                    mylogs.Close();
                }

            }
           else{
               // System.Diagnostics.Debug.WriteLine("Existe un error" + "\n");
                return "#Error";
            }
            return "imprimir";
        }
    }
}