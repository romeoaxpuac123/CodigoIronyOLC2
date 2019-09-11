using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class Tabla : NodoAbstracto
    {
        public Tabla(String Nombre) : base(Nombre)
        {

        }
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion creacion tabla");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion creacion tabla");
            String Tabla = this.Hijos[0].Nombre;
            String BD = entorno.Tabla();
            String IdTaba = "BRAY-TAB" + (entorno.CantidadDeTablas()+1);
            //String id = "BRAY-TAB";
            System.Diagnostics.Debug.WriteLine("Ejecucion creacion tabla inicio elementos-----------");
            int CuantosPY = 0;
            List<String> Llaves = new List<String>();
            List<Simbolo> Elementos = new List<Simbolo>();
            #region buscando llaves
            for (int i = 0; i<this.ListaID1.Count; i++)
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

                if (separadas[0].Contains("PRIMARY") == false){
                    if(separadas[1].ToUpper().Contains("STRING") || separadas[1].ToUpper().Contains("INT") || separadas[1].ToUpper().Contains("DATE")
                        || separadas[1].ToUpper().Contains("TIME") || separadas[1].ToUpper().Contains("DOUBLE") || separadas[1].ToUpper().Contains("BOOLEAN"))
                    {
                        //variables de tipo int, etc
                        System.Diagnostics.Debug.WriteLine("NOMBRE CAMPO->" + separadas[0] + " Tipo->" + separadas[1]);
                        Simbolo Elemento = new Simbolo(separadas[0],"",separadas[1]);
                        Elementos.Add(Elemento);
                    }else if(separadas[1].ToUpper().Contains("LIST") || separadas[1].ToUpper().Contains("SET")|| separadas[1].ToUpper().Contains("MAP"))
                    {
                        System.Diagnostics.Debug.WriteLine("NOMBRE COLECTION->" + separadas[0] + " Tipo->" + separadas[1] + " tipod->" + separadas[2]);
                        Simbolo Elemento = new Simbolo(separadas[0], "", separadas[1]+"<"+ separadas[2] +">");
                        Elementos.Add(Elemento);
                    }
                    else
                    {
                        if (entorno.ExisteVariable(separadas[1]) == true)
                        {
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
            if (CuantosPY > 1)
            {
                return "#ERROR la tabla contiene más de una llave primaria";
            }

            #endregion


            System.Diagnostics.Debug.WriteLine("Ejecucion creacion tabla fin elementos-----------");
            List<Simbolo> Elementos2 = new List<Simbolo>();
            Elementos2 = Elementos;

            System.Diagnostics.Debug.WriteLine("Ejecucion creacion tabla IDTabla->" + IdTaba);
            System.Diagnostics.Debug.WriteLine("Ejecucion creacion tabla Tabla->" + Tabla);
            System.Diagnostics.Debug.WriteLine("Ejecucion creacion tabla BD->" + BD);
            for(int i = 0; i < Elementos.Count; i++)
            {
                int toles = 0;
                System.Diagnostics.Debug.WriteLine("Ejecucion creacion tabla Campo" + i + " Nombre ->" + Elementos[i].ObtenerId()  +" Tipo ->" + Elementos[i].ObtenerTipo());
                for(int j = 0; j < Elementos2.Count; j++)
                {
                    if(Elementos[i].ObtenerId() == Elementos2[j].ObtenerId())
                    {
                        toles++;
                    }
                }
                if (toles > 1)
                {
                    return "#ERROR parametros repetidos";
                }
            }

            for (int i = 0; i< Llaves.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("Ejecucion creacion tabla Llave " +i +" ->" + Llaves[i]);
            }

            if(BD == "NULITO")
            {
                return "#ERROR BD NO EXISTENTE";
            }
            else
            {
                if(entorno.ExisteTabla(Tabla, BD) == false)
                {
                    entorno.AgregarTabla(IdTaba, Tabla, BD, Elementos, Llaves);
                }
                else
                {
                    return "#ERROR tabla ya EXISTENTE";
                }
            }
            entorno.MostrarUTablas();
            return "TABLA";
        }
    }
}