using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class CURSOR : NodoAbstracto
    {
        public CURSOR(String Nombre) : base(Nombre)
        {

        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion CURSOR");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion CURSOR");
            String Cursor = this.Hijos[0].Nombre.Replace(" (id2)","");
            NodoAbstracto SELECCION = this.Hijos[1];
            String BD = entorno.Tabla();
            System.Diagnostics.Debug.WriteLine("Ejecucion CURSOR Nombre->" + Cursor);
            String id = "BRAY-CURSOR" + (entorno.CantidadDeCursores()+1).ToString();
            System.Diagnostics.Debug.WriteLine("Ejecucion CURSOR id->" + id);
            if (entorno.ExisteCursor(Cursor) == false)
            {
                entorno.Agregarcursor(id, Cursor, "0", SELECCION);
            }
            else
            {
                return "#ERROR, YA EXISTE EL CURSOR";
            }
            //String valor1 = "";
            //SELECCION.Ejecutar(entorno);
            entorno.MostrarcURSORES();
            return "CURSOR";
        }
    }
}