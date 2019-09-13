using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class UPDATE : NodoAbstracto
    {
        public UPDATE(String Nombre) : base(Nombre)
        {
        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion UPDATE1");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion UPDATE1");
            String Tabla = this.Hijos[0].Nombre;
            String BD = entorno.Tabla();
            System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 tabla->" + Tabla);
            System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 bd->" + BD);
            List<Simbolo> Campos = new List<Simbolo>();
            Campos = entorno.TablaBD(Tabla, BD);
            for (int i = 0; i < this.ListaID1.Count; i++)
            {
                String cadena = this.ListaID1[i];
                string[] separadas;
                separadas = cadena.Split('=');
                System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 Campo " + i + "->" + separadas[0] + " Valor->" + separadas[1]);
                String TipoRetorno = separadas[1];
                String TipoRetornox = "";
                String ElCampo = separadas[0];
                String Valor = separadas[1].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (cadena)", "").Replace(" (id2)", "");
                /// verificando el tipo de cada uno de los elementos y se agregará a una lista
                if (TipoRetorno.ToUpper().Contains("NUMERO"))
                {
                    TipoRetornox = "int";
                }
                else if (TipoRetorno.ToUpper().Contains("DECIMAL"))
                {
                    TipoRetornox = "double";
                }
                else if (TipoRetorno.ToUpper().Contains("CADENA"))
                {
                    TipoRetornox = "String";
                }
                else if (TipoRetorno.ToUpper().Contains("(KEYWORD)") && (TipoRetorno.ToUpper().Contains("TRUE") || TipoRetorno.ToUpper().Contains("FALSE")))
                {
                    TipoRetornox = "Booleano";
                }
                else if (TipoRetorno.ToUpper().Contains("FECHAS"))
                {
                    TipoRetornox = "Date";
                }
                else if (TipoRetorno.ToUpper().Contains("HORA"))
                {
                    TipoRetornox = "Time";
                }
                else if (TipoRetorno.ToUpper().Contains("(ID2)"))
                {
                    TipoRetornox = entorno.ObtenerTipo(TipoRetorno.Replace(" (id2)", ""));
                }
                for (int x = 0; x < Campos.Count; x++)
                {
                    if(Campos[x].ObtenerId()== separadas[0])
                    {
                        if(Campos[x].ObtenerTipo().ToUpper() != TipoRetornox.ToUpper())
                        {
                            return "#ERROR el campo a actualizar no es el correcto";
                        }
                        else
                        {
                            entorno.ActualizarCampos(Tabla, BD, ElCampo, Valor);
                        }
                    }
                }

                

            }

            entorno.MostrarUTablas(Tabla, BD);
            entorno.MostrarCampos(Tabla, BD);
            return "UPDATE 1";
        }
    }
}