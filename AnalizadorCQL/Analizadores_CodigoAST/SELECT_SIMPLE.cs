using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class SELECT_SIMPLE : NodoAbstracto
    {
        public SELECT_SIMPLE(String Nombre) : base(Nombre)
        {
        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion UPDATE1");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion select1");
            String Tabla = this.Hijos[0].Nombre;
            String BD = entorno.Tabla();
            System.Diagnostics.Debug.WriteLine("Ejecucion SELECT1 tabla->" + Tabla);
            System.Diagnostics.Debug.WriteLine("Ejecucion SELECT1 bd->" + BD);
            System.Diagnostics.Debug.WriteLine("Ejecucion CAMPOS INCIO");
            List<Simbolo> Campos = new List<Simbolo>();
            Campos = entorno.TablaBD(Tabla, BD);
            if(this.ListaID1.Count ==1 && this.ListaID1[0] == "* (Key symbol)")
            {
                entorno.MostrarUTablas2(Tabla, BD);
                entorno.MostrarCampos2(Tabla, BD);
                return "SELECT SIMPLE";
            }
            List<String> CamposAMostrar = new List<String>();
            for (int i = 0; i< this.ListaID1.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(this.ListaID1[i]);
                String Campito = this.ListaID1[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (cadena)", "").Replace(" (id2)", "").Replace(" (id)", "");
                Boolean Exitencia = false;
                for (int x = 0; x < Campos.Count; x++)
                {
                    if (Campos[x].ObtenerId() == Campito)
                    {
                        Exitencia = true;
                        CamposAMostrar.Add(Campito);
                    }
                }
                if(Exitencia == false)
                {
                    return "#ERROR el campo a mostrar no existe;";
                }
            }
            System.Diagnostics.Debug.WriteLine("Ejecucion CAMPOS FIN");
            String LineaDeCampos = "\n\nSELECION\n\nTabla->" + Tabla + " BD:->" +BD + "\n";
            for(int i= 0; i < CamposAMostrar.Count; i++)
            {
                LineaDeCampos = LineaDeCampos + CamposAMostrar[i] + "         |";
            }
           System.Diagnostics.Debug.WriteLine(LineaDeCampos);
           entorno.MostrarCamposExactos(Tabla, BD, CamposAMostrar);


            return "SELECT SIMPLE";
        }
    }
}