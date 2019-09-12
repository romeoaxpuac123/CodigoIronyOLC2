using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class ALTER_TABLE_ADD : NodoAbstracto
    {
        public ALTER_TABLE_ADD(String Nombre) : base(Nombre)
        {

        }
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion creacion tabla");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion MODIFICACION tabla");
            String Tabla = this.Hijos[0].Nombre;
            String BD = entorno.Tabla();
            if (BD == "NULITO")
            {
                return "#ERROR BD NO EXISTENTE";
            }
            List<String> Llaves = new List<String>();
            List<Simbolo> Elementos = new List<Simbolo>();
            int CuantosPY = 0;
            #region buscando llaves
            for (int i = 0; i < this.ListaID1.Count; i++)
            {
                string[] separadas;
                separadas = ListaID1[i].Split('*');
                // System.Diagnostics.Debug.WriteLine(ListaID1[i]);

                if (ListaID1[i].Contains("PRIMARY*KEY"))
                {
                    CuantosPY++;
                    if (separadas[2].Contains("PRIMARY") && separadas[3].Contains("KEY"))
                    {
                        Llaves.Add(separadas[0]);
                    }
                    else if (separadas[0].Contains("PRIMARY") && separadas[1].Contains("KEY"))
                    {
                        String NuevoCadena = ListaID1[i].Replace("PRIMARY*KEY*", "");
                        string[] separadas2;
                        separadas2 = NuevoCadena.Split(',');
                        for (int h = 0; h < separadas2.Length; h++)
                        {
                            Llaves.Add(separadas2[h]);
                        }
                    }
                    else if (separadas[3].Contains("PRIMARY") && separadas[4].Contains("KEY"))
                    {
                        Llaves.Add(separadas[0]);
                    }
                }

                if (separadas[0].Contains("PRIMARY") == false)
                {
                    if (separadas[1].ToUpper().Contains("STRING") || separadas[1].ToUpper().Contains("INT") || separadas[1].ToUpper().Contains("DATE")
                        || separadas[1].ToUpper().Contains("TIME") || separadas[1].ToUpper().Contains("DOUBLE") || separadas[1].ToUpper().Contains("BOOLEAN"))
                    {
                        //variables de tipo int, etc
                        System.Diagnostics.Debug.WriteLine("NOMBRE CAMPO->" + separadas[0] + " Tipo->" + separadas[1]);
                        Simbolo Elemento = new Simbolo(separadas[0], "", separadas[1]);
                        Elementos.Add(Elemento);
                    }
                    else if (separadas[1].ToUpper().Contains("LIST") || separadas[1].ToUpper().Contains("SET") || separadas[1].ToUpper().Contains("MAP"))
                    {
                        System.Diagnostics.Debug.WriteLine("NOMBRE COLECTION->" + separadas[0] + " Tipo->" + separadas[1] + " tipod->" + separadas[2]);
                        Simbolo Elemento = new Simbolo(separadas[0], "", separadas[1] + "<" + separadas[2] + ">");
                        Elementos.Add(Elemento);
                    }
                    else
                    {
                        if (entorno.ExisteVariable(separadas[1]) == true || separadas[1].ToUpper() == "COUNTER")
                        {
                            if (separadas[1].ToUpper() == "COUNTER")
                            {
                                if (Llaves.Contains(separadas[0]) == false)
                                {
                                    return "#ERROR Counter no es llave primaria";
                                }
                            }
                            //variables de tipo ut
                            System.Diagnostics.Debug.WriteLine("NOMBRE CAMPO->" + separadas[0] + " Tipo oBJETO->" + separadas[1]);
                            Simbolo Elemento = new Simbolo(separadas[0], "", separadas[1]);
                            Elementos.Add(Elemento);
                        }
                        else
                        {
                            return "#ERROR se quiere usar un objeto que no existe";
                        }

                    }

                }


            }
            if (CuantosPY > 0)
            {
                return "#ERROR No se puede agregar llaves primarias desde un Alter";
            }

            #endregion

            #region comprobando que no viene campos repetidos 
            List<Simbolo> Elementos2 = new List<Simbolo>();
            Elementos2 = Elementos;

            System.Diagnostics.Debug.WriteLine("Ejecucion creacion tabla Tabla->" + Tabla);
            System.Diagnostics.Debug.WriteLine("Ejecucion creacion tabla BD->" + BD);
            for (int i = 0; i < Elementos.Count; i++)
            {
                int toles = 0;
                System.Diagnostics.Debug.WriteLine("Ejecucion creacion tabla Campo" + i + " Nombre ->" + Elementos[i].ObtenerId() + " Tipo ->" + Elementos[i].ObtenerTipo());
                for (int j = 0; j < Elementos2.Count; j++)
                {
                    if (Elementos[i].ObtenerId() == Elementos2[j].ObtenerId())
                    {
                        toles++;
                    }
                }
                if (toles > 1)
                {

                    return "#ERROR parametros repetidos";
                }
            }
            #endregion

            #region Comprobando que no vienene campos repetidos y aregistrads
            List<Simbolo> ElementosTabla = new List<Simbolo>();
            ElementosTabla = entorno.TablaBD(Tabla, BD);
            for(int i = 0; i < Elementos.Count; i++)
            {
                for(int j = 0; j<ElementosTabla.Count; j++)
                {
                    //System.Diagnostics.Debug.WriteLine("pssy->" + Elementos[i].ObtenerId());
                    if (Elementos[i].ObtenerId().ToUpper() == ElementosTabla[j].ObtenerId().ToUpper())
                    {
                        return "#ERROR EL CAMPO YA EXISTE EN LA TABLA;";
                    }
                }
            }

            #endregion
            System.Diagnostics.Debug.WriteLine("VAMOS A AGREGAR");
            entorno.AlterAddTablaBD(Tabla, BD, Elementos);
            entorno.AlterADDCampos(Tabla, BD, Elementos);
            entorno.MostrarUTablas(Tabla, BD);
            entorno.MostrarCampos(Tabla, BD);
            return "agREGAR CAMPO"; 
        }
    }
}