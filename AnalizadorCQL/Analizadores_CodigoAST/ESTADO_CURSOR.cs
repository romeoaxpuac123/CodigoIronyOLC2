using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class ESTADO_CURSOR : NodoAbstracto
    {
        public ESTADO_CURSOR(String Nombre) : base(Nombre)
        {
            
        }
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion estado-CURSOR");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion estado-CURSOR");
            String Tipo = this.Hijos[0].Nombre.Replace(" (Keyword)", "");
            String Cursor = this.Hijos[1].Nombre.Replace(" (id2)", "");
            System.Diagnostics.Debug.WriteLine("Ejecucion estado-CURSOR cursor->" + Cursor);
            System.Diagnostics.Debug.WriteLine("Ejecucion estado-CURSOR tipo->" + Tipo);
            if (entorno.ExisteCursor(Cursor) == true)
            {
                if (Tipo.ToUpper().Contains("OPEN") == true)
                {
                    entorno.AsignarValorCursor(Cursor, "1");
                    //System.Diagnostics.Debug.WriteLine("Ejecucion estado-CURSOR ACION->" + entorno.Selector(Cursor).ToString());
                    entorno.ElCursor(Cursor);
                    entorno.Selector(Cursor).Ejecutar(entorno);
                    //Aca quemamos los datos
                    // creamos los clases para los selects *
                    // guardamos los resultados en una archivo de la forma atributo1*tipo, atributo1*tipo\n
                }
                if (Tipo.ToUpper().Contains("CLOSE") == true)
                {
                    entorno.AsignarValorCursor(Cursor, "0");
                }
            }
            else
            {
                return "#ERORR EN ESTADO-CURSOOR, NO EXISTE CURSOR";
            }

            entorno.MostrarcURSORES();
            return "Ejecucion estado-CURSOR";
        }
    }
}