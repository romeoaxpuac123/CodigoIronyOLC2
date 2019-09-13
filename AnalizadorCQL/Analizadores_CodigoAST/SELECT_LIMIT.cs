using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class SELECT_LIMIT : NodoAbstracto
    {
        public SELECT_LIMIT(String Nombre) : base(Nombre)
        {
        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion SELECT-LIMIT");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion SELECT-LIMIT");
            String Tabla = this.Hijos[0].Nombre;
            String BD = entorno.Tabla();
            System.Diagnostics.Debug.WriteLine("Ejecucion SELECT-LIMIT tabla->" + Tabla);
            System.Diagnostics.Debug.WriteLine("Ejecucion SELECT-LIMIT bd->" + BD);
            String ElLimite = this.Hijos[1].Ejecutar(entorno);
            System.Diagnostics.Debug.WriteLine("Ejecucion SELECT-LIMIT limite->" + ElLimite);
            if (Int32.Parse(ElLimite) < 0)
            {
                return "#ERROR el parametro de limite invalido";
            }
            List<Simbolo> Campos = new List<Simbolo>();
            Campos = entorno.TablaBD(Tabla, BD);
            if (this.ListaID1.Count == 1 && this.ListaID1[0] == "* (Key symbol)")
            {
                entorno.MostrarUTablas2(Tabla, BD);
                entorno.MostrarCampos2Limite(Tabla, BD, Int32.Parse(ElLimite));
                return "SELECT SIMPLE";
            }
            List<String> CamposAMostrar = new List<String>();
            for (int i = 0; i < this.ListaID1.Count; i++)
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
                if (Exitencia == false)
                {
                    return "#ERROR el campo a mostrar no existe;";
                }
            }
            System.Diagnostics.Debug.WriteLine("Ejecucion CAMPOS FIN");
            String LineaDeCampos = "\n\nSELECION-limite\n\nTabla->" + Tabla + " BD:->" + BD + "\n";
            for (int i = 0; i < CamposAMostrar.Count; i++)
            {
                LineaDeCampos = LineaDeCampos + CamposAMostrar[i] + "         |";
            }
            System.Diagnostics.Debug.WriteLine(LineaDeCampos);
            entorno.MostrarCamposExactosLimite(Tabla, BD, CamposAMostrar,Int32.Parse(ElLimite));
            return "SELECT-LIMIT";
        }
    }
}