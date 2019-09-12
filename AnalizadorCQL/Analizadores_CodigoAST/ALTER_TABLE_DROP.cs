using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class ALTER_TABLE_DROP : NodoAbstracto
    {
        public ALTER_TABLE_DROP(String Nombre) : base(Nombre)
        {
            
        }
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion ELIMINACION DE ELEMTNOS tabla");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion ELIMINACION DE ELEMTNOS tabla");
            String Tabla = this.Hijos[0].Nombre;
            String BD = entorno.Tabla();
            List<String> llaves = entorno.LLaves(Tabla, BD);
            List<Simbolo> TablaBD = entorno.TablaBD(Tabla,BD);
            System.Diagnostics.Debug.WriteLine("DROP1 Tabla->" + Tabla );
            System.Diagnostics.Debug.WriteLine("DROP1 Tabla->" + BD);
            if (BD == "NULITO")
            {
                return "#ERROR BD NO EXISTENTE";
            }
            for(int i = 0; i<this.ListaID1.Count; i++)
            {
                String Dato = this.ListaID1[i].Replace(" (id)", "");
                System.Diagnostics.Debug.WriteLine("DROP1 Parametro" + i+"->" +Dato);
                if (llaves.Contains(Dato))
                {
                    return "#ERROR SE QUIERE ELIMINAR UNA LLAVE PRIMARI";
                }
                Boolean ExisteCampo = false;
                for(int j = 0; j < TablaBD.Count; j++)
                {
                    if(TablaBD[i].ObtenerId() == Dato)
                    {
                        ExisteCampo = true;
                    }
                }
                if(ExisteCampo == false)
                {
                    return "#ERROR SE QUIERE ELIMINAR UN CAMPO INEXISTENTE";
                }
            }
            entorno.MostrarUTablas(Tabla, BD);
            for (int i = 0; i < this.ListaID1.Count; i++)
            {
                String Dato = this.ListaID1[i].Replace(" (id)", "");
                entorno.AlterDropTablaBD(Tabla, BD, Dato);
                entorno.AlterDROPCampos(Tabla, BD, Dato);
            }
            entorno.MostrarUTablas(Tabla, BD);
            entorno.MostrarCampos(Tabla, BD);
            return "DROP CAMPO";
        }
    }
}